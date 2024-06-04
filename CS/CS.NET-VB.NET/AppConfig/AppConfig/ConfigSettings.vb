Imports System
Imports System.Xml

Imports System.Xml.XPath
Imports System.Configuration
Imports System.Reflection



Public Class ConfigSettings
    Private Sub New()
    End Sub


    Public Shared Function GetNodeValue(ByVal sFileName As String, ByVal sSelectExpression As String) As String
        Dim sRetVal As String = ""
        ' Read the XML document 
        Dim myXPathDocument As New XPathDocument(getConfigFilePath() + sFileName)
        Dim myXPathNavigator As XPathNavigator = myXPathDocument.CreateNavigator()
        Dim myXPathNodeIterator As XPathNodeIterator = myXPathNavigator.[Select](sSelectExpression)
        While myXPathNodeIterator.MoveNext()
            'Console.WriteLine("<" + myXPathNodeIterator.Current.Name + "> " + myXPathNodeIterator.Current.Value); 
            sRetVal = myXPathNodeIterator.Current.OuterXml.ToString()
        End While
        Return sRetVal
    End Function

    Public Shared Function ReadSetting(ByVal key As String) As String
        ' Return ConfigurationSettings.AppSettings(key)
        ' Note: Add Reference (System.Configuration.dll)
        Return System.Configuration.ConfigurationManager.AppSettings(key)
    End Function

    Public Shared Sub WriteSetting(ByVal key As String, ByVal value As String)
        ' load config document for current assembly 
        Dim doc As XmlDocument = loadConfigDocument()

        ' retrieve appSettings node 
        Dim node As XmlNode = doc.SelectSingleNode("//appSettings")

        If node Is Nothing Then
            Throw New InvalidOperationException("appSettings section not found in config file.")
        End If

        Try
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
            doc.Save(getConfigPathAndFile())
        Catch
            Throw
        End Try
    End Sub

    Public Shared Sub RemoveSetting(ByVal key As String)
        ' load config document for current assembly 
        Dim doc As XmlDocument = loadConfigDocument()

        ' retrieve appSettings node 
        Dim node As XmlNode = doc.SelectSingleNode("//appSettings")

        Try
            If node Is Nothing Then
                Throw New InvalidOperationException("appSettings section not found in config file.")
            Else
                ' remove 'add' element with coresponding key 
                node.RemoveChild(node.SelectSingleNode(String.Format("//add[@key='{0}']", key)))
                doc.Save(getConfigPathAndFile())
            End If
        Catch e As NullReferenceException
            Throw New Exception(String.Format("The key {0} does not exist.", key), e)
        End Try
    End Sub

    Private Shared Function loadConfigDocument() As XmlDocument
        Dim doc As XmlDocument = Nothing
        Try
            doc = New XmlDocument()
            doc.Load(getConfigPathAndFile())
            Return doc
        Catch e As System.IO.FileNotFoundException
            Throw New Exception("No configuration file found.", e)
        End Try
    End Function

    Friend Shared Function getConfigPathAndFile() As String
        ' Return Assembly.GetExecutingAssembly().Location + ".config" 
        Return Application.StartupPath.Remove(Application.StartupPath.Length - 9) + "App.Config"
    End Function

    Friend Shared Function getConfigFilePath() As String
        Return Application.StartupPath.Remove(Application.StartupPath.Length - 9)
    End Function


End Class


