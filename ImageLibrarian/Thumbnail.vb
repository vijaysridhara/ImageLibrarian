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
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports MetadataExtractor
Imports VijaySridhara.Applications
Imports Directory = MetadataExtractor.Directory

Friend Class Thumbnail
    Private _fileno As Long
    Private _cachefile As String
    Private _origfiename As String
    Private _filetype As String
    Dim _img As Image
    Private _fullPath As String
    Private RESOLWID = 200
    Private RESOLHT = 130
    Private _resol As Size = New Size(RESOLWID, RESOLHT)
    Private _tags As String = ""
    Private _stars As Integer
    Private _category As String = "Default"
    Private _subcategory As String = "Default"
    Private _comment As String = ""
    Private _lastmodtime As String
    Private _imageLoaded As Boolean
    Event ThumbnailLoaded(c As Thumbnail)
    Event ThumbnailSelected(c As Thumbnail)
    Event ThumbnailMetaUpdated(c As Thumbnail)
    Event ThumbnailHideChanged(c As Thumbnail)
    Private _metadata As New Dictionary(Of String, PropItem)
    Private _archname As String
    Private _hide As Boolean
    Public Property Hide As Boolean
        Get
            Return _hide
        End Get
        Set(value As Boolean)
            If _hide <> value Then
                _hide = value
                RaiseEvent ThumbnailHideChanged(Me)
            End If

        End Set
    End Property
    Public Property ArchiveName As String
        Get
            Return _archname
        End Get
        Set(value As String)
            _archname = value
        End Set
    End Property
    Public Property ImageLoaded As Boolean
        Get
            Return _imageLoaded
        End Get
        Set(value As Boolean)
            _imageLoaded = value
            If value Then
                RaiseEvent ThumbnailLoaded(Me)
            End If
        End Set
    End Property
    Private _cacheimageError As Boolean

    Event ErrorOccured(ex As Exception, pth As String)

    Private _location As Point
    Private _isExisting As Boolean
    Event ControlChanged(t As Object)
    Private _selected As Boolean
    Private selPen As New Pen(Color.Cyan, 3.0)
    Private bordPen As New Pen(Color.Gray, 1)
    Private _cachepath As String
    Private archHelper As ArchiveHelper


    Private _origResol As Size
    Private _fsize As Long
    Private _starImage As Image

    Event RedrawThumb(c As Thumbnail)
    Public ReadOnly Property MetaData As Dictionary(Of String, PropItem)
        Get
            Return _metadata
        End Get
    End Property
    Public ReadOnly Property IsExisting As Boolean
        Get
            Return _isExisting
        End Get
    End Property
    Public Property StarImage As Image
        Get
            Return _starImage
        End Get
        Set(value As Image)
            _starImage = value
        End Set
    End Property
    Public Property ThumbImage As Image
        Get
            Return _img
        End Get
        Set(value As Image)
            _img = value
        End Set
    End Property

    Public Property FileSize As Long
        Get
            Return _fsize
        End Get
        Set(value As Long)
            _fsize = value
        End Set
    End Property
    Public Property OrigResolution As Size
        Get
            Return _origResol
        End Get
        Set(value As Size)
            _origResol = value
        End Set
    End Property


    Public Property CachePath As String
        Get
            Return _cachepath
        End Get
        Set(value As String)
            _cachepath = value
        End Set
    End Property
    Public Property FileNumber As Long
        Get
            Return _fileno
        End Get
        Set(value As Long)
            _fileno = value
        End Set
    End Property
    Public Property CacheFilename As String
        Get
            Return _cachefile
        End Get
        Set(value As String)
            _cachefile = value


        End Set
    End Property
    Public Sub LoadThumb()
        Try

            If System.IO.File.Exists(CachePath & "\" & CacheFilename) = False Then
                'RaiseEvent ErrorOccured(New FileNotFoundException("The Cache file is not found", _cachefile), _cachefile & "." & FileType)
                MakeThumb()
                Exit Sub
            End If
            'Debug.Print("Am here")
            Using stream As System.IO.FileStream = New System.IO.FileStream(CachePath & "\" & CacheFilename, FileMode.Open, System.IO.FileAccess.Read)
                Using br As System.IO.BinaryReader = New BinaryReader(stream)
                    Dim memSt As System.IO.MemoryStream = New System.IO.MemoryStream(br.ReadBytes(stream.Length))
                    Me._img = New Bitmap(memSt)
                End Using
            End Using
            _cacheimageError = False
            ImageLoaded = True
        Catch ex As Exception
            _cacheimageError = True
            RaiseEvent ErrorOccured(ex, _cachepath & "\" & CacheFilename)
        End Try
    End Sub
    Public Property Origfilename As String
        Get
            Return _origfiename
        End Get
        Set(value As String)
            _origfiename = value
        End Set
    End Property
    Public Property FileType As String
        Get
            Return _filetype

        End Get
        Set(value As String)
            _filetype = value
        End Set
    End Property
    Public Property Selected As Boolean
        Get
            Return _selected
        End Get
        Set(value As Boolean)
            _selected = value
            If _selected Then
                RaiseEvent ThumbnailSelected(Me)
            End If
        End Set
    End Property
    Public Function HitTest(pt As Point) As Boolean
        Return New Rectangle(Me.Location, Me.Resolution).Contains(pt)
    End Function
    Public Function GetStarLoc(pot As Point) As Integer
        Dim starrect As New Rectangle(Location.X + Resolution.Width - 25, Location.Y + 5, 15, 80)
        If starrect.Contains(pot) = False Then
            Return -1
        Else
            Dim begY As Integer = Location.Y + 5
            If pot.Y < begY + 15 Then
                Return 1
            ElseIf pot.Y < begY + 30 Then
                Return 2
            ElseIf pot.Y < begY + 45 Then
                Return 3
            ElseIf pot.Y < begY + 60 Then
                Return 4
            ElseIf pot.Y < begY + 80 Then
                Return 5
            End If

        End If
    End Function

    Public Property LastModTime As String
        Get
            Return _lastmodtime
        End Get
        Set(value As String)
            If _lastmodtime <> value And IsExisting Then
                _lastmodtime = value
            Else
                _lastmodtime = value
            End If
        End Set
    End Property
    Public Overloads Property Location As Point
        Get
            Return _location
        End Get
        Set(value As Point)
            _location = value
        End Set
    End Property
    Public Property Image As Image
        Get
            Return _img
        End Get
        Set(value As Image)
            _img = value
        End Set
    End Property
    Public Property FullPath As String
        Get
            Return _fullPath
        End Get
        Set(value As String)
            _fullPath = value
        End Set
    End Property
    Public Property Resolution As Size
        Get
            Return _resol
        End Get
        Set(value As Size)
            _resol = value
        End Set
    End Property
    Public Property Tags As String
        Get
            Return _tags
        End Get
        Set(value As String)
            _tags = value
            RaiseEvent RedrawThumb(Me)
        End Set
    End Property
    Public Property Stars As Integer
        Get
            Return _stars
        End Get
        Set(value As Integer)
            _stars = value
            Select Case _stars
                Case 0
                    _starImage = My.Resources._0
                Case 1
                    _starImage = My.Resources._1
                Case 2
                    _starImage = My.Resources._2
                Case 3
                    _starImage = My.Resources._3
                Case 4
                    _starImage = My.Resources._4
                Case 5
                    _starImage = My.Resources._5
                Case Else
                    _starImage = My.Resources._0
            End Select
        End Set
    End Property
    Public Property Category As String
        Get
            Return _category
        End Get
        Set(value As String)
            _category = value
        End Set

    End Property
    Public Property SubCategory As String
        Get
            Return _subcategory
        End Get
        Set(value As String)
            _subcategory = value
        End Set

    End Property
    Public Property Comment As String
        Get
            Return _comment
        End Get
        Set(value As String)

            _comment = value
            RaiseEvent RedrawThumb(Me)
        End Set
    End Property
    Public Sub New(fileno As Long, filetype As String, cachepath As String, origpath As String)
        MyBase.New
        _isExisting = True
        Me._fileno = fileno
        Me._fullPath = origpath
        Me.FileType = filetype
        Me._cachepath = cachepath
        Me.CacheFilename = fileno & "." & filetype

    End Sub
    Public Sub New()
        MyBase.New
        _isExisting = True

    End Sub
    Public Sub InitializeCacheImage(fileno As Long, filetype As String, cachepath As String, origpath As String)
        Me._fileno = fileno
        Me._fullPath = origpath
        Me.FileType = filetype
        Me._cachepath = cachepath
        Me.CacheFilename = fileno & "." & filetype
    End Sub
    Public Sub New(imgpth As String, fileno As Long, cachepath As String)

        MyBase.New
        _fullPath = imgpth
        _fileno = fileno
        _cachepath = cachepath
        _origfiename = System.IO.Path.GetFileName(imgpth)
        _cachefile = fileno & System.IO.Path.GetExtension(imgpth).ToLower
        'MakeThumb() 'Call this in a different thread after loading
    End Sub
    Public Sub MakeThumb()
        Try
            Dim img As Image
            Using stream As System.IO.FileStream = New System.IO.FileStream(Me.FullPath, FileMode.Open, System.IO.FileAccess.Read)
                Using br As System.IO.BinaryReader = New BinaryReader(stream)
                    Dim memSt As System.IO.MemoryStream = New System.IO.MemoryStream(br.ReadBytes(stream.Length))
                    img = New Bitmap(memSt)
                End Using
            End Using
            Stars = 0
            Dim imgF As ImageFormat = img.RawFormat
            If imgF.Equals(ImageFormat.Jpeg) Then
                FileType = "jpg"
            ElseIf imgF.Equals(ImageFormat.Png) Then
                FileType = "png"
            ElseIf imgF.Equals(ImageFormat.Bmp) Then
                FileType = "bmp"
            ElseIf imgF.Equals(ImageFormat.Gif) Then
                FileType = "gif"
            End If
            Dim g As Graphics = Graphics.FromImage(img)
            Dim propItems() As Imaging.PropertyItem = img.PropertyItems
            Dim asrat As Single = img.Width / img.Height
            Dim nw, nh As Single
            Me.OrigResolution = New Size(img.Width, img.Height)
            If asrat > 1 Then
                nw = Resolution.Width
                nh = nw / asrat
                While nh > Resolution.Height
                    nw = nw - 2
                    nh = nw / asrat
                End While
            Else
                nh = Resolution.Height
                nw = asrat * nh
                While nw > Resolution.Width
                    nh = nh - 2
                    nw = asrat * nh
                End While
            End If

            Dim fAtts As FileInfo = New FileInfo(Me.FullPath)
            Me.FileSize = fAtts.Length
            Dim dt As Date = fAtts.LastWriteTime
            Me.LastModTime = dt.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)
            Me._img = New Bitmap(img, New Size(nw, nh))
            g.Dispose()
            img.Dispose()
            img = Nothing
            ImageLoaded = True
            Origfilename = System.IO.Path.GetFileName(FullPath)

            If LoadMetaData() Then
                RaiseEvent ThumbnailMetaUpdated(Me)
            End If

            'Debug.Print(x)
            'Select Case x
            '    Case "320"
            '        ed.ImageTitle = System.Text.ASCIIEncoding.ASCII.GetString(p.Value())
            '    Case "10f"
            '        ed.EquipmentManufacturerr = System.Text.ASCIIEncoding.ASCII.GetString(p.Value())
            '    Case "110"
            '        ed.EquipmentModel = System.Text.ASCIIEncoding.ASCII.GetString(p.Value())
            'End Select
            'Debug.Print("Property Item " + count.ToString())


            'Debug.Print("   ID: 0x" + p.Id.ToString("x"))


            'Debug.Print("   type: " + p.Type.ToString())

            'Debug.Print("   length: " + p.Len.ToString())



            _cachefile = CStr(FileNumber) & "." & FileType
            Me._img.Save(CachePath & "\" & CacheFilename)
            If IsExisting Then
                RaiseEvent RedrawThumb(Me)

            End If
        Catch ex As Exception

            RaiseEvent ErrorOccured(ex, Me.FullPath)
        End Try

    End Sub
    Private Function LoadMetaData() As Boolean
        Try
            MetaData.Clear()

            Dim count As Integer = 0
            Debug.Print("____" & Origfilename)
            Dim proDirecs As IEnumerable(Of Directory) = ImageMetadataReader.ReadMetadata(FullPath)
            For Each direc As Directory In proDirecs
                For Each tag As Tag In direc.Tags
                    ' Debug.Print(direc.Name & "-" & tag.Name & "=" & tag.Description)
                    If direc.Name = "JPEG" Then
                        If tag.Name = "Image Height" Then
                            Dim p As New PropItem("Height", Int(tag.Description.Split(" ")(0)))
                            MetaData.Add("Height", p)
                        End If
                        If tag.Name = "Image Width" Then
                            Dim p As New PropItem("Width", Int(tag.Description.Split(" ")(0)))
                            MetaData.Add("Width", p)
                        End If
                        If tag.Name = "Data Precision" Then
                            Dim p As New PropItem("Depth", tag.Description)
                            MetaData.Add("Depth", p)
                        End If
                    ElseIf direc.Name = "Exif IFD0" Then
                        If tag.Name = "X Resolution" Then
                            Dim p As New PropItem("Resolution", Int(tag.Description.Split(" ")(0)) & " dpi")
                            MetaData.Add("Resolution", p)
                        End If
                        If tag.Name = "Software" Then
                            Dim p As New PropItem("Software", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Date/Time" Then
                            Dim p As New PropItem("Date/Time", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Make" Then
                            Dim p As New PropItem("Device Make", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Model" Then
                            Dim p As New PropItem("Device Model", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Artist" Then
                            Dim p As New PropItem("Artist", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                    ElseIf direc.Name = "Exif SubIFD" Then
                        If tag.Name = "Exposure" Then
                            Dim p As New PropItem("Exposure", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "F-Number" Then
                            Dim p As New PropItem("F-Number", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "ISO Speed Ratings" Then
                            Dim p As New PropItem("ISO", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Shuter Speed Value" Then
                            Dim p As New PropItem("Shutter Speed", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Aperture Value" Then
                            Dim p As New PropItem("Aperture", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Flash" Then
                            Dim p As New PropItem("Flash", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Focal Length" Then
                            Dim p As New PropItem("Focal Length", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "Color Space" Then
                            Dim p As New PropItem("Color Space", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                        If tag.Name = "White Balance" Then
                            Dim p As New PropItem("White Balance", tag.Description)
                            MetaData.Add(p.Name, p)
                        End If
                    End If

                Next

            Next
            Return True
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex, FullPath)
            Return False
        End Try
    End Function
    Public nameFont As New Font("Arial", 8, FontStyle.Regular)
    Public nameBrush As New SolidBrush(Color.Black)
    Private clearBrush As New SolidBrush(SystemColors.ControlDarkDark)
    Public Function Draw(g As Graphics) As Boolean
        '   Debug.Print(_fullPath & " " & _img.Size.ToString)
        'If _img Is Nothing Then Exit Sub
        If Hide Then Exit Function
        On Error Resume Next
        If ImageLoaded Then
            g.FillRectangle(clearBrush, New Rectangle(Location, Resolution))
            g.DrawImage(Me._img, New Rectangle(Location.X + (Resolution.Width / 2 - Me._img.Width / 2), Location.Y + Resolution.Height / 2 - Me._img.Height / 2, _img.Width, _img.Height))
        ElseIf _cacheimageError Then
            g.FillRectangle(clearBrush, New Rectangle(Location, Resolution))
            g.DrawImage(My.Resources.cacheerror, New Rectangle(Location, Resolution))
        Else
            g.DrawImage(My.Resources.loading, New Rectangle(Location, Resolution))
        End If
        If Me.Selected Then
            g.DrawRectangle(selPen, New Rectangle(Location + New Point(1, 1), Resolution + New Size(0, 20) - New Size(2, 2)))
        Else
            g.DrawRectangle(bordPen, New Rectangle(Location, Resolution + New Size(0, 20)))
        End If
        If Me.StarImage Is Nothing Then Return True
        g.DrawImage(Me.StarImage, New Rectangle(Location.X + Resolution.Width - 25, Location.Y + 5, StarImage.Width, StarImage.Height))
        If Not String.IsNullOrEmpty(Tags) Then
            g.DrawImage(My.Resources.tag, New Rectangle(Location + New Point(2, 2), New Size(24, 24)))
        End If
        If Not String.IsNullOrEmpty(Comment) Then
            g.DrawImage(My.Resources.comments, New Rectangle(Location + New Point(2, Resolution.Height + 20 - 22), New Size(24, 24)))
        End If
        g.DrawString(Origfilename, nameFont, nameBrush, New Rectangle(New Point(Location + New Point(30, Resolution.Height + 20 - 18)), New Size(Resolution.Width - 20, 15)))
        Return True
    End Function
    Public Sub Unlink()
        _img.Dispose()
    End Sub
    Public Function Clone() As Thumbnail
        Dim c1 As New Thumbnail(GetNextKey, FileType, CachePath, FullPath)
        c1.Comment = Comment
        c1.Tags = Tags
        c1.FileSize = FileSize
        c1.OrigResolution = OrigResolution
        c1.Origfilename = Origfilename
        c1.LastModTime = LastModTime
        c1.Category = Category
        c1.SubCategory = SubCategory
        c1.ArchiveName = ArchiveName
        c1.Hide = Hide
        For Each propitm As PropItem In MetaData.Values
            Dim p1 As PropItem = propitm.Clone
            c1.MetaData.Add(p1.Name, p1)
        Next
        Return c1
    End Function
    Public Sub CreateQuickThumb(c1 As Thumbnail)
        Try
            Dim img As Image
            Using stream As System.IO.FileStream = New System.IO.FileStream(Me.FullPath, FileMode.Open, System.IO.FileAccess.Read)
                Using br As System.IO.BinaryReader = New BinaryReader(stream)
                    Dim memSt As System.IO.MemoryStream = New System.IO.MemoryStream(br.ReadBytes(stream.Length))
                    img = New Bitmap(memSt)
                End Using
            End Using
            Stars = 0
            Dim imgF As ImageFormat = img.RawFormat
            If imgF.Equals(ImageFormat.Jpeg) Then
                FileType = "jpg"
            ElseIf imgF.Equals(ImageFormat.Png) Then
                FileType = "png"
            ElseIf imgF.Equals(ImageFormat.Bmp) Then
                FileType = "bmp"
            ElseIf imgF.Equals(ImageFormat.Gif) Then
                FileType = "gif"
            End If
            Dim g As Graphics = Graphics.FromImage(img)
            Dim propItems() As Imaging.PropertyItem = img.PropertyItems
            Dim asrat As Single = img.Width / img.Height
            Dim nw, nh As Single
            c1.OrigResolution = New Size(img.Width, img.Height)
            If asrat > 1 Then
                nw = c1.Resolution.Width
                nh = nw / asrat
                While nh > c1.Resolution.Height
                    nw = nw - 2
                    nh = nw / asrat
                End While
            Else
                nh = c1.Resolution.Height
                nw = asrat * nh
                While nw > c1.Resolution.Width
                    nh = nh - 2
                    nw = asrat * nh
                End While
            End If

            Dim fAtts As FileInfo = New FileInfo(c1.FullPath)
            c1.FileSize = fAtts.Length
            Dim dt As Date = fAtts.LastWriteTime
            c1.LastModTime = dt.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture)
            c1.ThumbImage = New Bitmap(img, New Size(nw, nh))

            g.Dispose()
            img.Dispose()

            c1.ThumbImage.Save(c1.CachePath & "\" & c1.CacheFilename)
            c1.ImageLoaded = True
            img = Nothing
        Catch ex As Exception
            RaiseEvent ErrorOccured(ex, c1.FullPath)
        End Try
    End Sub
End Class
