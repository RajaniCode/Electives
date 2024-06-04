Imports System.Xml

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CheckappSettings()
        appSettings("key", "value")
    End Sub


    Private Sub CheckappSettings()

        Dim appconfig As New XmlDocument()
        Dim IsappSettings As Boolean = False
        Dim elements As XmlNodeList

        Dim strElement As String = String.Empty

        Try

            appconfig.Load(GetappconfigPathAndFile())
            elements = appconfig.SelectNodes("//appSettings")

            For Each element As XmlElement In elements
                strElement = element.Name
            Next

            If strElement = "appSettings" Then
                MsgBox("appSettings exists")
            Else
                WriteappSettings()
                MsgBox("appSettings appended")
            End If

        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Shared Sub WriteappSettings()

        Try
            ' load config document for current assembly 
            Dim doc As XmlDocument = Loadappconfig()
            ' retrieve appSettings node 
            Dim node As XmlNode = doc.SelectSingleNode("//configuration")

            ' select the 'add' element that contains the key 
            Dim elem As XmlElement = DirectCast(node.SelectSingleNode(String.Format("//add[@key='{0}']", "")), XmlElement)


            ' key was not found so create the 'add' element 
            ' and set it's key/value attributes 
            elem = doc.CreateElement("appSettings")

            node.AppendChild(elem)

            doc.Save(GetappconfigPathAndFile())
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Shared Sub appSettings(ByVal key As String, ByVal value As String)

        Try
            ' load config document for current assembly 
            Dim doc As XmlDocument = Loadappconfig()
            ' retrieve appSettings node 
            Dim node As XmlNode = doc.SelectSingleNode("//appSettings")

            ' select the 'add' element that contains the key 
            Dim elem As XmlElement = DirectCast(node.SelectSingleNode(String.Format("//add[@key='{0}']", key)), XmlElement)

            If elem IsNot Nothing Then
                ' add value for key 
                elem.SetAttribute("value", value)
            Else
                ' key was not found so create the 'add' element 
                ' and set it's key/value attributes 
                elem = doc.CreateElement("add")
                elem.SetAttribute("key", key)
                elem.SetAttribute("value", value)
                node.AppendChild(elem)
            End If
            doc.Save(GetappconfigPathAndFile())
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
        End Try

    End Sub

    Private Shared Function Loadappconfig() As XmlDocument

        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load(GetappconfigPathAndFile())
            Return doc
        Catch ExceptionMessage As System.IO.FileNotFoundException
            MsgBox(ExceptionMessage.ToString())
            Return Nothing
        End Try

    End Function

    Private Shared Function GetappconfigPathAndFile() As String

        Try
            Dim ApplicationStarupPath As String = String.Empty
            Dim appconfigPath As String = String.Empty

            ApplicationStarupPath = Application.StartupPath

            If ApplicationStarupPath.EndsWith("bin") Then
                appconfigPath = ApplicationStarupPath.Replace("bin", String.Empty)
            ElseIf ApplicationStarupPath.EndsWith("bin\Debug") Then
                appconfigPath = ApplicationStarupPath.Replace("bin\Debug", String.Empty)
            ElseIf ApplicationStarupPath.EndsWith("bin\Release") Then
                appconfigPath = ApplicationStarupPath.Replace("bin\Release", String.Empty)
            End If

            ' Return Assembly.GetExecutingAssembly().Location + ".config" 
            Return appconfigPath + "app.config"
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
            Return String.Empty
        End Try

    End Function

    Private Shared Function GetappconfigPath() As String

        Try
            Dim ApplicationStarupPath As String = String.Empty
            Dim appconfigPath As String = String.Empty

            ApplicationStarupPath = Application.StartupPath

            If ApplicationStarupPath.EndsWith("bin") Then
                appconfigPath = ApplicationStarupPath.Replace("bin", String.Empty)
            ElseIf ApplicationStarupPath.EndsWith("bin\Debug") Then
                appconfigPath = ApplicationStarupPath.Replace("bin\Debug", String.Empty)
            ElseIf ApplicationStarupPath.EndsWith("bin\Release") Then
                appconfigPath = ApplicationStarupPath.Replace("bin\Release", String.Empty)
            End If

            ' Return Assembly.GetExecutingAssembly().Location + ".config" 
            Return appconfigPath
        Catch ExceptionMessage As Exception
            MsgBox(ExceptionMessage.ToString())
            Return String.Empty
        End Try

    End Function

End Class
