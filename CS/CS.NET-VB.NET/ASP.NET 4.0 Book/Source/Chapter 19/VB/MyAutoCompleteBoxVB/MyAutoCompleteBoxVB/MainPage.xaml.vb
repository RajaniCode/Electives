Imports System
Imports System.Collections.Generic
Imports System.Text
Partial Public Class MainPage
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
        Dim cityNames As New List(Of String)
        cityNames.Add("Arizona")
        cityNames.Add("Atlanta")
        cityNames.Add("California")
        cityNames.Add("Chicago")
        cityNames.Add("Colorado")
        cityNames.Add("Denver")
        cityNames.Add("Detroit")
        cityNames.Add("Durham")
        cityNames.Add("Florida")
        cityNames.Add("Georgia")
        cityNames.Add("Hamilton")
        cityNames.Add("Hampshire")
        cityNames.Add("Lancaster")
        cityNames.Add("Las Vegas")
        cityNames.Add("Los Angeles")
        cityNames.Add("Michigan")
        cityNames.Add("New Jersey")
        cityNames.Add("New Orleans")
        cityNames.Add("New York")
        cityNames.Add("North Carolina")
        cityNames.Add("Ohio")
        cityNames.Add("Olympia")
        cityNames.Add("San Diego")
        cityNames.Add("San Francisco")
        cityNames.Add("San Jose")
        cityNames.Add("Seattle")
        cityNames.Add("Washington")
        cityNames.Add("Texas")
        myACB.ItemsSource = cityNames
    End Sub

End Class