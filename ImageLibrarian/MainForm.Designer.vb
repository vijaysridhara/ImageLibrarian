Imports VijaySridhara.Applications

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        pnlThumbnails = New ContainerPanel()
        ThumbnailContainer1 = New ThumbnailContainer()
        txtFocusBox = New TextBox()
        pnlLEft = New Panel()
        trvArchives = New TreeView()
        ctxTree = New ContextMenuStrip(components)
        ImportHereToolStripMenuItem = New ToolStripMenuItem()
        AddImagesHereToolStripMenuItem = New ToolStripMenuItem()
        RenameToolStripMenuItem = New ToolStripMenuItem()
        ExportThisToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        PictureBox1 = New PictureBox()
        cboShowtypes = New ComboBox()
        Label5 = New Label()
        butExport = New Button()
        butImportImages = New Button()
        butImport = New Button()
        Splitter1 = New Splitter()
        plRight = New Panel()
        txtSearch = New TextBox()
        lblWarn2 = New Label()
        lblWarn1 = New Label()
        butUpdateComments = New Button()
        butSearch = New Button()
        butUpdateTags = New Button()
        txtExif = New TextBox()
        Label3 = New Label()
        txtComments = New TextBox()
        Label2 = New Label()
        txtTags = New TextBox()
        Label1 = New Label()
        Splitter2 = New Splitter()
        pnlTop = New Panel()
        butCacelOp = New Button()
        chkPrivate = New CheckBox()
        Label4 = New Label()
        cboArchives = New ComboBox()
        butCopyFilelink = New Button()
        txtFile = New TextBox()
        butAbout = New Button()
        butSettings = New Button()
        ProgressBar1 = New ProgressBar()
        txtLog = New TextBox()
        Splitter3 = New Splitter()
        ToolTip1 = New ToolTip(components)
        pnlThumbnails.SuspendLayout()
        pnlLEft.SuspendLayout()
        ctxTree.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        plRight.SuspendLayout()
        pnlTop.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlThumbnails
        ' 
        pnlThumbnails.AutoScroll = True
        pnlThumbnails.AutoSizeMode = AutoSizeMode.GrowAndShrink
        pnlThumbnails.BackColor = SystemColors.ControlDarkDark
        pnlThumbnails.BorderStyle = BorderStyle.Fixed3D
        pnlThumbnails.Controls.Add(ThumbnailContainer1)
        pnlThumbnails.Controls.Add(txtFocusBox)
        pnlThumbnails.Dock = DockStyle.Fill
        pnlThumbnails.Location = New Point(207, 64)
        pnlThumbnails.Name = "pnlThumbnails"
        pnlThumbnails.Size = New Size(762, 404)
        pnlThumbnails.TabIndex = 2
        ' 
        ' ThumbnailContainer1
        ' 
        ThumbnailContainer1.ArchHelper = Nothing
        ThumbnailContainer1.BackColor = Color.Transparent
        ThumbnailContainer1.CancelOperation = False
        ThumbnailContainer1.ControlKey = False
        ThumbnailContainer1.CurrentArchive = Nothing
        ThumbnailContainer1.CurrentCategory = Nothing
        ThumbnailContainer1.CurrentSubCategory = Nothing
        ThumbnailContainer1.IsCurrentlyLoading = False
        ThumbnailContainer1.IsSearch = False
        ThumbnailContainer1.Location = New Point(0, 0)
        ThumbnailContainer1.Name = "ThumbnailContainer1"
        ThumbnailContainer1.ShiftKey = False
        ThumbnailContainer1.Showtypes = "all"
        ThumbnailContainer1.Size = New Size(0, 0)
        ThumbnailContainer1.TabIndex = 1
        ThumbnailContainer1.Text = "ThumbnailContainer1"
        ThumbnailContainer1.ThumbSize = New Size(200, 150)
        ' 
        ' txtFocusBox
        ' 
        txtFocusBox.BackColor = SystemColors.ControlDarkDark
        txtFocusBox.BorderStyle = BorderStyle.None
        txtFocusBox.Font = New Font("Segoe UI", 1.5F, FontStyle.Regular, GraphicsUnit.Point)
        txtFocusBox.Location = New Point(13, 72)
        txtFocusBox.Name = "txtFocusBox"
        txtFocusBox.Size = New Size(0, 3)
        txtFocusBox.TabIndex = 0
        ' 
        ' pnlLEft
        ' 
        pnlLEft.Controls.Add(trvArchives)
        pnlLEft.Controls.Add(PictureBox1)
        pnlLEft.Dock = DockStyle.Left
        pnlLEft.Location = New Point(0, 0)
        pnlLEft.Name = "pnlLEft"
        pnlLEft.Size = New Size(203, 589)
        pnlLEft.TabIndex = 0
        ' 
        ' trvArchives
        ' 
        trvArchives.AllowDrop = True
        trvArchives.BackColor = SystemColors.ControlDarkDark
        trvArchives.ContextMenuStrip = ctxTree
        trvArchives.Dock = DockStyle.Fill
        trvArchives.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        trvArchives.FullRowSelect = True
        trvArchives.HideSelection = False
        trvArchives.LabelEdit = True
        trvArchives.Location = New Point(0, 95)
        trvArchives.Name = "trvArchives"
        trvArchives.ShowRootLines = False
        trvArchives.Size = New Size(203, 494)
        trvArchives.TabIndex = 0
        ' 
        ' ctxTree
        ' 
        ctxTree.Items.AddRange(New ToolStripItem() {ImportHereToolStripMenuItem, AddImagesHereToolStripMenuItem, RenameToolStripMenuItem, ExportThisToolStripMenuItem, ToolStripMenuItem1, DeleteToolStripMenuItem})
        ctxTree.Name = "ctxTree"
        ctxTree.Size = New Size(164, 120)
        ' 
        ' ImportHereToolStripMenuItem
        ' 
        ImportHereToolStripMenuItem.Name = "ImportHereToolStripMenuItem"
        ImportHereToolStripMenuItem.Size = New Size(163, 22)
        ImportHereToolStripMenuItem.Text = "&Import here"
        ' 
        ' AddImagesHereToolStripMenuItem
        ' 
        AddImagesHereToolStripMenuItem.Name = "AddImagesHereToolStripMenuItem"
        AddImagesHereToolStripMenuItem.Size = New Size(163, 22)
        AddImagesHereToolStripMenuItem.Text = "&Add images here"
        ' 
        ' RenameToolStripMenuItem
        ' 
        RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        RenameToolStripMenuItem.Size = New Size(163, 22)
        RenameToolStripMenuItem.Text = "&Rename "
        ' 
        ' ExportThisToolStripMenuItem
        ' 
        ExportThisToolStripMenuItem.Name = "ExportThisToolStripMenuItem"
        ExportThisToolStripMenuItem.Size = New Size(163, 22)
        ExportThisToolStripMenuItem.Text = "E&xport this"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(160, 6)
        ' 
        ' DeleteToolStripMenuItem
        ' 
        DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        DeleteToolStripMenuItem.Size = New Size(163, 22)
        DeleteToolStripMenuItem.Text = "&Delete"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = SystemColors.ControlDarkDark
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
        PictureBox1.Dock = DockStyle.Top
        PictureBox1.Image = My.Resources.Resources.piclib_128
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(203, 95)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' cboShowtypes
        ' 
        cboShowtypes.BackColor = SystemColors.ControlDarkDark
        cboShowtypes.DropDownStyle = ComboBoxStyle.DropDownList
        cboShowtypes.FormattingEnabled = True
        cboShowtypes.Items.AddRange(New Object() {"All types", "JPG", "PNG", "BMP", "GIF"})
        cboShowtypes.Location = New Point(289, 5)
        cboShowtypes.Name = "cboShowtypes"
        cboShowtypes.Size = New Size(127, 25)
        cboShowtypes.TabIndex = 1
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(232, 8)
        Label5.Name = "Label5"
        Label5.Size = New Size(39, 17)
        Label5.TabIndex = 0
        Label5.Text = "Show"
        ' 
        ' butExport
        ' 
        butExport.BackgroundImage = My.Resources.Resources.export
        butExport.BackgroundImageLayout = ImageLayout.Zoom
        butExport.Enabled = False
        butExport.FlatAppearance.BorderSize = 0
        butExport.FlatStyle = FlatStyle.Flat
        butExport.Location = New Point(82, 5)
        butExport.Name = "butExport"
        butExport.Size = New Size(32, 32)
        butExport.TabIndex = 2
        ToolTip1.SetToolTip(butExport, "Export selected files")
        butExport.UseVisualStyleBackColor = True
        ' 
        ' butImportImages
        ' 
        butImportImages.BackgroundImage = My.Resources.Resources.importimages
        butImportImages.BackgroundImageLayout = ImageLayout.Zoom
        butImportImages.Enabled = False
        butImportImages.FlatAppearance.BorderSize = 0
        butImportImages.FlatStyle = FlatStyle.Flat
        butImportImages.Location = New Point(44, 5)
        butImportImages.Name = "butImportImages"
        butImportImages.Size = New Size(32, 32)
        butImportImages.TabIndex = 1
        ToolTip1.SetToolTip(butImportImages, "Import multiple files")
        butImportImages.UseVisualStyleBackColor = True
        ' 
        ' butImport
        ' 
        butImport.BackgroundImage = My.Resources.Resources.importfolder
        butImport.BackgroundImageLayout = ImageLayout.Zoom
        butImport.Enabled = False
        butImport.FlatAppearance.BorderSize = 0
        butImport.FlatStyle = FlatStyle.Flat
        butImport.Location = New Point(6, 5)
        butImport.Name = "butImport"
        butImport.Size = New Size(32, 32)
        butImport.TabIndex = 0
        ToolTip1.SetToolTip(butImport, "Import a folder")
        butImport.UseVisualStyleBackColor = True
        ' 
        ' Splitter1
        ' 
        Splitter1.Location = New Point(203, 0)
        Splitter1.Name = "Splitter1"
        Splitter1.Size = New Size(4, 589)
        Splitter1.TabIndex = 5
        Splitter1.TabStop = False
        ' 
        ' plRight
        ' 
        plRight.Controls.Add(txtSearch)
        plRight.Controls.Add(lblWarn2)
        plRight.Controls.Add(lblWarn1)
        plRight.Controls.Add(butUpdateComments)
        plRight.Controls.Add(butSearch)
        plRight.Controls.Add(butUpdateTags)
        plRight.Controls.Add(txtExif)
        plRight.Controls.Add(Label3)
        plRight.Controls.Add(txtComments)
        plRight.Controls.Add(Label2)
        plRight.Controls.Add(txtTags)
        plRight.Controls.Add(Label1)
        plRight.Dock = DockStyle.Right
        plRight.Location = New Point(973, 0)
        plRight.Name = "plRight"
        plRight.Size = New Size(220, 589)
        plRight.TabIndex = 4
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearch.BackColor = SystemColors.ControlDark
        txtSearch.Location = New Point(3, 16)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(184, 25)
        txtSearch.TabIndex = 0
        ' 
        ' lblWarn2
        ' 
        lblWarn2.Image = My.Resources.Resources.excl
        lblWarn2.Location = New Point(85, 441)
        lblWarn2.Name = "lblWarn2"
        lblWarn2.Size = New Size(18, 22)
        lblWarn2.TabIndex = 9
        lblWarn2.Visible = False
        ' 
        ' lblWarn1
        ' 
        lblWarn1.Image = My.Resources.Resources.excl
        lblWarn1.Location = New Point(84, 246)
        lblWarn1.Name = "lblWarn1"
        lblWarn1.Size = New Size(18, 22)
        lblWarn1.TabIndex = 5
        lblWarn1.Visible = False
        ' 
        ' butUpdateComments
        ' 
        butUpdateComments.Enabled = False
        butUpdateComments.FlatStyle = FlatStyle.Popup
        butUpdateComments.Location = New Point(4, 441)
        butUpdateComments.Name = "butUpdateComments"
        butUpdateComments.Size = New Size(75, 26)
        butUpdateComments.TabIndex = 8
        butUpdateComments.Text = "Update"
        butUpdateComments.UseVisualStyleBackColor = True
        ' 
        ' butSearch
        ' 
        butSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        butSearch.FlatStyle = FlatStyle.Popup
        butSearch.Image = My.Resources.Resources.search
        butSearch.Location = New Point(193, 16)
        butSearch.Name = "butSearch"
        butSearch.Size = New Size(24, 26)
        butSearch.TabIndex = 1
        ToolTip1.SetToolTip(butSearch, "Search within the archive")
        butSearch.UseVisualStyleBackColor = True
        ' 
        ' butUpdateTags
        ' 
        butUpdateTags.Enabled = False
        butUpdateTags.FlatStyle = FlatStyle.Popup
        butUpdateTags.Location = New Point(3, 241)
        butUpdateTags.Name = "butUpdateTags"
        butUpdateTags.Size = New Size(75, 26)
        butUpdateTags.TabIndex = 4
        butUpdateTags.Text = "Update"
        butUpdateTags.UseVisualStyleBackColor = True
        ' 
        ' txtExif
        ' 
        txtExif.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtExif.BackColor = SystemColors.ControlDark
        txtExif.Enabled = False
        txtExif.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtExif.Location = New Point(4, 494)
        txtExif.Multiline = True
        txtExif.Name = "txtExif"
        txtExif.ReadOnly = True
        txtExif.ScrollBars = ScrollBars.Vertical
        txtExif.Size = New Size(211, 78)
        txtExif.TabIndex = 10
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(4, 474)
        Label3.Name = "Label3"
        Label3.Size = New Size(68, 17)
        Label3.TabIndex = 9
        Label3.Text = "&Meta data"
        ' 
        ' txtComments
        ' 
        txtComments.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtComments.BackColor = SystemColors.ControlDark
        txtComments.Enabled = False
        txtComments.Location = New Point(4, 292)
        txtComments.Multiline = True
        txtComments.Name = "txtComments"
        txtComments.Size = New Size(211, 141)
        txtComments.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(4, 272)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 17)
        Label2.TabIndex = 6
        Label2.Text = "Co&mments"
        ' 
        ' txtTags
        ' 
        txtTags.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtTags.BackColor = SystemColors.ControlDark
        txtTags.Enabled = False
        txtTags.Location = New Point(4, 77)
        txtTags.Multiline = True
        txtTags.Name = "txtTags"
        txtTags.Size = New Size(211, 157)
        txtTags.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(4, 57)
        Label1.Name = "Label1"
        Label1.Size = New Size(35, 17)
        Label1.TabIndex = 2
        Label1.Text = "&Tags"
        ' 
        ' Splitter2
        ' 
        Splitter2.Dock = DockStyle.Right
        Splitter2.Location = New Point(969, 0)
        Splitter2.Name = "Splitter2"
        Splitter2.Size = New Size(4, 589)
        Splitter2.TabIndex = 7
        Splitter2.TabStop = False
        ' 
        ' pnlTop
        ' 
        pnlTop.BackColor = SystemColors.ControlDarkDark
        pnlTop.Controls.Add(butCacelOp)
        pnlTop.Controls.Add(cboShowtypes)
        pnlTop.Controls.Add(Label5)
        pnlTop.Controls.Add(chkPrivate)
        pnlTop.Controls.Add(Label4)
        pnlTop.Controls.Add(cboArchives)
        pnlTop.Controls.Add(butExport)
        pnlTop.Controls.Add(butCopyFilelink)
        pnlTop.Controls.Add(butImportImages)
        pnlTop.Controls.Add(txtFile)
        pnlTop.Controls.Add(butAbout)
        pnlTop.Controls.Add(butSettings)
        pnlTop.Controls.Add(butImport)
        pnlTop.Controls.Add(ProgressBar1)
        pnlTop.Dock = DockStyle.Top
        pnlTop.Location = New Point(207, 0)
        pnlTop.Name = "pnlTop"
        pnlTop.Size = New Size(762, 64)
        pnlTop.TabIndex = 1
        ' 
        ' butCacelOp
        ' 
        butCacelOp.BackgroundImage = My.Resources.Resources.cancelops
        butCacelOp.FlatStyle = FlatStyle.Popup
        butCacelOp.Location = New Point(221, 43)
        butCacelOp.Name = "butCacelOp"
        butCacelOp.Size = New Size(18, 18)
        butCacelOp.TabIndex = 10
        ToolTip1.SetToolTip(butCacelOp, "Cancel current operation")
        butCacelOp.UseVisualStyleBackColor = True
        butCacelOp.Visible = False
        ' 
        ' chkPrivate
        ' 
        chkPrivate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        chkPrivate.AutoSize = True
        chkPrivate.Location = New Point(632, 5)
        chkPrivate.Name = "chkPrivate"
        chkPrivate.Size = New Size(130, 21)
        chkPrivate.TabIndex = 8
        chkPrivate.Text = "Show private also"
        ToolTip1.SetToolTip(chkPrivate, "List private archives")
        chkPrivate.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Location = New Point(539, 5)
        Label4.Name = "Label4"
        Label4.Size = New Size(87, 17)
        Label4.TabIndex = 7
        Label4.Text = "Select archive"
        ' 
        ' cboArchives
        ' 
        cboArchives.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cboArchives.BackColor = SystemColors.ControlDarkDark
        cboArchives.DropDownStyle = ComboBoxStyle.DropDownList
        cboArchives.FormattingEnabled = True
        cboArchives.Location = New Point(542, 31)
        cboArchives.Name = "cboArchives"
        cboArchives.Size = New Size(214, 25)
        cboArchives.TabIndex = 9
        ' 
        ' butCopyFilelink
        ' 
        butCopyFilelink.BackgroundImage = My.Resources.Resources.copy
        butCopyFilelink.BackgroundImageLayout = ImageLayout.Zoom
        butCopyFilelink.FlatAppearance.BorderSize = 0
        butCopyFilelink.FlatStyle = FlatStyle.Popup
        butCopyFilelink.Location = New Point(506, 41)
        butCopyFilelink.Name = "butCopyFilelink"
        butCopyFilelink.Size = New Size(18, 20)
        butCopyFilelink.TabIndex = 6
        ToolTip1.SetToolTip(butCopyFilelink, "Copy file path")
        butCopyFilelink.UseVisualStyleBackColor = True
        ' 
        ' txtFile
        ' 
        txtFile.BackColor = SystemColors.ControlDark
        txtFile.BorderStyle = BorderStyle.None
        txtFile.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtFile.Location = New Point(247, 43)
        txtFile.Name = "txtFile"
        txtFile.ReadOnly = True
        txtFile.Size = New Size(253, 15)
        txtFile.TabIndex = 5
        ' 
        ' butAbout
        ' 
        butAbout.BackgroundImage = My.Resources.Resources.about
        butAbout.BackgroundImageLayout = ImageLayout.Zoom
        butAbout.FlatAppearance.BorderSize = 0
        butAbout.FlatStyle = FlatStyle.Flat
        butAbout.Location = New Point(184, 5)
        butAbout.Name = "butAbout"
        butAbout.Size = New Size(32, 32)
        butAbout.TabIndex = 4
        ToolTip1.SetToolTip(butAbout, "About Image librarian")
        butAbout.UseVisualStyleBackColor = True
        ' 
        ' butSettings
        ' 
        butSettings.BackgroundImage = My.Resources.Resources.settings
        butSettings.BackgroundImageLayout = ImageLayout.Zoom
        butSettings.FlatAppearance.BorderSize = 0
        butSettings.FlatStyle = FlatStyle.Flat
        butSettings.Location = New Point(146, 5)
        butSettings.Name = "butSettings"
        butSettings.Size = New Size(32, 32)
        butSettings.TabIndex = 3
        ToolTip1.SetToolTip(butSettings, "Show settings")
        butSettings.UseVisualStyleBackColor = True
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(6, 43)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(210, 17)
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.TabIndex = 6
        ProgressBar1.Visible = False
        ' 
        ' txtLog
        ' 
        txtLog.BackColor = SystemColors.ControlDark
        txtLog.Dock = DockStyle.Bottom
        txtLog.Font = New Font("Lucida Console", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtLog.Location = New Point(207, 471)
        txtLog.MaxLength = 256000000
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.ScrollBars = ScrollBars.Vertical
        txtLog.Size = New Size(762, 118)
        txtLog.TabIndex = 3
        ' 
        ' Splitter3
        ' 
        Splitter3.Dock = DockStyle.Bottom
        Splitter3.Location = New Point(207, 468)
        Splitter3.Name = "Splitter3"
        Splitter3.Size = New Size(762, 3)
        Splitter3.TabIndex = 1
        Splitter3.TabStop = False
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDarkDark
        ClientSize = New Size(1193, 589)
        Controls.Add(pnlThumbnails)
        Controls.Add(pnlTop)
        Controls.Add(Splitter3)
        Controls.Add(txtLog)
        Controls.Add(Splitter2)
        Controls.Add(plRight)
        Controls.Add(Splitter1)
        Controls.Add(pnlLEft)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "MainForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Image Librarian"
        pnlThumbnails.ResumeLayout(False)
        pnlThumbnails.PerformLayout()
        pnlLEft.ResumeLayout(False)
        ctxTree.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        plRight.ResumeLayout(False)
        plRight.PerformLayout()
        pnlTop.ResumeLayout(False)
        pnlTop.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents ThumbnailContainer1 As ThumbnailContainer
    Friend WithEvents pnlThumbnails As ContainerPanel
    Friend WithEvents pnlLEft As Panel
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents plRight As Panel
    Friend WithEvents Splitter2 As Splitter
    Friend WithEvents pnlTop As Panel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents trvArchives As TreeView
    Friend WithEvents butExport As Button
    Friend WithEvents butImportImages As Button
    Friend WithEvents butImport As Button
    Friend WithEvents txtLog As TextBox
    Friend WithEvents Splitter3 As Splitter
    Friend WithEvents txtTags As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents butUpdateTags As Button
    Friend WithEvents butUpdateComments As Button
    Friend WithEvents txtComments As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtExif As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblWarn1 As Label
    Friend WithEvents lblWarn2 As Label
    Friend WithEvents txtFile As TextBox
    Friend WithEvents butCopyFilelink As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents butSearch As Button
    Friend WithEvents butAbout As Button
    Friend WithEvents butSettings As Button
    Friend WithEvents cboArchives As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkPrivate As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtFocusBox As TextBox
    Friend WithEvents cboShowtypes As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents butCacelOp As Button
    Friend WithEvents ctxTree As ContextMenuStrip
    Friend WithEvents ImportHereToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddImagesHereToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportThisToolStripMenuItem As ToolStripMenuItem
End Class
