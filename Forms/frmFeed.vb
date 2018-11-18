Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json

Public Class frmFeed : Inherits baseForm

#Region "Constructor"

    Sub New(e As endPoint)

        MyBase.New(e)
        FormType = eFormType.debug

        With e
            epType = .Type

        End With

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim myTable As New DataTable
        Dim dc As New DataColumn
        With dc
            .DataType = System.Type.GetType("System.String")
            .ColumnName = "Parameter"
            .ReadOnly = True
        End With

        myTable.Columns.Add(dc)

        dc = New DataColumn
        With dc
            .DataType = System.Type.GetType("System.String")
            .ColumnName = "Data Type"
            .ReadOnly = True

        End With

        myTable.Columns.Add(dc)

        dc = New DataColumn
        With dc
            .DataType = System.Type.GetType("System.String")
            .ColumnName = "Value"
            .ReadOnly = False

        End With

        myTable.Columns.Add(dc)


        Me.DataGridView.DataSource = myTable
        Me.DataGridView.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.TableLayoutPanel3.RowStyles(0).Height = DataGridView.ColumnHeadersHeight + 8
        For Each p As String In e.params.Keys
            myTable.Rows.Add({p, e.params(p), ""})
            Me.TableLayoutPanel3.RowStyles(0).Height += DataGridView.Rows(0).Height + 1

        Next


    End Sub

#End Region

    Public ReadOnly Property getUrl As String
        Get
            Dim str As New StringBuilder
            str.AppendFormat(
                "{0}/api/{1}/{2}",
                server,
                Environment,
                Split(EndPoint, ".")(0)
            )
            Select Case rJSON.Checked
                Case True
                    str.Append(".json")

                Case Else
                    str.Append(".xml")

            End Select
            str.Append("?")
            For Each r As DataGridViewRow In Me.DataGridView.Rows
                str.AppendFormat("{0}={1}&", r.Cells(0).Value, r.Cells(2).Value)
            Next
            Return str.ToString
        End Get
    End Property

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles rJSON.CheckedChanged, rXML.CheckedChanged
        rXML.Checked = Not rJSON.Checked
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, ExecuteToolStripMenuItem.Click
        With SendWorker
            If Not .IsBusy Then
                Try
                    WebBrowser.DocumentText = ""
                    Application.DoEvents()
                    .RunWorkerAsync("")

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

            End If

        End With

    End Sub

#Region "Send Worker"

    Public Overrides ReadOnly Property activity As Boolean
        Get
            Return Me.SendWorker.IsBusy
        End Get
    End Property

    Private Sub SendWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles SendWorker.DoWork

        Try
            Dim requestStream As Stream = Nothing
            Dim uploadResponse As Net.HttpWebResponse = Nothing
            Dim uploadRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(getUrl), Net.HttpWebRequest)

            With uploadRequest
                .Method = "GET"
                .Proxy = Nothing
            End With

            uploadResponse = uploadRequest.GetResponse()

            e.Result = uploadResponse

        Catch ex As Exception
            e.Result = ex

        End Try

    End Sub

    Private Sub SendWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles SendWorker.RunWorkerCompleted

        If TypeOf (e.Result) Is Exception Then
            With TryCast(e.Result, Exception)
                MsgBox(.Message)
            End With

        Else
            With TryCast(e.Result, Net.WebResponse)
                Dim reader As New StreamReader(.GetResponseStream)
                Dim doctext As String = reader.ReadToEnd

                Select Case .ContentType.ToLower.Contains("text/json")
                    Case True

                        Try
                            Using stringReader As New StringReader(doctext)
                                Using stringWriter As New StringWriter
                                    Dim jsonreader As New JsonTextReader(stringReader)
                                    Dim jsonwriter As New JsonTextWriter(stringWriter)
                                    With jsonwriter
                                        .Formatting = Newtonsoft.Json.Formatting.Indented
                                        .WriteToken(jsonreader)

                                    End With
                                    Dim myEncoder As New System.Text.ASCIIEncoding
                                    WebBrowser.DocumentText = stringWriter.ToString.Replace(vbCrLf, "<br/>").Replace(" ", "&nbsp;")

                                End Using
                            End Using

                        Catch ex As Exception
                            WebBrowser.DocumentText = doctext
                            MsgBox("Invaild JSON response.")

                        End Try

                    Case Else
                        WebBrowser.DocumentText = doctext

                End Select

            End With

            For Each f As baseForm In Me.MdiParent.MdiChildren
                With f
                    If .server = Me.server _
                        And .Environment = Me.Environment _
                        And .EndPoint = Me.EndPoint _
                        And .FormType = eFormType.log Then
                        TryCast(f, frmLog).doRefresh(f, New EventArgs)
                        Exit For
                    End If
                End With
            Next

        End If

    End Sub


#End Region

End Class