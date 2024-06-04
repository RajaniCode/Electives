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

Public Class ShoppingCartController
    Inherits Controller
    Private storeDB As New MusicStoreEntities

    '
    'GET: /ShoppingCart/

    Public Function Index() As ActionResult
        Dim cart = ShoppingCart.GetCart(Me.HttpContext)

        'Set up our ViewModel
        Dim viewModel = New ShoppingCartViewModel With {.CartItems = cart.GetCartItems(), .CartTotal = cart.GetTotal()}

        'Return the view
        Return View(viewModel)
    End Function

    '
    'GET: /Store/AddToCart/5

    Public Function AddToCart(ByVal id As Integer) As ActionResult

        'Retrieve the album from the database
        Dim addedAlbum = storeDB.Albums.Single(Function(album) album.AlbumId = id)

        'Add it to the shopping cart
        Dim cart = ShoppingCart.GetCart(Me.HttpContext)

        cart.AddToCart(addedAlbum)

        'Go back to the main store page for more shopping
        Return RedirectToAction("Index")
    End Function

    '
    'AJAX: /ShoppingCart/RemoveFromCart/5

    <HttpPost()>
    Public Function RemoveFromCart(ByVal id As Integer) As ActionResult
        'Remove the item from the cart
        Dim cart = ShoppingCart.GetCart(Me.HttpContext)

        'Get the name of the album to display confirmation
        Dim albumName As String = storeDB.Carts.Single(Function(item) item.RecordId = id).Album.Title

        'Remove from cart. Note that for simplicity, we're 
        'removing all rather than decrementing the count.
        cart.RemoveFromCart(id)

        'Display the confirmation message
        Dim results = New ShoppingCartRemoveViewModel With { _
                                                                .Message = Server.HtmlEncode(albumName) & " has been removed from your shopping cart.", _
                                                                .CartTotal = cart.GetTotal(), .CartCount = cart.GetCount(), .DeleteId = id}

        Return Json(results)
    End Function

    '
    'GET: /ShoppingCart/CartSummary

    <ChildActionOnly()>
    Public Function CartSummary() As ActionResult
        Dim cart = ShoppingCart.GetCart(Me.HttpContext)

        ViewData("CartCount") = cart.GetCount()

        Return PartialView("CartSummary")
    End Function
End Class
