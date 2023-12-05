Imports System.Xml
Imports System.Data.SqlClient

'reference
'http://www.aspsnippets.com/Articles/Programmatically-Add-or-Update-Connection-String-in-ASPNet-WebConfig-File.aspx

Namespace Webconfig

    Public Class ConnectionString

        ''' <summary>
        '''NOT USABLE.
        '''For example only
        ''' </summary>
        ''' <param name="ConnectionstringName"></param>
        ''' <returns></returns>
        Public Shared Function GetConnectionString(ConnectionstringName As String) As String
            ''Need to add reference to System.Configuration

            'Return ConfigurationManager.ConnectionStrings(ConnectionstringName).ConnectionString
            Return Nothing
        End Function

        ''' <summary>
        ''' adds or updates the connection string based on the connection string name. 
        ''' If the connection string with the name does not exists a new connection string node will be created in the Web.Config file.
        ''' </summary>
        ''' <param name="name"></param>
        Public Shared Sub AddUpdateConnectionString(name As String)
            Dim isNew As Boolean = False
            'Dim path As String = Server.MapPath("~/Web.Config")
            Dim path As String = AppDomain.CurrentDomain.BaseDirectory & "Web.Config"
            Dim doc As New XmlDocument()
            doc.Load(path)
            Dim list As XmlNodeList = doc.DocumentElement.SelectNodes(String.Format("connectionStrings/add[@name='{0}']", name))
            Dim node As XmlNode
            isNew = list.Count = 0
            If isNew Then
                node = doc.CreateNode(XmlNodeType.Element, "add", Nothing)
                Dim attribute As XmlAttribute = doc.CreateAttribute("name")
                attribute.Value = name
                node.Attributes.Append(attribute)

                attribute = doc.CreateAttribute("connectionString")
                attribute.Value = ""
                node.Attributes.Append(attribute)

                attribute = doc.CreateAttribute("providerName")
                attribute.Value = "System.Data.SqlClient"
                node.Attributes.Append(attribute)
            Else
                node = list(0)
            End If
            Dim conString As String = node.Attributes("connectionString").Value
            Dim conStringBuilder As New SqlConnectionStringBuilder(conString)
            conStringBuilder.InitialCatalog = "TestDB"
            conStringBuilder.DataSource = "myserver"
            conStringBuilder.IntegratedSecurity = False
            conStringBuilder.UserID = "test"
            conStringBuilder.Password = "12345"
            node.Attributes("connectionString").Value = conStringBuilder.ConnectionString
            If isNew Then
                doc.DocumentElement.SelectNodes("connectionStrings")(0).AppendChild(node)
            End If
            doc.Save(path)
        End Sub



    End Class

End Namespace


