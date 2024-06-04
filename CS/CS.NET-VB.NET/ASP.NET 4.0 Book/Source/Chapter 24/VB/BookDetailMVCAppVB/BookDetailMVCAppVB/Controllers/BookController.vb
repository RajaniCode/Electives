Imports System.Web.Mvc

Namespace BookDetailMVCAppVB
    Public Class BookController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Book

        Function Index() As ActionResult

            Dim bs As New ClassBook()
            bs.BName = "Black Book ASP.NET"
            bs.BEdition = "2010"
            bs.BPrice = "800"
            bs.BISBN = "111-2222"
            bs.publisher = "Kogent Learning Solutions"

            Return View(bs)

        End Function

    End Class
End Namespace