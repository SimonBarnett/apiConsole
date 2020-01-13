Imports System.ComponentModel
Imports System.IO
Imports System.Xml

Public Class dlgSchema

    Private _url As String
    Private _path As String

    Private _e As Exception = Nothing
    Public ReadOnly Property Exception As Exception
        Get
            Return _e
        End Get
    End Property

    Sub New(Path As String, URL As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _url = URL
        _path = Path

        SendWorker.RunWorkerAsync("")

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        With ProgressBar
            If .Value < .Maximum Then
                .Value += 1
            Else
                .Value = 0
            End If
        End With

    End Sub

#Region "Send Worker"

    Private Sub SendWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles SendWorker.DoWork

        System.Net.ServicePointManager.ServerCertificateValidationCallback =
          Function(se As Object,
          cert As System.Security.Cryptography.X509Certificates.X509Certificate,
          chain As System.Security.Cryptography.X509Certificates.X509Chain,
          sslerror As System.Net.Security.SslPolicyErrors) True

        Try
            Dim doc As New XmlDocument
            doc.Load(_url)

            For Each Entity As XmlNode In doc.SelectNodes("Schema/EntityType")
                Using sw As New StreamWriter(
                            Path.Combine(
                                _path,
                                String.Format(
                                    "{0}.vb",
                                    Entity.Attributes("Name").Value
                                )
                            )
                        )
                    With sw
                        .Write(New entForm(Entity).tostring)
                        .Write(New entRow(Entity).toString)
                        .Write(New entSerial(Entity).toString)

                    End With

                End Using

            Next

        Catch ex As Exception
            _e = ex

        End Try

    End Sub

    Private Sub SendWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles SendWorker.RunWorkerCompleted

        If _e Is Nothing Then
            Me.DialogResult = DialogResult.OK

        Else
            Me.DialogResult = DialogResult.No

        End If

    End Sub

#End Region

End Class