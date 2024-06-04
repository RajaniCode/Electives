<%@ Page Language="VB" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Image" %>
<script runat="server">
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Read the name to write
		Dim strName As String
		strName = Request.QueryString("name")
		If strName = "" Then strName = "ASP 101"

		' Create a bitmap object and load the background image from a file
		Dim myBitmap As Bitmap
		myBitmap = New Bitmap(System.Drawing.Image.FromFile(Server.MapPath("images/mynameis.gif")))
		' For those of you who forgot to save the sample image, it's located here:
		' http://www.asp101.com/samples/images/mynameis.gif

		' Create graphics object
		Dim graphicsObject As Graphics
		graphicsObject = Graphics.FromImage(myBitmap)

		' Create new black brush to write with
		Dim objBrush As SolidBrush = New SolidBrush(Color.Black)

		Dim objFont As Font
		objFont = New Font("Comic Sans MS", 30, FontStyle.Bold)

		' VERY VERY rough centering calulation based on the assumptions that
		'   a. The tag will hold about 16 characters
		'   b. Each character is about 20px wide
		Dim intX As Integer
		If Len(strName) <= 16 Then
			intX = (17 - Len(strName)) * 10
		Else
			intX = 10 ' Small indent to try and fit long text
		End If

		' Write the name on the background
		graphicsObject.DrawString(strName, objFont, objBrush, intX, 110)
		graphicsObject.Flush()

		' Set response header to correct file type
		Response.ContentType = "image/gif"

		' Save the file to output stream to be displayed in browser
		myBitmap.Save(Response.OutputStream, Imaging.ImageFormat.Gif)

		' Flush the Response
		Response.Flush()
	End Sub
</script>