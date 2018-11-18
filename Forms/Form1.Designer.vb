<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.imgTree = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllButThisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExectueHandlerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GITHubcomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Activity = New System.Windows.Forms.ToolStripProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ServTree = New System.Windows.Forms.TreeView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.InstallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgTree
        '
        Me.imgTree.ImageStream = CType(resources.GetObject("imgTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTree.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTree.Images.SetKeyName(0, "ENTIRNET.ICO")
        Me.imgTree.Images.SetKeyName(1, "http_file_server.ico")
        Me.imgTree.Images.SetKeyName(2, "priority.ico")
        Me.imgTree.Images.SetKeyName(3, "Feeds.ico")
        Me.imgTree.Images.SetKeyName(4, "handler.png")
        Me.imgTree.Images.SetKeyName(5, "feed-mef.ico")
        Me.imgTree.Images.SetKeyName(6, "feed-dbo.ico")
        Me.imgTree.Images.SetKeyName(7, "feed-fso.ico")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.MdiWindowListItem = Me.WindowToolStripMenuItem
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(684, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddServerToolStripMenuItem, Me.ToolStripMenuItem2, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripMenuItem4, Me.CloseToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.CloseAllButThisToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'AddServerToolStripMenuItem
        '
        Me.AddServerToolStripMenuItem.Name = "AddServerToolStripMenuItem"
        Me.AddServerToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.AddServerToolStripMenuItem.Text = "Add Server"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(160, 6)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Enabled = False
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Enabled = False
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(160, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Enabled = False
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.CloseToolStripMenuItem.Text = "&Close"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Enabled = False
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.CloseAllToolStripMenuItem.Text = "Close All"
        '
        'CloseAllButThisToolStripMenuItem
        '
        Me.CloseAllButThisToolStripMenuItem.Enabled = False
        Me.CloseAllButThisToolStripMenuItem.Name = "CloseAllButThisToolStripMenuItem"
        Me.CloseAllButThisToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.CloseAllButThisToolStripMenuItem.Text = "Close All but this"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(160, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExectueHandlerToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.FormatToolStripMenuItem, Me.ToolStripMenuItem3, Me.InstallToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'ExectueHandlerToolStripMenuItem
        '
        Me.ExectueHandlerToolStripMenuItem.Enabled = False
        Me.ExectueHandlerToolStripMenuItem.Name = "ExectueHandlerToolStripMenuItem"
        Me.ExectueHandlerToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.ExectueHandlerToolStripMenuItem.Text = "E&xecute"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Enabled = False
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.ReloadToolStripMenuItem.Text = "&Reload"
        '
        'FormatToolStripMenuItem
        '
        Me.FormatToolStripMenuItem.Enabled = False
        Me.FormatToolStripMenuItem.Name = "FormatToolStripMenuItem"
        Me.FormatToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.FormatToolStripMenuItem.Text = "For&mat"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TileHorizontallyToolStripMenuItem, Me.TileVerticallyToolStripMenuItem, Me.CascadeToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "&Window"
        '
        'TileHorizontallyToolStripMenuItem
        '
        Me.TileHorizontallyToolStripMenuItem.Name = "TileHorizontallyToolStripMenuItem"
        Me.TileHorizontallyToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.TileHorizontallyToolStripMenuItem.Text = "Tile Horizontally"
        '
        'TileVerticallyToolStripMenuItem
        '
        Me.TileVerticallyToolStripMenuItem.Name = "TileVerticallyToolStripMenuItem"
        Me.TileVerticallyToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.TileVerticallyToolStripMenuItem.Text = "Tile Vertically"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.CascadeToolStripMenuItem.Text = "Cascade"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.GITHubcomToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'GITHubcomToolStripMenuItem
        '
        Me.GITHubcomToolStripMenuItem.Name = "GITHubcomToolStripMenuItem"
        Me.GITHubcomToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.GITHubcomToolStripMenuItem.Text = "GITHub.com"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Activity})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 472)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(684, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Activity
        '
        Me.Activity.Name = "Activity"
        Me.Activity.Size = New System.Drawing.Size(100, 16)
        Me.Activity.Step = 1
        Me.Activity.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Activity.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ServTree)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 448)
        Me.Panel1.TabIndex = 7
        '
        'ServTree
        '
        Me.ServTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ServTree.ImageIndex = 0
        Me.ServTree.ImageList = Me.imgTree
        Me.ServTree.Location = New System.Drawing.Point(0, 0)
        Me.ServTree.Name = "ServTree"
        Me.ServTree.SelectedImageIndex = 0
        Me.ServTree.Size = New System.Drawing.Size(200, 448)
        Me.ServTree.TabIndex = 4
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(200, 24)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(5, 448)
        Me.Splitter1.TabIndex = 8
        Me.Splitter1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(149, 6)
        '
        'InstallToolStripMenuItem
        '
        Me.InstallToolStripMenuItem.Name = "InstallToolStripMenuItem"
        Me.InstallToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InstallToolStripMenuItem.Text = "Install"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 494)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Console"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgTree As ImageList
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ServTree As TreeView
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents AddServerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExectueHandlerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Activity As ToolStripProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents FormatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents CloseAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseAllButThisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TileHorizontallyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TileVerticallyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GITHubcomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents InstallToolStripMenuItem As ToolStripMenuItem
End Class
