Imports System.ComponentModel
Imports System.Xml

Public Class frmLog : Inherits baseForm

    Public Overrides ReadOnly Property activity As Boolean
        Get
            Return Me.RefreshWorker.IsBusy
        End Get
    End Property

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DateTimePicker1.Value = Now()
        Me.WindowState = FormWindowState.Maximized

    End Sub

#End Region

#Region "Private Properties"

    Private Enum LogEntryType
        Err = 1
        Warning = 2
        Information = 4
        SuccessAudit = 8
        FailureAudit = 16
    End Enum

    Private ReadOnly Property SelectDay As Integer
        Get
            Return DatePart(DateInterval.Day, DateTimePicker1.Value)
        End Get
    End Property

    Private ReadOnly Property SelectMonth As Integer
        Get
            Return DatePart(DateInterval.Month, DateTimePicker1.Value)
        End Get
    End Property

    Private ReadOnly Property SelectYear As Integer
        Get
            Return DatePart(DateInterval.Year, DateTimePicker1.Value)
        End Get
    End Property

#End Region

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        With Me
            ListLog.Items.Clear()
            .LogText.Text = ""
            doRefresh(sender, e)

        End With
    End Sub

    Private Sub ListLog_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListLog.SelectedIndexChanged

        ReloadToolStripMenuItem1.Enabled = (Me.epType = epType.handler) And Not SelectedItem() Is Nothing
        ReloadToolStripMenuItem.Enabled = (Me.epType = epType.handler) And Not SelectedItem() Is Nothing

        Dim sel As ListViewItem = SelectedItem()
        If Not sel Is Nothing Then
            Dim doc As New XmlDocument
            Dim logurl As String = String.Format(
                "{0}/api/{1}/{2}/{3}/{4}/{5}",
                server,
                Environment,
                SelectYear,
                SelectMonth,
                SelectDay,
                sel.SubItems(1).Text
            )

            doc.Load(logurl)
            Dim el As XmlElement = doc.SelectSingleNode("Log/msg")
            LogText.Lines = Split(el.InnerText, vbLf)

            If Me.epType = epType.handler Then
                WebBrowser1.Navigate(New Uri(String.Format("{0}.xml", logurl)))
            End If

        End If

    End Sub

#Region "Item funcs"

    Function SelectedItem() As ListViewItem
        With ListLog
            For Each lvi As ListViewItem In .SelectedItems
                Return lvi
            Next
        End With
        Return Nothing
    End Function

    Private Function lvi(item As XmlNode) As ListViewItem
        Dim i As New ListViewItem
        With i
            Select Case CInt(item.Attributes("Severity").Value)
                Case LogEntryType.Err
                    .ImageIndex = 0
                Case LogEntryType.Warning
                    .ImageIndex = 2
                Case LogEntryType.Information
                    .ImageIndex = 1
                Case LogEntryType.SuccessAudit
                    .ImageIndex = 1
                Case LogEntryType.FailureAudit
                    .ImageIndex = 2
            End Select

            .SubItems(0).Text = item.Attributes("Time").Value
            .SubItems.Add(item.Attributes("BubbleID").Value)
            .Tag = item.Attributes("row").Value

        End With
        Return i

    End Function

#End Region

#Region "Refresh Data"

    Public Sub doRefresh(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click, RefreshToolStripMenuItem1.Click, Timer1.Tick
        If Not server Is Nothing Then
            With Me.RefreshWorker
                If Not .IsBusy Then
                    Dim row As Integer = 0
                    If Me.ListLog.Items.Count > 0 Then
                        row = Me.ListLog.Items(0).Tag
                    End If
                    .RunWorkerAsync(row)
                End If
            End With
        End If
    End Sub

    Private Sub RefreshWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles RefreshWorker.DoWork

        Dim result As New List(Of ListViewItem)
        Dim doc As New XmlDocument
        Try
            doc.Load(
                String.Format(
                    "{0}/api/{1}/{2}/{3}/{4}/{5}?row={6}",
                    server,
                    Environment,
                    SelectYear,
                    SelectMonth,
                    SelectDay,
                    Replace(EndPoint, ".ashx", ".log"),
                    e.Argument.ToString
                )
            )

            For Each item As XmlNode In doc.SelectNodes("log/item")
                result.Add(lvi(item))
            Next

        Catch ex As Exception
            'If TryCast(Me.MdiParent.ActiveMdiChild, baseForm).ID = Me.ID Then
            '    MsgBox(ex.Message)
            'End If

        End Try

        e.Result = result

    End Sub

    Private Sub RefreshWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles RefreshWorker.RunWorkerCompleted
        If Not e.Result Is Nothing Then
            For Each i As ListViewItem In TryCast(e.Result, List(Of ListViewItem))
                ListLog.Items.Insert(0, i)
            Next
        End If

    End Sub

#End Region

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Reload_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem.Click, ReloadToolStripMenuItem1.Click

        Dim doc As New XmlDocument
        Dim sel As ListViewItem = SelectedItem()
        If sel Is Nothing Then
            Exit Sub
        Else

            Dim logurl As String = String.Format(
                "{0}/api/{1}/{2}/{3}/{4}/{5}.xml",
                server,
                Environment,
                SelectYear,
                SelectMonth,
                SelectDay,
                sel.SubItems(1).Text
            )

            Try
                doc.Load(logurl)

            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub

            End Try

        End If

        For Each f As baseForm In Me.MdiParent.MdiChildren
            If f.FormType = eFormType.debug _
                And f.server = Me.server _
                And f.Environment = Me.Environment _
                And f.EndPoint = Me.EndPoint _
            Then
                With TryCast(f, frmHandler)
                    .rtb.Text = doc.OuterXml
                End With

                f.BringToFront()
                Exit Sub
            End If
        Next

        Dim frm As New frmHandler

        frm.epType = epType.handler
        frm.FormType = eFormType.debug

        'Display the new form.                      
        'Set the Parent Form of the Child window.  
        frm.MdiParent = Me.MdiParent
        frm.rtb.Text = doc.OuterXml
        frm.rtb.Indent()

        frm.server = Me.server
        frm.Environment = Me.Environment
        frm.EndPoint = Me.EndPoint

        frm.Text = String.Format(
            "{0}/api/{1}/{2}",
            frm.server,
            frm.Environment,
            frm.EndPoint
        )
        frm.WindowState = FormWindowState.Maximized
        frm.Show()

    End Sub

End Class