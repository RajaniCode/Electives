Imports Microsoft.WindowsAPICodePack.Shell
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Xml
Imports System.Xml.XPath
Public Class Form1
    Private strLocationID As String() = {"2295411", "615702", "44418", "2295424", "2295426"}
    Private strLocations As String() = {"Mumbai", "Paris", "London", "Chennai", "Trivandrum"}
    Private currentLocation As Integer = 0
    Private buttonNext As ThumbnailToolbarButton
    Private buttonPrevious As ThumbnailToolbarButton
    Private tbManager As TaskbarManager = TaskbarManager.Instance

    Sub GetWeatherReport(ByVal locationId As Integer)
        Me.Text = strLocations(locationId)

        Dim doc As New XPathDocument("http://weather.yahooapis.com/forecastrss?w=" & strLocationID(locationId) & "&u=c")
        Dim nav As XPathNavigator = doc.CreateNavigator()

        Dim ns As New XmlNamespaceManager(nav.NameTable)
        ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0")
        Dim nodes As XPathNodeIterator = nav.[Select]("/rss/channel/item/yweather:condition", ns)


        While (nodes.MoveNext())
            Dim node As XPathNavigator = nodes.Current
            RTTemp.Text = node.GetAttribute("temp", ns.DefaultNamespace).ToString() & "°C"
            RTWeatherType.Text = node.GetAttribute("text", ns.DefaultNamespace).ToString()
            weatherImage.ImageLocation = "http://l.yimg.com/a/i/us/we/52/" & node.GetAttribute("code", ns.DefaultNamespace).ToString() & ".gif"
            SetProgressBarStyle(Convert.ToInt16(node.GetAttribute("temp", ns.DefaultNamespace)))
        End While

    End Sub

    Private Sub SetProgressBarStyle(ByVal weather As Integer)
        tbManager.SetProgressValue(50, 100)
        If weather <= 10 Then
            tbManager.SetProgressState(TaskbarProgressBarState.Normal)
        End If
        If weather >= 20 Then
            tbManager.SetProgressState(TaskbarProgressBarState.Paused)
        End If
        If weather >= 30 Then
            tbManager.SetProgressState(TaskbarProgressBarState.[Error])
        End If
    End Sub


    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown


        buttonNext = New ThumbnailToolbarButton(My.Resources.nextArrow, "Next Location")
        buttonNext.Enabled = True
        AddHandler buttonNext.Click, AddressOf buttonNext_Click
        buttonPrevious = New ThumbnailToolbarButton(My.Resources.prevArrow, "Previous Location")
        buttonPrevious.Enabled = True
        AddHandler buttonPrevious.Click, AddressOf buttonPrevious_Click
        TaskbarManager.Instance.ThumbnailToolbars.AddButtons(Me.Handle, buttonPrevious, buttonNext)
   GetWeatherReport(currentLocation)


    End Sub



    Private Sub buttonNext_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (currentLocation + 1) < strLocationID.Length Then
            currentLocation += 1
            GetWeatherReport(currentLocation)
        End If
    End Sub



    Private Sub buttonPrevious_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (currentLocation - 1) >= 0 Then
            currentLocation -= 1
            GetWeatherReport(currentLocation)
        End If
    End Sub


End Class
