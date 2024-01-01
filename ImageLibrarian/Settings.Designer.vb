<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
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
        Label1 = New Label()
        txtLocation = New TextBox()
        butBrowse = New Button()
        ListView1 = New ListView()
        colHArchName = New ColumnHeader()
        colHIsPrivate = New ColumnHeader()
        butAdd = New Button()
        txtArchName = New TextBox()
        butModify = New Button()
        butDelete = New Button()
        chkPrivate = New CheckBox()
        butCancel = New Button()
        butOK = New Button()
        Label2 = New Label()
        txtimgEditor1 = New TextBox()
        butImgEditor1 = New Button()
        Label3 = New Label()
        txtImageEditor2 = New TextBox()
        butImageEditor2 = New Button()
        Label4 = New Label()
        txtImageEditor3 = New TextBox()
        butImageEditor3 = New Button()
        Label5 = New Label()
        txtWorkfolder = New TextBox()
        butBrowseWorkFolder = New Button()
        chkOtherDrives = New CheckBox()
        Label6 = New Label()
        txtIgnoreFolders = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(106, 17)
        Label1.TabIndex = 0
        Label1.Text = "Archives location"
        ' 
        ' txtLocation
        ' 
        txtLocation.Location = New Point(124, 22)
        txtLocation.Name = "txtLocation"
        txtLocation.ReadOnly = True
        txtLocation.Size = New Size(299, 25)
        txtLocation.TabIndex = 1
        ' 
        ' butBrowse
        ' 
        butBrowse.Location = New Point(429, 23)
        butBrowse.Name = "butBrowse"
        butBrowse.Size = New Size(28, 26)
        butBrowse.TabIndex = 2
        butBrowse.Text = "..."
        butBrowse.UseVisualStyleBackColor = True
        ' 
        ' ListView1
        ' 
        ListView1.Columns.AddRange(New ColumnHeader() {colHArchName, colHIsPrivate})
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.HideSelection = True
        ListView1.Location = New Point(12, 54)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(270, 174)
        ListView1.TabIndex = 3
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' colHArchName
        ' 
        colHArchName.Text = "Archive name"
        colHArchName.Width = 200
        ' 
        ' colHIsPrivate
        ' 
        colHIsPrivate.Text = "Private"
        ' 
        ' butAdd
        ' 
        butAdd.Location = New Point(380, 87)
        butAdd.Name = "butAdd"
        butAdd.Size = New Size(77, 36)
        butAdd.TabIndex = 6
        butAdd.Text = "&Add"
        butAdd.UseVisualStyleBackColor = True
        ' 
        ' txtArchName
        ' 
        txtArchName.Location = New Point(284, 56)
        txtArchName.Name = "txtArchName"
        txtArchName.Size = New Size(173, 25)
        txtArchName.TabIndex = 4
        ' 
        ' butModify
        ' 
        butModify.Location = New Point(284, 131)
        butModify.Name = "butModify"
        butModify.Size = New Size(77, 36)
        butModify.TabIndex = 7
        butModify.Text = "&Modify"
        butModify.UseVisualStyleBackColor = True
        ' 
        ' butDelete
        ' 
        butDelete.Location = New Point(380, 131)
        butDelete.Name = "butDelete"
        butDelete.Size = New Size(77, 36)
        butDelete.TabIndex = 8
        butDelete.Text = "&Delete"
        butDelete.UseVisualStyleBackColor = True
        ' 
        ' chkPrivate
        ' 
        chkPrivate.AutoSize = True
        chkPrivate.Location = New Point(288, 94)
        chkPrivate.Name = "chkPrivate"
        chkPrivate.Size = New Size(66, 21)
        chkPrivate.TabIndex = 5
        chkPrivate.Text = "Private"
        chkPrivate.UseVisualStyleBackColor = True
        ' 
        ' butCancel
        ' 
        butCancel.Location = New Point(380, 445)
        butCancel.Name = "butCancel"
        butCancel.Size = New Size(77, 35)
        butCancel.TabIndex = 25
        butCancel.Text = "&Cancel"
        butCancel.UseVisualStyleBackColor = True
        ' 
        ' butOK
        ' 
        butOK.Location = New Point(288, 445)
        butOK.Name = "butOK"
        butOK.Size = New Size(77, 35)
        butOK.TabIndex = 24
        butOK.Text = "O&K"
        butOK.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(11, 322)
        Label2.Name = "Label2"
        Label2.Size = New Size(90, 17)
        Label2.TabIndex = 12
        Label2.Text = "Image editor1"
        ' 
        ' txtimgEditor1
        ' 
        txtimgEditor1.Location = New Point(115, 318)
        txtimgEditor1.Name = "txtimgEditor1"
        txtimgEditor1.ReadOnly = True
        txtimgEditor1.Size = New Size(308, 25)
        txtimgEditor1.TabIndex = 13
        ' 
        ' butImgEditor1
        ' 
        butImgEditor1.Location = New Point(429, 318)
        butImgEditor1.Name = "butImgEditor1"
        butImgEditor1.Size = New Size(28, 26)
        butImgEditor1.TabIndex = 14
        butImgEditor1.Text = "..."
        butImgEditor1.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(11, 354)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 17)
        Label3.TabIndex = 15
        Label3.Text = "Image editor2"
        ' 
        ' txtImageEditor2
        ' 
        txtImageEditor2.Location = New Point(115, 351)
        txtImageEditor2.Name = "txtImageEditor2"
        txtImageEditor2.ReadOnly = True
        txtImageEditor2.Size = New Size(308, 25)
        txtImageEditor2.TabIndex = 16
        ' 
        ' butImageEditor2
        ' 
        butImageEditor2.Location = New Point(429, 351)
        butImageEditor2.Name = "butImageEditor2"
        butImageEditor2.Size = New Size(28, 26)
        butImageEditor2.TabIndex = 17
        butImageEditor2.Text = "..."
        butImageEditor2.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(11, 387)
        Label4.Name = "Label4"
        Label4.Size = New Size(90, 17)
        Label4.TabIndex = 18
        Label4.Text = "Image editor3"
        ' 
        ' txtImageEditor3
        ' 
        txtImageEditor3.Location = New Point(115, 384)
        txtImageEditor3.Name = "txtImageEditor3"
        txtImageEditor3.ReadOnly = True
        txtImageEditor3.Size = New Size(308, 25)
        txtImageEditor3.TabIndex = 19
        ' 
        ' butImageEditor3
        ' 
        butImageEditor3.Location = New Point(429, 384)
        butImageEditor3.Name = "butImageEditor3"
        butImageEditor3.Size = New Size(28, 26)
        butImageEditor3.TabIndex = 20
        butImageEditor3.Text = "..."
        butImageEditor3.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(11, 417)
        Label5.Name = "Label5"
        Label5.Size = New Size(77, 17)
        Label5.TabIndex = 21
        Label5.Text = "Work folder"
        ' 
        ' txtWorkfolder
        ' 
        txtWorkfolder.Location = New Point(115, 414)
        txtWorkfolder.Name = "txtWorkfolder"
        txtWorkfolder.ReadOnly = True
        txtWorkfolder.Size = New Size(308, 25)
        txtWorkfolder.TabIndex = 22
        ' 
        ' butBrowseWorkFolder
        ' 
        butBrowseWorkFolder.Location = New Point(429, 414)
        butBrowseWorkFolder.Name = "butBrowseWorkFolder"
        butBrowseWorkFolder.Size = New Size(28, 26)
        butBrowseWorkFolder.TabIndex = 23
        butBrowseWorkFolder.Text = "..."
        butBrowseWorkFolder.UseVisualStyleBackColor = True
        ' 
        ' chkOtherDrives
        ' 
        chkOtherDrives.Location = New Point(288, 196)
        chkOtherDrives.Name = "chkOtherDrives"
        chkOtherDrives.Size = New Size(169, 46)
        chkOtherDrives.TabIndex = 9
        chkOtherDrives.Text = "Check other drives for a missing file"
        chkOtherDrives.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 231)
        Label6.Name = "Label6"
        Label6.Size = New Size(91, 17)
        Label6.TabIndex = 10
        Label6.Text = "&Ignore folders"
        ' 
        ' txtIgnoreFolders
        ' 
        txtIgnoreFolders.Location = New Point(12, 251)
        txtIgnoreFolders.Multiline = True
        txtIgnoreFolders.Name = "txtIgnoreFolders"
        txtIgnoreFolders.Size = New Size(445, 61)
        txtIgnoreFolders.TabIndex = 11
        ' 
        ' Settings
        ' 
        AcceptButton = butOK
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = butCancel
        ClientSize = New Size(469, 509)
        Controls.Add(txtIgnoreFolders)
        Controls.Add(butCancel)
        Controls.Add(butOK)
        Controls.Add(chkOtherDrives)
        Controls.Add(chkPrivate)
        Controls.Add(butDelete)
        Controls.Add(butModify)
        Controls.Add(butAdd)
        Controls.Add(ListView1)
        Controls.Add(butBrowseWorkFolder)
        Controls.Add(butImageEditor3)
        Controls.Add(butImageEditor2)
        Controls.Add(butImgEditor1)
        Controls.Add(butBrowse)
        Controls.Add(txtArchName)
        Controls.Add(txtWorkfolder)
        Controls.Add(Label5)
        Controls.Add(txtImageEditor3)
        Controls.Add(Label4)
        Controls.Add(txtImageEditor2)
        Controls.Add(Label3)
        Controls.Add(txtimgEditor1)
        Controls.Add(Label2)
        Controls.Add(txtLocation)
        Controls.Add(Label6)
        Controls.Add(Label1)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Settings"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents butBrowse As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents colHArchName As ColumnHeader
    Friend WithEvents colHIsPrivate As ColumnHeader
    Friend WithEvents butAdd As Button
    Friend WithEvents txtArchName As TextBox
    Friend WithEvents butModify As Button
    Friend WithEvents butDelete As Button
    Friend WithEvents chkPrivate As CheckBox
    Friend WithEvents butCancel As Button
    Friend WithEvents butOK As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtimgEditor1 As TextBox
    Friend WithEvents butImgEditor1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtImageEditor2 As TextBox
    Friend WithEvents butImageEditor2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtImageEditor3 As TextBox
    Friend WithEvents butImageEditor3 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtWorkfolder As TextBox
    Friend WithEvents butBrowseWorkFolder As Button
    Friend WithEvents chkOtherDrives As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtIgnoreFolders As TextBox
End Class
