
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
Imports System.Data.SQLite

Friend Class ArchiveHelper
    Dim FILE_PATH As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\ArchiveRespository.db"
    Dim CONN_STR As String = "Data Source=" + FILE_PATH + ";Version=3"

    Private _cache_path As String
    Dim colChecksDone As Boolean = False
    Private Sub ColumnChecks()
        If colChecksDone = False Then
            Dim chkCmd As New SQLiteCommand
            Dim chk1 As String = "Select COUNT(*) As CNTREC FROM pragma_table_info('properties') WHERE name='sequence'"
            chkCmd.Connection = con
            chkCmd.CommandText = chk1
            Dim rdr As SQLiteDataReader = chkCmd.ExecuteReader
            Dim colExists As Boolean = False
            If rdr.Read Then
                If rdr(0) > 0 Then
                    colExists = True
                End If

            End If
            rdr.Close()
            If Not colExists Then
                chkCmd.CommandText = "alter table properties add column sequence integer default 0"
                chkCmd.ExecuteNonQuery()
            End If
            colChecksDone = True
            chkCmd.Dispose()
        End If
    End Sub
    Public Sub Cleanup()
        If Not con Is Nothing Then
            ConnectionOpen()
            Dim cmd As New SQLiteCommand
            cmd.CommandText = "VACUUM"
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            If con.State = ConnectionState.Closed Then
            Else
                con.Close()
            End If
            con.Dispose()
        End If
        If Not updCommand Is Nothing Then
            updCommand.Dispose()
        End If
        If Not insCommand Is Nothing Then
            insCommand.Dispose()
        End If
        If Not delCommand Is Nothing Then
            delCommand.Dispose()
        End If


    End Sub

    Public Function GetArchiveList() As Boolean
        Try
            Dim query = "Select distinct archname,isprivate,password from archivenames  order by 1"
            If Not ConnectionOpen() Then Return Nothing
            Dim cmd As New SQLiteCommand(query)
            cmd.Connection = con
            Dim rdr As SQLiteDataReader = cmd.ExecuteReader
            archives.Clear()
            While rdr.Read
                Dim arch As New Arch(rdr(0), IIf(rdr.IsDBNull(1), False, rdr(1)), IIf(rdr.IsDBNull(2), "", rdr(2)))
                archives.Add(arch)
            End While

            rdr.Close()
            cmd.Dispose()
            Return True
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Public Function UpdateArchive(a As Arch) As Boolean
        Try
            Dim query As String = ""
            Dim query2 As String = ""
            Dim nameupdate As Boolean = False
            If Not (String.IsNullOrEmpty(a.newName) Or a.newName = a.Name) Then
                nameupdate = True
                query = "update archivenames Set archname=@archname,isprivate=@isprivate,password=@password where archname='" & a.Name & "'"
                query2 = "update archives set archivename=@archivename where archivename='" & a.Name & "'"
            Else
                query = "update archivenames set  isprivate=@isprivate,password=@password where archname='" & a.Name & "'"
            End If
            If Not ConnectionOpen() Then Return Nothing
            Dim cmd As New SQLiteCommand(query)
            cmd.Connection = con
            If nameupdate Then
                cmd.Parameters.Add("@archname", DbType.String)
                cmd.Parameters.Add("@isprivate", DbType.Boolean)
                cmd.Parameters.Add("@password", DbType.String)
                cmd.Parameters(0).Value = a.newName
                cmd.Parameters(1).Value = a.IsPrivate
                cmd.Parameters(2).Value = a.Password

            Else
                cmd.Parameters.Add("@isprivate", DbType.Boolean)
                cmd.Parameters.Add("@password", DbType.String)
                cmd.Parameters(0).Value = a.IsPrivate
                cmd.Parameters(1).Value = a.Password
            End If
            Dim res As Integer = cmd.ExecuteNonQuery

            If res > 0 And nameupdate Then
                cmd.Parameters.Clear()
                cmd.CommandText = query2
                cmd.Parameters.Add("@archivename", DbType.String)
                cmd.Parameters(0).Value = a.newName
                res = cmd.ExecuteNonQuery
                cmd.Dispose()
                Return True
            ElseIf res > 0 Then
                cmd.Dispose()
                Return True
            Else
                cmd.Dispose()
                Return False
            End If
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try

    End Function

    Public Function DeleteArchive(a As Arch) As Boolean
        Try
            Dim query As String = ""
            Dim query2 As String = ""
            query = "delete from archivenames  where archname='" & a.Name & "'"
                query2 = "delete from archives  where archivename='" & a.Name & "'"
            If Not ConnectionOpen() Then Return Nothing
            Dim cmd As New SQLiteCommand(query)
            cmd.Connection = con
            Dim res As Integer = cmd.ExecuteNonQuery
            If res > 0 Then
                cmd.CommandText = query2
                res = cmd.ExecuteNonQuery
                cmd.Dispose()
                Return True
            ElseIf res > 0 Then
                cmd.Dispose()
                Return True
            Else
                cmd.Dispose()
                Return False
            End If
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Public Function InsertArchive(a As Arch) As Boolean
        Try
            Dim query As String = ""
            query = "insert into archivenames(archname,isprivate,password) values(@archname,@isprivate,@password)"

            If Not ConnectionOpen() Then Return Nothing
            Dim cmd As New SQLiteCommand(query)
            cmd.Connection = con
            With cmd.Parameters
                .Add("@archname", DbType.String)
                .Add("@isprivate", DbType.Boolean)
                .Add("@password", DbType.String)
            End With
            With cmd
                .Parameters(0).Value = a.Name
                .Parameters(1).Value = a.IsPrivate
                .Parameters(2).Value = a.Password
            End With
            Dim res As Integer = cmd.ExecuteNonQuery
            cmd.Dispose()
            If res > 0 Then

                Return True
            Else

                Return False
            End If
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Public Property CachePath As String
        Get
            Return _cache_path
        End Get
        Set(value As String)
            _cache_path = value
            FILE_PATH = _cache_path + "\ArchiveRepository.db"
            CONN_STR = "Data Source=" + FILE_PATH + ";Verion=3"

            'IO.Path.GetDirectoryName(Application.ExecutablePath)
        End Set
    End Property

    Public Sub New(cachePath As String)
        Me.CachePath = cachePath
    End Sub

    Dim con As System.Data.SQLite.SQLiteConnection
    Event DatabaseError(ex As Exception)
    Public Function ConnectionOpen() As Boolean
        Try
            If con Is Nothing Then con = New SQLite.SQLiteConnection(CONN_STR)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            If Not colChecksDone Then
                ColumnChecks()
            End If
            Return True
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function

    Public Function GetCategories(archname As String) As Boolean

        Try
            Dim query = "Select distinct category,subcat from archives where archivename='" & archname & "' order by 1,2"
            If Not ConnectionOpen() Then Return Nothing

            Dim cmd As New SQLiteCommand(query)
            cmd.Connection = con
            Dim rdr As SQLiteDataReader
            rdr = cmd.ExecuteReader
            Dim ent As String = ""
            Dim prevent As String = ""
            Dim curent As String = ""
            Dim c As Classification
            While rdr.Read
                curent = rdr(0)
                If curent <> prevent Then
                    c = New Classification(curent)
                    prevent = curent
                    classifications.Add(curent, c)
                End If
                c.AddSubCat(rdr(1))

            End While
            rdr.Close()
            query = "select max(filenumber) from archives"
            cmd.CommandText = query
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                nextKey = IIf(rdr.IsDBNull(0), 0, rdr(0))
            Else
                nextKey = 0
            End If
            rdr.Close()
            cmd.Dispose()
            Return True
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Public Function ContainsSubcat(cat As String, subcat As String, archname As String) As Boolean
        Try
            Dim query As String = "select 1 from archives where UPPER(category)='" & cat.ToUpper & "' and UPPER(subcat)='" & subcat.ToUpper & "' and UPPER(archivename)='" & archname.ToUpper & "'"
            Dim cmd As New SQLiteCommand(query)
            cmd.Connection = con
            Dim RDR As SQLiteDataReader
            RDR = cmd.ExecuteReader
            Dim FND As Boolean = False
            If RDR.Read Then
                FND = IIf(RDR.IsDBNull(0), False, True)

            End If
            RDR.Close()
            cmd.Dispose()
            Return FND
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Public Function ContainsCat(cat As String, archname As String) As Boolean
        Try
            Dim query As String = "select 1 from archives where UPPER(category)='" & cat.ToUpper & "' and UPPER(archivename)='" & archname.ToUpper & "'"
            Dim cmd As New SQLiteCommand(query)
            cmd.Connection = con
            Dim RDR As SQLiteDataReader
            RDR = cmd.ExecuteReader
            Dim FND As Boolean = False
            If RDR.Read Then
                FND = IIf(RDR.IsDBNull(0), False, True)

            End If
            RDR.Close()
            cmd.Dispose()
            Return FND
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function

    Public Function ContainsFile(file As String, cat As String, subcat As String, archname As String) As Boolean
        Try
            Dim query As String = "select 1 from archives where UPPER(ORIGFILEPATH)='" & file.ToUpper.Replace("`", "'") & "' and UPPER(category)='" & cat.ToUpper & "' and UPPER(subcat)='" & subcat.ToUpper & "' and UPPER(archivename)='" & archname.ToUpper & "'"
            Dim cmd As New SQLiteCommand(query)
            cmd.Connection = con
            Dim RDR As SQLiteDataReader
            RDR = cmd.ExecuteReader
            Dim FND As Boolean = False
            If RDR.Read Then
                FND = IIf(RDR.IsDBNull(0), False, True)

            End If
            RDR.Close()
            cmd.Dispose()
            Return FND
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Dim updCommand As New SQLiteCommand
    Dim delCommand As New SQLiteCommand
    Public Function RemoveThumb(c As Thumbnail) As Boolean
        Try
            If ConnectionOpen() = False Then Return False
            delCommand.Connection = con
            delCommand.CommandText = "delete from archives where filenumber=" & c.FileNumber
            Dim cnt As Integer = delCommand.ExecuteNonQuery()
            delCommand.CommandText = "delete from properties where filenumber=" & c.FileNumber
            delCommand.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Public Function RemoveThumbs(cat As String, arch As String, Optional subcat As String = "%") As List(Of String)
        Try
            If ConnectionOpen() = False Then Return Nothing
            Dim delC As New SQLiteCommand
            delC.Connection = con
            delC.CommandText = "select cachefilename,filenumber from archives where category='" & cat & "' and subcat " & IIf(subcat = "%", " like '%'", "='" & subcat & "' ") & " and archivename='" & arch & "'"
            Dim rdr As SQLiteDataReader
            rdr = delC.ExecuteReader
            Dim l As New List(Of String)
            Dim filenums As New ArrayList
            Dim cnt As Integer = 0
            Dim delProps As String = "delete from  properties where filenumber in ({0})"
            Dim delC1 As New SQLiteCommand()
            delC1.Connection = con
            While rdr.Read
                l.Add(rdr(0))
                cnt += 1
                If cnt Mod 100 = 0 Then
                    delC1.CommandText = String.Format(delProps, String.Join(",", filenums.ToArray))
                    delC1.ExecuteNonQuery()
                    cnt = 0
                    filenums.Clear()
                Else

                    filenums.Add(rdr(1))
                End If
            End While
            If filenums.Count > 0 Then
                delC1.CommandText = String.Format(delProps, String.Join(",", filenums.ToArray))
                delC1.ExecuteNonQuery()
                filenums.Clear()
            End If
            rdr.Close()

            delC.CommandText = "delete from archives where  category='" & cat & "' and subcat  " & IIf(subcat = "%", " like '%'", "='" & subcat & "' ") & " and archivename='" & arch & "'"
            delC.ExecuteNonQuery()

            delC.Dispose()
            delC1.Dispose()
            Return l
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return Nothing
        End Try
    End Function
    Dim metaCommand As New SQLiteCommand
    Public Function UpdateMeta(filenum As Long, metadata As Dictionary(Of String, PropItem)) As Boolean

        Try
            If ConnectionOpen() = False Then Return False

            metaCommand.Parameters.Clear()
            metaCommand.Connection = con
            metaCommand.CommandText = "delete from properties where filenumber=" & filenum
            metaCommand.ExecuteNonQuery()
            metaCommand.CommandText = "insert into properties (filenumber,propertyname,propertyval,sequence) values " &
                    "(@filenumber,@propertyname,@propertyval,@sequence)"
            metaCommand.Parameters.Add("@filenumber", DbType.Int64)
            metaCommand.Parameters.Add("@propertyname", DbType.String)
            metaCommand.Parameters.Add("@propertyval", DbType.String)
            metaCommand.Parameters.Add("@sequence", DbType.Int32)
            For Each prop As PropItem In metadata.Values
                metaCommand.Parameters(0).Value = filenum
                metaCommand.Parameters(1).Value = prop.Name
                metaCommand.Parameters(3).Value = prop.Sequence
                metaCommand.Parameters(2).Value = IIf(prop.Value Is Nothing, "", prop.Value)
                metaCommand.ExecuteNonQuery()
                Application.DoEvents()
            Next


            Return True
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)

        End Try

    End Function
    Public Function ChangeCat(oldCat As String, oldSubcat As String, newCat As String, archname As String) As Boolean
        Try
            If ConnectionOpen() = False Then Return False
            Dim updCommand As New SQLiteCommand
            updCommand.Connection = con
            updCommand.CommandText = "update archives set category='" & newCat & "' where category='" & oldCat & "' and subcat='" & oldSubcat & "' and archivename='" & archname & "'"
            updCommand.ExecuteNonQuery()
            updCommand.Dispose()
            Return True
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try

    End Function
    Public Function UpdateThumb(field As String, c As Thumbnail, Optional subcat As Boolean = False) As Boolean
        Try
            If ConnectionOpen() = False Then Return False
            updCommand.Connection = con
            updCommand.Parameters.Clear()
            Dim query As String = "update archives set "
            If field = "*" Then
                query += "origfilename=@origfilename,resolution=@resolution, size=@size, lastmodtime=@lastmodtime," &
                "comments=@comments, stars=@stars, tags=@tags, category=@category "
            ElseIf subcat = False Then
                query += " [" + field + "]=@" + field + " "
            ElseIf subcat Then
                query += " category=@category, subcat=@subcat, archivename=@archivename"

            End If
            query += " where filenumber=" & c.FileNumber
            updCommand.CommandText = query
            Select Case field
                Case "*"
                    With updCommand.Parameters
                        .Add("@origfilename", DbType.String)
                        .Add("@resolution", DbType.String)
                        .Add("@size", DbType.Int64)
                        .Add("@lastmodtime", DbType.String)
                        .Add("@comments", DbType.String)
                        .Add("@stars", DbType.Int16)
                        .Add("@tags", DbType.String)
                        .Add("@category", DbType.String)

                    End With
                Case "origfilename"
                    updCommand.Parameters.Add("@origfilename", DbType.String)
                    updCommand.Parameters(0).Value = IIf(c.Origfilename.Contains("'"), c.Origfilename.Replace("'", "`"), c.Origfilename)
                Case "resolution"
                    updCommand.Parameters.Add("@resolution", DbType.String)
                    updCommand.Parameters(0).Value = c.OrigResolution.Width & "," & c.OrigResolution.Height
                Case "size"
                    updCommand.Parameters.Add("@size", DbType.Int64)
                    updCommand.Parameters(0).Value = c.FileSize
                Case "lastmodtime"
                    updCommand.Parameters.Add("@lastmodtime", DbType.String)
                    updCommand.Parameters(0).Value = c.LastModTime
                Case "comments"
                    updCommand.Parameters.Add("@comments", DbType.String)
                    updCommand.Parameters(0).Value = c.Comment
                Case "stars"
                    updCommand.Parameters.Add("@stars", DbType.Int16)
                    updCommand.Parameters(0).Value = c.Stars
                Case "tags"
                    updCommand.Parameters.Add("@tags", DbType.String)
                    updCommand.Parameters(0).Value = c.Tags
                Case "category"
                    updCommand.Parameters.Add("@category", DbType.String)
                    updCommand.Parameters.Add("@subcat", DbType.String)
                    updCommand.Parameters.Add("@archivename", DbType.String)
                    updCommand.Parameters(0).Value = c.Category
                    updCommand.Parameters(1).Value = c.SubCategory
                    updCommand.Parameters(2).Value = c.ArchiveName

            End Select
            'updCommand.Parameters.Add("?", DBType.Int64)
            'updCommand.Parameters(1).Value = c.FileNumber

            updCommand.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function

    Dim insCommand As New SQLiteCommand

    Public Function AddEntry(c As Thumbnail) As Boolean
        Try

            If ConnectionOpen() = False Then Return False

            insCommand.Connection = con
            insCommand.CommandText = "insert into archives " &
                                        "(filenumber,cachefilename,origfilename,origfilepath,resolution,size,filetype," &
                                        "lastmodtime,comments,stars,tags,category,subcat,archivename) values " &
                                        "(@filenumber,@cachefilename,@origfilename,@origfilepath,@resolution,@size,@filetype," &
                                        "@lastmodtime,@comments,@stars,@tags,@category,@subcat,@archivename)"
            If insCommand.Parameters.Count = 0 Then

                With insCommand.Parameters
                    .Add("@filenumber", DbType.Int64)
                    .Add("@cachefilename", DbType.String)
                    .Add("@origfilename", DbType.String)
                    .Add("@origfilepath", DbType.String)
                    .Add("@resolution", DbType.String)
                    .Add("@size", DbType.Int64)
                    .Add("@filetype", DbType.String)
                    .Add("@lastmodtime", DbType.String)
                    .Add("@comments", DbType.String)
                    .Add("@stars", DbType.Int16)
                    .Add("@tags", DbType.String)
                    .Add("@category", DbType.String)
                    .Add("@subcat", DbType.String)
                    .Add("@archivename", DbType.String)

                End With
            End If

            With insCommand
                '.Parameters("@filenumber").Value = c.FileNumber
                '.Parameters("@archname").Value = c.Archive
                '.Parameters("@cachefilename").Value = c.CacheFilename
                '.Parameters("@origfilename").Value = c.Origfilename
                '.Parameters("@origfilepath").Value = c.FullPath
                '.Parameters("@resolution").Value = c.OrigResolution.ToString()
                '.Parameters("@size").Value = c.FileSize
                '.Parameters("@filetype").Value = c.FileType
                '.Parameters("@lastmodtime").Value = c.LastModTime
                '.Parameters("@comments").Value = c.Comment
                '.Parameters("@stars").Value = c.Stars
                '.Parameters("@tags").Value = c.Tags
                '.Parameters("@category").Value = c.Category
                .Parameters(0).Value = c.FileNumber
                .Parameters(1).Value = c.CacheFilename
                .Parameters(2).Value = IIf(c.Origfilename.Contains("'"), c.Origfilename.Replace("'", "`"), c.Origfilename)
                .Parameters(3).Value = IIf(c.FullPath.Contains("'"), c.FullPath.Replace("'", "`"), c.FullPath)
                .Parameters(4).Value = c.OrigResolution.Width & "," & c.OrigResolution.Height
                .Parameters(5).Value = c.FileSize
                .Parameters(6).Value = c.FileType
                .Parameters(7).Value = c.LastModTime
                .Parameters(8).Value = c.Comment
                .Parameters(9).Value = c.Stars
                .Parameters(10).Value = c.Tags
                .Parameters(11).Value = c.Category
                .Parameters(12).Value = c.SubCategory
                .Parameters(13).Value = c.ArchiveName
            End With
            insCommand.ExecuteNonQuery()
            'insCommand.Dispose()
            UpdateMeta(c.FileNumber, c.MetaData)

            Return True

        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False

        End Try
    End Function
    Event ThumbnailsCount(cnt As Integer, cat As String, tnails As List(Of Thumbnail))
    Event Progress(pct As Integer)

    Public Function GetThumbnails(cat As String, subcat As String, archname As String) As List(Of Thumbnail)
        Try
            Dim ls As New List(Of Thumbnail)
            Dim cmd As New SQLiteCommand
            cmd.Connection = con
            Dim q1 As String = "select count(category) from archives where category='" & cat & "' and subcat='" & subcat & "' and archivename='" & archname & "'"
            cmd.CommandText = q1
            Dim rdr As SQLiteDataReader
            rdr = cmd.ExecuteReader
            Dim recCnt As Integer = 0
            If rdr.Read Then
                recCnt = IIf(rdr.IsDBNull(0), 0, rdr(0))
            End If
            For i As Integer = 1 To recCnt
                Dim c As New Thumbnail()
                ls.Add(c)
            Next
            RaiseEvent ThumbnailsCount(recCnt, cat, ls)

            rdr.Close()


            Dim query = "Select filenumber,cachefilename, origfilename, origfilepath, resolution, Size,  filetype, lastmodtime, comments, stars, tags from archives where  category='" + cat + "' and subcat='" & subcat & "'  and archivename='" & archname & "' order by 3"
            If Not ConnectionOpen() Then Return Nothing

            cmd.CommandText = query


            rdr = cmd.ExecuteReader
            Dim ent As String = ""
            Dim inc As Integer = 0
            While rdr.Read
                inc += 1
                Application.DoEvents()
                'Debug.Print(inc)
                If inc Mod 5 = 0 Then
                    RaiseEvent Progress(Int(inc / recCnt * 100))
                End If
                Dim t As Thumbnail = ls(inc - 1)
                t.InitializeCacheImage(rdr(0), rdr(6), _cache_path & "\CacheImages", IIf(rdr(3).ToString.Contains("`"), rdr(3).ToString.Replace("`", "'"), rdr(3)))
                ' Dim t As New Thumbnail(rdr(0), rdr(6), _cache_path & "\CacheImages", rdr(3))
                ' t.CacheFilename = rdr(1)
                t.Origfilename = IIf(rdr(2).ToString.Contains("`"), rdr(2).ToString.Replace("`", "'"), rdr(2))
                t.OrigResolution = New Size(rdr(4).split(",")(0), rdr(4).split(",")(1))
                t.FileSize = rdr(5)
                t.LastModTime = IIf(rdr.IsDBNull(7), "", rdr(7))
                t.Comment = IIf(rdr.IsDBNull(8), "", rdr(8))
                t.Stars = rdr(9)
                t.Tags = IIf(rdr.IsDBNull(10), "", rdr(10))
                t.Category = cat
                t.SubCategory = subcat
                t.ArchiveName = archname
                ' ls.Add(t)
                GetMeta(t)
            End While
            rdr.Close()
            cmd.Dispose()
            If recCnt = 0 Then RaiseEvent Progress(100) : Else RaiseEvent Progress(Int(inc / recCnt * 100))
            Return ls

        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return Nothing
        End Try
    End Function
    Public Function UpdateCategory(labeltype As String, parent As String, oldlabel As String, newlabel As String, arch As String) As Boolean
        Try
            If Not ConnectionOpen() Then Return False
            Dim cmd As New SQLiteCommand
            cmd.Connection = con
            If labeltype = "Subcat" Then
                cmd.CommandText = "update archives set subcat='" & newlabel & "' where archivename='" & arch & "' and category='" & parent & "' and subcat='" & oldlabel & "'"
                If cmd.ExecuteNonQuery > 0 Then
                    cmd.Dispose()
                    Return True

                End If
            ElseIf labeltype = "Category" Then
                cmd.CommandText = "update archives set category='" & newlabel & "' where archivename='" & arch & "' and category='" & oldlabel & "'"
                If cmd.ExecuteNonQuery > 0 Then
                    cmd.Dispose()
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Private Function GetMeta(t As Thumbnail) As Boolean
        Try
            Dim cmd As New SQLiteCommand("select propertyname,propertyval,sequence from properties where filenumber=" & t.FileNumber & " order by sequence")
            cmd.Connection = con
            Dim rdr As SQLiteDataReader
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim prop As New PropItem(rdr(0), rdr(1), rdr(2))
                t.MetaData.Add(prop.Name, prop)
            End While

            rdr.Close()
            cmd.Dispose()
            Return True
        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return False
        End Try
    End Function
    Public Function SearchThumbs(searchString As String, archname As String) As List(Of Thumbnail)
        Try
            Dim ls As New List(Of Thumbnail)
            Dim cmd As New SQLiteCommand
            cmd.Connection = con
            If Not ConnectionOpen() Then Return Nothing
            Dim searchString1 = "'%" & searchString & "%'"
            Dim q1 As String = "select count(category) from archives where (category like {0} or subcat like {0} or cachefilename like {0} or origfilename like {0} " &
                "or origfilepath like {0} or filetype like {0} or comments like {0} or tags like {0}) and archivename='" & archname & "'"
            q1 = String.Format(q1, searchString1)

            cmd.CommandText = q1
            Dim rdr As SQLiteDataReader
            rdr = cmd.ExecuteReader
            Dim recCnt As Integer = 0
            If rdr.Read Then
                recCnt = IIf(rdr.IsDBNull(0), 0, rdr(0))
            End If
            For i As Integer = 1 To recCnt
                Dim c As New Thumbnail()
                ls.Add(c)
            Next
            RaiseEvent ThumbnailsCount(recCnt, searchString, ls)
            rdr.Close()


            Dim query = "Select filenumber,cachefilename, origfilename, origfilepath, resolution, Size,  filetype, lastmodtime, comments, stars, tags, category, subcat, archivename from archives " &
                " where (category like {0} or subcat like {0} or cachefilename like {0} or origfilename like {0} " &
                "or origfilepath like {0} or filetype like {0} or comments like {0} or tags like {0}) and archivename='" & archname & "' order by 1"

            q1 = String.Format(query, searchString1)
                cmd.CommandText = q1


                rdr = cmd.ExecuteReader
                Dim ent As String = ""
                Dim inc As Integer = 0
                While rdr.Read
                    inc += 1
                    'Debug.Print(inc)
                    If inc Mod 5 = 0 Then
                        RaiseEvent Progress(Int(inc / recCnt * 100))
                    End If
                    Application.DoEvents()
                Dim t As Thumbnail = ls(inc - 1)
                'For i As Integer = 0 To rdr.FieldCount - 1
                '    If rdr.IsDBNull(i) Then
                '        MsgBox("Hi")

                '    End If

                'Next
                t.InitializeCacheImage(rdr(0), rdr(6), _cache_path & "\CacheImages", IIf(rdr(3).ToString.Contains("`"), rdr(3).ToString.Replace("`", "'"), rdr(3)))
                ' t.CacheFilename = rdr(1)
                t.Origfilename = IIf(rdr(2).ToString.Contains("`"), rdr(2).ToString.Replace("`", "'"), rdr(2))
                t.OrigResolution = New Size(rdr(4).split(",")(0), rdr(4).split(",")(1))
                    t.FileSize = rdr(5)
                t.LastModTime = IIf(rdr.IsDBNull(7), "", rdr(7)) '0.4.5, to fix null issue
                t.Comment = rdr(8)
                t.Stars = rdr(9)
                    t.Tags = rdr(10)
                    t.Category = rdr(11)
                    t.SubCategory = rdr(12)
                    t.ArchiveName = rdr(13)
                    GetMeta(t)
            End While

            rdr.Close()
            cmd.Dispose()
            Return ls

        Catch ex As Exception
            RaiseEvent DatabaseError(ex)
            Return Nothing
        End Try
    End Function
End Class
