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
Imports System.IO

Friend Class Export
    Dim ls As List(Of Thumbnail)
    Public Sub New(sellist As List(Of Thumbnail))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ls = sellist
        txtLocation.Text = EXPLOC
    End Sub
    Private Sub butOuterBorderColor_Click(sender As Object, e As EventArgs) Handles butOuterBorderColor.Click
        Dim cd As New ColorDialog
        cd.Color = butOuterBorderColor.BackColor
        If cd.ShowDialog = DialogResult.OK Then
            butOuterBorderColor.BackColor = cd.Color
        End If
    End Sub

    Private Sub butInBorderColor_Click(sender As Object, e As EventArgs) Handles butInBorderColor.Click
        Dim cd As New ColorDialog
        cd.Color = butInBorderColor.BackColor
        If cd.ShowDialog = DialogResult.OK Then
            butInBorderColor.BackColor = cd.Color
        End If
    End Sub

    Private Sub butBrowse_Click(sender As Object, e As EventArgs) Handles butBrowse.Click
        Dim fdb As New FolderBrowserDialog
        If Not String.IsNullOrEmpty(txtLocation.Text) Then
            fdb.SelectedPath = txtLocation.Text
        End If
        If fdb.ShowDialog = DialogResult.OK Then
            txtLocation.Text = fdb.SelectedPath
            EXPLOC = txtLocation.Text
            My.Settings.ExportLocation = EXPLOC
            My.Settings.Save()
        End If
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click

        If String.IsNullOrEmpty(txtLocation.Text) Then
            MsgBox("Set the location first..", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IO.Directory.Exists(txtLocation.Text) = False Then
            MsgBox("The selected directory doesn't exist", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim resize As Boolean = chkResize.Checked
        Dim maxlong As Integer = nupdMaxWidth.Value

        Dim obord As Boolean = chkOutBorder.Checked
        Dim ibord As Boolean = chkInBorder.Checked
        Dim obordwidth As Integer = IIf(obord, nupdOuterBorder.Value, 0)
        Dim ibordwidth As Integer = IIf(ibord, nupdInnerBorder.Value, 0)
        Dim obordcolor As Color = butOuterBorderColor.BackColor
        Dim ibordcolor As Color = butInBorderColor.BackColor
        Dim ibordBrush = New SolidBrush(ibordcolor)
        With My.Settings
            .BordColor2 = ibordcolor
            .BordColor1 = obordcolor
            .Border1 = obord
            .Border2 = ibord
            .BordWidth1 = obordwidth
            .BordWidth2 = ibordwidth
            .Resize = resize
            .MaxSide = maxlong
            .Save()
        End With
        Try
            Dim cnt As Integer = 0
            Dim totCnt As Integer = ls.Count
            For Each tn As Thumbnail In ls
                cnt += 1

                Dim img As Image
                Using stream As IO.FileStream = New IO.FileStream(tn.FullPath, FileMode.Open, IO.FileAccess.Read)
                    Using br As IO.BinaryReader = New BinaryReader(stream)
                        Dim memSt As IO.MemoryStream = New IO.MemoryStream(br.ReadBytes(stream.Length))
                        img = New Bitmap(memSt)

                    End Using
                End Using
                Dim asrat As Single = img.Width / img.Height
                Dim nw, nh As Integer
                Dim finImage As Bitmap
                nw = img.Width
                nh = img.Height
                If resize Then
                    If asrat > 1 Then
                        If img.Width > maxlong Then
                            nw = maxlong
                            nh = nw / asrat
                        Else
                            nw = img.Width
                            nh = img.Height
                        End If
                    Else
                        If img.Height > maxlong Then
                            nh = maxlong
                            nw = nh * asrat
                        Else
                            nh = img.Height
                            nw = img.Width
                        End If
                    End If

                End If
                If ibord Then
                    nw += 2 * ibordwidth
                    nh += 2 * ibordwidth
                End If
                If obord Then
                    nw += 2 * obordwidth
                    nh += 2 * obordwidth
                End If
                finImage = New Bitmap(nw, nh)
                If tn.FileType = "png" Then
                    finImage.MakeTransparent()
                End If
                Dim g As Graphics = Graphics.FromImage(finImage)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                If obord Then
                    g.Clear(obordcolor)

                End If
                If ibord Then
                    g.FillRectangle(ibordBrush, New Rectangle(obordwidth, obordwidth, nw - 2 * obordwidth, nh - 2 * obordwidth))
                End If
                g.DrawImage(img, New Rectangle(obordwidth + ibordwidth, obordwidth + ibordwidth, nw - 2 * (obordwidth + ibordwidth), nh - 2 * (obordwidth + ibordwidth)))
                finImage.Save(txtLocation.Text & "\" & tn.Origfilename)
                g.Dispose()
                finImage.Dispose()
                lblStatusmessage.Text = "Processed " & cnt & " of " & totCnt & " files..."

            Next
            Shell("explorer " & txtLocation.Text, AppWinStyle.NormalFocus)
        Catch ex As Exception
            DE(ex)

        End Try

    End Sub

    Private Sub chkResize_CheckedChanged(sender As Object, e As EventArgs) Handles chkResize.CheckedChanged
        nupdMaxWidth.Enabled = chkResize.Checked

    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.Close()
    End Sub

    Private Sub Export_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkResize.Checked = My.Settings.Resize
        nupdMaxWidth.Value = My.Settings.MaxSide
        nupdOuterBorder.Value = My.Settings.BordWidth1
        nupdInnerBorder.Value = My.Settings.BordWidth2
        butInBorderColor.BackColor = My.Settings.BordColor2
        butOuterBorderColor.BackColor = My.Settings.BordColor1
        chkInBorder.Checked = My.Settings.Border2
        chkOutBorder.Checked = My.Settings.Border1
    End Sub
End Class