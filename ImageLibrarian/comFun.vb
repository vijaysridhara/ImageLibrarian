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
Friend Class Classification
    Public Category As String
    Public SubCategories As New List(Of String)

    Public Sub New(cat As String)
        Category = cat
    End Sub
    Public Sub AddSubCat(st As String)
        SubCategories.Add(st)
    End Sub

End Class
Friend Class Arch
    Public Name As String
    Public IsPrivate As Boolean
    Public Password As String
    Public newName As String

    Public Sub New(n As String, ispri As Boolean, pass As String)
        Me.Name = n

        Me.IsPrivate = ispri
        Me.Password = pass
    End Sub
End Class
Friend Class PropItem
    Public Name As String
    Public Value As String
    Public Sequence As Integer = 0
    Public Sub New(name, value, seq)
        Me.Name = name
        Me.Value = value
        Me.Sequence = seq
    End Sub
    Public Function Clone() As PropItem
        Dim p1 As New PropItem(Me.Name, Me.Value, Me.Sequence)
        Return p1
    End Function

End Class
Module comFun
    Public ARCHLOC As String
    Public EXPLOC As String
    Public COPYLOC As String
    Public IMPFROM As String
    Public nextKey As Long
    Public LASTARCH As String
    Public classifications As New Dictionary(Of String, Classification)
    Public archives As New List(Of Arch)
    Public StringLengthCalcImage As Image = New Bitmap(150, 50)
    Public StringLegthCalcGraphis As Graphics

    Public Function GetLengthofString(st As String, f As Font) As SizeF
        If StringLegthCalcGraphis Is Nothing Then
            StringLegthCalcGraphis = Graphics.FromImage(StringLengthCalcImage)

        End If
        Return StringLegthCalcGraphis.MeasureString(st, f)
    End Function
    Public Function GetNextKey() As Long
        Try
            nextKey += 1
            Return nextKey
        Catch ex As Exception

        End Try
    End Function
    Public Sub DE(ex As Exception)
        MsgBox(ex.Message, MsgBoxStyle.Critical)
    End Sub

End Module
