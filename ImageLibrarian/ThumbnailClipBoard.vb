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
Friend Class ThumbnailClipBoard
    Private _clippedElements As List(Of Thumbnail)
    Private _op As String 'Cut or copy
    Public Property Operation As String
        Get
            Return _op
        End Get
        Set(value As String)
            _op = value
        End Set
    End Property
    Public Sub SetClippedElements(c As List(Of Thumbnail))
        ClearLip()
        _clippedElements = c

    End Sub
    Public Function GetClippedElements() As List(Of Thumbnail)
        Return _clippedElements
    End Function
    Public Sub ClearLip()
        If Not _clippedElements Is Nothing Then _clippedElements.Clear()
        _clippedElements = Nothing
    End Sub
End Class
