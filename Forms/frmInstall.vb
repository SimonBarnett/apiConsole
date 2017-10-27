Imports System.IO
Imports System.Xml

Public Class frmInstall : Inherits baseForm

    Public Overrides ReadOnly Property activity As Boolean
        Get
            Return Me.PatchWorker.IsBusy
        End Get
    End Property

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Execute_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click, ExecuteToolStripMenuItem.Click, ExecuteToolStripMenuItem1.Click

        Try
            LogText.Text = ""

            Dim requestStream As Stream = Nothing
            Dim uploadResponse As Net.HttpWebResponse = Nothing
            Dim uploadRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(url), Net.HttpWebRequest)
            uploadRequest.Method = "PATCH"
            uploadRequest.Proxy = Nothing

            Dim myEncoder As New System.Text.ASCIIEncoding


            requestStream = uploadRequest.GetRequestStream()
            requestStream.Close()
            uploadResponse = uploadRequest.GetResponse()

            Dim reader As New StreamReader(uploadResponse.GetResponseStream)
            Dim doc As New XmlDocument
            Dim logurl As String = String.Format(
                "{0}/api/{1}/{2}/{3}/{4}/{5}",
                server,
                Environment,
                DatePart(DateInterval.Year, Date.Parse(uploadResponse.Headers("date"))),
                DatePart(DateInterval.Month, Date.Parse(uploadResponse.Headers("date"))),
                DatePart(DateInterval.Day, Date.Parse(uploadResponse.Headers("date"))),
                uploadResponse.Headers("BubbleID")
            )

            doc.Load(logurl)
            Dim el As XmlElement = doc.SelectSingleNode("Log/msg")
            LogText.Lines = Split(el.InnerText, vbLf)


        Catch ex As Exception
            LogText.Lines = Split(ex.Message & vbCrLf & ex.StackTrace, vbCrLf)


        End Try

    End Sub

End Class