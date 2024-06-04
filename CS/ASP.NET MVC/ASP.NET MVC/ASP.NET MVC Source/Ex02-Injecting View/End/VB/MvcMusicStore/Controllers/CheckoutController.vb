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

<Authorize()>
Public Class CheckoutController
    Inherits Controller

    Private storeDB As New MusicStoreEntities
    Private Const PromoCode = "FREE"

    '
    'GET: /Checkout/AddressAndPayment

    Public Function AddressAndPayment() As ActionResult
        Return View()
    End Function

    '
    'POST: /Checkout/AddressAndPayment

    <HttpPost()>
    Public Function AddressAndPayment(ByVal values As FormCollection) As ActionResult
        Dim order = New Order
        TryUpdateModel(order)

        Try
            If String.Equals(values("PromoCode"),PromoCode, StringComparison.OrdinalIgnoreCase) = False Then
                Return View(order)
            Else
                order.Username = User.Identity.Name
                order.OrderDate = Date.Now

                'Save Order
                storeDB.AddToOrders(order)
                storeDB.SaveChanges()

                'Process the order
                Dim cart = ShoppingCart.GetCart(Me.HttpContext)
                cart.CreateOrder(order)

                Return RedirectToAction("Complete", New With {Key .id = order.OrderId})
            End If

        Catch
            'Invalid - redisplay with errors
            Return View(order)
        End Try
    End Function

    '
    'GET: /Checkout/Complete

    Public Function Complete(ByVal id As Integer) As ActionResult
        'Validate customer owns this order
        Dim isValid = storeDB.Orders.Any(
            Function(o) o.OrderId = id AndAlso o.Username = User.Identity.Name)

        If isValid Then
            Return View(id)
        Else
            Return View("Error")
        End If
    End Function
End Class
