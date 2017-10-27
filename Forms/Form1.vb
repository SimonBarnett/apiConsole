Imports System.ComponentModel

Public Class Form1

    Dim rootNode As TreeNode

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.Servers Is Nothing Then
            My.Settings.Servers = New Specialized.StringCollection
        End If

        rootNode = New TreeNode
        With rootNode
            .Name = "Servers"
            .Text = "Servers"
            .SelectedImageIndex = 0
            .ImageIndex = 0

            Dim cmServers As New ContextMenu
            With cmServers
                .MenuItems.Add(New MenuItem("Add Server", AddressOf addServer))
                .MenuItems.Add(New MenuItem("Refresh", AddressOf RefreshToolStripMenuItem_Click))
            End With
            .ContextMenu = cmServers

        End With

        ServTree.Nodes.Add(rootNode)

        For Each ServerName As String In My.Settings.Servers
            With rootNode
                .Nodes.Add(New ServerNode(Me, ServerName))
                TryCast(.Nodes(ServerName), ServerNode).Refresh(Me, Nothing)
            End With
        Next

    End Sub

    Private Sub addServer(sender As Object, e As System.EventArgs) Handles AddServerToolStripMenuItem.Click
        Dim dlg As New addServerDialog
        If dlg.ShowDialog() = DialogResult.OK Then
            Try
                If My.Settings.Servers.Contains(dlg.url) Then
                    Throw New Exception("Server already exists.")
                End If

                My.Settings.Servers.Add(dlg.url)
                My.Settings.Save()

                rootNode.Nodes.Add(New ServerNode(Me, dlg.url))
                TryCast(rootNode.Nodes(dlg.url), ServerNode).Refresh(Me, Nothing)

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If

    End Sub

    Public Sub OpenDebug()
        If Not ServTree.SelectedNode Is Nothing Then
            With ServTree.SelectedNode
                If Not ServTree.SelectedNode.Parent Is Nothing Then

                    For Each f As baseForm In Me.MdiChildren
                        If f.FormType = eFormType.debug _
                            And f.server = ServTree.SelectedNode.Parent.Parent.Parent.Name _
                            And f.Environment = ServTree.SelectedNode.Parent.Parent.Name _
                            And f.EndPoint = ServTree.SelectedNode.Name _
                        Then
                            f.BringToFront()
                            Exit Sub
                        End If
                    Next

                    Dim frm As baseForm
                    Select Case ServTree.SelectedNode.Parent.Name
                        Case "feeds"
                            frm = New frmFeed()
                            frm.epType = epType.feed
                            frm.FormType = eFormType.debug

                        Case "handlers"
                            frm = New frmHandler()
                            frm.epType = epType.handler
                            frm.FormType = eFormType.debug

                        Case Else
                            Exit Sub

                    End Select

                    'Display the new form.                      
                    'Set the Parent Form of the Child window.  
                    frm.MdiParent = Me

                    frm.server = .Parent.Parent.Parent.Name
                    frm.Environment = .Parent.Parent.Name
                    frm.EndPoint = .Name

                    frm.Text = String.Format(
                        "{0}/api/{1}/{2}",
                        frm.server,
                        frm.Environment,
                        frm.EndPoint
                    )
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                End If

            End With

        End If

    End Sub

    Public Sub OpenLog()

        If Not ServTree.SelectedNode Is Nothing Then
            With ServTree.SelectedNode
                If Not .Parent Is Nothing Then
                    Select Case .Parent.Name.ToLower
                        Case "feeds", "handlers"
                            For Each f As baseForm In Me.MdiChildren
                                If f.FormType = eFormType.log _
                                    And f.server = .Parent.Parent.Parent.Name _
                                    And f.Environment = .Parent.Parent.Name _
                                    And f.EndPoint = .Name _
                                Then
                                    f.BringToFront()
                                    Exit Sub
                                End If
                            Next

                            'Display the new form.  
                            Dim frmLog As New frmLog()

                            'Set the Parent Form of the Child window.  
                            frmLog.MdiParent = Me
                            frmLog.FormType = eFormType.log

                            Select Case .Parent.Name.ToLower
                                Case "feeds"
                                    frmLog.epType = epType.feed
                                    frmLog.TabControl.TabPages.RemoveAt(1)

                                Case "handlers"
                                    frmLog.epType = epType.handler

                            End Select

                            frmLog.server = .Parent.Parent.Parent.Name
                            frmLog.Environment = .Parent.Parent.Name
                            frmLog.EndPoint = .Name

                            frmLog.Text = String.Format(
                                "{0}/api/{1}/{2}",
                                frmLog.server,
                                frmLog.Environment,
                                Replace(frmLog.EndPoint, ".ashx", ".log")
                            )
                            frmLog.WindowState = FormWindowState.Maximized
                            frmLog.Show()
                            frmLog.doRefresh(frmLog, New System.EventArgs)

                    End Select

                End If

            End With

        End If

    End Sub

    Public Sub OpenInstall()
        If Not ServTree.SelectedNode Is Nothing Then
            With ServTree.SelectedNode
                If Not ServTree.SelectedNode.Parent Is Nothing Then

                    For Each f As baseForm In Me.MdiChildren
                        If f.FormType = eFormType.install _
                            And f.server = ServTree.SelectedNode.Parent.Parent.Parent.Name _
                            And f.Environment = ServTree.SelectedNode.Parent.Parent.Name _
                            And f.EndPoint = ServTree.SelectedNode.Name _
                        Then
                            f.BringToFront()
                            Exit Sub
                        End If
                    Next

                    Dim frm As New frmInstall
                    frm.epType = epType.feed
                    frm.FormType = eFormType.debug


                    'Display the new form.                      
                    'Set the Parent Form of the Child window.  
                    frm.MdiParent = Me

                    frm.server = .Parent.Parent.Parent.Name
                    frm.Environment = .Parent.Parent.Name
                    frm.EndPoint = .Name

                    frm.Text = String.Format(
                        "{0}/api/{1}/{2}",
                        frm.server,
                        frm.Environment,
                        Replace(frm.EndPoint, ".ashx", ".install")
                    )
                    frm.WindowState = FormWindowState.Maximized
                    frm.Show()
                End If

            End With

        End If

    End Sub

