Imports System.Xml

Public Class endPoint : Inherits TreeNode

    Private _f As Form1

    Private _epType As epType
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

    Private _Environment As String
    Public ReadOnly Property Environment As String
        Get
            Return _Environment
        End Get
    End Property

    Public ReadOnly Property Server As String
        Get
            Return _parent.Name
        End Get
    End Property

    Private _Params As New Dictionary(Of String, String)
    Public ReadOnly Property params As Dictionary(Of String, String)
        Get
            Return _Params
        End Get
    End Property

    Private _parent As TreeNode
    Friend Sub New(f As Form, parent As TreeNode, Environment As String, Name As String, epType As epType, Optional feed As XmlNode = Nothing)

        If Not feed Is Nothing Then
            For Each param As XmlNode In feed.SelectNodes("param")
                _Params.Add(param.Attributes("name").Value, param.Attributes("type").Value)
            Next
        End If

        _f = f
        _parent = parent
        _epType = epType
        _Environment = Environment

        Dim cm As New ContextMenu
        With Me
            .Name = Name
            .Text = Name
            .Tag = Name
            .ContextMenu = cm

            Select Case _epType
                Case epType.handler
                    .SelectedImageIndex = 4
                    .ImageIndex = 4
                    With cm
                        .MenuItems.Add(New MenuItem("View Log", AddressOf ParentForm.OpenLog))
                        .MenuItems.Add(New MenuItem("Debug Handler", AddressOf ParentForm.OpenDebug))
                    End With

                Case Else
                    With cm
                        .MenuItems.Add(New MenuItem("View Log", AddressOf ParentForm.OpenLog))
                        .MenuItems.Add(New MenuItem("Debug Feed", AddressOf ParentForm.OpenDebug))

                    End With

                    Select Case _epType
                        Case epType.feed_mef
                            .SelectedImageIndex = 5
                            .ImageIndex = 5
                            With cm
                                .MenuItems.Add(New MenuItem("-"))
                                .MenuItems.Add(New MenuItem("Install Feed", AddressOf ParentForm.OpenInstall))
                            End With

                        Case epType.feed_dbo
                            .SelectedImageIndex = 6
                            .ImageIndex = 6

                        Case epType.feed_fso
                            .SelectedImageIndex = 7
                            .ImageIndex = 7

                    End Select



            End Select


        End With

    End Sub

End Class
