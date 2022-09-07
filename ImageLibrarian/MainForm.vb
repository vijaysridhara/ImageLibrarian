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
Public Class MainForm
    Private WithEvents archHelper As ArchiveHelper

    Private selectedThumbNail As Thumbnail
    Private WithEvents chktmr As New Timer()
    Private CurrentArchive As String = "<Archive name>"
    Private WithEvents thumbProcessor As New ThumbnailProcessor()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tn As TreeNode = trvArchives.Nodes.Add("[[ROOT]]", "<Archive name>")
        tn.Tag = "ROOT"
        ' ARCHLOC = IO.Path.GetDirectoryName(Application.ExecutablePath)
        ARCHLOC = IIf(String.IsNullOrEmpty(My.Settings.ArchiveLocation), My.Computer.FileSystem.SpecialDirectories.MyDocuments, My.Settings.ArchiveLocation)
        COPYLOC = IIf(String.IsNullOrEmpty(My.Settings.CopyLocation), My.Computer.FileSystem.SpecialDirectories.MyDocuments, My.Settings.CopyLocation)
        EXPLOC = IIf(String.IsNullOrEmpty(My.Settings.ExportLocation), My.Computer.FileSystem.SpecialDirectories.MyPictures, My.Settings.ExportLocation)
        IMPFROM = IIf(String.IsNullOrEmpty(My.Settings.ImportFrom), My.Computer.FileSystem.SpecialDirectories.MyPictures, My.Settings.ImportFrom)
        LASTARCH = My.Settings.LastArchive
        cboShowtypes.SelectedIndex = 0
        archTimer.Interval = 200
        archTimer.Enabled = True
        If IO.Directory.Exists(ARCHLOC) Then
            If IO.Directory.Exists(ARCHLOC & "\CacheImages") Then
                If IO.File.Exists(ARCHLOC & "\ArchiveRepository.db") Then

                    Initialize(ARCHLOC)
                    Exit Sub
                End If
            End If
        End If
        chktmr.Interval = 1000
        chktmr.Enabled = True

    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
    End Sub
    Dim isinitialized As Boolean
    Public Sub Initialize(cachePath As String)
        Try
            Try
                If Not archHelper Is Nothing Then
                    archHelper.Cleanup()
                    RemoveHandler archHelper.DatabaseError, AddressOf archDBError
                    RemoveHandler archHelper.Progress, AddressOf ArchProgress
                End If
                ThumbnailContainer1.ClearImages()
                classifications.Clear()
                archives.Clear()
                nextKey = 0
            Catch ex As Exception

            End Try


            archHelper = New ArchiveHelper(cachePath)
            AddHandler archHelper.DatabaseError, AddressOf archDBError
            AddHandler archHelper.Progress, AddressOf ArchProgress

            If archHelper.ConnectionOpen Then
                isinitialized = True
                ThumbnailContainer1.ArchHelper = Me.archHelper
                thumbProcessor.ArchHelper = archHelper
                cboArchives.Items.Clear()
                If archHelper.GetArchiveList Then
                    For Each a As Arch In archives
                        If (a.IsPrivate And chkPrivate.Checked) Or a.IsPrivate = False Then cboArchives.Items.Add(a.Name)
                    Next
                End If
                If cboArchives.Items.Count > 0 Then
                    If Not String.IsNullOrEmpty(LASTARCH) Then
                        If cboArchives.Items.Contains(LASTARCH) Then
                            cboArchives.SelectedIndex = cboArchives.Items.IndexOf(LASTARCH)
                            Exit Sub
                        End If
                    End If
                    cboArchives.SelectedIndex = 0
                End If

            Else
                isinitialized = False
            End If

        Catch ex As Exception
            LogMessages("[ERROR]: " + ex.Message)
        End Try
    End Sub
    Dim msgQueue As New Queue(Of String)
    Private WithEvents archTimer As New Timer
    Private Sub archDBError(ex As Exception)
        msgQueue.Enqueue("[ERROR]: " + ex.Message)
    End Sub

    Private Sub pnlThumbnails_Scroll(sender As Object, e As ScrollEventArgs) Handles pnlThumbnails.Scroll

        ShowThumbnailsinVisibleArea()

    End Sub
    Private Sub ShowThumbnailsinVisibleArea()
        Dim topPos As Integer = pnlThumbnails.VerticalScroll.Value
        Dim botPos As Integer = pnlThumbnails.Height
        ThumbnailContainer1.SetControlView(topPos, topPos + botPos)
        ThumbnailContainer1.Invalidate()
    End Sub

    Private Sub pnlThumbnails_Resize(sender As Object, e As EventArgs) Handles pnlThumbnails.Resize
        Dim wid As Integer = pnlThumbnails.Width
        Dim maxNos As Integer = Math.Round(wid / ThumbnailContainer1.MaxThumbWidth)
        ThumbnailContainer1.maxColCount = maxNos
        pnlThumbnails.VerticalScroll.Value = 0
        pnlThumbnails.HorizontalScroll.Value = 0
        ThumbnailContainer1.Rearrange()

        ShowThumbnailsinVisibleArea()
    End Sub

    Private Sub ThumbnailContainer_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.ControlKey Then
            ThumbnailContainer1.ControlKey = False

        End If
        If e.KeyCode = Keys.ShiftKey Then
            ThumbnailContainer1.ShiftKey = False

        End If
    End Sub

    Private Sub ArchProgress(pct As Integer)
        ProgressBar1.Value = pct
        If pct = 100 Then
            ProgressBar1.Hide()

        Else
            ProgressBar1.Show()

        End If
        ProgressBar1.Refresh()
    End Sub
    Private Sub ThumbnailContainer1_Progress(pct As Integer) Handles ThumbnailContainer1.Progress
        ProgressBar1.Value = pct

        If pct = 100 Then
            ProgressBar1.Hide()
            butCacelOp.Hide()
        Else
            ProgressBar1.Show()
            butCacelOp.Show()
        End If
        ProgressBar1.Refresh()
    End Sub

    Dim progSelect As Boolean = False
    Private _cancelOp As Boolean
    Private Sub butImport_Click(sender As Object, e As EventArgs) Handles butImport.Click
        Dim selcat As String = "", selsubcat As String = ""
        If Not trvArchives.SelectedNode Is Nothing Then
            If Not trvArchives.SelectedNode Is trvArchives.Nodes("[[ROOT]]") Then
                If Not trvArchives.SelectedNode.Parent Is trvArchives.Nodes("[[ROOT]]") Then
                    selcat = trvArchives.SelectedNode.Parent.Text
                    selsubcat = trvArchives.SelectedNode.Text
                Else
                    selcat = trvArchives.SelectedNode.Text
                End If
            End If
        End If
        Dim self As New SelectType(selcat, selsubcat)

        Dim fd As New FolderBrowserDialog
        With fd
            .SelectedPath = My.Settings.ImportFrom

            If .ShowDialog = DialogResult.OK Then

                If self.ShowDialog = DialogResult.OK Then
                    IMPFROM = .SelectedPath
                    My.Settings.ImportFrom = .SelectedPath
                    My.Settings.Save()
                    Dim types As New List(Of String)
                    If self.chkJPEG.Checked Then
                        types.Add("*.jpeg")
                        types.Add("*.jpg")
                    End If
                    If self.chkPNG.Checked Then
                        types.Add("*.png")
                    End If
                    If self.chkBMP.Checked Then
                        types.Add("*.bmp")
                    End If
                    If self.chkGIF.Checked Then
                        types.Add("*.gif")


                    End If
                    butCacelOp.Show()
                    'ThumbnailContainer1.ClearImages()
                    Dim wid As Integer = pnlThumbnails.Width
                    Dim maxNos As Integer = Math.Round(wid / ThumbnailContainer1.MaxThumbWidth) 'The wid-10 is for scrollbar
                    ThumbnailContainer1.maxColCount = maxNos
                    'If self.chkSubfolders.Checked Then
                    ThumbnailContainer1.ClearImages()
                    subcatList.Clear()
                    If LoadImagesSilent(0, .SelectedPath, self.cboCat.Text, self.cboSubCat.Text, types, self.chkSubfolders.Checked) Then
                        If Not trvArchives.Nodes("[[ROOT]]").Nodes.ContainsKey(self.cboCat.Text) Then
                            trvArchives.Nodes("[[ROOT]]").Nodes.Add(self.cboCat.Text, self.cboCat.Text).Tag = self.cboCat.Text
                            classifications.Add(self.cboCat.Text, New Classification(self.cboCat.Text))
                        End If
                        For Each s As String In subcatList
                            If trvArchives.Nodes("[[ROOT]]").Nodes(self.cboCat.Text).Nodes.ContainsKey(s) Then Continue For
                            trvArchives.Nodes("[[ROOT]]").Nodes(self.cboCat.Text).Nodes.Add(s, s).Tag = s
                            classifications(self.cboCat.Text).AddSubCat(s)
                        Next
                    End If
                    trvArchives.SelectedNode = trvArchives.Nodes("[[ROOT]]").Nodes(self.cboCat.Text)
                    LogMessages("[info]: Completed loading folders *************************")
                    Exit Sub

                End If
            End If

        End With





    End Sub
    Private subcatList As New List(Of String)

    Private Function LoadImagesSilent(level As Integer, rootPath As String, cat As String, subcat As String, types As List(Of String), Optional subFolderas As Boolean = False) As Integer
        Try
            If _cancelOp Then Return 0
            Dim rowsFound As Integer = 0
            If subcat = "A Modern Fairytale" Then
                MsgBox("Hi")
            End If
            rowsFound = thumbProcessor.Massload(level, rootPath, types, cat, subcat, CurrentArchive)
            Dim dirs() As String = IO.Directory.GetDirectories(rootPath)
            For Each d As String In dirs
                Dim newsubcat As String = ""
                If level = 0 Then
                    newsubcat = IO.Path.GetFileName(d)
                ElseIf level >= 1 Then
                    newsubcat = subcat
                End If
                If subFolderas Then
                    rowsFound += LoadImagesSilent(level + 1, d, cat, newsubcat, types, subFolderas)
                Else

                End If

            Next
            If level = 0 And rowsFound > 0 Then AddNodes(cat, subcat)
            If level = 1 And rowsFound > 0 Then AddNodes(cat, subcat)
            Return rowsFound
        Catch ex As Exception
            LogMessages("[ERROR]: " & ex.Message)
            Return 0
        End Try
    End Function
    Private Sub AddNodes(cat As String, subcat As String)
        If Not trvArchives.Nodes("[[ROOT]]").Nodes.ContainsKey(cat) Then
            trvArchives.Nodes("[[ROOT]]").Nodes.Add(cat, cat).Tag = cat
            classifications.Add(cat, New Classification(cat))
        End If

        If trvArchives.Nodes("[[ROOT]]").Nodes(cat).Nodes.ContainsKey(subcat) Then Exit Sub
        trvArchives.Nodes("[[ROOT]]").Nodes(cat).Nodes.Add(subcat, subcat).Tag = subcat
        classifications(cat).SubCategories.Add(subcat)
        trvArchives.Nodes("[[ROOT]]").Nodes(cat).Expand()
    End Sub
    Private Sub ThumbnailContainer1_Message(msg As String) Handles ThumbnailContainer1.Message
        If msg = "[LOAD COMPLETED]" Then
            isloading = False

            Exit Sub
        ElseIf msg = "[LOAD BEGAN]" Then
            isloading = True

            Exit Sub
        End If
        msgQueue.Enqueue("[info]: " + msg)

    End Sub

    Private Sub ThumbnailContainer1_Errored(ex As Exception) Handles ThumbnailContainer1.Errored
        msgQueue.Enqueue("[ERROR]: " + ex.Message)
    End Sub
    Private Sub LogMessages(msg As String)
        txtLog.Text += msg & vbCrLf
        txtLog.SelectionStart = txtLog.Text.Length
        txtLog.ScrollToCaret()
        txtLog.Refresh()
    End Sub

    Private Sub trvArchives_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvArchives.AfterSelect
        Try
            If draggingBegan Then Exit Sub
            If progSelect Then Exit Sub
            If Not ThumbnailContainer1.IsCurrentlyLoading Then

                ThumbnailContainer1.CancelOperation = True
                While ThumbnailContainer1.IsCurrentlyLoading
                    Threading.Thread.Sleep(100)
                    Application.DoEvents()
                End While
            End If
            If e.Node.Tag = "ROOT" Then

                ThumbnailContainer1.ClearImages()
            ElseIf e.Node.Parent.Tag = "ROOT" Then

                ThumbnailContainer1.ClearImages()
            Else

                ThumbnailContainer1.GetImagesfromCache(e.Node.Parent.Tag, e.Node.Tag)
            End If

        Catch ex As Exception
            LogMessages("[ERROR]: " + ex.Message)
        End Try
    End Sub

    Private Sub ThumbnailContainer1_ThumbnailsCleared() Handles ThumbnailContainer1.ThumbnailsCleared
        selectedThumbNail = Nothing
        txtComments.Clear()
        txtExif.Clear()
        txtTags.Clear()
        txtComments.Enabled = False
        txtExif.Enabled = False
        txtTags.Enabled = False
        lblWarn1.Hide()
        lblWarn2.Hide()
        butUpdateComments.Enabled = False
        butUpdateTags.Enabled = False
        txtFile.Hide()
        butCopyFilelink.Hide()
    End Sub

    Private Sub ThumbnailContainer1_ThumbnailSelected(c As Thumbnail) Handles ThumbnailContainer1.ThumbnailSelected
        selectedThumbNail = c
        txtComments.Enabled = True
        txtExif.Enabled = True
        txtTags.Enabled = True
        butUpdateComments.Enabled = False
        butUpdateTags.Enabled = False
        txtComments.Text = c.Comment
        txtTags.Text = c.Tags
        lblWarn1.Hide()
        lblWarn2.Hide()
        txtFile.Text = c.FullPath
        txtFile.Show()
        butCopyFilelink.Show()
        txtExif.Clear()
        For Each prop As PropItem In c.MetaData.Values
            txtExif.Text += prop.Name & ": " & prop.Value & vbCrLf
        Next

    End Sub

    Private Sub txtTags_TextChanged(sender As Object, e As EventArgs) Handles txtTags.TextChanged
        lblWarn1.Image = My.Resources.excl
        lblWarn1.Show()
        butUpdateTags.Enabled = True

    End Sub

    Private Sub txtComments_TextChanged(sender As Object, e As EventArgs) Handles txtComments.TextChanged
        lblWarn2.Image = My.Resources.excl
        lblWarn2.Show()
        butUpdateComments.Enabled = True
    End Sub

    Private Sub butUpdateTags_Click(sender As Object, e As EventArgs) Handles butUpdateTags.Click
        selectedThumbNail.Tags = txtTags.Text.Trim
        If archHelper.UpdateThumb("tags", selectedThumbNail) Then
            butUpdateTags.Enabled = False
            lblWarn1.Image = My.Resources.tick
        End If

    End Sub

    Private Sub butUpdateComments_Click(sender As Object, e As EventArgs) Handles butUpdateComments.Click
        selectedThumbNail.Comment = txtComments.Text.Trim
        If archHelper.UpdateThumb("comments", selectedThumbNail) Then
            butUpdateComments.Enabled = False
            lblWarn2.Image = My.Resources.tick
        End If

    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        ThumbnailContainer1.ClearImages()

        If Not archHelper Is Nothing Then
            archHelper.Cleanup()
            RemoveHandler archHelper.DatabaseError, AddressOf archDBError
            RemoveHandler archHelper.Progress, AddressOf ArchProgress


        End If
        chktmr.Dispose()
        archTimer.Enabled = False
        archTimer.Dispose()
    End Sub

    Private Sub butCopyFilelink_Click(sender As Object, e As EventArgs) Handles butCopyFilelink.Click
        Clipboard.SetText(txtFile.Text)
    End Sub

    Private Sub ThumbnailContainer1_ThumbnailsUnselected()
        selectedThumbNail = Nothing
        txtComments.Clear()
        txtExif.Clear()
        txtTags.Clear()
        txtComments.Enabled = False
        txtExif.Enabled = False
        txtTags.Enabled = False
        lblWarn1.Hide()
        lblWarn2.Hide()
        butUpdateComments.Enabled = False
        butUpdateTags.Enabled = False
        txtFile.Hide()
        butCopyFilelink.Hide()
    End Sub

    Private Sub butImportImages_Click(sender As Object, e As EventArgs) Handles butImportImages.Click
        Try
            Dim selcat As String = "", selsubcat As String = ""
            If Not trvArchives.SelectedNode Is Nothing Then
                If Not trvArchives.SelectedNode Is trvArchives.Nodes("[[ROOT]]") Then
                    If Not trvArchives.SelectedNode.Parent Is trvArchives.Nodes("[[ROOT]]") Then
                        selcat = trvArchives.SelectedNode.Parent.Text
                        selsubcat = trvArchives.SelectedNode.Text
                    Else
                        selcat = trvArchives.SelectedNode.Text
                    End If
                End If
            End If
            Dim self As New SelectType(selcat, selsubcat)


            Dim fd As New OpenFileDialog

            With fd
                .InitialDirectory = My.Settings.ImportFrom
                .Filter = "JPEG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|GIF Files(*.gif)|*.gif"
                .FilterIndex = 0
                .Multiselect = True
                If .ShowDialog = DialogResult.OK Then
                    If trvArchives.SelectedNode.Tag <> "ROOT" Then
                        self.cboCat.Text = trvArchives.SelectedNode.Text
                    End If
                    Dim ext As String = IO.Path.GetExtension(.FileName)
                    self.GroupBox1.Enabled = False
                    Select Case fd.FilterIndex
                        Case 0
                            self.chkBMP.Checked = False
                            self.chkPNG.Checked = False
                            self.chkJPEG.Checked = True
                            self.chkGIF.Checked = False
                        Case 1
                            self.chkBMP.Checked = False
                            self.chkPNG.Checked = True
                            self.chkJPEG.Checked = False
                            self.chkGIF.Checked = False
                        Case 2
                            self.chkBMP.Checked = True
                            self.chkPNG.Checked = False
                            self.chkJPEG.Checked = False
                            self.chkGIF.Checked = False
                        Case 3
                            self.chkBMP.Checked = False
                            self.chkPNG.Checked = False
                            self.chkJPEG.Checked = False
                            self.chkGIF.Checked = True

                    End Select
                    If self.ShowDialog = DialogResult.OK Then
                        Dim wid As Integer = pnlThumbnails.Width
                        Dim maxNos As Integer = Math.Round(wid / ThumbnailContainer1.MaxThumbWidth) 'The wid-10 is for scrollbar
                        ThumbnailContainer1.maxColCount = maxNos

                        If thumbProcessor.AddIndividualImages(.FileNames, self.cboCat.Text.Trim, self.cboSubCat.Text.Trim, CurrentArchive) Then
                            If Not trvArchives.Nodes("[[ROOT]]").Nodes.ContainsKey(self.cboCat.Text) Then
                                trvArchives.Nodes("[[ROOT]]").Nodes.Add(self.cboCat.Text, self.cboCat.Text).Tag = self.cboCat.Text
                                classifications.Add(self.cboCat.Text, New Classification(self.cboCat.Text))
                            End If

                            If Not trvArchives.Nodes("[[ROOT]]").Nodes(self.cboCat.Text).Nodes.ContainsKey(self.cboSubCat.Text) Then
                                trvArchives.Nodes("[[ROOT]]").Nodes(self.cboCat.Text).Nodes.Add(self.cboSubCat.Text, self.cboSubCat.Text).Tag = self.cboSubCat.Text
                                classifications(self.cboCat.Text).AddSubCat(self.cboSubCat.Text)
                            End If
                            ThumbnailContainer1.ClearImages()
                            trvArchives_AfterSelect(trvArchives, New TreeViewEventArgs(trvArchives.Nodes("[[ROOT]]").Nodes(self.cboCat.Text).Nodes(self.cboSubCat.Text)))
                        End If

                        End If
                    If .FileNames.Length > 0 Then
                        IMPFROM = IO.Path.GetDirectoryName(.FileNames(0))
                        My.Settings.ImportFrom = IO.Path.GetDirectoryName(.FileNames(0))
                        My.Settings.Save()
                    End If
                End If
            End With
        Catch ex As Exception
            LogMessages("[ERROR]: " & ex.Message)
        End Try
    End Sub

    Private Sub pnlThumbnails_MouseWheel(sender As Object, e As MouseEventArgs) Handles pnlThumbnails.MouseWheel

        'Dim noTextLines As Integer = e.Delta * SystemInformation.MouseWheelScrollLines / 120
        'Dim noPixes As Integer = noTextLines * pnlThumbnails.Font.Size
        'pnlThumbnails.VerticalScroll.Value += noPixes
        ShowThumbnailsinVisibleArea()
    End Sub



    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlThumbnails_Resize(Nothing, Nothing)
    End Sub

    Private Sub butSearch_Click(sender As Object, e As EventArgs) Handles butSearch.Click
        Try
            Dim txtS As String = txtSearch.Text.Trim
            If String.IsNullOrEmpty(txtS) Then Exit Sub
            ThumbnailContainer1.IsSearch = True
            ThumbnailContainer1.SearchText(txtS)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ThumbnailContainer1_CategoryChanged(cat As String, subcat As String) Handles ThumbnailContainer1.CategoryChanged
        If classifications.ContainsKey(cat) Then
            If classifications(cat).SubCategories.Contains(subcat) Then
                Exit Sub
            Else
                classifications(cat).SubCategories.Add(subcat)
                trvArchives.Nodes("[[ROOT]]").Nodes(cat).Nodes.Add(subcat, subcat).Tag = subcat
            End If
        Else
            Dim NC As New Classification(cat)
            NC.SubCategories.Add(subcat)
            Dim tn As TreeNode = trvArchives.Nodes("[[ROOT]]").Nodes.Add(cat, cat)
            tn.Nodes.Add(subcat, subcat).Tag = subcat
        End If

    End Sub

    Private Sub butExport_Click(sender As Object, e As EventArgs) Handles butExport.Click
        ThumbnailContainer1.BeginExport()
    End Sub

    Private Sub butSettings_Click(sender As Object, e As EventArgs) Handles butSettings.Click
        Dim oldArchLoc As String = ARCHLOC
        Dim setT As New Settings(archHelper)
        If setT.ShowDialog() = DialogResult.OK Then
            If oldArchLoc.ToLower <> setT.txtLocation.Text.ToLower Then
                trvArchives.Nodes("[[ROOT]]").Nodes.Clear()
                My.Settings.ArchiveLocation = setT.txtLocation.Text
                ARCHLOC = My.Settings.ArchiveLocation
                My.Settings.Save()
                Initialize(ARCHLOC)
                cboArchives.Items.Clear()
                For Each a As Arch In archives
                    If (a.IsPrivate And chkPrivate.Checked) Or a.IsPrivate = False Then cboArchives.Items.Add(a.Name)

                Next
                If cboArchives.Items.Count > 0 Then
                    cboArchives.SelectedIndex = 0
                End If
            End If
        End If
        For Each a As Arch In archives
            If cboArchives.Items.Contains(a.Name) Then Continue For
            If (a.IsPrivate And chkPrivate.Checked) Or a.IsPrivate = False Then cboArchives.Items.Add(a.Name)
        Next
        Dim notfounditems As New List(Of String)
        For Each b As String In cboArchives.Items
            Dim fnd As Boolean = False
            For Each a As Arch In archives
                If a.Name.ToLower = b.ToLower Then
                    fnd = True
                End If
            Next
            If Not fnd Then
                notfounditems.Add(b)
            End If
        Next
        For Each i As String In notfounditems
            cboArchives.Items.Remove(i)
        Next
        If cboArchives.Text <> CurrentArchive Then
            ThumbnailContainer1.ClearImages()
            CurrentArchive = cboArchives.Text
            ThumbnailContainer1.CurrentArchive = ""
            trvArchives.Nodes("[[ROOT]]").Nodes.Clear()
        End If
    End Sub

    Private Sub chktmr_Tick(sender As Object, e As EventArgs) Handles chktmr.Tick
        chktmr.Enabled = False
        If MsgBox("The archive directory is not initialized, select a folder which can " & vbCrLf &
                  "easily accommodate about 500mb to 10GB of cache data, I would suggest SSD though",
                  MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation, "ImageLibrarian") = MsgBoxResult.Cancel Then
            Me.Close()
            End
        End If
        Dim setT As New Settings(archHelper)
        If setT.ShowDialog() = DialogResult.OK Then
            If ARCHLOC.ToLower <> setT.txtLocation.Text.ToLower Then
                ARCHLOC = setT.txtLocation.Text.ToLower
                My.Settings.ArchiveLocation = ARCHLOC
                My.Settings.Save()
            End If
            If IO.Directory.Exists(ARCHLOC) Then
                If IO.Directory.Exists(ARCHLOC & "\CacheImages") Then
                    If IO.File.Exists(ARCHLOC & "\ArchiveRepository.db") Then
                        Initialize(ARCHLOC)

                        Exit Sub
                    Else
                        If IO.File.Exists(ARCHLOC & "\ArchiveRepository.db") = False Then
                            Dim fst As IO.BinaryWriter = New IO.BinaryWriter(New IO.FileStream(ARCHLOC & "\ArchiveRepository.db", IO.FileMode.CreateNew))
                            fst.Write(My.Resources.ArchiveRepository)
                            fst.Dispose()
                            Initialize(ARCHLOC)
                        End If
                        If IO.Directory.Exists(ARCHLOC & "\CacheImages") = False Then
                            My.Computer.FileSystem.CreateDirectory(ARCHLOC & "\CacheImages")

                        End If

                    End If
                Else
                    If IO.File.Exists(ARCHLOC & "\ArchiveRepository.db") = False Then
                        Dim fst As IO.BinaryWriter = New IO.BinaryWriter(New IO.FileStream(ARCHLOC & "\ArchiveRepository.db", IO.FileMode.CreateNew))
                        fst.Write(My.Resources.ArchiveRepository)
                        fst.Dispose()
                        Initialize(ARCHLOC)
                    End If
                    If IO.Directory.Exists(ARCHLOC & "\CacheImages") = False Then
                        My.Computer.FileSystem.CreateDirectory(ARCHLOC & "\CacheImages")

                    End If
                End If
            Else
                MsgBox("The location doesn't exist, please create the location or change the location and try again", MsgBoxStyle.Information)
                Exit Sub
            End If

        End If

    End Sub

    Dim isloading As Boolean
    Private Sub archTimer_Tick(sender As Object, e As EventArgs) Handles archTimer.Tick
        If Not isloading Then
            butCacelOp.Hide()

        ElseIf isloading Then
            butCacelOp.Show()

        End If
        While msgQueue.Count > 0

            LogMessages(msgQueue.Dequeue)

        End While
    End Sub
    Dim passfail As Boolean
    Private Sub cboArchives_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboArchives.SelectedIndexChanged
        If cboArchives.SelectedIndex = -1 Then
            butExport.Enabled = False
            butImport.Enabled = False
            butImportImages.Enabled = False
            ThumbnailContainer1.ClearImages()
            classifications.Clear()
            CurrentArchive = ""
            ThumbnailContainer1.CurrentArchive = ""
            trvArchives.Nodes("[[ROOT]]").Nodes.Clear()
        Else
            If passfail Then
                passfail = False
                Exit Sub
            End If
            For Each ar As Arch In archives
                If ar.Name.ToLower = cboArchives.Text.ToLower Then
                    If ar.IsPrivate Then
                        Dim cp As New CheckPasswor(ar.Password)
                        If cp.ShowDialog = DialogResult.Cancel Then
                            passfail = True
                            cboArchives.Text = CurrentArchive
                            Exit Sub
                        End If
                    End If
                End If
            Next
            ThumbnailContainer1.ClearImages()
            classifications.Clear()
            CurrentArchive = cboArchives.Text
            ThumbnailContainer1.CurrentArchive = cboArchives.Text
            If archHelper.GetCategories(cboArchives.Text) = False Then
                MsgBox("Could not get categories from the cache, so exiting", MsgBoxStyle.Critical)
                Me.Close()
                End
                Exit Sub
            End If
            Dim rootNd As TreeNode = trvArchives.Nodes("[[ROOT]]")

            rootNd.Nodes.Clear()
            rootNd.Text = CurrentArchive
            For Each el As Classification In classifications.Values
                Dim catNode As TreeNode = rootNd.Nodes.Add(el.Category, el.Category)
                catNode.Tag = el.Category
                For Each s As String In el.SubCategories
                    Dim scatNode As TreeNode = catNode.Nodes.Add(s, s)
                    scatNode.Tag = s
                Next
            Next
            My.Settings.LastArchive = CurrentArchive
            My.Settings.Save()
            rootNd.Expand()
            trvArchives.SelectedNode = rootNd
            butExport.Enabled = True
            butImport.Enabled = True
            butImportImages.Enabled = True
            LogMessages("[Info]: Current Archive is set to [" & CurrentArchive & "]")
        End If
    End Sub

    Private Sub chkPrivate_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrivate.CheckedChanged
        LoadArchiveCombo()
    End Sub
    Private Sub LoadArchiveCombo()
        If chkPrivate.Checked Then
            Dim lastArch As String = cboArchives.Text
            cboArchives.Items.Clear()
            For Each a As Arch In archives
                cboArchives.Items.Add(a.Name)
            Next
            cboArchives.SelectedItem = lastArch
        Else
            Dim lastArch As String = cboArchives.Text
            cboArchives.Items.Clear()
            For Each a As Arch In archives
                If a.IsPrivate = False Then cboArchives.Items.Add(a.Name)
                If a.Name = lastArch And a.IsPrivate Then
                    lastArch = ""
                End If
            Next
            If lastArch = "" Then
                If cboArchives.Items.Count > 0 Then
                    cboArchives.SelectedIndex = 0
                End If
            Else
                cboArchives.SelectedItem = lastArch
            End If
        End If
    End Sub

    Private Sub ThumbnailContainer1_KeyDown(sender As Object, e As KeyEventArgs) Handles ThumbnailContainer1.KeyDown

    End Sub

    Private Sub ThumbnailContainer1_GotFocus(sender As Object, e As EventArgs) Handles ThumbnailContainer1.GotFocus
        Debug.Print("Got focus")
    End Sub

    Private Sub ThumbnailContainer1_LostFocus(sender As Object, e As EventArgs) Handles ThumbnailContainer1.LostFocus
        Debug.Print("Lost focus")
    End Sub

    Private Sub butAbout_Click(sender As Object, e As EventArgs) Handles butAbout.Click
        Dim ab As New About
        ab.ShowDialog()
    End Sub

    Dim oldLabel As String = ""
    Dim editedLabelType As String
    Dim editedParent As String = ""
    Dim newLabel As String = ""
    Private Sub trvArchives_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles trvArchives.BeforeLabelEdit
        If e.Node.Tag = "ROOT" Then e.CancelEdit = True : Exit Sub
        If ThumbnailContainer1.IsCurrentlyLoading Then e.CancelEdit = True
    End Sub

    Private Sub trvArchives_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles trvArchives.AfterLabelEdit
        If e.Node.Tag = "ROOT" Then e.CancelEdit = True : Exit Sub
        If ThumbnailContainer1.IsCurrentlyLoading Then e.CancelEdit = True : Exit Sub
        If e.Node.Tag = e.Label Or String.IsNullOrEmpty(e.Label) Then
            e.CancelEdit = True
            Exit Sub
        End If
        If e.Node.Parent.Tag = "ROOT" Then
            editedLabelType = "Category"
            oldLabel = e.Node.Tag
            editedParent = ""
            newLabel = e.Label
        Else
            editedLabelType = "Subcat"
            oldLabel = e.Node.Tag
            editedParent = e.Node.Parent.Tag
            newLabel = e.Label
        End If
        If archHelper.UpdateCategory(editedLabelType, editedParent, oldLabel, newLabel, CurrentArchive) Then
            e.Node.Tag = newLabel

            ThumbnailContainer1.ClearImages()
            trvArchives_AfterSelect(Nothing, New TreeViewEventArgs(e.Node))
            If editedLabelType = "Subcat" Then
                Dim classi As Classification = classifications(editedParent)
                If classi.SubCategories.Contains(oldLabel) Then
                    classi.SubCategories.Remove(oldLabel)
                    classi.SubCategories.Add(newLabel)
                End If
            ElseIf editedLabelType = "Category" Then
                Dim classi As Classification = classifications(oldLabel)
                classifications.Remove(oldLabel)
                classi.Category = newLabel
                classifications.Add(newLabel, classi)
            End If
        Else
            e.CancelEdit = True
        End If
    End Sub

    Private Sub txtFile_TextChanged(sender As Object, e As EventArgs) Handles txtFile.TextChanged

    End Sub

    Private Sub pnlThumbnails_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlThumbnails.MouseDown
        txtFocusBox.Focus()
    End Sub

    Private Sub ThumbnailContainer1_MouseDown(sender As Object, e As MouseEventArgs) Handles ThumbnailContainer1.MouseDown
        txtFocusBox.Focus()
    End Sub

    Private Sub cboShowtypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboShowtypes.SelectedIndexChanged
         Select Case cboShowtypes.SelectedIndex
            Case 0
                ThumbnailContainer1.Showtypes = "all"
            Case 1
                ThumbnailContainer1.Showtypes = "jpg"
            Case 2
                ThumbnailContainer1.Showtypes = "png"
            Case 3
                ThumbnailContainer1.Showtypes = "bmp"
            Case 4
                ThumbnailContainer1.Showtypes = "gif"
        End Select
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub butCacelOp_Click(sender As Object, e As EventArgs) Handles butCacelOp.Click
        ThumbnailContainer1.CancelOperation = True
        If thumbProcessor.IsCurrentlyLoading Then
            thumbProcessor.CancelOperation = True
        End If
        butCacelOp.Hide()
    End Sub

    Private Sub txtFocusBox_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFocusBox.KeyDown
        If e.KeyCode = Keys.ControlKey Then
            ThumbnailContainer1.ControlKey = True

        End If
        If e.KeyCode = Keys.ShiftKey Then
            ThumbnailContainer1.ShiftKey = True
        End If

        Select Case e.KeyCode
            Case Keys.X
                If e.Control Then
                    ThumbnailContainer1.Cut()
                End If
            Case Keys.C
                If e.Control Then
                    ThumbnailContainer1.Copy()
                End If
            Case Keys.A
                If e.Control Then
                    ThumbnailContainer1.SelectAll()
                End If
            Case Keys.V
                If e.Control Then
                    ThumbnailContainer1.Paste()
                End If
            Case Keys.Delete
                If e.Control Then
                    ThumbnailContainer1.DeleteFile()
                Else
                    ThumbnailContainer1.DeleteThumb()
                End If

            Case Keys.F5
                If e.Control Then
                    ThumbnailContainer1.RefreshThumb()
                End If

            Case Keys.Enter
                ThumbnailContainer1.Openfile()
            Case Keys.Right
                ThumbnailContainer1.MoveRight()
            Case Keys.Down
                ThumbnailContainer1.MoveDown()
            Case Keys.Up
                ThumbnailContainer1.MoveUp()
            Case Keys.Left
                ThumbnailContainer1.MoveLeft()
        End Select
        e.Handled = True
        e.SuppressKeyPress = True

    End Sub

    Private Sub MainForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        e.Handled = True
    End Sub

    Private Sub ThumbnailContainer1_ThumbnailsScrolled() Handles ThumbnailContainer1.ThumbnailsScrolled

        ShowThumbnailsinVisibleArea()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSearch_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub thumbProcessor_Errored(ex As Exception) Handles thumbProcessor.Errored
        msgQueue.Enqueue("[ERROR]: " + ex.Message)
    End Sub

    Private Sub thumbProcessor_Message(msg As String) Handles thumbProcessor.Message

        msgQueue.Enqueue("[info]: " + msg)
    End Sub

    Private Sub thumbProcessor_Loading(running As Boolean) Handles thumbProcessor.Loading
        isloading = running
    End Sub

    Private Sub thumbProcessor_Progress(pct As Integer) Handles thumbProcessor.Progress
        ProgressBar1.Value = pct
        If pct = 100 Then
            ProgressBar1.Hide()
            butCacelOp.Hide()
        Else
            ProgressBar1.Show()
            butCacelOp.Show()
        End If
    End Sub

    Private Sub ctxTree_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxTree.Opening
        If trvArchives.Nodes.ContainsKey("[[ROOT]]") = False Then
            ImportHereToolStripMenuItem.Enabled = False
            AddImagesHereToolStripMenuItem.Enabled = False
            RenameToolStripMenuItem.Enabled = False
            ExportThisToolStripMenuItem.Enabled = False
            DeleteToolStripMenuItem.Enabled = False
        Else
            If trvArchives.SelectedNode Is Nothing Then

                ImportHereToolStripMenuItem.Enabled = False
                AddImagesHereToolStripMenuItem.Enabled = False
                RenameToolStripMenuItem.Enabled = False
                ExportThisToolStripMenuItem.Enabled = False
                DeleteToolStripMenuItem.Enabled = False

                Exit Sub
            ElseIf trvArchives.SelectedNode Is trvArchives.Nodes("[[ROOT]]") Then
                ImportHereToolStripMenuItem.Enabled = True
                AddImagesHereToolStripMenuItem.Enabled = True
                RenameToolStripMenuItem.Enabled = False
                ExportThisToolStripMenuItem.Enabled = False
                DeleteToolStripMenuItem.Enabled = False

            ElseIf trvArchives.SelectedNode.Parent Is trvArchives.Nodes("[[ROOT]]") Then
                ImportHereToolStripMenuItem.Enabled = True
                AddImagesHereToolStripMenuItem.Enabled = True
                RenameToolStripMenuItem.Enabled = True
                ExportThisToolStripMenuItem.Enabled = False
                DeleteToolStripMenuItem.Enabled = True
            Else
                ImportHereToolStripMenuItem.Enabled = True
                AddImagesHereToolStripMenuItem.Enabled = True
                RenameToolStripMenuItem.Enabled = True
                ExportThisToolStripMenuItem.Enabled = True
                DeleteToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub

    Private Sub ImportHereToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportHereToolStripMenuItem.Click
        butImport_Click(Nothing, Nothing)
    End Sub

    Private Sub AddImagesHereToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddImagesHereToolStripMenuItem.Click
        butImportImages_Click(Nothing, Nothing)
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click

        trvArchives.SelectedNode.BeginEdit()
    End Sub

    Private Sub ExportThisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportThisToolStripMenuItem.Click
        ThumbnailContainer1.BeginExport()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim cat As String = ""
        Dim subcat As String = ""


        If trvArchives.SelectedNode.Parent Is trvArchives.Nodes("[[ROOT]]") Then
            cat = trvArchives.SelectedNode.Text
        Else
            cat = trvArchives.SelectedNode.Parent.Text
            subcat = trvArchives.SelectedNode.Text
        End If
        If subcat = "" Then
            If MsgBox("This would delete the entire category and subcategories from cache. Do you want to proceeed?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Dim l As List(Of String) = archHelper.RemoveThumbs(cat, CurrentArchive)
                LogMessages("[info]: Cleaning cached files...")
                LogMessages("[info]: There are " & l.Count & " cached images to be deleted.hold on...")
                Dim cnt As Integer = 0
                For Each s As String In l

                    Try
                        cnt += 1
                        If cnt Mod 10 = 0 Then
                            ProgressBar1.Value = Math.Floor(CInt(cnt / l.Count * 100))
                            ProgressBar1.Refresh()
                        End If
                        My.Computer.FileSystem.DeleteFile(ARCHLOC & "\CacheImages\" & s)
                    Catch ex As Exception
                        LogMessages("[ERROR]: " & ex.Message & " Cached file: " & s)
                    End Try
                Next
                LogMessages("[info]: Completed cleanup")
                Dim tn As TreeNode = trvArchives.SelectedNode
                classifications.Remove(tn.Text)
                tn.Remove()
            Else
                Exit Sub

            End If
        Else
            If MsgBox("This would delete the selected subcategory from cache. Do you want to proceeed?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Dim l As List(Of String) = archHelper.RemoveThumbs(cat, CurrentArchive, subcat)
                LogMessages("[info]: Cleaning cached files...")
                If Not ThumbnailContainer1.IsSearch Then
                    ThumbnailContainer1.ClearImages()
                End If
                LogMessages("[info]: There are " & l.Count & " cached images to be deleted.hold on...")
                Dim cnt As Integer = 0
                For Each s As String In l
                    Try
                        cnt += 1
                        If cnt Mod 10 = 0 Then
                            ProgressBar1.Value = Math.Floor(CInt(cnt / l.Count * 100))
                            ProgressBar1.Refresh()
                        End If
                        My.Computer.FileSystem.DeleteFile(ARCHLOC & "\CacheImages\" & s)
                    Catch ex As Exception
                        LogMessages("[ERROR]: " & ex.Message & " Cached file: " & s)
                    End Try
                Next
                LogMessages("[info]: Completed cleanup")
                Dim tn As TreeNode = trvArchives.SelectedNode
                Dim pn As TreeNode = tn.Parent
                classifications(pn.Text).SubCategories.Remove(tn.Text)
                tn.Remove()
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private draggingBegan As Boolean
    Private Sub trvArchives_DragEnter(sender As Object, e As DragEventArgs) Handles trvArchives.DragEnter
        e.Effect = e.AllowedEffect
        draggingBegan = True
        'If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then

        '    'TreeNode found allow move effect
        '    e.Effect = DragDropEffects.Move
        'Else
        '    'No TreeNode found, prevent move
        '    e.Effect = DragDropEffects.None
        'End If
    End Sub

    Private Sub trvArchives_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles trvArchives.ItemDrag
        If e.Button = MouseButtons.Left Then
            If CType(e.Item, TreeNode).Tag = "ROOT" Then
            ElseIf CType(e.Item, TreeNode).Parent.Tag = "ROOT" Then
            Else
                DoDragDrop(e.Item, DragDropEffects.Move)
                draggingBegan = True
            End If
        End If

    End Sub

    Private Sub trvArchives_DragDrop(sender As Object, e As DragEventArgs) Handles trvArchives.DragDrop
        Dim targPoint As Point = trvArchives.PointToClient(New Point(e.X, e.Y))
        Dim targNode As TreeNode = trvArchives.GetNodeAt(targPoint)
        Dim srcNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        If Not srcNode Is targNode And ValidNode(targNode, srcNode) Then
            If e.Effect = DragDropEffects.Move Then
                If archHelper.ChangeCat(srcNode.Parent.Text, srcNode.Text, targNode.Text, CurrentArchive) Then
                    classifications(srcNode.Parent.Text).SubCategories.Remove(srcNode.Text)
                    srcNode.Remove()
                    If Not targNode.Nodes.ContainsKey(srcNode.Text) Then
                        targNode.Nodes.Add(srcNode)
                        classifications(targNode.Text).SubCategories.Add(srcNode.Text)
                    End If
                    ThumbnailContainer1.ClearImages()
                    draggingBegan = False
                    trvArchives.SelectedNode = srcNode
                    'trvArchives_AfterSelect(Nothing, New TreeViewEventArgs(targNode.Nodes(srcNode.Text)))

                End If
            End If
        End If
        draggingBegan = False
    End Sub

    Private Sub trvArchives_DragOver(sender As Object, e As DragEventArgs) Handles trvArchives.DragOver
        Dim targPoint As Point = trvArchives.PointToClient(New Point(e.X, e.Y))
        trvArchives.SelectedNode = trvArchives.GetNodeAt(targPoint)
    End Sub
    Private Function ValidNode(parNode As TreeNode, childNode As TreeNode) As Boolean
        If childNode.Parent Is Nothing Then Return False
        If childNode.Parent Is parNode Then Return False
        If parNode.Parent Is Nothing Then Return False
        If parNode.Parent Is trvArchives.Nodes("[[ROOT]]") Then Return True
        Return False
    End Function

    Private Sub trvArchives_MouseDown(sender As Object, e As MouseEventArgs) Handles trvArchives.MouseDown
        draggingBegan = False
    End Sub

    Private Sub trvArchives_MouseUp(sender As Object, e As MouseEventArgs) Handles trvArchives.MouseUp

    End Sub

    Private Sub txtFocusBox_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFocusBox.KeyUp
        If e.KeyCode = Keys.ControlKey Then
            ThumbnailContainer1.ControlKey = False

        End If
        If e.KeyCode = Keys.ShiftKey Then
            ThumbnailContainer1.ShiftKey = False
        End If

    End Sub

    Private Sub archHelper_DatabaseError(ex As Exception) Handles archHelper.DatabaseError
        msgQueue.Enqueue("[DBERROR]: " & ex.Message)
    End Sub


End Class
