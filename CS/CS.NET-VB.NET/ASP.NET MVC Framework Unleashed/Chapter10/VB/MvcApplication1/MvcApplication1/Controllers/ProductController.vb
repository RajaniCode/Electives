Public Class ProductController
    Inherits Controller

    <FeaturedProduct()> _
    Public Function Index() As ActionResult
        Return View()
    End Function

    <FeaturedProduct()> _
    Public Function Details() As ActionResult
        Return View()
    End Function


    Public Function About() As ActionResult
        Return View()
    End Function

End Class
