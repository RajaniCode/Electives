'Imports System.IO

'Public Module DataGridHelper

'    <System.Runtime.CompilerServices.Extension()> _
'    Function DataGrid(Of T)(ByVal helper As HtmlHelper) As String
'        Return DataGrid(Of T)(helper, Nothing, Nothing)
'    End Function


'    <System.Runtime.CompilerServices.Extension()> _
'    Function DataGrid(Of T)(ByVal helper As HtmlHelper, ByVal data As Object) As String
'        Return DataGrid(Of T)(helper, data, Nothing)
'    End Function


'    <System.Runtime.CompilerServices.Extension()> _
'    Function DataGrid(Of T)(ByVal helper As HtmlHelper, ByVal data As IEnumerable(Of T), ByVal columns() As String) As String
'        ' Get items
'        Dim items = CType(data, IEnumerable(Of T))
'        If items Is Nothing Then
'            items = CType(helper.ViewData.Model, IEnumerable(Of T))
'        End If

'        ' Get column names
'        If columns Is Nothing Then
'            columns = GetType(T).GetProperties().Select(Function(p) p.Name).ToArray()
'        End If

'        ' Create HtmlTextWriter
'        Dim writer = New HtmlTextWriter(New StringWriter())

'        ' Open table tag
'        writer.RenderBeginTag(HtmlTextWriterTag.Table)

'        ' Render table header
'        writer.RenderBeginTag(HtmlTextWriterTag.Thead)
'        RenderHeader(helper, writer, columns)
'        writer.RenderEndTag()

'        ' Render table body
'        writer.RenderBeginTag(HtmlTextWriterTag.Tbody)
'        For Each item In items
'            RenderRow(Of T)(helper, writer, columns, item)
'        Next item
'        writer.RenderEndTag()

'        ' Close table tag
'        writer.RenderEndTag()

'        ' Return the string
'        Return writer.InnerWriter.ToString()
'    End Function


'    Private Sub RenderHeader(ByVal helper As HtmlHelper, ByVal writer As HtmlTextWriter, ByVal columns() As String)
'        writer.RenderBeginTag(HtmlTextWriterTag.Tr)
'        For Each columnName In columns
'            writer.RenderBeginTag(HtmlTextWriterTag.Th)
'            writer.Write(helper.Encode(columnName))
'            writer.RenderEndTag()
'        Next columnName
'        writer.RenderEndTag()
'    End Sub


'    Private Sub RenderRow(Of T)(ByVal helper As HtmlHelper, ByVal writer As HtmlTextWriter, ByVal columns() As String, ByVal item As T)
'        writer.RenderBeginTag(HtmlTextWriterTag.Tr)
'        For Each columnName In columns
'            writer.RenderBeginTag(HtmlTextWriterTag.Td)
'            Dim value = GetType(T).GetProperty(columnName).GetValue(item, Nothing)
'            If IsNothing(value) Then value = String.Empty
'            writer.Write(helper.Encode(value.ToString()))
'            writer.RenderEndTag()
'        Next columnName
'        writer.RenderEndTag()
'    End Sub

'End Module
