'***********************************************************************
'Copyright 2022 Vijay Sridhara

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at

'http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'***********************************************************************
Imports System.ComponentModel

Public Class Photoview
    Private ph As Photo
    Dim dirty As Boolean
    Dim currentFile As String = ""
    Public CoreImageChanged As Boolean
    Private initFile As Boolean
    Public Sub LoadFile(FNAME As String)

        currentFile = FNAME
        ph = New Photo(FNAME)
        pnlPhotoContainerr.Controls.Add(ph)
        AddHandler ph.Cropevent, AddressOf PhotoCropFired
        AddHandler ph.Resize, AddressOf PhotoResized
        AddHandler ph.FitZoom, AddressOf PhotoFitZoom
        PhotoResized(Nothing, Nothing)
        enableDisable(True)
        tlstpFitToscreen_Click(Nothing, Nothing)
    End Sub
    Private Sub PhotoFitZoom(pc As Integer)
        tlstpZoom.Text = pc
    End Sub

    Public Sub New(fname As String)
        initFile = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        currentFile = fname
        LoadFile(fname)
    End Sub
    Private Sub PhotoResized(sender As Object, e As EventArgs)
        pnlPhotoContainerr_Resize(Nothing, Nothing)
    End Sub
    Private Sub PhotoCropFired(drawn As Boolean)

        tlstpConfirmCrop.Enabled = drawn

    End Sub
    Private Sub pnlPhotoContainerr_Resize(sender As Object, e As EventArgs) Handles pnlPhotoContainerr.Resize
        If pnlPhotoContainerr.Controls.Count = 0 Then Exit Sub
        Dim ph As Control = pnlPhotoContainerr.Controls(0)
        ph.Location = New Point(0, 0)
        If pnlPhotoContainerr.Width > ph.Width Then
            ph.Left = pnlPhotoContainerr.Width / 2 - ph.Width / 2

        End If
        If pnlPhotoContainerr.Height > ph.Height Then
            ph.Top = pnlPhotoContainerr.Height / 2 - ph.Height / 2
        End If
    End Sub

    Private Sub pnlPhotoContainerr_ControlAdded(sender As Object, e As ControlEventArgs) Handles pnlPhotoContainerr.ControlAdded

    End Sub




    Private Sub tlstpConfirmCrop_Click(sender As Object, e As EventArgs) Handles tlstpConfirmCrop.Click
        ph.ConfirmCrop()
        tlstpConfirmCrop.Enabled = False
    End Sub

    Private Sub tlstpCrop_CheckedChanged(sender As Object, e As EventArgs) Handles tlstpCrop.CheckedChanged
        If ph Is Nothing Then Exit Sub
        ph.EnableCrop = tlstpCrop.Checked
    End Sub

    Private Sub tlstpClose_Click(sender As Object, e As EventArgs) Handles tlstpClose.Click
        RemovePhoto()
    End Sub
    Private Function RemovePhoto() As Boolean
        If dirty Then
            If MsgBox("The photo is modified, do you want to save it?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then Return False
            RemoveHandler ph.Cropevent, AddressOf PhotoCropFired
            RemoveHandler ph.Resize, AddressOf PhotoResized
            RemoveHandler ph.FitZoom, AddressOf PhotoFitZoom

            pnlPhotoContainerr.Controls.Clear()
            ph.Dispose()
            If initFile Then initFile = False

            enableDisable(False)
            Return True
        Else
            If ph Is Nothing Then Return True
            RemoveHandler ph.Cropevent, AddressOf PhotoCropFired
            RemoveHandler ph.Resize, AddressOf PhotoResized
             RemoveHandler ph.FitZoom , AddressOf PhotoFitZoom 
            pnlPhotoContainerr.Controls.Clear()
            ph.Dispose()
            If initFile Then initFile = False

            enableDisable(False)
            Return True
        End If
    End Function
    Private Sub enableDisable(enable As Boolean)

        tlstpCrop.Enabled = enable
        If enable = False Then
            tlstpConfirmCrop.Enabled = enable
            tlstpSave.Enabled = enable
            tlstpCrop.Checked = False
        End If
        tlstpFlipHorizontal.Enabled = enable
        tlstpFlipVertical.Enabled = enable
        'tlstpUndo.Enabled = enable
        'tlstpRedo.Enabled = enable
        tlstpClose.Enabled = enable
        tlstpResetImage.Enabled = enable
        tlstpZoom.Enabled = enable
        tlstpSave.Enabled = enable
        tlstpRotateimage.Enabled = enable
        tlstpFitToscreen.Enabled = enable
        tlstpSaveas.Enabled = enable
        tlstpCopyImage.Enabled = enable
        tlstpResizeimage.Enabled = enable
    End Sub

    Private Sub tlstpOpen_Click(sender As Object, e As EventArgs) Handles tlstpOpen.Click
        If RemovePhoto() Then
            Dim fd As New OpenFileDialog
            With fd
                .Filter = "JPEG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif"
                .FilterIndex = 0
                .Multiselect = True
                If .ShowDialog = DialogResult.OK Then
                    currentFile = .FileName
                    LoadFile(currentFile)
                End If
            End With
        End If
    End Sub

    Private Sub tlstpSave_Click(sender As Object, e As EventArgs) Handles tlstpSave.Click
        Try
            ph.SaveFile(currentFile)
            If initFile Then CoreImageChanged = True
            Me.dirty = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub tlstpRotateimage_Click(sender As Object, e As EventArgs) Handles tlstpRotateimage.Click
        ph.RotateImage()
    End Sub

    Private Sub tlstpFlipHorizontal_Click(sender As Object, e As EventArgs) Handles tlstpFlipHorizontal.Click
        ph.FlipHorizontal()
    End Sub

    Private Sub tlstpFlipVertical_Click(sender As Object, e As EventArgs) Handles tlstpFlipVertical.Click
        ph.FlipVertical()
    End Sub

    Private Sub Photoview_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not RemovePhoto() Then
            e.Cancel = True

        End If
    End Sub

    Private Sub tlstpResetImage_Click(sender As Object, e As EventArgs) Handles tlstpResetImage.Click
        ph.resetPhoto
    End Sub

    Private Sub tlstpZoom_Click(sender As Object, e As EventArgs) Handles tlstpZoom.Click

    End Sub

    Private Sub tlstpZoom_Paint(sender As Object, e As PaintEventArgs) Handles tlstpZoom.Paint

    End Sub

    Private Sub Photoview_Load(sender As Object, e As EventArgs) Handles Me.Load
        For i As Integer = 100 To 5 Step -5
            tlstpZoom.Items.Add(i)
        Next

    End Sub

    Private Sub tlstpZoom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tlstpZoom.SelectedIndexChanged
        If ph Is Nothing Then Exit Sub
        ph.Zoom(CInt(tlstpZoom.Text))
    End Sub

    Private Sub pnlPhotoContainerr_Paint(sender As Object, e As PaintEventArgs) Handles pnlPhotoContainerr.Paint

    End Sub

    Private Sub tlstpFitToscreen_Click(sender As Object, e As EventArgs) Handles tlstpFitToscreen.Click
        If ph Is Nothing Then Exit Sub
        ph.ZoomtoFit(pnlPhotoContainerr.Size - New Size(4, 4))
    End Sub


    Private Sub tlstpSaveas_Click(sender As Object, e As EventArgs) Handles tlstpSaveas.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .Filter = "Jpeg files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|BMPFiles(*.bmp)|*.bmp"
            If .ShowDialog = DialogResult.OK Then
                ph.SaveFile(.FileName)
                currentFile = .FileName
                If initFile Then initFile = False
                dirty = False
            End If

        End With
    End Sub

    Private Sub tlstpCopyImage_Click(sender As Object, e As EventArgs) Handles tlstpCopyImage.Click
        ph.CopyImage()
    End Sub

    Private Sub tlstpResizeimage_Click(sender As Object, e As EventArgs) Handles tlstpResizeimage.Click
        Dim rsz As New ResizeImage(ph.WorkingImage)
        If rsz.ShowDialog = DialogResult.OK Then
            If rsz.chgPct = 100 Then Exit Sub
            Dim newSZ As New Size(rsz.chgPct * ph.WorkingImage.Width / 100, rsz.chgPct * ph.WorkingImage.Height / 100)
            Dim img As Image = New Bitmap(newSZ.Width, newSZ.Height)
            Dim g As Graphics = Graphics.FromImage(img)
            g.DrawImage(ph.WorkingImage, New Rectangle(0, 0, newSZ.Width, newSZ.Height))
            g.Dispose()
            ph.WorkingImage = img
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub Photoview_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Photoview_Closing(Nothing, New CancelEventArgs)
        End If
    End Sub
End Class
