' ----------------------------------------------------------------------------------
' Microsoft Developer & Platform Evangelism
' 
' Copyright (c) Microsoft Corporation. All rights reserved.
' 
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
' OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ----------------------------------------------------------------------------------
' The example companies, organizations, products, domain names,
' e-mail addresses, logos, people, places, and events depicted
' herein are fictitious.  No association with any real company,
' organization, product, domain name, email address, logo, person,
' places, or events is intended or should be inferred.
' ----------------------------------------------------------------------------------

Public Class StoreService
    Implements IStoreService

    Private storeDB As New MusicStoreEntities

    Public Function GetGenreNames() As IList(Of String) Implements IStoreService.GetGenreNames

        Dim genres = From genre In storeDB.Genres
                     Select genre.Name
        Return genres.ToList()

    End Function

    Public Function GetGenreByName(ByVal name As String) As Genre Implements IStoreService.GetGenreByName

        Dim genre = storeDB.Genres.Include("Albums").Single(Function(g) g.Name = name)
        Return genre

    End Function

    Public Function GetAlbum(ByVal id As Integer) As Album Implements IStoreService.GetAlbum

        Dim album = storeDB.Albums.Single(Function(a) a.AlbumId = id)
        Return album

    End Function
End Class
