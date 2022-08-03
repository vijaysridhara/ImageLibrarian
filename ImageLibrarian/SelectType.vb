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
Public Class SelectType
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        cboCat.Items.AddRange(classifications.Keys.ToArray)
        If cboCat.Items.Count > 0 Then cboCat.SelectedIndex = 0
    End Sub
    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        If chkBMP.Checked = False And chkGIF.Checked = False And chkJPEG.Checked = False And chkPNG.Checked = False Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCat.Text) Or String.IsNullOrEmpty(cboSubCat.Text) Then
            Exit Sub
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectType_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCat.SelectedIndexChanged
        Dim text As String = cboCat.Text
        cboSubCat.Items.Clear()
        If String.IsNullOrEmpty(text) Then Exit Sub
        If classifications.ContainsKey(text) Then
            cboSubCat.Items.AddRange(classifications(text).SubCategories.ToArray)
            cboSubCat.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboCat_TextChanged(sender As Object, e As EventArgs) Handles cboCat.TextChanged
        Dim text As String = cboCat.Text
        cboSubCat.Items.Clear()
        If String.IsNullOrEmpty(text) Then Exit Sub
        If classifications.ContainsKey(text) Then
            cboSubCat.Items.AddRange(classifications(text).SubCategories.ToArray)
            cboSubCat.SelectedIndex = 0
        End If
    End Sub

    Private Sub chkSubfolders_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubfolders.CheckedChanged
        If chkSubfolders.Checked Then
            If MsgBox("This will take long time, based on how many folders, subfolders exist, and the images there in,  in your selected main folder. Do you want to proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                chkSubfolders.Checked = False
            End If
        End If
    End Sub
End Class