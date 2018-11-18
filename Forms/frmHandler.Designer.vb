<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHandler
    Inherits baseForm 'System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHandler))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.rtb = New apiConsole.xmlEditor()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.LogText = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExecuteHandlerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SendWorker = New System.ComponentModel.BackgroundWorker()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExecuteToolStripMenuItem, Me.ExecuteToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(152, 48)
        '
        'ExecuteToolStripMenuItem
        '
        Me.ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem"
        Me.ExecuteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ExecuteToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ExecuteToolStripMenuItem.Text = "Execute"
        '
        'ExecuteToolStripMenuItem1
        '
        Me.ExecuteToolStripMenuItem1.Name = "ExecuteToolStripMenuItem1"
        Me.ExecuteToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ExecuteToolStripMenuItem1.Size = New System.Drawing.Size(151, 22)
        Me.ExecuteToolStripMenuItem1.Text = "Execute"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.rtb)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.TabControl)
        Me.SplitContainer.Size = New System.Drawing.Size(447, 403)
        Me.SplitContainer.SplitterDistance = 178
        Me.SplitContainer.TabIndex = 1
        '
        'rtb
        '
        Me.rtb.AcceptsTab = True
        Me.rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.rtb.IndentSp = 3
        Me.rtb.Location = New System.Drawing.Point(0, 0)
        Me.rtb.Name = "rtb"
        Me.rtb.Size = New System.Drawing.Size(447, 178)
        Me.rtb.TabIndex = 0
        Me.rtb.Text = ""
        Me.rtb.WordWrap = False
        '
        'TabControl
        '
        Me.TabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(447, 221)
        Me.TabControl.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.LogText)
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(439, 195)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Log"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'LogText
        '
        Me.LogText.AcceptsReturn = True
        Me.LogText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogText.Location = New System.Drawing.Point(3, 3)
        Me.LogText.Multiline = True
        Me.LogText.Name = "LogText"
        Me.LogText.ReadOnly = True
        Me.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.LogText.Size = New System.Drawing.Size(433, 189)
        Me.LogText.TabIndex = 7
        Me.LogText.WordWrap = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.WebBrowser)
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(439, 181)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Result"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'WebBrowser
        '
        Me.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser.Name = "WebBrowser"
        Me.WebBrowser.Size = New System.Drawing.Size(433, 175)
        Me.WebBrowser.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(447, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.CloseToolStripMenuItem.Text = "&Close"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExecuteHandlerToolStripMenuItem, Me.FormatToolStripMenuItem})
        Me.ToolsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'ExecuteHandlerToolStripMenuItem
        '
        Me.ExecuteHandlerToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
        Me.ExecuteHandlerToolStripMenuItem.Name = "ExecuteHandlerToolStripMenuItem"
        Me.ExecuteHandlerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExecuteHandlerToolStripMenuItem.Text = "E&xecute"
        '
        'FormatToolStripMenuItem
        '
        Me.FormatToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace
        Me.FormatToolStripMenuItem.Name = "FormatToolStripMenuItem"
        Me.FormatToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.FormatToolStripMenuItem.Text = "For&mat"
        '
        'SendWorker
        '
        '
        'frmHandler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 403)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmHandler"
        Me.Text = "frmHandler"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer As SplitContainer
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ExecuteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExecuteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExecuteHandlerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents LogText As TextBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents WebBrowser As WebBrowser
    Friend WithEvents SendWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents FormatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents rtb As xmlEditor
End Class
