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
Public Class ResizeImage
    Dim modifImage As Image
    Public chgPct As Integer = 100
    Public Sub New(modifImage As Image)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.modifImage = modifImage
    End Sub
    Private Sub ResizeImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtHeight.Text = modifImage.Height
        txtWidth.Text = modifImage.Width
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        chgPct = nupdPercent.Value
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub trkPct_Scroll(sender As Object, e As EventArgs) Handles trkPct.Scroll
        If modifImage Is Nothing Then Exit Sub
        If nupdPercent.Value <> trkPct.Value Then
            nupdPercent.Value = trkPct.Value
            txtHeight.Text = CInt(Math.Floor(modifImage.Height * trkPct.Value / 100))
            txtWidth.Text = CInt(Math.Floor(modifImage.Width * trkPct.Value / 100))
        End If


    End Sub

    Private Sub nupdPercent_ValueChanged(sender As Object, e As EventArgs) Handles nupdPercent.ValueChanged
        If modifImage Is Nothing Then Exit Sub
        If trkPct.Value <> nupdPercent.Value Then
            trkPct.Value = nupdPercent.Value
            txtHeight.Text = CInt(Math.Floor(modifImage.Height * trkPct.Value / 100))
            txtWidth.Text = CInt(Math.Floor(modifImage.Width * trkPct.Value / 100))
        End If
    End Sub
End Class