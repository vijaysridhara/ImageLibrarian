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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.pnlThumbnails = New System.Windows.Forms.Panel()
        Me.ThumbnailContainer1 = New VijaySridhara.Applications.ThumbnailContainer()
        Me.pnlLEft = New System.Windows.Forms.Panel()
        Me.trvArchives = New System.Windows.Forms.TreeView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.butExport = New System.Windows.Forms.Button()
        Me.butImportImages = New System.Windows.Forms.Button()
        Me.butImport = New System.Windows.Forms.Button()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.plRight = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblWarn2 = New System.Windows.Forms.Label()
        Me.lblWarn1 = New System.Windows.Forms.Label()
        Me.butUpdateComments = New System.Windows.Forms.Button()
        Me.butSearch = New System.Windows.Forms.Button()
        Me.butUpdateTags = New System.Windows.Forms.Button()
        Me.txtExif = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTags = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.chkPrivate = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboArchives = New System.Windows.Forms.ComboBox()
        Me.butCopyFilelink = New System.Windows.Forms.Button()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.butAbout = New System.Windows.Forms.Button()
        Me.butSettings = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.Splitter3 = New System.Windows.Forms.Splitter()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlThumbnails.SuspendLayout()
        Me.pnlLEft.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.plRight.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlThumbnails
        '
        Me.pnlThumbnails.AutoScroll = True
        Me.pnlThumbnails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlThumbnails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlThumbnails.Controls.Add(Me.ThumbnailContainer1)
        Me.pnlThumbnails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlThumbnails.Location = New System.Drawing.Point(207, 64)
        Me.pnlThumbnails.Name = "pnlThumbnails"
        Me.pnlThumbnails.Size = New System.Drawing.Size(762, 404)
        Me.pnlThumbnails.TabIndex = 3
        '
        'ThumbnailContainer1
        '
        Me.ThumbnailContainer1.ArchHelper = Nothing
        Me.ThumbnailContainer1.ControlKey = False
        Me.ThumbnailContainer1.CurrentArchive = Nothing
        Me.ThumbnailContainer1.CurrentCategory = Nothing
        Me.ThumbnailContainer1.CurrentSubCategory = Nothing
        Me.ThumbnailContainer1.IsSearch = False
        Me.ThumbnailContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ThumbnailContainer1.Name = "ThumbnailContainer1"
        Me.ThumbnailContainer1.ShiftKey = False
        Me.ThumbnailContainer1.Size = New System.Drawing.Size(0, 0)
        Me.ThumbnailContainer1.TabIndex = 0
        Me.ThumbnailContainer1.Text = "ThumbnailContainer1"
        Me.ThumbnailContainer1.ThumbSize = New System.Drawing.Size(200, 150)
        '
        'pnlLEft
        '
        Me.pnlLEft.Controls.Add(Me.trvArchives)
        Me.pnlLEft.Controls.Add(Me.PictureBox1)
        Me.pnlLEft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLEft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLEft.Name = "pnlLEft"
        Me.pnlLEft.Size = New System.Drawing.Size(203, 589)
        Me.pnlLEft.TabIndex = 0
        '
        'trvArchives
        '
        Me.trvArchives.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.trvArchives.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvArchives.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.trvArchives.FullRowSelect = True
        Me.trvArchives.HideSelection = False
        Me.trvArchives.LabelEdit = True
        Me.trvArchives.Location = New System.Drawing.Point(0, 125)
        Me.trvArchives.Name = "trvArchives"
        Me.trvArchives.ShowRootLines = False
        Me.trvArchives.Size = New System.Drawing.Size(203, 464)
        Me.trvArchives.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.VijaySridhara.Applications.My.Resources.Resources.piclib_128
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(203, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'butExport
        '
        Me.butExport.BackgroundImage = Global.VijaySridhara.Applications.My.Resources.Resources.export
        Me.butExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.butExport.Enabled = False
        Me.butExport.FlatAppearance.BorderSize = 0
        Me.butExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butExport.Location = New System.Drawing.Point(82, 5)
        Me.butExport.Name = "butExport"
        Me.butExport.Size = New System.Drawing.Size(32, 32)
        Me.butExport.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.butExport, "Export selected files")
        Me.butExport.UseVisualStyleBackColor = True
        '
        'butImportImages
        '
        Me.butImportImages.BackgroundImage = Global.VijaySridhara.Applications.My.Resources.Resources.importimages
        Me.butImportImages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.butImportImages.Enabled = False
        Me.butImportImages.FlatAppearance.BorderSize = 0
        Me.butImportImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butImportImages.Location = New System.Drawing.Point(44, 5)
        Me.butImportImages.Name = "butImportImages"
        Me.butImportImages.Size = New System.Drawing.Size(32, 32)
        Me.butImportImages.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.butImportImages, "Import multiple files")
        Me.butImportImages.UseVisualStyleBackColor = True
        '
        'butImport
        '
        Me.butImport.BackgroundImage = Global.VijaySridhara.Applications.My.Resources.Resources.importfolder
        Me.butImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.butImport.Enabled = False
        Me.butImport.FlatAppearance.BorderSize = 0
        Me.butImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butImport.Location = New System.Drawing.Point(6, 5)
        Me.butImport.Name = "butImport"
        Me.butImport.Size = New System.Drawing.Size(32, 32)
        Me.butImport.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.butImport, "Import a folder")
        Me.butImport.UseVisualStyleBackColor = True
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(203, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(4, 589)
        Me.Splitter1.TabIndex = 5
        Me.Splitter1.TabStop = False
        '
        'plRight
        '
        Me.plRight.Controls.Add(Me.txtSearch)
        Me.plRight.Controls.Add(Me.lblWarn2)
        Me.plRight.Controls.Add(Me.lblWarn1)
        Me.plRight.Controls.Add(Me.butUpdateComments)
        Me.plRight.Controls.Add(Me.butSearch)
        Me.plRight.Controls.Add(Me.butUpdateTags)
        Me.plRight.Controls.Add(Me.txtExif)
        Me.plRight.Controls.Add(Me.Label3)
        Me.plRight.Controls.Add(Me.txtComments)
        Me.plRight.Controls.Add(Me.Label2)
        Me.plRight.Controls.Add(Me.txtTags)
        Me.plRight.Controls.Add(Me.Label1)
        Me.plRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.plRight.Location = New System.Drawing.Point(973, 0)
        Me.plRight.Name = "plRight"
        Me.plRight.Size = New System.Drawing.Size(220, 589)
        Me.plRight.TabIndex = 0
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txtSearch.Location = New System.Drawing.Point(3, 16)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(184, 25)
        Me.txtSearch.TabIndex = 0
        '
        'lblWarn2
        '
        Me.lblWarn2.Image = Global.VijaySridhara.Applications.My.Resources.Resources.excl
        Me.lblWarn2.Location = New System.Drawing.Point(85, 441)
        Me.lblWarn2.Name = "lblWarn2"
        Me.lblWarn2.Size = New System.Drawing.Size(18, 22)
        Me.lblWarn2.TabIndex = 8
        Me.lblWarn2.Visible = False
        '
        'lblWarn1
        '
        Me.lblWarn1.Image = Global.VijaySridhara.Applications.My.Resources.Resources.excl
        Me.lblWarn1.Location = New System.Drawing.Point(84, 246)
        Me.lblWarn1.Name = "lblWarn1"
        Me.lblWarn1.Size = New System.Drawing.Size(18, 22)
        Me.lblWarn1.TabIndex = 5
        Me.lblWarn1.Visible = False
        '
        'butUpdateComments
        '
        Me.butUpdateComments.Enabled = False
        Me.butUpdateComments.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butUpdateComments.Location = New System.Drawing.Point(4, 441)
        Me.butUpdateComments.Name = "butUpdateComments"
        Me.butUpdateComments.Size = New System.Drawing.Size(75, 26)
        Me.butUpdateComments.TabIndex = 7
        Me.butUpdateComments.Text = "Update"
        Me.butUpdateComments.UseVisualStyleBackColor = True
        '
        'butSearch
        '
        Me.butSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butSearch.Image = Global.VijaySridhara.Applications.My.Resources.Resources.search
        Me.butSearch.Location = New System.Drawing.Point(193, 16)
        Me.butSearch.Name = "butSearch"
        Me.butSearch.Size = New System.Drawing.Size(24, 26)
        Me.butSearch.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.butSearch, "Search within the archive")
        Me.butSearch.UseVisualStyleBackColor = True
        '
        'butUpdateTags
        '
        Me.butUpdateTags.Enabled = False
        Me.butUpdateTags.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butUpdateTags.Location = New System.Drawing.Point(3, 241)
        Me.butUpdateTags.Name = "butUpdateTags"
        Me.butUpdateTags.Size = New System.Drawing.Size(75, 26)
        Me.butUpdateTags.TabIndex = 4
        Me.butUpdateTags.Text = "Update"
        Me.butUpdateTags.UseVisualStyleBackColor = True
        '
        'txtExif
        '
        Me.txtExif.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExif.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txtExif.Enabled = False
        Me.txtExif.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtExif.Location = New System.Drawing.Point(4, 494)
        Me.txtExif.Multiline = True
        Me.txtExif.Name = "txtExif"
        Me.txtExif.ReadOnly = True
        Me.txtExif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExif.Size = New System.Drawing.Size(211, 78)
        Me.txtExif.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 474)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "&Meta data"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txtComments.Enabled = False
        Me.txtComments.Location = New System.Drawing.Point(4, 292)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(211, 141)
        Me.txtComments.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 272)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Co&mments"
        '
        'txtTags
        '
        Me.txtTags.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTags.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txtTags.Enabled = False
        Me.txtTags.Location = New System.Drawing.Point(4, 77)
        Me.txtTags.Multiline = True
        Me.txtTags.Name = "txtTags"
        Me.txtTags.Size = New System.Drawing.Size(211, 157)
        Me.txtTags.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&Tags"
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter2.Location = New System.Drawing.Point(969, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(4, 589)
        Me.Splitter2.TabIndex = 7
        Me.Splitter2.TabStop = False
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pnlTop.Controls.Add(Me.chkPrivate)
        Me.pnlTop.Controls.Add(Me.Label4)
        Me.pnlTop.Controls.Add(Me.cboArchives)
        Me.pnlTop.Controls.Add(Me.butExport)
        Me.pnlTop.Controls.Add(Me.butCopyFilelink)
        Me.pnlTop.Controls.Add(Me.butImportImages)
        Me.pnlTop.Controls.Add(Me.txtFile)
        Me.pnlTop.Controls.Add(Me.butAbout)
        Me.pnlTop.Controls.Add(Me.butSettings)
        Me.pnlTop.Controls.Add(Me.butImport)
        Me.pnlTop.Controls.Add(Me.ProgressBar1)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(207, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(762, 64)
        Me.pnlTop.TabIndex = 1
        '
        'chkPrivate
        '
        Me.chkPrivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPrivate.AutoSize = True
        Me.chkPrivate.Location = New System.Drawing.Point(632, 5)
        Me.chkPrivate.Name = "chkPrivate"
        Me.chkPrivate.Size = New System.Drawing.Size(130, 21)
        Me.chkPrivate.TabIndex = 9
        Me.chkPrivate.Text = "Show private also"
        Me.ToolTip1.SetToolTip(Me.chkPrivate, "List private archives")
        Me.chkPrivate.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(539, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Select archive"
        '
        'cboArchives
        '
        Me.cboArchives.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboArchives.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.cboArchives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArchives.FormattingEnabled = True
        Me.cboArchives.Location = New System.Drawing.Point(542, 31)
        Me.cboArchives.Name = "cboArchives"
        Me.cboArchives.Size = New System.Drawing.Size(214, 25)
        Me.cboArchives.TabIndex = 8
        '
        'butCopyFilelink
        '
        Me.butCopyFilelink.BackgroundImage = Global.VijaySridhara.Applications.My.Resources.Resources.copy
        Me.butCopyFilelink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.butCopyFilelink.Enabled = False
        Me.butCopyFilelink.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butCopyFilelink.Location = New System.Drawing.Point(506, 41)
        Me.butCopyFilelink.Name = "butCopyFilelink"
        Me.butCopyFilelink.Size = New System.Drawing.Size(18, 20)
        Me.butCopyFilelink.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.butCopyFilelink, "Copy file path")
        Me.butCopyFilelink.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFile.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtFile.Location = New System.Drawing.Point(222, 43)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ReadOnly = True
        Me.txtFile.Size = New System.Drawing.Size(278, 15)
        Me.txtFile.TabIndex = 4
        '
        'butAbout
        '
        Me.butAbout.BackgroundImage = Global.VijaySridhara.Applications.My.Resources.Resources.about
        Me.butAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.butAbout.FlatAppearance.BorderSize = 0
        Me.butAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butAbout.Location = New System.Drawing.Point(184, 5)
        Me.butAbout.Name = "butAbout"
        Me.butAbout.Size = New System.Drawing.Size(32, 32)
        Me.butAbout.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.butAbout, "About Image librarian")
        Me.butAbout.UseVisualStyleBackColor = True
        '
        'butSettings
        '
        Me.butSettings.BackgroundImage = Global.VijaySridhara.Applications.My.Resources.Resources.settings
        Me.butSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.butSettings.FlatAppearance.BorderSize = 0
        Me.butSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSettings.Location = New System.Drawing.Point(146, 5)
        Me.butSettings.Name = "butSettings"
        Me.butSettings.Size = New System.Drawing.Size(32, 32)
        Me.butSettings.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.butSettings, "Show settings")
        Me.butSettings.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 43)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(210, 17)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 6
        Me.ProgressBar1.Visible = False
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtLog.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtLog.Location = New System.Drawing.Point(207, 471)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(762, 118)
        Me.txtLog.TabIndex = 2
        '
        'Splitter3
        '
        Me.Splitter3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter3.Location = New System.Drawing.Point(207, 468)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(762, 3)
        Me.Splitter3.TabIndex = 1
        Me.Splitter3.TabStop = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1193, 589)
        Me.Controls.Add(Me.pnlThumbnails)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.Splitter3)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.plRight)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.pnlLEft)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Librarian"
        Me.pnlThumbnails.ResumeLayout(False)
        Me.pnlLEft.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.plRight.ResumeLayout(False)
        Me.plRight.PerformLayout()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ThumbnailContainer1 As ThumbnailContainer
    Friend WithEvents pnlThumbnails As Panel
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
End Class
