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

<Authorize(Roles:="Administrator")>
    Public Class StoreManagerController
    Inherits Controller
    Private storeDB As New MusicStoreEntities

    '
    'GET: /StoreManager/

    Public Function Index() As ActionResult
        Dim albums = storeDB.Albums.Include("Genre").Include("Artist").ToList()

        Return View(albums)
    End Function

    Public Function Index2() As ActionResult
        Dim albums = storeDB.Albums.Include("Genre").Include("Artist").ToList()

        Return View(albums)
    End Function

    '
    'GET: /StoreManager/Create

    Public Function Create() As ActionResult
        Dim viewModel = New StoreManagerViewModel With {.Album = New Album, _
                                                        .Genres = New SelectList(storeDB.Genres.ToList(), "GenreId", "Name"), _
                                                        .Artists = New SelectList(storeDB.Artists.ToList(), "ArtistId", "Name")}

        Return View(viewModel)
    End Function

    '
    'POST: /StoreManager/Create

    <HttpPost()>
    Public Function Create(ByVal album As Album) As ActionResult
        Try
            If ModelState.IsValid Then
                'Save Album
                storeDB.AddToAlbums(album)
                storeDB.SaveChanges()

                Return Redirect("Index")
            End If
        Catch ex As Exception
            ModelState.AddModelError(String.Empty, ex)
        End Try

        'Invalid - redisplay with errors

        Dim viewModel = New StoreManagerViewModel With {.Album = album, _
                                                       .Genres = New SelectList(storeDB.Genres.ToList(), "GenreId", "Name", album.GenreId), _
                                                        .Artists = New SelectList(storeDB.Artists.ToList(), "ArtistId", "Name", album.ArtistId)}

        Return View(viewModel)
    End Function

    '
    'GET: /StoreManager/Edit/5

    Public Function Edit(ByVal id As Integer) As ActionResult
        Dim album As Album = storeDB.Albums.Single(Function(a) a.AlbumId = id)

        Dim viewModel = New StoreManagerViewModel With {.Album = album, _
                                                        .Genres = New SelectList(storeDB.Genres.ToList(), "GenreId", "Name", album.GenreId), _
                                                        .Artists = New SelectList(storeDB.Artists.ToList(), "ArtistId", "Name", album.ArtistId)}

        Return View(viewModel)
    End Function

    '
    'POST: /StoreManager/Edit/5

    <HttpPost()>
    Public Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim album = storeDB.Albums.Single(Function(a) a.AlbumId = id)

        Try
            'Save Album

            UpdateModel(album, "Album")
            storeDB.SaveChanges()

            Return RedirectToAction("Index")
        Catch
            'Error ocurred - so redisplay the form

            Dim viewModel = New StoreManagerViewModel With {.Album = album, _
                                                           .Genres = New SelectList(storeDB.Genres.ToList(), "GenreId", "Name", album.GenreId), _
                                                           .Artists = New SelectList(storeDB.Artists.ToList(), "ArtistId", "Name", album.ArtistId)}

            Return View(viewModel)
        End Try
    End Function

    '
    'GET: /StoreManager/Delete/5

    Public Function Delete(ByVal id As Integer) As ActionResult
        Dim album = storeDB.Albums.Single(Function(a) a.AlbumId = id)

        Return View(album)
    End Function

    '
    'POST: /StoreManager/Delete/5

    <HttpPost()>
    Public Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Dim album = storeDB.Albums.Include("OrderDetails").Include("Carts").Single(Function(a) a.AlbumId = id)

        storeDB.DeleteObject(album)
        storeDB.SaveChanges()

        Return RedirectToAction("Index")

    End Function
End Class

