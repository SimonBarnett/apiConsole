Imports System.Xml
Imports System.Net
Imports System.IO
Imports System.ComponentModel

Public Class ServerNode : Inherits TreeNode

    Dim cmServer As New ContextMenu
    Dim _f As Form

    Private _tabulaini As String = "tabula.ini"
    Public ReadOnly Property tabulaini As String
        Get
            Return _tabulaini
        End Get
    End Property

    Public refreshWorker As System.ComponentModel.BackgroundWorker

    Private ReadOnly Property url As String
        Get
            Return String.Format("{0}/api/default.ashx", Me.Text)
        End Get
    End Property

    Public ReadOnly Property ParentForm As Form
        Get
            Return _f
        End Get
    End Property

    Public ReadOnly Property Activity As Boolean
        Get
            Return refreshWorker.IsBusy
        End Get
    End Property

    Sub New(f As Form, Name As String)
        _f = f
        With Me
            .refreshWorker = New BackgroundWorker
            AddHandler .refreshWorker.DoWork, AddressOf doWork
            AddHandler .refreshWorker.RunWorkerCompleted, AddressOf workComplete
            .Tag = Name
            .Name = Name
            .Text = Name
            .ContextMenu = cmServer
            .SelectedImageIndex = 1
            .ImageIndex = 1
        End With

        With cmServer
            .MenuItems.Add(New MenuItem("Remove Server", AddressOf removeServer))
            .MenuItems.Add(New MenuItem("Refresh", AddressOf Refresh))

        End With

    End Sub

    Sub doWork(sender As Object, e As DoWorkEventArgs)

        System.Net.ServicePointManager.ServerCertificateValidationCallback =
          Function(se As Object,
          cert As System.Security.Cryptography.X509Certificates.X509Certificate,
          chain As System.Security.Cryptography.X509Certificates.X509Chain,
          sslerror As System.Net.Security.SslPolicyErrors) True

        Try

            Dim requestStream As Stream = Nothing
            Dim uploadResponse As Net.HttpWebResponse = Nothing
            Dim uploadRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(url), Net.HttpWebRequest)
            uploadRequest.Method = "VIEW"
            uploadRequest.Proxy = Nothing
            requestStream = uploadRequest.GetRequestStream()
            requestStream.Close()

            uploadResponse = uploadRequest.GetResponse()

            Dim thisRequest As New XmlDocument
            Dim reader As New StreamReader(uploadResponse.GetResponseStream)
            e.Result = reader

        Catch ex As Exception
            e.Result = ex

        End Try

    End Sub

    Sub workComplete(sender As Object, e As RunWorkerCompletedEventArgs)

        If TypeOf (e.Result) Is Exception Then
            With TryCast(e.Result, Exception)
                MsgBox(.Message)
            End With
            Exit Sub
        End If

        Dim doc As New XmlDocument
        doc.LoadXml(e.Result.ReadToEnd)

        Try
            _tabulaini = doc.SelectSingleNode("api").Attributes("tabulaini").Value
        Catch : End Try

        For Each env As XmlNode In doc.SelectNodes("//env")
            Dim envName As String = env.Attributes("name").Value
            If Not Nodes.ContainsKey(envName) Then
                Nodes.Add(New envNode(Me, envName))

            End If

            For Each feed As XmlNode In env.SelectNodes("feed")
                With TryCast(Me.Nodes(envName), envNode).Feeds.Nodes
                    Dim feedName As String = feed.Attributes("name").Value
                    If Not .ContainsKey(feedName) Then
                        Select Case feed.Attributes("type").Value.ToLower
                            Case "mef"
                                .Add(New endPoint(ParentForm, Me, envName, feedName, epType.feed_mef, feed))

                            Case "dbo"
                                .Add(New endPoint(ParentForm, Me, envName, feedName, epType.feed_dbo, feed))

                            Case "fso"
                                .Add(New endPoint(ParentForm, Me, envName, feedName, epType.feed_fso, feed))

                        End Select

                    End If
                End With
            Next

            For Each handler As XmlNode In env.SelectNodes("handler")
                With TryCast(Me.Nodes(envName), envNode).Handlers.Nodes
                    Dim handlerName As String = handler.Attributes("name").Value
                    If Not .ContainsKey(handlerName) Then
                        .Add(New endPoint(ParentForm, Me, envName, handlerName, epType.handler))
                    End If
                End With
            Next

        Next
    End Sub

    Public Sub Refresh(sender As Object, e As System.EventArgs)
        With refreshWorker
            If Not .IsBusy Then
                .RunWorkerAsync()
            End If
        End With

    End Sub

    Private Sub removeServer(sender As Object, e As System.EventArgs)        '
        Me.TreeView.SelectedNode = Me
        With Me.TreeView.SelectedNode
            If MsgBox(String.Format("Remove server {0}?", .Text), vbOKCancel, "Remove") = vbOK Then
                My.Settings.Servers.Remove(.Text)
                My.Settings.Save()
                .Remove()
            End If
        End With
    End Sub


End Class
