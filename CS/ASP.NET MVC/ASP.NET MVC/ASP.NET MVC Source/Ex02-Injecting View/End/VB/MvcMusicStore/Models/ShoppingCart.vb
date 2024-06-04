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

Partial Public Class ShoppingCart
    Private storeDB As New MusicStoreEntities
    Private Property shoppingCartId As String
    Public Const CartSessionKey = "CartId"

    Public Shared Function GetCart(ByVal context As HttpContextBase) As ShoppingCart

        Dim cart = New ShoppingCart
        cart.shoppingCartId = cart.GetCartId(context)
        Return cart

    End Function

    Public Sub AddToCart(ByVal album As Album)
        Dim cartItem = storeDB.Carts.SingleOrDefault(Function(c) c.CartId = shoppingCartId AndAlso c.AlbumId = album.AlbumId)

        If cartItem Is Nothing Then
            'Create a new cart item
            cartItem = New Cart With{.AlbumId = album.AlbumId, .CartId = shoppingCartId,.Count = 1,.DateCreated = Date.Now}

            storeDB.AddToCarts(cartItem)
        Else
            'Add one to the quantity
            cartItem.Count += 1
        End If

        'Save it
        storeDB.SaveChanges()
    End Sub

    Public Sub RemoveFromCart(ByVal id As Integer)
        'Get the cart
        Dim cartItem = storeDB.Carts.Single(
            Function(cart) cart.CartId = shoppingCartId AndAlso cart.RecordId = id)

        If cartItem IsNot Nothing Then
            If cartItem.Count > 1 Then
                cartItem.Count -= 1
            Else
                storeDB.Carts.DeleteObject(cartItem)
            End If
            storeDB.SaveChanges()
        End If
    End Sub

    Public Sub EmptyCart()
        Dim cartItems = storeDB.Carts.Where(Function(cart) cart.CartId = shoppingCartId)

        For Each cartItem In cartItems
            storeDB.DeleteObject(cartItem)
        Next cartItem

        storeDB.SaveChanges()
    End Sub

    Public Function GetCartItems() As List(Of Cart)
        Dim cartItems = (
            From cart In storeDB.Carts
            Where cart.CartId = shoppingCartId
            Select cart).ToList()
        Return cartItems
    End Function

    Public Function GetCount() As Integer

        Dim count? = (
            From cartItems In storeDB.Carts
            Where cartItems.CartId = shoppingCartId
            Select CType(cartItems.Count, Integer?)).Sum()

        Return If(count, 0)

    End Function

    Public Function GetTotal() As Decimal

        Dim total? = (
            From cartItems In storeDB.Carts
            Where cartItems.CartId = shoppingCartId
            Select CType(cartItems.Count, Integer?) * cartItems.Album.Price).Sum()

        Return If(total, Decimal.Zero)

    End Function

    Public Function CreateOrder(ByVal order As Order) As Integer
        Dim orderTotal = 0D

        Dim cartItems = GetCartItems()

        'Iterate the items in the cart, adding Order Details for each
        For Each cartItem In cartItems
            Dim orderDetails = New OrderDetail With {.AlbumId = cartItem.AlbumId, _
                                                    .OrderId = order.OrderId, .UnitPrice = cartItem.Album.Price}

            storeDB.OrderDetails.AddObject(orderDetails)

            orderTotal += (cartItem.Count * cartItem.Album.Price)
        Next cartItem

        'Save the order
        storeDB.SaveChanges()

        'Empty the shopping cart
        EmptyCart()

        'Return the OrderId as a confirmation number
        Return order.OrderId
    End Function

    'We're using HttpContextBase to allow access to cookies.
    Public Function GetCartId(ByVal context As HttpContextBase) As String
        If context.Session(CartSessionKey) Is Nothing Then
            If Not String.IsNullOrWhiteSpace(context.User.Identity.Name) Then
                'User is logged in, associate the cart with there username
                context.Session(CartSessionKey) = context.User.Identity.Name
            Else
                'Generate a new random GUID using System.Guid Class
                Dim tempCartId As Guid = Guid.NewGuid()

                'Send tempCartId back to client as a cookie
                context.Session(CartSessionKey) = tempCartId.ToString()
            End If
        End If
        Return context.Session(CartSessionKey).ToString()
    End Function

    'When a user has logged in, migrate their shopping cart to
    'be associated with their username
    Public Sub MigrateCart(ByVal userName As String)

        Dim shoppingCart = storeDB.Carts.Where(Function(c) c.CartId = shoppingCartId)

        For Each item As Cart In shoppingCart
            item.CartId = userName
        Next item
        storeDB.SaveChanges()

    End Sub
End Class
