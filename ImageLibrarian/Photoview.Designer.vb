<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Photoview
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
        ToolStrip1 = New ToolStrip()
        tlstpOpen = New ToolStripButton()
        tlstpSave = New ToolStripButton()
        tlstpSaveas = New ToolStripButton()
        tlstpCopyImage = New ToolStripButton()
        tlstpClose = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        tlstpUndo = New ToolStripButton()
        tlstpRedo = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        tlstpResizeimage = New ToolStripButton()
        tlstpCrop = New ToolStripButton()
        tlstpConfirmCrop = New ToolStripButton()
        tlstpFlipHorizontal = New ToolStripButton()
        tlstpFlipVertical = New ToolStripButton()
        tlstpRotateimage = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        ToolStripLabel1 = New ToolStripLabel()
        tlstpZoom = New ToolStripComboBox()
        tlstpFitToscreen = New ToolStripButton()
        ToolStripSeparator4 = New ToolStripSeparator()
        tlstpResetImage = New ToolStripButton()
        pnlPhotoContainerr = New Panel()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.ImageScalingSize = New Size(24, 24)
        ToolStrip1.Items.AddRange(New ToolStripItem() {tlstpOpen, tlstpSave, tlstpSaveas, tlstpCopyImage, tlstpClose, ToolStripSeparator1, tlstpUndo, tlstpRedo, ToolStripSeparator2, tlstpResizeimage, tlstpCrop, tlstpConfirmCrop, tlstpFlipHorizontal, tlstpFlipVertical, tlstpRotateimage, ToolStripSeparator3, ToolStripLabel1, tlstpZoom, tlstpFitToscreen, ToolStripSeparator4, tlstpResetImage})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1006, 31)
        ToolStrip1.TabIndex = 0
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' tlstpOpen
        ' 
        tlstpOpen.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpOpen.Image = My.Resources.Resources.open
        tlstpOpen.ImageTransparentColor = Color.Magenta
        tlstpOpen.Name = "tlstpOpen"
        tlstpOpen.Size = New Size(28, 28)
        tlstpOpen.Text = "Open image"
        ' 
        ' tlstpSave
        ' 
        tlstpSave.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpSave.Enabled = False
        tlstpSave.Image = My.Resources.Resources.save
        tlstpSave.ImageTransparentColor = Color.Magenta
        tlstpSave.Name = "tlstpSave"
        tlstpSave.Size = New Size(28, 28)
        tlstpSave.Text = "Save to original location"
        ' 
        ' tlstpSaveas
        ' 
        tlstpSaveas.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpSaveas.Enabled = False
        tlstpSaveas.Image = My.Resources.Resources.saveas
        tlstpSaveas.ImageTransparentColor = Color.Magenta
        tlstpSaveas.Name = "tlstpSaveas"
        tlstpSaveas.Size = New Size(28, 28)
        tlstpSaveas.Text = "Save image as"
        ' 
        ' tlstpCopyImage
        ' 
        tlstpCopyImage.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpCopyImage.Enabled = False
        tlstpCopyImage.Image = My.Resources.Resources.copyimage
        tlstpCopyImage.ImageTransparentColor = Color.Magenta
        tlstpCopyImage.Name = "tlstpCopyImage"
        tlstpCopyImage.Size = New Size(28, 28)
        tlstpCopyImage.Text = "Copy image to clipboard"
        ' 
        ' tlstpClose
        ' 
        tlstpClose.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpClose.Enabled = False
        tlstpClose.Image = My.Resources.Resources.close
        tlstpClose.ImageTransparentColor = Color.Magenta
        tlstpClose.Name = "tlstpClose"
        tlstpClose.Size = New Size(28, 28)
        tlstpClose.Text = "Close image"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 31)
        ' 
        ' tlstpUndo
        ' 
        tlstpUndo.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpUndo.Enabled = False
        tlstpUndo.Image = My.Resources.Resources.undo
        tlstpUndo.ImageTransparentColor = Color.Magenta
        tlstpUndo.Name = "tlstpUndo"
        tlstpUndo.Size = New Size(28, 28)
        tlstpUndo.Text = "ToolStripButton3"
        ' 
        ' tlstpRedo
        ' 
        tlstpRedo.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpRedo.Enabled = False
        tlstpRedo.Image = My.Resources.Resources.redo
        tlstpRedo.ImageTransparentColor = Color.Magenta
        tlstpRedo.Name = "tlstpRedo"
        tlstpRedo.Size = New Size(28, 28)
        tlstpRedo.Text = "Redo"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 31)
        ' 
        ' tlstpResizeimage
        ' 
        tlstpResizeimage.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpResizeimage.Enabled = False
        tlstpResizeimage.Image = My.Resources.Resources.resize
        tlstpResizeimage.ImageTransparentColor = Color.Magenta
        tlstpResizeimage.Name = "tlstpResizeimage"
        tlstpResizeimage.Size = New Size(28, 28)
        tlstpResizeimage.Text = "Resize image"
        ' 
        ' tlstpCrop
        ' 
        tlstpCrop.CheckOnClick = True
        tlstpCrop.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpCrop.Enabled = False
        tlstpCrop.Image = My.Resources.Resources.crop
        tlstpCrop.ImageTransparentColor = Color.Magenta
        tlstpCrop.Name = "tlstpCrop"
        tlstpCrop.Size = New Size(28, 28)
        tlstpCrop.Text = "Crop image"
        ' 
        ' tlstpConfirmCrop
        ' 
        tlstpConfirmCrop.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpConfirmCrop.Enabled = False
        tlstpConfirmCrop.Image = My.Resources.Resources.tick1
        tlstpConfirmCrop.ImageTransparentColor = Color.Magenta
        tlstpConfirmCrop.Name = "tlstpConfirmCrop"
        tlstpConfirmCrop.Size = New Size(28, 28)
        tlstpConfirmCrop.Text = "Confirm crop"
        ' 
        ' tlstpFlipHorizontal
        ' 
        tlstpFlipHorizontal.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpFlipHorizontal.Enabled = False
        tlstpFlipHorizontal.Image = My.Resources.Resources.fliphorizontal
        tlstpFlipHorizontal.ImageTransparentColor = Color.Magenta
        tlstpFlipHorizontal.Name = "tlstpFlipHorizontal"
        tlstpFlipHorizontal.Size = New Size(28, 28)
        tlstpFlipHorizontal.Text = "Flip horizontal"
        ' 
        ' tlstpFlipVertical
        ' 
        tlstpFlipVertical.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpFlipVertical.Enabled = False
        tlstpFlipVertical.Image = My.Resources.Resources.flipvertical
        tlstpFlipVertical.ImageTransparentColor = Color.Magenta
        tlstpFlipVertical.Name = "tlstpFlipVertical"
        tlstpFlipVertical.Size = New Size(28, 28)
        tlstpFlipVertical.Text = "Flip vertical"
        ' 
        ' tlstpRotateimage
        ' 
        tlstpRotateimage.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpRotateimage.Enabled = False
        tlstpRotateimage.Image = My.Resources.Resources.rotate_clock
        tlstpRotateimage.ImageTransparentColor = Color.Magenta
        tlstpRotateimage.Name = "tlstpRotateimage"
        tlstpRotateimage.Size = New Size(28, 28)
        tlstpRotateimage.Text = "Rotate image by 90 degrees"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 31)
        ' 
        ' ToolStripLabel1
        ' 
        ToolStripLabel1.Name = "ToolStripLabel1"
        ToolStripLabel1.Size = New Size(66, 28)
        ToolStripLabel1.Text = "Zoom level"
        ' 
        ' tlstpZoom
        ' 
        tlstpZoom.Enabled = False
        tlstpZoom.Name = "tlstpZoom"
        tlstpZoom.Size = New Size(75, 31)
        tlstpZoom.Text = "100"
        ' 
        ' tlstpFitToscreen
        ' 
        tlstpFitToscreen.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpFitToscreen.Enabled = False
        tlstpFitToscreen.Image = My.Resources.Resources.fittoscreen
        tlstpFitToscreen.ImageTransparentColor = Color.Magenta
        tlstpFitToscreen.Name = "tlstpFitToscreen"
        tlstpFitToscreen.Size = New Size(28, 28)
        tlstpFitToscreen.Text = "Fit to screen"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 31)
        ' 
        ' tlstpResetImage
        ' 
        tlstpResetImage.DisplayStyle = ToolStripItemDisplayStyle.Image
        tlstpResetImage.Enabled = False
        tlstpResetImage.Image = My.Resources.Resources.refresh
        tlstpResetImage.ImageTransparentColor = Color.Magenta
        tlstpResetImage.Name = "tlstpResetImage"
        tlstpResetImage.Size = New Size(28, 28)
        tlstpResetImage.Text = "Reset image to original"
        ' 
        ' pnlPhotoContainerr
        ' 
        pnlPhotoContainerr.AutoScroll = True
        pnlPhotoContainerr.Dock = DockStyle.Fill
        pnlPhotoContainerr.Location = New Point(0, 31)
        pnlPhotoContainerr.Name = "pnlPhotoContainerr"
        pnlPhotoContainerr.Size = New Size(1006, 585)
        pnlPhotoContainerr.TabIndex = 2
        ' 
        ' Photoview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDarkDark
        ClientSize = New Size(1006, 616)
        Controls.Add(pnlPhotoContainerr)
        Controls.Add(ToolStrip1)
        KeyPreview = True
        Name = "Photoview"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Photoview"
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tlstpOpen As ToolStripButton
    Friend WithEvents tlstpClose As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tlstpUndo As ToolStripButton
    Friend WithEvents tlstpRedo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tlstpCrop As ToolStripButton
    Friend WithEvents tlstpConfirmCrop As ToolStripButton
    Friend WithEvents tlstpRotateimage As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tlstpZoom As ToolStripComboBox
    Friend WithEvents tlstpResetImage As ToolStripButton
    Friend WithEvents tlstpFlipHorizontal As ToolStripButton
    Friend WithEvents tlstpFlipVertical As ToolStripButton
    Friend WithEvents tlstpFitToscreen As ToolStripButton
    Friend WithEvents tlstpSave As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tlstpSaveas As ToolStripButton
    Friend WithEvents tlstpCopyImage As ToolStripButton
    Friend WithEvents tlstpResizeimage As ToolStripButton
    Friend WithEvents pnlPhotoContainerr As Panel
End Class
