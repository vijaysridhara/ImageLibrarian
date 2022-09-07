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
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO

Public Class Photo
    Inherits Control
    Private FilePath As String
    Private origImage As Bitmap
    Private modImage As Bitmap
    Private zoomedImage As Bitmap
    Private defzoompct As Integer = 100
    Private curZoomPct As Integer = 100
    Dim resizerects As New List(Of Rectangle)

    Private _enableCrop As Boolean
    Private croppen As New Pen(Color.White, 2)
    Private drewCrop As Boolean = False
    Dim resrectsize As Integer = 8
    Event Cropevent(drawn As Boolean)
    Event CropImagePreview(i As Image)
    Event FitZoom(pct As Integer)

    Public Property WorkingImage As Image
        Get
            Return modImage
        End Get
        Set(value As Image)
            If Not modImage Is Nothing Then modImage.Dispose()
            modImage = value
            Zoom(curZoomPct)
        End Set
    End Property
    Public Sub CopyImage()
        Try
            Dim b As Bitmap = New Bitmap(modImage.Width, modImage.Height, PixelFormat.Format32bppArgb)
            Dim g As Graphics = Graphics.FromImage(b)

            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

            g.DrawImage(modImage, New Rectangle(0, 0, modImage.Width, modImage.Height))

            Clipboard.SetImage(b)
            g.Dispose()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Sub New(fname As String)
        MyBase.New
        FilePath = fname

        For i = 0 To 3
            Dim rect As New Rectangle(0, 0, resrectsize, resrectsize)
            resizerects.Add(rect)
        Next
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.Selectable, True)

        Using stream As IO.FileStream = New IO.FileStream(Me.FilePath, FileMode.Open, IO.FileAccess.Read)
            Using br As IO.BinaryReader = New BinaryReader(stream)
                Dim memSt As IO.MemoryStream = New IO.MemoryStream(br.ReadBytes(stream.Length))
                origImage = New Bitmap(memSt)
                origImage.MakeTransparent()
                modImage = origImage.Clone
                modImage.MakeTransparent()
                Me.BackgroundImageLayout = ImageLayout.Zoom

                Zoom(defzoompct)


            End Using
        End Using
    End Sub
    Public Sub Zoom(pct As Integer)
        curZoomPct = pct
        If Not zoomedImage Is Nothing Then zoomedImage.Dispose()

        Dim newSz As Size = New Size(Int(modImage.Width * pct / 100), Int(modImage.Height * pct / 100))
        zoomedImage = New Bitmap(newSz.Width, newSz.Height)
        Dim g As Graphics = Graphics.FromImage(zoomedImage)
        g.DrawImage(modImage, New Rectangle(0, 0, newSz.Width, newSz.Height))
        Me.BackgroundImage = Nothing
        Me.Size = New Size(newSz.Width, newSz.Height)
        Me.BackgroundImage = zoomedImage

    End Sub
    Public Sub RotateImage()
        Try

            modImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Zoom(curZoomPct)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Sub FlipVertical()
        Try

            modImage.RotateFlip(RotateFlipType.Rotate180FlipY)
            Zoom(curZoomPct)
        Catch ex As Exception
            DE(ex)
        End Try

    End Sub

    Public Sub FlipHorizontal()
        Try

            modImage.RotateFlip(RotateFlipType.Rotate180FlipX)
            Zoom(curZoomPct)
        Catch ex As Exception
            DE(ex)
        End Try

    End Sub
    Public Function SaveFile(fname As String) As Boolean
        Try
            modImage.Save(fname)

            Return True
        Catch ex As Exception
            DE(ex)
            Return False
        End Try

    End Function
    Public Property EnableCrop As Boolean
        Get
            Return _enableCrop
        End Get
        Set(value As Boolean)
            _enableCrop = value
            If _enableCrop Then
                Me.Cursor = Cursors.Cross

            Else
                Me.Cursor = Cursors.Default

            End If
            ResetCrop()
        End Set
    End Property
    Dim cropRect As Rectangle
    Dim cropSize As Size
    Dim cropStart As Point
    Dim mdown As Point
    Dim ix As Integer = 0
    Dim staticStart As Point
    Dim staticSize As Size
    Private Sub Photo_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ix = HitTest(e.Location)
        Debug.Print("Pressed at : " & e.Location.ToString)
        staticStart = cropStart
        staticSize = cropSize
        Select Case ix
            Case 0
                If EnableCrop Then Me.Cursor = Cursors.Cross Else Me.Cursor = Cursors.Default
            Case 1, 3
                Me.Cursor = Cursors.SizeNWSE
            Case 2, 4
                Me.Cursor = Cursors.SizeNESW
            Case 5
                Me.Cursor = Cursors.Hand
        End Select
        If EnableCrop And ix = 0 Then
            If e.Button = MouseButtons.Left Then
                cropStart = e.Location
                cropSize = New Size(0, 0)
            End If
        ElseIf EnableCrop And drewCrop Then
            mdown = e.Location
        End If
    End Sub

    Public Sub ConfirmCrop()
        Try

            Dim b As New Bitmap(CInt(Int(cropSize.Width * 100 / curZoomPct)), CInt(Int(cropSize.Height * 100 / curZoomPct))) '4/3 is point to pixel ratio

            Dim g As Graphics = Graphics.FromImage(b)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            Dim newStart As Point = New Point(CInt(Int(cropStart.X * 100 / curZoomPct)), CInt(Int(cropStart.Y * 100 / curZoomPct)))
            g.DrawImage(modImage, New Rectangle(0, 0, b.Width, b.Height), New Rectangle(newStart.X, newStart.Y, b.Width, b.Height), GraphicsUnit.Pixel)
            modImage.Dispose()
            modImage = b
            Zoom(curZoomPct)
            ResetCrop()
            Me.Invalidate()


        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub ResetCrop()
        cropStart = New Point(0, 0)
        cropSize = New Size(0, 0)
        ' _enableCrop = False
        drewCrop = False
        Me.Invalidate()
        RaiseEvent Cropevent(False)
    End Sub
    Private Sub Photo_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove


        If e.Button = MouseButtons.Left And EnableCrop Then
            If ix = 0 Then
                If cropStart.X >= e.Location.X Or cropStart.Y >= e.Location.Y Then Exit Sub
                cropSize = New Size(e.Location.X - cropStart.X, e.Location.Y - cropStart.Y)
                RaiseEvent Cropevent(True)
                drewCrop = True
                ArrangeResizeRects()

            ElseIf ix = 1 Then
                Dim deltaX, deltaY As Integer
                deltaX = e.Location.X - mdown.X
                deltaY = e.Location.Y - mdown.Y
                cropStart = New Point(staticStart.X + deltaX, staticStart.Y + deltaY)
                cropSize = New Size(staticSize.Width - deltaX, staticSize.Height - deltaY)
                ArrangeResizeRects()
            ElseIf ix = 2 Then
                Dim deltaX, deltaY As Integer
                deltaX = e.Location.X - mdown.X
                deltaY = e.Location.Y - mdown.Y
                cropStart = New Point(staticStart.X, staticStart.Y + deltaY)
                cropSize = New Size(staticSize.Width + deltaX, staticSize.Height - deltaY)
                ArrangeResizeRects()
            ElseIf ix = 3 Then
                Dim deltaX, deltaY As Integer
                deltaX = e.Location.X - mdown.X
                deltaY = e.Location.Y - mdown.Y
                cropStart = New Point(staticStart.X, staticStart.Y)
                cropSize = New Size(staticSize.Width + deltaX, staticSize.Height + deltaY)
                ArrangeResizeRects()
            ElseIf ix = 4 Then
                Dim deltaX, deltaY As Integer
                deltaX = e.Location.X - mdown.X
                deltaY = e.Location.Y - mdown.Y
                cropStart = New Point(staticStart.X + deltaX, staticStart.Y)
                cropSize = New Size(staticSize.Width - deltaX, staticSize.Height + deltaY)
                ArrangeResizeRects()
            ElseIf ix = 5 Then
                Dim deltaX, deltaY As Integer
                deltaX = e.Location.X - mdown.X
                deltaY = e.Location.Y - mdown.Y
                cropStart = New Point(staticStart.X + deltaX, staticStart.Y + deltaY)
                ArrangeResizeRects()
            End If

        Else
            ix = HitTest(e.Location)

            Select Case ix
                Case 0
                    If EnableCrop Then Me.Cursor = Cursors.Cross Else Me.Cursor = Cursors.Default
                Case 1, 3
                    Me.Cursor = Cursors.SizeNWSE
                Case 2, 4
                    Me.Cursor = Cursors.SizeNESW
                Case 5
                    Me.Cursor = Cursors.Hand
            End Select
        End If
        Me.Invalidate()
    End Sub
    Private Sub PreviewImage()
        If EnableCrop And drewCrop And cropSize.Width > 0 And cropSize.Height > 0 Then
            Dim b As New Bitmap(CInt(Int(cropSize.Width * 100 / curZoomPct)), CInt(Int(cropSize.Height * 100 / curZoomPct)))
            b.MakeTransparent()
            Dim g As Graphics = Graphics.FromImage(b)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            Dim newStart As Point = New Point(CInt(Int(cropStart.X * 100 / curZoomPct)), CInt(Int(cropStart.Y * 100 / curZoomPct)))
            g.DrawImage(modImage, 0, 0, New Rectangle(newStart.X, newStart.Y, b.Width, b.Height), GraphicsUnit.Pixel)
            RaiseEvent CropImagePreview(b)
        End If
    End Sub
    Dim resizerectpen As New Pen(Color.Black, 1)
    Dim resizerectbrush As New SolidBrush(Color.Yellow)
    Private Sub Photo_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Red, 2), New Rectangle(0, 0, Me.Width, Me.Height))
        If EnableCrop And drewCrop Then
            cropRect = New Rectangle(cropStart, cropSize)
            e.Graphics.DrawRectangle(croppen, cropRect)
        End If

        If drewCrop Then
            For i As Integer = 0 To 3
                e.Graphics.DrawRectangle(resizerectpen, resizerects(i))
                e.Graphics.FillRectangle(resizerectbrush, resizerects(i))
            Next
        End If
    End Sub
    Private Function HitTest(pt As Point) As Integer
        If drewCrop Then
            For i As Integer = 0 To 3
                If resizerects(i).Contains(pt) Then
                    Return i + 1
                End If
            Next
            If New Rectangle(cropStart, cropSize).Contains(pt) Then
                Return 5
            End If
            Return 0
        End If
    End Function
    Private Sub Photo_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Debug.Print("Lifted at : " & e.Location.ToString)
        Debug.Print("Cropsize: " & cropSize.ToString)
        PreviewImage()
    End Sub
    Private Sub ArrangeResizeRects()
        If EnableCrop And drewCrop Then
            resizerects(0) = New Rectangle(cropStart - New Point(resrectsize, resrectsize), New Size(resrectsize, resrectsize))
            resizerects(1) = New Rectangle(cropStart + cropSize - New Point(0, cropSize.Height + resrectsize), New Size(resrectsize, resrectsize))
            resizerects(2) = New Rectangle(cropStart + cropSize, New Size(resrectsize, resrectsize))
            resizerects(3) = New Rectangle(cropStart + cropSize - New Point(cropSize.Width + resrectsize, 0), New Size(resrectsize, resrectsize))
        End If
    End Sub
    Public Sub ResetPhoto()
        modImage.Dispose()
        modImage = origImage.Clone
        Zoom(curZoomPct)
    End Sub
    Public Sub ZoomtoFit(resol As Size)
        Dim asrat As Single = modImage.Width / modImage.Height
        Dim nw, nh As Integer
        If asrat > 1 Then
            nw = resol.Width
            nh = nw / asrat
            While nh > resol.Height
                nw = nw - 2
                nh = nw / asrat
            End While
        Else
            nh = resol.Height
            nw = asrat * nh
            While nw > resol.Width
                nh = nh - 2
                nw = asrat * nh
            End While
        End If
        zoomedImage = New Bitmap(nw, nh)
        Dim g As Graphics = Graphics.FromImage(zoomedImage)
        Me.BackgroundImage = Nothing
        Me.Size = New Size(nw, nh)
        g.DrawImage(modImage, New Rectangle(0, 0, nw, nh))
        Me.BackgroundImage = zoomedImage
        Me.BackgroundImageLayout = ImageLayout.Zoom
        curZoomPct = (nw / modImage.Width * 100)
        RaiseEvent FitZoom(Math.Floor(nw / modImage.Width * 100))

    End Sub
End Class
