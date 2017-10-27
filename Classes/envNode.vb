Public Class envNode : Inherits TreeNode

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

End Class
