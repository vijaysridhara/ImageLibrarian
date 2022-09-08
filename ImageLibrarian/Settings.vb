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
Friend Class Settings
    Dim archH As ArchiveHelper
    Public Sub New(archHelper As ArchiveHelper)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.archH = archHelper
        If archH Is Nothing Then
            butAdd.Enabled = False
            butDelete.Enabled = False
            butModify.Enabled = False
            chkPrivate.Enabled = False
            ListView1.Enabled = False
            txtArchName.Enabled = False
        End If
    End Sub
    Private Sub butBrowse_Click(sender As Object, e As EventArgs) Handles butBrowse.Click
        Dim fdb As New FolderBrowserDialog
        If Not String.IsNullOrEmpty(txtLocation.Text) Then
            fdb.SelectedPath = txtLocation.Text
        End If
        If fdb.ShowDialog = DialogResult.OK Then
            txtLocation.Text = fdb.SelectedPath

            If IO.File.Exists(fdb.SelectedPath & "\ArchiveRepository.db") = False Then
                Dim fst As IO.BinaryWriter = New IO.BinaryWriter(New IO.FileStream(fdb.SelectedPath & "\ArchiveRepository.db", IO.FileMode.CreateNew))
                fst.Write(My.Resources.ArchiveRepository)
                fst.Dispose()
            End If
            If IO.Directory.Exists(fdb.SelectedPath & "\CacheImages") = False Then
                My.Computer.FileSystem.CreateDirectory(fdb.SelectedPath & "\CacheImages")

            End If
            MsgBox("This requires cache initialization. Click OK, and reopen settings to add archive names to the repository", MsgBoxStyle.Information)
            butAdd.Enabled = False
            butDelete.Enabled = False
            butModify.Enabled = False
            chkPrivate.Enabled = False
            ListView1.Enabled = False
            txtArchName.Enabled = False
            Exit Sub
        End If


    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLocation.Text = ARCHLOC
        txtImageEditor2.Text = My.Settings.IME2
        txtimgEditor1.Text = My.Settings.IME1

        If Not archH Is Nothing Then
            For Each a As Arch In archives
                Dim lv As New ListViewItem(a.Name)
                lv.SubItems.Add(CStr(a.IsPrivate))
                ListView1.Items.Add(lv)
            Next
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        txtArchName.Clear()
        chkPrivate.Checked = False
        If ListView1.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        For Each a As Arch In archives
            If a.Name.ToLower = ListView1.SelectedItems(0).Text.ToLower Then
                chkPrivate.Checked = a.IsPrivate
                txtArchName.Text = a.Name
                Exit Sub
            End If
        Next

    End Sub

    Private Sub butModify_Click(sender As Object, e As EventArgs) Handles butModify.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If String.IsNullOrEmpty(txtArchName.Text) Then Exit Sub
        Dim lv As ListViewItem = ListView1.SelectedItems(0)
        Dim arch As Arch
        For Each a As Arch In archives
            If a.Name.ToLower = lv.Text.ToLower Then
                arch = a
                Exit For
            End If
        Next
        If txtArchName.Text <> arch.Name Then
            arch.newName = txtArchName.Name
        End If
        If arch.IsPrivate = False And chkPrivate.Checked Then
            Dim pass As String = ""
            arch.IsPrivate = True
            Dim password As New Password(arch.Password)
            If password.ShowDialog() = DialogResult.OK Then
                arch.Password = password.ConfirmedPass
            End If
        ElseIf arch.IsPrivate And Not chkPrivate.Checked Then
            arch.Password = ""
            arch.IsPrivate = False
        End If
        If archH.UpdateArchive(arch) Then
            lv.Text = arch.Name
            lv.SubItems(0).Text = CStr(arch.IsPrivate)
        End If
    End Sub

    Private Sub butDelete_Click(sender As Object, e As EventArgs) Handles butDelete.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub

        Dim lv As ListViewItem = ListView1.SelectedItems(0)
        Dim arch As Arch
        For Each a As Arch In archives
            If a.Name.ToLower = lv.Text.ToLower Then
                arch = a
                Exit For
            End If
        Next
        archives.Remove(arch)
        If archH.DeleteArchive(arch) Then
            ListView1.Items.Remove(lv)
        End If
    End Sub

    Private Sub butAdd_Click(sender As Object, e As EventArgs) Handles butAdd.Click
        If String.IsNullOrEmpty(txtArchName.Text) Then Exit Sub
        For Each a As Arch In archives
            If a.Name.ToLower = txtArchName.Text.ToLower Then
                MsgBox("This name already exists, please choose a different one", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Next
        Dim pass As String = ""
        Dim ispri As Boolean
        If chkPrivate.Checked Then
            ispri = True
            Dim password As New Password("")
            If password.ShowDialog() = DialogResult.OK Then
                pass = password.ConfirmedPass
            End If
        End If
        Dim arch As New Arch(txtArchName.Text.Trim, ispri, pass)
        If archH.InsertArchive(arch) Then
            Dim lv As New ListViewItem(arch.Name)
            lv.SubItems.Add(CStr(arch.IsPrivate))
            ListView1.Items.Add(lv)
            archives.Add(arch)
            txtArchName.Clear()
            chkPrivate.Checked = False
        End If

    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub butImgEditor1_Click(sender As Object, e As EventArgs) Handles butImgEditor1.Click
        Dim openfdg As New OpenFileDialog
        With openfdg
            .Filter = "Applications(*.exe)|*.exe"
            .InitialDirectory = txtimgEditor1.Text
            If .ShowDialog = DialogResult.OK Then
                txtimgEditor1.Text = .FileName
                My.Settings.IME1 = .FileName
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub butImageEditor2_Click(sender As Object, e As EventArgs) Handles butImageEditor2.Click
        Dim openfdg As New OpenFileDialog
        With openfdg
            .Filter = "Applications(*.exe)|*.exe"
            .InitialDirectory = txtImageEditor2.Text
            If .ShowDialog = DialogResult.OK Then
                txtImageEditor2.Text = .FileName
                My.Settings.IME2 = .FileName
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub butImageEditor3_Click(sender As Object, e As EventArgs) Handles butImageEditor3.Click
        Dim openfdg As New OpenFileDialog
        With openfdg
            .Filter = "Applications(*.exe)|*.exe"
            .InitialDirectory = txtImageEditor3.Text
            If .ShowDialog = DialogResult.OK Then
                txtImageEditor3.Text = .FileName
                My.Settings.IME3 = .FileName
                My.Settings.Save()
            End If
        End With
    End Sub

    Private Sub butBrowseWorkFolder_Click(sender As Object, e As EventArgs) Handles butBrowseWorkFolder.Click
        Dim fdb As New FolderBrowserDialog
        With fdb
            .SelectedPath = My.Settings.WorkFolder
            If .ShowDialog = DialogResult.OK Then
                My.Settings.WorkFolder = .SelectedPath
                txtWorkfolder.Text = .SelectedPath
                My.Settings.Save()
            End If
        End With
    End Sub
End Class