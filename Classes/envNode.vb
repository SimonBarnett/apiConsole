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
                .MenuItems.Add(New MenuItem("$metadata", AddressOf metadata))

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
                    "{0}/odata/Priority/tabula.ini/{1}/$metadata",
                    _Parent.Name,
                    Me.Name
                ),
                "http://",
                "https://",,, CompareMethod.Text
            )
        )
    End Sub

End Class
