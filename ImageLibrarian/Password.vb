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
Public Class Password
    Public ConfirmedPass As String = ""
    Public Sub New(p As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtPass.Text = p
        txtConfirm.Text = p
    End Sub
    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        If txtConfirm.Text = txtPass.Text And Not String.IsNullOrEmpty(txtPass.Text) Then
            ConfirmedPass = txtConfirm.Text
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Password mismatch", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class