#Region "Control handlers"

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Not Me.ActiveMdiChild Is Nothing Then
            Me.ActiveMdiChild.Close()
        End If
    End Sub

    Private Sub ServTree_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles ServTree.NodeMouseClick
        If e.Button = MouseButtons.Right Then ServTree.SelectedNode = e.Node
    End Sub

    Private Sub ServTree_DoubleClick(sender As Object, e As EventArgs) Handles ServTree.DoubleClick
        OpenLog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        refreshNode()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = Not (MsgBox("Close the application?", vbOKCancel, "Close?") = MsgBoxResult.Ok)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        With Activity
            If .Value = .Maximum Then
                .Value = 0
            Else
                .Value += 5
            End If
        End With

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim f As Boolean = False
        For Each frm As baseForm In Me.MdiChildren
            If frm.activity Then
                f = True
                Exit For
            End If
        Next
        For Each node As ServerNode In rootNode.Nodes
            If node.Activity Then
                f = True
                Exit For
            End If
        Next
        With Activity
            If f Then
                If Not .Visible Then
                    .Value = 0
                    .Visible = True
                End If

            Else
                If .Visible Then
                    .Visible = False
                End If
            End If
        End With
    End Sub

    Private Sub ServTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles ServTree.AfterSelect

    End Sub

    Private Sub ServTree_KeyDown(sender As Object, e As KeyEventArgs) Handles ServTree.KeyDown
        If Not ServTree.SelectedNode Is Nothing Then
            With ServTree.SelectedNode
                Select Case e.KeyData

                    Case Keys.F5
                        e.Handled = True
                        e.SuppressKeyPress = True
                        refreshNode()

                    Case Keys.Enter
                        e.Handled = True
                        e.SuppressKeyPress = True
                        If Not .Parent Is Nothing Then
                            Select Case .Parent.Name.ToLower
                                Case "feeds", "handlers"
                                    e.Handled = True
                                    OpenLog()

                            End Select
                        End If

                    Case Keys.Enter + Keys.Shift
                        e.Handled = True
                        e.SuppressKeyPress = True
                        If Not .Parent Is Nothing Then
                            Select Case .Parent.Name.ToLower
                                Case "feeds", "handlers"
                                    e.Handled = True
                                    OpenDebug()

                            End Select
                        End If

                End Select
            End With
        End If
    End Sub

    Private Sub refreshNode()
        If ServTree.SelectedNode Is rootNode Then
            For Each node As ServerNode In rootNode.Nodes
                node.Refresh(Me, Nothing)
            Next
        Else
            If ServTree.SelectedNode.Parent Is rootNode Then
                TryCast(ServTree.SelectedNode, ServerNode).Refresh(Me, Nothing)
            End If

        End If
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each f As baseForm In Me.MdiChildren
            f.Close()
        Next
    End Sub

    Private Sub CloseAllButThisToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CloseAllButThisToolStripMenuItem.Click
        For Each f As baseForm In Me.MdiChildren
            If Not f Is Me.ActiveMdiChild Then f.Close()
        Next
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
        CloseAllToolStripMenuItem.Enabled = Me.MdiChildren.Count > 0
        CloseAllButThisToolStripMenuItem.Enabled = Me.MdiChildren.Count > 1
    End Sub

    Private Sub TileHorizontallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileHorizontallyToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TileVerticallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileVerticallyToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

#End Region

End Class
