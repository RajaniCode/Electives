Public Class ProductController
    Inherits System.Web.Mvc.Controller

    Private _entities As New ToyStoreDBEntities()

    Function Index() As ActionResult
        Return View(_entities.ProductSet.ToList())
    End Function

    
    Function List() As ActionResult
        ViewData("products") = _entities.ProductSet.ToList()
        Return View()
    End Function

    Function SortProducts(ByVal sort As String) As ActionResult
	    Dim products As IEnumerable(Of Product)
	    sort = If((sort <> Nothing), sort, String.Empty)
	    Select Case sort.ToLower()
		    Case "name"
			    products = From p In _entities.ProductSet _
			               Order By p.Name _
			               Select p
		    Case "price"
			    products = From p In _entities.ProductSet _
			               Order By p.Price _
			               Select p
		    Case Else
			    products = From p In _entities.ProductSet _
			               Order By p.Id _
			               Select p
	    End Select

	    Return View(products)
    End Function

    Function PagedProducts(ByVal page As Integer?) As ActionResult
        Dim products = _entities.ProductSet _
                .OrderBy(Function(p) p.Id) _
                .ToPagedList(page, 2)

	    Return View(products)
    End Function


    Function PagedSortedProducts(ByVal sort As String, ByVal page As Integer?) As ActionResult
	    Dim products As IQueryable(Of Product)
	    sort = If((sort <> Nothing), sort, String.Empty)
	    Select Case sort.ToLower()
		    Case "name"
			    products = From p In _entities.ProductSet _
			               Order By p.Name _
			               Select p
		    Case "price"
			    products = From p In _entities.ProductSet _
			               Order By p.Price _
			               Select p
		    Case Else
			    products = From p In _entities.ProductSet _
			               Order By p.Id _
			               Select p
	    End Select

	    ViewData.Model = products.ToPagedList(page, 2, sort)
	    Return View()
    End Function



End Class
