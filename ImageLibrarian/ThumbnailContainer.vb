﻿'***********************************************************************
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
Imports VijaySridhara.Applications

Friend Class ThumbnailContainer
    Inherits Control
    Dim THUMB_HEIGHT = 150
    Dim THUMB_WIDTH = 200
    Dim res As New Size(THUMB_WIDTH, THUMB_HEIGHT)
    Private tnailList As New List(Of Thumbnail)
    Public maxColCount As Integer = 5
    Public MaxThumbWidth As Integer = 200 + 1
    Event Progress(pct As Integer)
    Private _archHelper As ArchiveHelper
    Private isInitialized As Boolean
    Event Errored(ex As Exception)
    Event Message(msg As String)
    Event ThumbnailSelected(c As Thumbnail)
    Event ThumbnailsCleared()
    Event ThumbnailsUnselected()

    Event ThumbnailOneAdded(c As Thumbnail)
    Private WithEvents ctxContext As New ContextMenuStrip
    Private WithEvents tlstpCopyTo As New ToolStripMenuItem("Copy to", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpChangeCategory As New ToolStripMenuItem("Change category", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpRemoveOriginal As New ToolStripMenuItem("Delete from disk", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpRemoveCached As New ToolStripMenuItem("Remove thumb", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpCut As New ToolStripMenuItem("Cut", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpCopy As New ToolStripMenuItem("Copy", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpPaste As New ToolStripMenuItem("Paste", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpSelectAll As New ToolStripMenuItem("Select all", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpDeSelectAll As New ToolStripMenuItem("Unselect all", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpExportto As New ToolStripMenuItem("Export resized", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlspShowFile As New ToolStripMenuItem("Show file", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpEditFile As New ToolStripMenuItem("Edit with", Nothing)
    Private WithEvents tlstpEditFileWithP3 As New ToolStripMenuItem("<Program 3>", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpEditFileWithP2 As New ToolStripMenuItem("<Program 2>", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpEditFileWithP1 As New ToolStripMenuItem("<Program 1>", Nothing, AddressOf menuItemClicked)
    Private WithEvents tlstpEditFileWithInternal As New ToolStripMenuItem("Simple editor", Nothing, AddressOf menuItemClicked)

    Private WithEvents tlstpSep1 As New ToolStripSeparator
    Private WithEvents tlstpSep2 As New ToolStripSeparator
    Private WithEvents tlstpSep3 As New ToolStripSeparator
    Private WithEvents tlstpRefreshThumbnail As New ToolStripMenuItem("Refresh thumbnail", Nothing, AddressOf menuItemClicked)
    Private _isSearch As Boolean
    Event CategoryChanged(cat As String, subcat As String)
    Private tnaiClipboard As New ThumbnailClipBoard
    Private _currentCategory As String
    Private _currentSubCategory As String
    Private _currentArchive As String
    Public Property CurrentArchive As String
        Get
            Return _currentArchive
        End Get
        Set(value As String)
            _currentArchive = value
        End Set
    End Property
    Public Property CurrentCategory As String
        Get
            Return _currentCategory
        End Get
        Set(value As String)
            _currentCategory = value
        End Set
    End Property
    Public Property CurrentSubCategory As String
        Get
            Return _currentSubCategory
        End Get
        Set(value As String)
            _currentSubCategory = value
        End Set
    End Property
    Public Property IsSearch As Boolean
        Get
            Return _isSearch
        End Get
        Set(value As Boolean)
            _isSearch = value
            If _isSearch Then
                CurrentCategory = ""
            End If
        End Set
    End Property

    Private Function GetSelThumbs() As List(Of Thumbnail)
        Dim lst As New List(Of Thumbnail)
        For Each c As Thumbnail In tnailList
            If c.Selected Then
                lst.Add(c)
            End If
        Next
        Return lst
    End Function

    Private Sub menuItemClicked(sender As Object, e As EventArgs)
        Try
            Select Case CType(sender, ToolStripMenuItem).Tag
                Case "Edit with prog1"
                    If selecteDThumb Is Nothing Then Exit Sub
                    If CType(sender, ToolStripMenuItem).Text = "<Program 1>" Then
                        MsgBox("Set a image editing program in the settings like Photoshop, Gimp, Affinity Photo etc", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    Process.Start(My.Settings.IME1, """" & selecteDThumb.FullPath & """")
                Case "Simple edit"
                    If selecteDThumb Is Nothing Then Exit Sub
                    ThumbnailContainer_MouseDoubleClick(Nothing, New MouseEventArgs(MouseButtons.Left, 2, selecteDThumb.Location.X + 10, selecteDThumb.Location.Y + 10, 0))
                Case "Edit with prog2"
                    If selecteDThumb Is Nothing Then Exit Sub
                    If CType(sender, ToolStripMenuItem).Text = "<Program 2>" Then
                        MsgBox("Set a image editing program in the settings like Photoshop, Gimp, Affinity Photo etc", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    Process.Start(My.Settings.IME2, """" & selecteDThumb.FullPath & """")
                Case "Edit with prog3"
                    If selecteDThumb Is Nothing Then Exit Sub
                    If CType(sender, ToolStripMenuItem).Text = "<Program 3>" Then
                        MsgBox("Set a image editing program in the settings like Photoshop, Gimp, Affinity Photo etc", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    Process.Start(My.Settings.IME2, """" & selecteDThumb.FullPath & """")
            End Select
        Catch ex As Exception
            RaiseEvent Errored(ex)
            Exit Sub
        End Try


        Select Case CType(sender, ToolStripMenuItem).Text

                Case "Select all"
                    For Each c As Thumbnail In tnailList
                        c.Selected = True
                    Next
                    Me.Invalidate()
                Case "Unselect all"
                    For Each c As Thumbnail In tnailList
                        c.Selected = False
                    Next
                    Me.Invalidate()

                Case "Show file"
                    If selecteDThumb Is Nothing Then Exit Sub
                    Process.Start("explorer.exe", "/select," & selecteDThumb.FullPath)
                Case "Paste"
                    If IsSearch Then
                        MsgBox("You cannot paste into search output", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    Dim clipList As List(Of Thumbnail) = tnaiClipboard.GetClippedElements
                    If tnaiClipboard.Operation = "CUT" Then
                        Dim cnt As Integer = 0
                        If clipList Is Nothing Then Exit Select
                        Dim totcount As Integer = clipList.Count
                        For Each c As Thumbnail In clipList
                            cnt += 1
                            If Not ArchHelper.ContainsFile(c.FullPath, CurrentCategory, CurrentSubCategory, CurrentArchive) Then
                                c.Category = CurrentCategory
                                c.SubCategory = CurrentSubCategory
                                c.ArchiveName = CurrentArchive
                                ArchHelper.UpdateThumb("category", c, True)
                                AddThumb(c)
                            End If
                            RaiseEvent Progress(Math.Floor(cnt / totcount * 100))
                        Next
                        Rearrange()
                        Invalidate()
                        tnaiClipboard.ClearLip()
                    ElseIf tnaiClipboard.Operation = "COPY" Then
                        Dim cnt As Integer = 0
                        If clipList Is Nothing Then Exit Select
                        Dim totcount As Integer = clipList.Count
                        For Each c As Thumbnail In clipList
                            cnt += 1
                            If Not ArchHelper.ContainsFile(c.FullPath, CurrentCategory, CurrentSubCategory, CurrentArchive) Then
                                Dim C1 As Thumbnail = c.Clone
                                C1.Category = CurrentCategory
                                C1.SubCategory = CurrentSubCategory
                                C1.ArchiveName = CurrentArchive
                                AddThumb(C1)
                                ArchHelper.AddEntry(C1)
                            End If
                            RaiseEvent Progress(Math.Floor(cnt / totcount * 100))
                        Next
                    End If
                Case Else
                    ExecuteMenuFunc(CType(sender, ToolStripMenuItem).Text)
            End Select
    End Sub

    Private Sub ExecuteMenuFunc(menuname As String)
        Try
            If selecteDThumb Is Nothing Then Exit Sub
            Dim selThumbs As List(Of Thumbnail) = GetSelThumbs()
            If selThumbs.Count = 0 Then Exit Sub
            Select Case menuname
                Case "Copy to"
                    Dim fdb As New FolderBrowserDialog
                    fdb.SelectedPath = COPYLOC
                    If fdb.ShowDialog = DialogResult.OK Then
                        COPYLOC = fdb.SelectedPath
                        My.Settings.CopyLocation = COPYLOC
                        My.Settings.Save()
                        For Each c As Thumbnail In selThumbs
                            If IO.File.Exists(fdb.SelectedPath & "\" & c.Origfilename) Then
                                My.Computer.FileSystem.DeleteFile(fdb.SelectedPath & "\" & c.Origfilename)
                            End If
                            IO.File.Copy(c.FullPath, fdb.SelectedPath & "\" & c.Origfilename)
                        Next
                        RaiseEvent Message(selThumbs.Count & " files copied to" & fdb.SelectedPath)
                    End If

                Case "Change category"
                    Dim cc As New Category(selThumbs(0).Category, selThumbs(0).SubCategory)
                    If cc.ShowDialog = DialogResult.OK Then
                        Dim cnt As Integer = 0
                        Dim totcount As Integer = selThumbs.Count
                        For Each C As Thumbnail In selThumbs
                            cnt += 1
                            RaiseEvent Progress(Math.Floor(cnt / totcount * 100))
                            If C.Category <> cc.cboCat.Text.Trim Or C.SubCategory <> cc.cboSubCat.Text.Trim Then
                                C.Category = cc.cboCat.Text.Trim
                                C.SubCategory = cc.cboSubCat.Text.Trim
                                ArchHelper.UpdateThumb("category", C, True)
                                RemoveHandler C.ErrorOccured, AddressOf Thumb_ErrorOccured
                                RemoveHandler C.RedrawThumb, AddressOf Thumb_UpdateCalled
                                RemoveHandler C.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
                                RemoveHandler C.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
                                RemoveHandler C.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated
                                tnailList.Remove(C)
                            End If
                        Next
                        If _isSearch = False Then RaiseEvent CategoryChanged(cc.cboCat.Text, cc.cboSubCat.Text)
                        Rearrange()
                        Me.Invalidate()
                    End If

                Case "Delete from disk"
                    If MsgBox("Do you really want to delete these files from disk? You cannot undo this program", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                    Dim cc As New Category(selThumbs(0).Category, selThumbs(0).SubCategory)

                    Dim cnt As Integer = 0
                    Dim totcount As Integer = selThumbs.Count
                    For Each C As Thumbnail In selThumbs
                        cnt += 1
                        My.Computer.FileSystem.DeleteFile(C.FullPath)
                        If ArchHelper.RemoveThumb(C) Then
                            RaiseEvent Progress(Math.Floor(cnt / totcount * 100))
                            RemoveHandler C.ErrorOccured, AddressOf Thumb_ErrorOccured
                            RemoveHandler C.RedrawThumb, AddressOf Thumb_UpdateCalled
                            RemoveHandler C.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
                            RemoveHandler C.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
                            RemoveHandler C.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated
                            tnailList.Remove(C)
                        End If

                    Next
                    Rearrange()
                    Me.Invalidate()
                Case "Remove thumb"
                    If MsgBox("Do you really want to delete thumbnail? You can import this file back from source, if you need it again", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                    Dim cnt As Integer = 0
                    Dim totcount As Integer = selThumbs.Count
                    For Each C As Thumbnail In selThumbs
                        cnt += 1
                        If ArchHelper.RemoveThumb(C) Then
                            RaiseEvent Progress(Math.Floor(cnt / totcount * 100))
                            RemoveHandler C.ErrorOccured, AddressOf Thumb_ErrorOccured
                            RemoveHandler C.RedrawThumb, AddressOf Thumb_UpdateCalled
                            RemoveHandler C.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
                            RemoveHandler C.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
                            RemoveHandler C.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated
                            tnailList.Remove(C)
                        End If
                    Next
                    Rearrange()
                    Me.Invalidate()
                Case "Cut"
                    tnaiClipboard.SetClippedElements(GetSelThumbs)
                    tnaiClipboard.Operation = "CUT"
                Case "Copy"
                    tnaiClipboard.SetClippedElements(GetSelThumbs)
                    tnaiClipboard.Operation = "COPY"
                Case "Export resized"
                    Dim ls As List(Of Thumbnail) = GetSelThumbs()
                    Dim es As New Export(ls)
                    es.ShowDialog()
                Case "Refresh thumbnail"
                    selecteDThumb.MakeThumb()
            End Select
        Catch ex As Exception
            RaiseEvent Errored(ex)
        End Try
    End Sub
    Public Sub SearchText(st As String)
        Try
            ClearImages()
            RaiseEvent Message("Searching images from cache...")
            Dim l As List(Of Thumbnail) = ArchHelper.SearchThumbs(st, CurrentArchive)

            If l Is Nothing Then Exit Sub
            RaiseEvent Message("There are " & l.Count & " images in cache for the searched text [" & st & "]")

            Rearrange()
            Me.Invalidate()
            Dim cnt As Integer = l.Count
            Dim inc As Integer
            For Each c As Thumbnail In tnailList
                inc += 1
                If inc Mod 5 = 0 Then
                    RaiseEvent Progress(Math.Floor(inc / cnt * 100))
                End If

                AddHandler c.ErrorOccured, AddressOf Thumb_ErrorOccured
                AddHandler c.RedrawThumb, AddressOf Thumb_UpdateCalled
                AddHandler c.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
                AddHandler c.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
                AddHandler c.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated
            Next
            RaiseEvent Progress(100)
            'Me.Parent.Refresh()
            Dim thd As New Threading.Thread(AddressOf LoadThumbnailImagesThread)
            thd.Start()
        Catch ex As Exception
            RaiseEvent Errored(ex)
        End Try
    End Sub
    Private Sub AddThumb(c As Thumbnail)
        tnailList.Add(c)
        AddHandler c.ErrorOccured, AddressOf Thumb_ErrorOccured
        AddHandler c.RedrawThumb, AddressOf Thumb_UpdateCalled
        AddHandler c.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
        AddHandler c.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
        AddHandler c.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated
    End Sub
    Public Sub New()
        MyBase.New
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.Selectable, True)

        tlstpEditFile.DropDownItems.AddRange({tlstpEditFileWithInternal, tlstpEditFileWithP1, tlstpEditFileWithP2, tlstpEditFileWithP3})
        ctxContext.Items.AddRange({tlstpEditFile, tlstpCut, tlstpCopy, tlstpPaste, tlstpCopyTo, tlstpChangeCategory, tlstpSelectAll, tlstpDeSelectAll, tlstpSep1, tlstpCopyTo, tlstpExportto, tlstpSep2, tlstpRemoveCached, tlspShowFile, tlstpRemoveOriginal, tlstpSep3, tlstpRefreshThumbnail})
        Me.ContextMenuStrip = ctxContext
        tlstpEditFileWithInternal.Tag = "Simple edit"
        tlstpEditFileWithP1.Tag = "Edit with prog1"
        tlstpEditFileWithP2.Tag = "Edit with prog2"
        tlstpEditFileWithP3.Tag = "Edit with prog3"
    End Sub
    Dim paintTop As Integer = 0
    Dim paintBot As Integer = 0
    Public Sub SetControlView(toppos As Integer, botpos As Integer)
        paintTop = toppos
        paintBot = botpos

    End Sub
    Public Property ArchHelper As ArchiveHelper
        Get
            Return _archHelper
        End Get
        Set(value As ArchiveHelper)
            Me._archHelper = value
            If _archHelper Is Nothing Then Exit Property
            AddHandler _archHelper.ThumbnailsCount, AddressOf Arch_ThumbCount
        End Set
    End Property
    Private Sub Arch_ThumbCount(recCnt As Integer, cat As String, ls As List(Of Thumbnail))
        Dim inc As Integer = 0
        Dim cnt As Integer = ls.Count
        For Each c As Thumbnail In ls
            inc += 1
            If inc Mod 5 = 0 Then
                RaiseEvent Progress(Math.Floor(inc / cnt * 100))
            End If
            tnailList.Add(c)
            Application.DoEvents()
            AddHandler c.ErrorOccured, AddressOf Thumb_ErrorOccured
            AddHandler c.RedrawThumb, AddressOf Thumb_UpdateCalled
            AddHandler c.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
            AddHandler c.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
            AddHandler c.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated
        Next
        RaiseEvent Progress(100)
        Rearrange()
        Me.Invalidate()
    End Sub
    Public Property ThumbSize As Size
        Get
            Return res
        End Get
        Set(value As Size)
            res = value
        End Set
    End Property
    Public Sub ClearImages()
        Me.Width = 0
        Me.Height = 0
        begIx = -1
        ControlKey = False
        ShiftKey = False
        For Each t As Thumbnail In tnailList
            RemoveHandler t.ErrorOccured, AddressOf Thumb_ErrorOccured
            RemoveHandler t.RedrawThumb, AddressOf Thumb_UpdateCalled
            RemoveHandler t.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
            RemoveHandler t.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
            RemoveHandler t.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated
        Next
        tnailList.Clear()
        selecteDThumb = Nothing
        _isSearch = False
        _currentCategory = ""
        _currentSubCategory = ""

        RaiseEvent ThumbnailsCleared()
    End Sub
    Public IsCurrentlyLoading
    Public Sub GetImagesfromCache(cat As String, subcat As String)
        Try
            ClearImages()
            IsCurrentlyLoading = True
            CurrentCategory = cat
            CurrentSubCategory = subcat
            RaiseEvent Message("Getting images from cache...")
            Dim l As List(Of Thumbnail) = ArchHelper.GetThumbnails(cat, subcat, CurrentArchive)

            If l Is Nothing Then Exit Sub
            RaiseEvent Message("There are " & l.Count & " images in cache for the selected category[" & cat & "] And subcategory[" & subcat & "]")
            Application.DoEvents()
            Dim cnt As Integer = l.Count
            Dim inc As Integer
            'For Each c As Thumbnail In l
            '    inc += 1
            '    If inc Mod 5 = 0 Then
            '        RaiseEvent Progress(Int(inc / cnt * 100))
            '    End If
            '    'tnailList.Add(c)
            '    'AddHandler c.ErrorOccured, AddressOf Thumb_ErrorOccured
            '    'AddHandler c.RedrawThumb, AddressOf Thumb_UpdateCalled
            '    'AddHandler c.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
            '    'AddHandler c.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
            'Next
            'RaiseEvent Progress(100)
            'Rearrange()
            'Me.Parent.Refresh()
            Dim thd As New Threading.Thread(AddressOf LoadThumbnailImagesThread)
            thd.Start()
        Catch ex As Exception
            RaiseEvent Errored(ex)
            IsCurrentlyLoading = False
        End Try
    End Sub
    Public Function AddIndividualImages(paths() As String, cat As String, subcat As String) As Boolean
        Try
            IsCurrentlyLoading = True
            CurrentCategory = cat
            For Each path In paths
                If tnailList.Count > 0 Then
                    Dim c1 As Thumbnail = tnailList(0)
                    If c1.Category <> cat Then
                        ClearImages()
                    End If
                End If
                If ArchHelper.ContainsFile(path, cat, subcat, CurrentArchive) Then
                    RaiseEvent Message("The file already exists in cache " & path)
                    Return False
                End If
                Dim c As New Thumbnail(path, GetNextKey, ArchHelper.CachePath & "\CacheImages")
                c.Category = cat
                tnailList.Add(c)
                AddHandler c.ErrorOccured, AddressOf Thumb_ErrorOccured
                AddHandler c.RedrawThumb, AddressOf Thumb_UpdateCalled
                AddHandler c.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
                AddHandler c.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
                AddHandler c.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated
                ArchHelper.AddEntry(c)

            Next
            UnselectAll()
            Rearrange()
            tnailList(tnailList.Count - 1).Selected = True
            RaiseEvent ThumbnailSelected(tnailList(tnailList.Count - 1))
            RaiseEvent ThumbnailOneAdded(tnailList(tnailList.Count - 1))
            Me.Parent.Refresh()
            Dim thd As New Threading.Thread(AddressOf LoadThumbnailImagesThread)
            thd.Start()
        Catch ex As Exception
            RaiseEvent Errored(ex)
            IsCurrentlyLoading = False
        End Try

    End Function
    Public Function LoadImages(pth As String, types() As String, cat As String, subcat As String) As Boolean
        Try
            CurrentCategory = cat
            CurrentSubCategory = subcat
            IsCurrentlyLoading = True
            Dim dupes As Boolean = False
            If tnailList.Count > 0 Then
                Dim c As Thumbnail = tnailList(0)
                If c.Category <> cat Then
                    ClearImages()
                End If
            End If
            For Each t As String In types
                RaiseEvent Message("Getting files of type " & t)
                Dim files() As String = IO.Directory.GetFiles(pth, t)
                If files.Length = 0 Then Continue For
                Dim row As Integer = 0
                Dim col As Integer = 0
                Dim tt As Integer = files.Count
                Dim ct As Integer = 0
                Dim tenCt As Integer = 0
                RaiseEvent Message("Checking for duplicates...")
                Dim finList As New List(Of String)

                For Each f As String In files
                    If ArchHelper.ContainsFile(f, cat, subcat, CurrentArchive) Then Continue For
                    finList.Add(f)
                Next
                If files.Length > finList.Count Then
                    dupes = True
                End If
                RaiseEvent Message("There are " & finList.Count & " images in this folder, moving them To cache")
                For Each f As String In finList
                    ct += 1
                    If ct Mod 5 = 0 Then
                        tenCt += 1
                        RaiseEvent Progress(Math.Floor(ct / tt * 100))
                    End If
                    Dim c As New Thumbnail(f, GetNextKey, ArchHelper.CachePath & "\CacheImages")
                    c.Category = cat
                    c.SubCategory = subcat
                    c.ArchiveName = CurrentArchive
                    tnailList.Add(c)
                    AddHandler c.ErrorOccured, AddressOf Thumb_ErrorOccured
                    AddHandler c.RedrawThumb, AddressOf Thumb_UpdateCalled
                    AddHandler c.ThumbnailLoaded, AddressOf Thumb_ThumbnailLoaded
                    AddHandler c.ThumbnailSelected, AddressOf Thumb_ThumbnailSelected
                    AddHandler c.ThumbnailMetaUpdated, AddressOf Thumb_MetaUpdated

                Next
                RaiseEvent Progress(100)
                Rearrange()
            Next

            If dupes Then
                MsgBox("There were some files already existing In the cache, so didn't import them", MsgBoxStyle.Exclamation)

            End If
            If tnailList.Count > 0 Then
                UnselectAll()
                Rearrange()
                tnailList(tnailList.Count - 1).Selected = True
                RaiseEvent ThumbnailSelected(tnailList(tnailList.Count - 1))
                RaiseEvent ThumbnailOneAdded(tnailList(tnailList.Count - 1))

            End If
            Me.Parent.Refresh()
            Dim thd As New Threading.Thread(AddressOf LoadThumbnailImagesThread)
            thd.Start()
            Return True
        Catch ex As Exception
            RaiseEvent Errored(ex)
            IsCurrentlyLoading = False
            Return False
        End Try

    End Function
    Public Sub BeginExport()
        Try
            If selecteDThumb Is Nothing Then Exit Sub
            Dim ls As List(Of Thumbnail) = GetSelThumbs()
            Dim ex As New Export(ls)
            ex.ShowDialog()
        Catch ex As Exception
            RaiseEvent Errored(ex)
        End Try
    End Sub
    Private Function GetIndent(lev As String) As String
        Dim st As String = ""
        Dim i As Integer = 0
        While i < lev
            st += "  "
            i += 1
        End While
        Return st
    End Function
    Public Function Massload(level As Integer, pth As String, types() As String, cat As String, subcat As String) As Integer
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

                For Each f As String In files
                    If ArchHelper.ContainsFile(f, cat, subcat, CurrentArchive) Then Continue For
                    finList.Add(f)
                Next
                If files.Length > finList.Count Then
                    dupes = True
                End If
                RaiseEvent Message(indent & "There are " & finList.Count & " images in this folder, moving them To cache")
                For Each f As String In finList
                    ct += 1
                    If ct Mod 5 = 0 Then
                        tenCt += 1
                        RaiseEvent Progress(Math.Floor(ct / tt * 100))
                    End If
                    Dim c As New Thumbnail(f, GetNextKey, ArchHelper.CachePath & "\CacheImages")
                    c.Category = cat
                    c.SubCategory = subcat
                    c.ArchiveName = CurrentArchive
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

    Private Sub LoadThumbnailImagesThread()

        'On Error Resume Next
        For Each c As Thumbnail In tnailList
            If c.ImageLoaded Then Continue For
            If c.IsExisting Then
                c.LoadThumb()
            Else
                c.MakeThumb()
                ArchHelper.AddEntry(c)
            End If
        Next
        Me.Invalidate()
        IsCurrentlyLoading = False

    End Sub
    Dim selecteDThumb As Thumbnail
    Private Sub Thumb_ThumbnailSelected(c As Thumbnail)
        selecteDThumb = c
    End Sub
    Private Sub Thumb_ErrorOccured(ex As Exception, pth As String)
        RaiseEvent Errored(ex)
        RaiseEvent Message(vbTab & pth)
    End Sub
    Private Sub Thumb_MetaUpdated(c As Thumbnail)
        ArchHelper.UpdateMeta(c.FileNumber, c.MetaData)
    End Sub

    Private Sub Thumb_UpdateCalled(c As Thumbnail)
        If ((c.Location.Y + c.Resolution.Height) > paintTop And (c.Location.Y + c.Resolution.Height) < paintBot) Or
           (c.Location.Y >= paintTop And c.Location.Y <= paintBot) Or (c.Location.Y < paintBot And (c.Location.Y + c.Resolution.Height) >= paintBot) Then
            c.Draw(Me.CreateGraphics)
        End If
    End Sub

    Private Sub Thumb_ThumbnailLoaded(c As Thumbnail)
        If ((c.Location.Y + c.Resolution.Height) > paintTop And (c.Location.Y + c.Resolution.Height) < paintBot) Or
           (c.Location.Y >= paintTop And c.Location.Y <= paintBot) Or (c.Location.Y < paintBot And (c.Location.Y + c.Resolution.Height) >= paintBot) Then
            c.Draw(Me.CreateGraphics)
        End If
    End Sub
    Public ReadOnly Property ThumbnailCount() As Integer
        Get
            Return tnailList.Count
        End Get
    End Property
    Public Sub Rearrange()
        Dim row, col As Integer
        row = 0
        col = 0

        If tnailList.Count >= maxColCount Then
            Me.Width = maxColCount * (res.Width + 1)
        Else
            Me.Width = tnailList.Count * (res.Width + 1)
        End If
        Dim cnt As Integer
        For Each c As Thumbnail In tnailList
            c.Location = New Point(col * (res.Width + 1), row * (res.Height + 1))
            cnt += 1
            Debug.Print("Item " & cnt & " at col: " & col & " row: " & row)
            If col = (maxColCount - 1) Then
                col = 0
                row += 1

            Else
                col += 1

            End If
        Next
        Debug.Print("Row value here is" & row)
        If maxColCount = 0 Then Exit Sub
        If tnailList.Count Mod maxColCount = 0 And row > 0 Then
            Me.Height = (row) * (res.Height + 1)
        Else
            Me.Height = (row + 1) * (res.Height + 1)
        End If

        Me.Invalidate()
    End Sub
    Private Sub ThumbnailContainer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        'For Each t As Thumbnail In tnailList
        '    t.Draw(e.Graphics)
        'Next
        Dim cnt As Integer = 0
        Dim totCnt As Integer = tnailList.Count
        For Each c As Thumbnail In tnailList
            cnt += 1
            If ((c.Location.Y + c.Resolution.Height) > paintTop And (c.Location.Y + c.Resolution.Height) < paintBot) Or
            (c.Location.Y >= paintTop And c.Location.Y <= paintBot) Or (c.Location.Y < paintBot And (c.Location.Y + c.Resolution.Height) >= paintBot) Then
                ' Debug.Print("TopPos: " & paintTop & " Bot pos " & paintBot & "  Qualified " & cnt & " of " & totCnt)
                If c.Draw(e.Graphics) Then

                    'Do nothing
                End If
            End If
        Next
    End Sub

    Dim beginVisIndex As Integer = 0
    Dim endVisIndex As Integer = 0
    Dim begIx As Integer = -1
    Private Sub ThumbnailContainer_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Dim fnd As Boolean = False

        If e.Button = MouseButtons.Left Then
            For Each c As Thumbnail In tnailList
                If c.HitTest(e.Location) Then
                    fnd = True
                    If c.Selected = False Then
                        c.Selected = True
                        RaiseEvent ThumbnailSelected(c)

                    End If

                    If ShiftKey Then
                        Dim endix As Integer = tnailList.IndexOf(c)
                        If begIx > -1 Then
                            For i As Integer = begIx To endix
                                tnailList(i).Selected = True
                            Next
                            begIx = endix
                        End If
                    End If
                    If Not ControlKey And Not ShiftKey Then
                        Dim x As Integer = c.GetStarLoc(e.Location)
                        If x > -1 Then
                            If x = 1 And c.Stars = 1 Then
                                c.Stars = 0
                                c.Draw(Me.CreateGraphics)
                                ArchHelper.UpdateThumb("stars", c)
                            ElseIf x <> c.Stars Then
                                c.Stars = x
                                c.Draw(Me.CreateGraphics)
                                ArchHelper.UpdateThumb("stars", c)
                            End If
                        Else
                            For Each c1 As Thumbnail In tnailList
                                If c1 Is c Then Continue For
                                c1.Selected = False
                            Next
                        End If

                    End If
                    begIx = tnailList.IndexOf(c)
                    Exit For
                End If
            Next
            If fnd = False Then
                UnselectAll()
            End If
        End If
        Me.Invalidate()
    End Sub
    Private Sub UnselectAll()
        For Each c1 As Thumbnail In tnailList
            c1.Selected = False
        Next
        selecteDThumb = Nothing
        RaiseEvent ThumbnailsUnselected()
    End Sub

    Private Sub ctxContext_Opening(sender As Object, e As CancelEventArgs) Handles ctxContext.Opening
        tlstpCut.Enabled = False
        tlstpCopy.Enabled = False
        tlstpPaste.Enabled = False
        tlstpSelectAll.Enabled = False
        tlstpDeSelectAll.Enabled = False
        tlstpChangeCategory.Enabled = False
        tlstpExportto.Enabled = False
        tlstpRefreshThumbnail.Enabled = False
        tlstpRemoveCached.Enabled = False
        tlstpRemoveOriginal.Enabled = False
        tlspShowFile.Enabled = False
        tlstpEditFile.Enabled = False
        tlstpCopyTo.Enabled = False
        If Not selecteDThumb Is Nothing Then
            tlstpCut.Enabled = True
            tlstpCopy.Enabled = True
            tlstpDeSelectAll.Enabled = True
            tlstpChangeCategory.Enabled = True
            tlstpExportto.Enabled = True
            tlstpRefreshThumbnail.Enabled = True
            tlstpRemoveCached.Enabled = True
            tlstpRemoveOriginal.Enabled = True
            tlspShowFile.Enabled = True
            tlstpEditFile.Enabled = True
            tlstpCopyTo.Enabled = True
        End If
        If tnailList.Count > 0 Then
            tlstpSelectAll.Enabled = True
        End If

        If Not IsSearch And Not (String.IsNullOrEmpty(CurrentCategory) Or String.IsNullOrEmpty(CurrentSubCategory)) Then
            If Not tnaiClipboard.GetClippedElements Is Nothing Then
                If tnaiClipboard.GetClippedElements.Count > 0 Then
                    tlstpPaste.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub ThumbnailContainer_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        If selecteDThumb Is Nothing Then Exit Sub
        Dim pv As New Photoview(selecteDThumb.FullPath)
        If pv.ShowDialog Then
            If pv.CoreImageChanged Then
                selecteDThumb.MakeThumb()
            End If
        End If
    End Sub

    Private Sub tlstpEditFile_DropDownOpening(sender As Object, e As EventArgs) Handles tlstpEditFile.DropDownOpening
        If IO.File.Exists(My.Settings.IME1) Then
            tlstpEditFileWithP1.Text = IO.Path.GetFileNameWithoutExtension(My.Settings.IME1)
        End If
        If IO.File.Exists(My.Settings.IME2) Then
            tlstpEditFileWithP2.Text = IO.Path.GetFileNameWithoutExtension(My.Settings.IME2)
        End If
        If IO.File.Exists(My.Settings.IME3) Then
            tlstpEditFileWithP3.Text = IO.Path.GetFileNameWithoutExtension(My.Settings.IME3)
        End If
    End Sub

    Public _ControlKey As Boolean
    Public _ShiftKey As Boolean
    Public Property ShiftKey As Boolean
        Get
            Return _ShiftKey
        End Get
        Set(value As Boolean)
            _ShiftKey = value
            If Not value Then
                begIx = -1
            End If
        End Set
    End Property
    Public Property ControlKey As Boolean
        Get
            Return _ControlKey
        End Get
        Set(value As Boolean)
            _ControlKey = value
        End Set
    End Property


End Class