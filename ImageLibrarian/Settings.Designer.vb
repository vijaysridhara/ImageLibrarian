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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.butBrowse = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.colHArchName = New System.Windows.Forms.ColumnHeader()
        Me.colHIsPrivate = New System.Windows.Forms.ColumnHeader()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.txtArchName = New System.Windows.Forms.TextBox()
        Me.butModify = New System.Windows.Forms.Button()
        Me.butDelete = New System.Windows.Forms.Button()
        Me.chkPrivate = New System.Windows.Forms.CheckBox()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtimgEditor1 = New System.Windows.Forms.TextBox()
        Me.butImgEditor1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImageEditor2 = New System.Windows.Forms.TextBox()
        Me.butImageEditor2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtImageEditor3 = New System.Windows.Forms.TextBox()
        Me.butImageEditor3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtWorkfolder = New System.Windows.Forms.TextBox()
        Me.butBrowseWorkFolder = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Archives location"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(124, 22)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(299, 25)
        Me.txtLocation.TabIndex = 1
        '
        'butBrowse
        '
        Me.butBrowse.Location = New System.Drawing.Point(429, 23)
        Me.butBrowse.Name = "butBrowse"
        Me.butBrowse.Size = New System.Drawing.Size(28, 26)
        Me.butBrowse.TabIndex = 2
        Me.butBrowse.Text = "..."
        Me.butBrowse.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHArchName, Me.colHIsPrivate})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = True
        Me.ListView1.Location = New System.Drawing.Point(12, 54)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(270, 174)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'colHArchName
        '
        Me.colHArchName.Text = "Archive name"
        Me.colHArchName.Width = 200
        '
        'colHIsPrivate
        '
        Me.colHIsPrivate.Text = "Private"
        '
        'butAdd
        '
        Me.butAdd.Location = New System.Drawing.Point(380, 87)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(77, 36)
        Me.butAdd.TabIndex = 6
        Me.butAdd.Text = "&Add"
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'txtArchName
        '
        Me.txtArchName.Location = New System.Drawing.Point(284, 56)
        Me.txtArchName.Name = "txtArchName"
        Me.txtArchName.Size = New System.Drawing.Size(173, 25)
        Me.txtArchName.TabIndex = 4
        '
        'butModify
        '
        Me.butModify.Location = New System.Drawing.Point(284, 131)
        Me.butModify.Name = "butModify"
        Me.butModify.Size = New System.Drawing.Size(77, 36)
        Me.butModify.TabIndex = 7
        Me.butModify.Text = "&Modify"
        Me.butModify.UseVisualStyleBackColor = True
        '
        'butDelete
        '
        Me.butDelete.Location = New System.Drawing.Point(380, 131)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(77, 36)
        Me.butDelete.TabIndex = 8
        Me.butDelete.Text = "&Delete"
        Me.butDelete.UseVisualStyleBackColor = True
        '
        'chkPrivate
        '
        Me.chkPrivate.AutoSize = True
        Me.chkPrivate.Location = New System.Drawing.Point(288, 94)
        Me.chkPrivate.Name = "chkPrivate"
        Me.chkPrivate.Size = New System.Drawing.Size(66, 21)
        Me.chkPrivate.TabIndex = 5
        Me.chkPrivate.Text = "Private"
        Me.chkPrivate.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Location = New System.Drawing.Point(380, 375)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(77, 35)
        Me.butCancel.TabIndex = 22
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(288, 375)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(77, 35)
        Me.butOK.TabIndex = 21
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 252)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Image editor1"
        '
        'txtimgEditor1
        '
        Me.txtimgEditor1.Location = New System.Drawing.Point(115, 248)
        Me.txtimgEditor1.Name = "txtimgEditor1"
        Me.txtimgEditor1.ReadOnly = True
        Me.txtimgEditor1.Size = New System.Drawing.Size(308, 25)
        Me.txtimgEditor1.TabIndex = 10
        '
        'butImgEditor1
        '
        Me.butImgEditor1.Location = New System.Drawing.Point(429, 248)
        Me.butImgEditor1.Name = "butImgEditor1"
        Me.butImgEditor1.Size = New System.Drawing.Size(28, 26)
        Me.butImgEditor1.TabIndex = 11
        Me.butImgEditor1.Text = "..."
        Me.butImgEditor1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Image editor2"
        '
        'txtImageEditor2
        '
        Me.txtImageEditor2.Location = New System.Drawing.Point(115, 281)
        Me.txtImageEditor2.Name = "txtImageEditor2"
        Me.txtImageEditor2.ReadOnly = True
        Me.txtImageEditor2.Size = New System.Drawing.Size(308, 25)
        Me.txtImageEditor2.TabIndex = 13
        '
        'butImageEditor2
        '
        Me.butImageEditor2.Location = New System.Drawing.Point(429, 281)
        Me.butImageEditor2.Name = "butImageEditor2"
        Me.butImageEditor2.Size = New System.Drawing.Size(28, 26)
        Me.butImageEditor2.TabIndex = 14
        Me.butImageEditor2.Text = "..."
        Me.butImageEditor2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 317)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Image editor3"
        '
        'txtImageEditor3
        '
        Me.txtImageEditor3.Location = New System.Drawing.Point(115, 314)
        Me.txtImageEditor3.Name = "txtImageEditor3"
        Me.txtImageEditor3.ReadOnly = True
        Me.txtImageEditor3.Size = New System.Drawing.Size(308, 25)
        Me.txtImageEditor3.TabIndex = 16
        '
        'butImageEditor3
        '
        Me.butImageEditor3.Location = New System.Drawing.Point(429, 314)
        Me.butImageEditor3.Name = "butImageEditor3"
        Me.butImageEditor3.Size = New System.Drawing.Size(28, 26)
        Me.butImageEditor3.TabIndex = 17
        Me.butImageEditor3.Text = "..."
        Me.butImageEditor3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 347)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Work folder"
        '
        'txtWorkfolder
        '
        Me.txtWorkfolder.Location = New System.Drawing.Point(115, 344)
        Me.txtWorkfolder.Name = "txtWorkfolder"
        Me.txtWorkfolder.ReadOnly = True
        Me.txtWorkfolder.Size = New System.Drawing.Size(308, 25)
        Me.txtWorkfolder.TabIndex = 19
        '
        'butBrowseWorkFolder
        '
        Me.butBrowseWorkFolder.Location = New System.Drawing.Point(429, 344)
        Me.butBrowseWorkFolder.Name = "butBrowseWorkFolder"
        Me.butBrowseWorkFolder.Size = New System.Drawing.Size(28, 26)
        Me.butBrowseWorkFolder.TabIndex = 20
        Me.butBrowseWorkFolder.Text = "..."
        Me.butBrowseWorkFolder.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(469, 410)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.chkPrivate)
        Me.Controls.Add(Me.butDelete)
        Me.Controls.Add(Me.butModify)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.butBrowseWorkFolder)
        Me.Controls.Add(Me.butImageEditor3)
        Me.Controls.Add(Me.butImageEditor2)
        Me.Controls.Add(Me.butImgEditor1)
        Me.Controls.Add(Me.butBrowse)
        Me.Controls.Add(Me.txtArchName)
        Me.Controls.Add(Me.txtWorkfolder)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtImageEditor3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtImageEditor2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtimgEditor1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Settings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
End Class
