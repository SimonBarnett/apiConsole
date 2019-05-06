Imports System.IO
Imports System.Xml

Public Class envNode : Inherits TreeNode

    Dim cmEnv As New ContextMenu

    Private _Feeds As TreeNode
    Public ReadOnly Property Feeds As TreeNode
        Get
            Return _Feeds
        End Get
    End Property

    Private _handlers As TreeNode
    Public ReadOnly Property Handlers As TreeNode
        Get
            Return _handlers
        End Get
    End Property

    Private _Parent As TreeNode
    Sub New(parent As TreeNode, Name As String)
        _Parent = parent
        With Me
            .Name = Name
            .Text = Name
            .Tag = Name
            .SelectedImageIndex = 2
            .ImageIndex = 2
            .ContextMenu = cmEnv

            With cmEnv
                If String.Compare(Me.Name, "system", True) = 0 Then
                    Beep()

                Else
                    .MenuItems.Add(New MenuItem("$metadata", AddressOf metadata))
                    .MenuItems.Add(New MenuItem("Build Schema", AddressOf buildschema))

                End If

            End With

            _Feeds = New TreeNode
            With _Feeds
                .Name = "feeds"
                .Text = "Feeds"
                .SelectedImageIndex = 3
                .ImageIndex = 3
            End With

            _handlers = New TreeNode
            With _handlers
                .Name = "handlers"
                .Text = "handlers"
                .SelectedImageIndex = 4
                .ImageIndex = 4
            End With

            With .Nodes
                .Add(_Feeds)
                .Add(_handlers)
            End With

        End With

    End Sub

    Private Sub metadata(sender As Object, e As System.EventArgs)
        System.Diagnostics.Process.Start(
            Replace(
                String.Format(
                    "{0}/odata/Priority/{1}/{2}/$metadata",
                    _Parent.Name,
                    Me.Name,
                    TryCast(_Parent, ServerNode).tabulaini
                ),
                "http://",
                "https://",,, CompareMethod.Text
            )
        )
    End Sub

    Private Sub buildschema(sender As Object, e As System.EventArgs)

        Using d As New FolderBrowserDialog
            d.SelectedPath = AppDomain.CurrentDomain.BaseDirectory
            Try
                d.SelectedPath = My.Settings.LastSchemaLoc
            Catch : End Try

            If d.ShowDialog = DialogResult.OK Then
                With My.Settings
                    .LastSchemaLoc = d.SelectedPath
                    .Save()
                End With

                Dim dlgSch As New dlgSchema(
                    d.SelectedPath,
                    String.Format("{0}/api/{1}/schema.ashx", _Parent.Name, Me.Name)
                )

                Dim res As DialogResult = dlgSch.ShowDialog()
                If Not res = DialogResult.OK Then
                    MsgBox(dlgSch.Exception.Message)

                Else
                    MsgBox("Ok.")

                End If

            End If

        End Using

    End Sub

End Class
