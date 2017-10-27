Public Class endPoint : Inherits TreeNode

    Private _f As Form1

    Private _epType As epType = epType.feed
    Friend ReadOnly Property Type As epType
        Get
            Return _epType
        End Get
    End Property

    Public ReadOnly Property ParentForm As Form1
        Get
            Return _f
        End Get
    End Property

    Private _parent As TreeNode
    Friend Sub New(f As Form, parent As TreeNode, Name As String, epType As epType)
        _f = f
        _parent = parent
        _epType = epType

        Dim cm As New ContextMenu
        With Me
            .Name = Name
            .Text = Name
            .Tag = Name
            .ContextMenu = cm

            Select Case _epType
                Case epType.feed
                    .SelectedImageIndex = 3
                    .ImageIndex = 3
                    With cm
                        .MenuItems.Add(New MenuItem("View Log", AddressOf ParentForm.OpenLog))
                        .MenuItems.Add(New MenuItem("Debug Feed", AddressOf ParentForm.OpenDebug))
                        .MenuItems.Add(New MenuItem("-"))
                        .MenuItems.Add(New MenuItem("Install Feed", AddressOf ParentForm.OpenInstall))
                    End With

                Case epType.handler
                    .SelectedImageIndex = 4
                    .ImageIndex = 4
                    With cm
                        .MenuItems.Add(New MenuItem("View Log", AddressOf ParentForm.OpenLog))
                        .MenuItems.Add(New MenuItem("Debug Handler", AddressOf ParentForm.OpenDebug))
                    End With
            End Select


        End With

    End Sub

End Class
