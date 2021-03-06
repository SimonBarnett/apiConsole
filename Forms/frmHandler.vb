﻿
Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports Newtonsoft.Json

Public Class frmHandler

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

    End Sub

#End Region

    Private xmlDoc As New XmlDocument
    Private _filename As String = Nothing

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormatToolStripMenuItem.Click
        With rtb
            .Indent()
        End With
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        With OpenFileDialog1
            .Multiselect = False
            .Filter = "XML Files|*.xml|JSON Files|*.json|All Files|*.*"
            .Title = "Select an file."
            .FileName = ""

            If .ShowDialog() = DialogResult.OK Then
                Try
                    Using sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
                        rtb.Text = sr.ReadToEnd
                        _filename = .FileName
                        rtb.Indent()

                    End Using

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

            End If

        End With

    End Sub

#Region "Save Files"

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        With SaveFileDialog1
            If _filename Is Nothing Then
                .Title = "Save File."
                .Filter = .Filter = "XML Files|*.xml|JSON Files|*.json|All Files|*.*"
                If .ShowDialog() = DialogResult.OK Then
                    _filename = .FileName
                    SaveFile()
                End If
            Else
                SaveFile()
            End If
        End With

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        With SaveFileDialog1
            If Not _filename Is Nothing Then .FileName = _filename
            .Title = "Save file."
            .Filter = .Filter = "XML Files|*.xml|JSON Files|*.json|All Files|*.*"
            If .ShowDialog() = DialogResult.OK Then
                _filename = .FileName
                SaveFile()

            End If
        End With

    End Sub

    Private Sub SaveFile()
        Using sw As New StreamWriter(_filename)
            sw.Write(rtb.Text)
        End Using

    End Sub

#End Region

#Region "Send Worker"

    Public Overrides ReadOnly Property activity As Boolean
        Get
            Return Me.SendWorker.IsBusy
        End Get
    End Property

    Private Sub StartWorker_Click(sender As Object, e As EventArgs) Handles ExecuteToolStripMenuItem.Click, ExecuteToolStripMenuItem1.Click, ExecuteHandlerToolStripMenuItem.Click, rtb.Execute
        With SendWorker
            If Not .IsBusy Then
                Try
                    'Dim x As New XmlDocument
                    'x.LoadXml(rtb.Text)

                    ExecuteHandlerToolStripMenuItem.Enabled = False
                    ExecuteToolStripMenuItem1.Enabled = False
                    ExecuteToolStripMenuItem.Enabled = False

                    WebBrowser.DocumentText = ""
                    LogText.Text = ""
                    Application.DoEvents()

                    .RunWorkerAsync(Trim(rtb.Text))

                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try

            End If
        End With

    End Sub

    Private Sub SendWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles SendWorker.DoWork

        Try
            Dim requestStream As Stream = Nothing
            Dim uploadResponse As Net.HttpWebResponse = Nothing
            Dim uploadRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(url), Net.HttpWebRequest)

            With uploadRequest
                .Method = "POST"
                .Proxy = Nothing
                Select Case e.Argument.ToString.Substring(0, 1)
                    Case "{"
                        .ContentType = "text/json"

                    Case Else
                        .ContentType = "text/xml"

                End Select
            End With

            Dim myEncoder As New System.Text.ASCIIEncoding
            Dim ms As MemoryStream = New MemoryStream(myEncoder.GetBytes(e.Argument.ToString))

            requestStream = uploadRequest.GetRequestStream()

            ' Upload the XML
            Dim buffer(1024) As Byte
            Dim bytesRead As Integer
            While True
                bytesRead = ms.Read(buffer, 0, buffer.Length)
                If bytesRead = 0 Then
                    Exit While
                End If
                requestStream.Write(buffer, 0, bytesRead)
            End While

            requestStream.Close()
            e.Result = uploadRequest.GetResponse()

        Catch ex As Exception
            e.Result = ex

        End Try

    End Sub

    Private Sub SendWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles SendWorker.RunWorkerCompleted

        If TypeOf (e.Result) Is Exception Then
            With TryCast(e.Result, Exception)
                LogText.Lines = Split(.Message & vbCrLf & .StackTrace, vbCrLf)
            End With

        Else
            With TryCast(e.Result, Net.WebResponse)
                Dim reader As New StreamReader(.GetResponseStream)
                Dim doctext As String = reader.ReadToEnd

                Select Case .ContentType.ToLower
                    Case "text/json"

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

                Dim doc As New XmlDocument
                Dim logurl As String = String.Format(
                        "{0}/api/{1}/{2}/{3}/{4}/{5}",
                        server,
                        Environment,
                        DatePart(DateInterval.Year, Date.Parse(.Headers("date"))),
                        DatePart(DateInterval.Month, Date.Parse(.Headers("date"))),
                        DatePart(DateInterval.Day, Date.Parse(.Headers("date"))),
                        .Headers("BubbleID")
                    )

                doc.Load(logurl)
                Dim el As XmlElement = doc.SelectSingleNode("Log/msg")
                LogText.Lines = Split(el.InnerText, vbLf)

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

        ExecuteHandlerToolStripMenuItem.Enabled = True
        ExecuteToolStripMenuItem1.Enabled = True
        ExecuteToolStripMenuItem.Enabled = True

    End Sub




#End Region

End Class