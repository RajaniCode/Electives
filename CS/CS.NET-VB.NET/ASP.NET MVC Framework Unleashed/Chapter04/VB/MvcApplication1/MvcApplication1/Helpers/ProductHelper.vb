Imports System.IO

Public Module ProductHelper

    <System.Runtime.CompilerServices.Extension()> _
    Function ProductList(ByVal helper As HtmlHelper) As String
        ' Get products from view data
        Dim products = CType(helper.ViewData.Model, IEnumerable(Of Product))

        ' Create HTML TextWriter
        Dim html = New HtmlTextWriter(New StringWriter())

        ' Open table
        html.RenderBeginTag(HtmlTextWriterTag.Table)

        ' Render product rows
        For Each product In products
            ' Open tr
            html.RenderBeginTag(HtmlTextWriterTag.Tr)

            ' Render name
            html.RenderBeginTag(HtmlTextWriterTag.Td)
            html.Write(product.Name)
            html.RenderEndTag()

            ' Render price
            html.RenderBeginTag(HtmlTextWriterTag.Td)
            html.Write("{0:c}", product.Price)
            html.RenderEndTag()

            ' Close tr
            html.RenderEndTag()
        Next 

        ' Close table
        html.RenderEndTag()

        Return html.InnerWriter.ToString()
    End Function


End Module