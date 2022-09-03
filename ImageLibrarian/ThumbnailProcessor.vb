
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
Friend Class ThumbnailProcessor
    Private _archHelper As ArchiveHelper
    Event Loading(running As Boolean)
    Event Message(msg As String)
    Event Errored(ex As Exception)
    Event Progress(pct As Integer)
    Public Sub New()

    End Sub
    Private _iscurload As Boolean
    Public Property ArchHelper As ArchiveHelper
        Get
            Return _archHelper
        End Get
        Set(value As ArchiveHelper)
            Me._archHelper = value
        End Set
    End Property
    Public Property IsCurrentlyLoading As Boolean
        Get
            Return _iscurload
        End Get
        Set(value As Boolean)
            _iscurload = value
            RaiseEvent Loading(value)
        End Set
    End Property
    Private Function GetIndent(lev As String) As String
        Dim st As String = ""
        Dim i As Integer = 0
        While i < lev
            st += "  "
            i += 1
        End While
        Return st
    End Function
    Private _cancelOp As Boolean
    Public Property CancelOperation As Boolean
        Get
            Return _cancelOp
        End Get
        Set(value As Boolean)
            _cancelOp = value
        End Set
    End Property

    Public Function AddIndividualImages(paths() As String, cat As String, subcat As String, archive As String) As Boolean
        Try
            IsCurrentlyLoading = True
            Dim tnailList As New List(Of Thumbnail)
            For Each path In paths
                Application.DoEvents()
                If ArchHelper.ContainsFile(path, cat, subcat, archive) Then
                    RaiseEvent Message("The file already exists in cache " & path)
                    Return False
                End If
                Dim c As New Thumbnail(path, GetNextKey, ArchHelper.CachePath & "\CacheImages")
                c.Category = cat
                c.ArchiveName = archive
                c.SubCategory = subcat
                c.Tags = c.FullPath.Substring(3, c.FullPath.Length - c.Origfilename.Length - 4).Replace("\", ",")
                tnailList.Add(c)
                c.MakeThumb()
                ArchHelper.AddEntry(c)
                If CancelOperation Then
                    RaiseEvent Message("Cancel requested...")
                    IsCurrentlyLoading = False
                    Return True

                End If
            Next
            IsCurrentlyLoading = False
            Return True
        Catch ex As Exception
            RaiseEvent Errored(ex)
            IsCurrentlyLoading = False
            Return False
        End Try

    End Function

    Public Function Massload(level As Integer, pth As String, types() As String, cat As String, subcat As String, currentArchive As String) As Integer
        Try
            IsCurrentlyLoading = True
            Dim filesLoaded As Integer = 0
            Dim dupes As Boolean = False
            Dim indent As String = GetIndent(level)
            ' Dim tempThumbs As New List(Of Thumbnail)
            RaiseEvent Message(indent & "***Folder: " & pth & "*******")
            For Each t As String In types
                RaiseEvent Message(indent & "Getting files of type " & t)
                Dim files() As String = IO.Directory.GetFiles(pth, t)
                If files.Length = 0 Then Continue For
                Dim row As Integer = 0
                Dim col As Integer = 0
                Dim tt As Integer = files.Count
                Dim ct As Integer = 0
                Dim tenCt As Integer = 0
                RaiseEvent Message(indent & "Checking for duplicates...")
                Dim finList As New List(Of String)
                If CancelOperation Then
                    RaiseEvent Message("Cancel requested, so cancelling...")
                    Return 0
                End If
                For Each f As String In files
                    Application.DoEvents()
                    If ArchHelper.ContainsFile(f, cat, subcat, currentArchive) Then Continue For
                    finList.Add(f)
                    If CancelOperation Then
                        RaiseEvent Message("Cancel requested, so cancelling...")
                        Return 0
                    End If
                Next
                If files.Length > finList.Count Then
                    dupes = True
                End If
                RaiseEvent Message(indent & "There are " & finList.Count & " images in this folder, moving them To cache")
                For Each f As String In finList
                    Application.DoEvents()
                    ct += 1
                    If ct Mod 5 = 0 Then
                        tenCt += 1
                        RaiseEvent Progress(Math.Floor(ct / tt * 100))
                    End If
                    If CancelOperation Then
                        RaiseEvent Message("Cancel requested, so cancelling...")
                        RaiseEvent Progress(100)
                        Return ct

                    End If
                    Dim c As New Thumbnail(f, GetNextKey, ArchHelper.CachePath & "\CacheImages")
                    c.Category = cat
                    c.SubCategory = subcat
                    c.ArchiveName = currentArchive
                    c.Tags = c.FullPath.Substring(3, c.FullPath.Length - c.Origfilename.Length - 4).Replace("\", ",")
                    'just split the folder structure to tags, remove the drive and the file information
                    'tempThumbs.Add(c)
                    c.MakeThumb()
                    ArchHelper.AddEntry(c)
                    c = Nothing
                Next
                filesLoaded += finList.Count
                RaiseEvent Progress(100)
            Next

            If dupes Then
                RaiseEvent Message(indent & "There were some files already existing In the cache, so didn't import them, [" & pth & "]")

            End If
            IsCurrentlyLoading = False
            Return filesLoaded
        Catch ex As Exception
            RaiseEvent Errored(ex)
            IsCurrentlyLoading = False
            Return 0
        End Try

    End Function

End Class
