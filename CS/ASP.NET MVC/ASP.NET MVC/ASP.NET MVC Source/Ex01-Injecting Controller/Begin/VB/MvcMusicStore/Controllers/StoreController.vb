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

Public Class StoreController
    Inherits Controller
    Private service As IStoreService

    Public Sub New(ByVal service As IStoreService)
        Me.service = service
    End Sub
    '
    'GET: /Store/
    Public Function Index() As ActionResult
        'Create list of genres
        Dim genres = Me.service.GetGenreNames()

        'Create your view model
        Dim viewModel = New StoreIndexViewModel With{.Genres = genres.ToList(),.NumberOfGenres = genres.Count()}
        Return View(viewModel)
    End Function

    '
    'GET: /Store/Browse?genre=Disco

    Public Function Browse(ByVal genre As String) As ActionResult
        Dim genreModel = Me.service.GetGenreByName(genre)

        Dim viewModel = New StoreBrowseViewModel With{.Genre = genreModel,.Albums = genreModel.Albums.ToList()}

        Return View(viewModel)
    End Function

    '
    'GET: /Store/Details/5

    Public Function Details(ByVal id As Integer) As ActionResult
        Dim album = Me.service.GetAlbum(id)

        Return View(album)
    End Function
End Class

