Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports Newtonsoft.Json

Public Class POSTexample

    Private URL As String = "https://prioritydev.flags.co.uk/api/test/pfhandler.ashx"

    Private WithEvents SendWorker As New BackgroundWorker

#Region "Send Worker"

    Private Sub StartWorker(sender As Object, e As EventArgs)
        With SendWorker
            If Not .IsBusy Then
                Try
                    .RunWorkerAsync("<request/>")

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
            Dim uploadRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(URL), Net.HttpWebRequest)

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
            uploadResponse = uploadRequest.GetResponse()

            e.Result = uploadResponse

        Catch ex As Exception
            e.Result = ex

        End Try

    End Sub

    Private Sub SendWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles SendWorker.RunWorkerCompleted

        If TypeOf (e.Result) Is Exception Then
            With TryCast(e.Result, Exception)
                Console.Write(.Message)

            End With

        Else
            With TryCast(e.Result, Net.WebResponse)
                Dim reader As New StreamReader(.GetResponseStream)
                Dim doctext As String = reader.ReadToEnd

                Select Case .ContentType.ToLower.Contains("text/json")
                    Case True
                        Using stringReader As New StringReader(doctext)
                            Using stringWriter As New StringWriter
                                Dim jsonreader As New JsonTextReader(stringReader)
                                Dim jsonwriter As New JsonTextWriter(stringWriter)
                                With jsonwriter
                                    .Formatting = Newtonsoft.Json.Formatting.Indented
                                    .WriteToken(jsonreader)
                                End With

                                Dim myEncoder As New System.Text.ASCIIEncoding
                                Console.Write(stringWriter.ToString)

                            End Using
                        End Using

                    Case Else
                        Dim doc As New XmlDocument
                        With doc
                            .LoadXml(doctext)
                            Console.Write(.OuterXml)
                        End With

                End Select

            End With

        End If

    End Sub

#End Region

End Class
