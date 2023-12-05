Imports System.Xml

Namespace Config

    Public Class Xml

#Region "Public Properties"

        ''' <summary>
        ''' Read / Write from XML. Support only 1 level node
        ''' </summary>
        ''' <param name="NodeName">XML node. 1st level only</param>
        ''' <param name="XmlFullPath">Full path including filename</param>
        Public Shared Property XmlVal(NodeName As String, XmlFullPath As String) As String
            Get
                Return ReadXml(NodeName, XmlFullPath)
            End Get
            Set(value As String)
                WriteXml(NodeName, value, XmlFullPath)
            End Set
        End Property

#End Region

#Region "Read / Write (Private)"

        ''' <summary>
        ''' Read from XML. Support only 1 level node
        ''' </summary>
        ''' <param name="NodeName">XML node. 1st level only</param>
        ''' <param name="XmlFullPath">Full path including filename</param>
        Private Shared Function ReadXml(NodeName As String, XmlFullPath As String) As String
            Dim ReturnValue As String = Nothing

            Try
                Dim XmlDoc As New XmlDocument
                Dim XmlRoot As XmlNode

                XmlDoc.Load(XmlFullPath)
                XmlRoot = XmlDoc.DocumentElement

                ReturnValue = XmlRoot.SelectSingleNode(NodeName).ChildNodes(0).Value
            Catch ex As Exception
                ReturnValue = Nothing
            End Try

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Write to XML. Support only 1 level node
        ''' </summary>
        ''' <param name="NodeName">XML node. 1st level only</param>
        ''' <param name="XmlFullPath">Full path including filename</param>
        Private Shared Sub WriteXml(NodeName As String, NodeValue As String, XmlFullPath As String)

            Dim XmlDoc As New XmlDocument 'Treat XmlDoc as Database
            Dim XmlRoot As XmlNode 'Treat XmlRoot as Table
            Dim outNode As XmlNode

            Try
                XmlDoc.Load(XmlFullPath)
                XmlRoot = XmlDoc.DocumentElement
                outNode = XmlRoot.SelectSingleNode(NodeName).ChildNodes(0) 'Treat ChildNodes as Row
                outNode.InnerText = NodeValue
                XmlDoc.Save(XmlFullPath)
            Catch ex As Exception
                Dim ReturnValue As String = Nothing
            End Try

        End Sub

#End Region

#Region "Generate Xml File"

        ''' <summary>
        ''' Generate blank XML file with specified nodes.
        ''' Only support 1 level node.
        ''' Version 1.0, Encoding UTF-8.
        ''' </summary>
        ''' <param name="RootName">Root Node name</param>
        ''' <param name="XmlFullPath">Xml Fullpath including filename</param>
        ''' <param name="NodeList">List of Nodes</param>
        Public Shared Sub GenerateXml(RootName As String, XmlFullPath As String, ParamArray NodeList() As String)
            Dim MyXmlDoc As New XmlDocument()
            Dim MyXmlSetting As XmlNode = MyXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
            MyXmlDoc.AppendChild(MyXmlSetting)

            Dim MyRootNode As XmlNode = Nothing
            Dim MyChildNode As XmlNode = Nothing

            MyRootNode = MyXmlDoc.CreateElement(RootName)
            MyXmlDoc.AppendChild(MyRootNode)

            For i As Integer = 0 To NodeList.Count - 1
                MyChildNode = MyXmlDoc.CreateElement(NodeList(i))
                MyChildNode.AppendChild(MyXmlDoc.CreateTextNode(NodeList(i)))
                MyRootNode.AppendChild(MyChildNode)
            Next

            MyXmlDoc.Save(XmlFullPath)
        End Sub

#End Region

    End Class

End Namespace


