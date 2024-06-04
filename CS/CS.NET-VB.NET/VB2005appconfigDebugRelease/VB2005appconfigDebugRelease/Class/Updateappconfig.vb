Imports System.Configuration
Imports System.Xml

Public Class Updateappconfig

    Public Shared Sub UpdateappSettings(ByVal KeyName As String, ByVal KeyValue As String)
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
