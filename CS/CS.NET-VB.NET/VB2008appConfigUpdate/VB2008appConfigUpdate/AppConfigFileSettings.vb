
Imports System.Configuration
Imports System.Xml

''' <summary>
''' AppConfigFileSettings: This class is used to Change the AppConfigs Paramters at rumtime through User Interface
''' </summary>
''' <remarks></remarks>
Public Class AppConfigFileSettings

    ''' <summary>
    ''' UpdateAppSettings: It will update the app.Config file AppConfig key values
    ''' </summary>
    ''' <param name="KeyName">AppConfigs KeyName</param>
    ''' <param name="KeyValue">AppConfigs KeyValue</param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateAppSettings(ByVal KeyName As String, ByVal KeyValue As String)
        Dim XmlDoc As New XmlDocument()
        XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        For Each xElement As XmlElement In XmlDoc.DocumentElement
            If xElement.Name = "appSettings" Then
                For Each xNode As XmlNode In xElement.ChildNodes
                    If xNode.Attributes(0).Value = KeyName Then
                        xNode.Attributes(1).Value = KeyValue
                    End If
                Next
            End If
        Next
        XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
    End Sub
End Class
