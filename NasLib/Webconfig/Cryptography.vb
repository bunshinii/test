Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Configuration
Imports System.Security.Cryptography

Namespace Webconfig

    Public Class Cryptography

        Private Shared EncryptionKey As String = "N4SHWEBC0NF1G"


#Region "AppSetting.Key"
        'Encrypt AppSettings Key (Tags) in Web.Config File in ASP.Net using C# and VB.Net
        'the key tag must exist
        '
        '<appSettings>
        '   <add key = "PicProviderLink" value="http://online.ptar.uitm.edu.my/Images/Patron/" />
        '   <add key = "ChartImageHandler" value="storage=file;timeout=20;dir=c:\TempImageFiles\;" />
        '</appSettings>
        '
        'Usage Example:
        'EncryptAppSetting(PicProviderLink)


#Region "Encrypt"

        ''' <summary>
        '''  Encrypt AppSetting value in Web.Config or App.Config file. 
        '''  This function accepts the name of the AppSetting Key as parameter. 
        '''  It first reads the Web.Config file using XmlDocument and the node is traversed using the name of the AppSetting key. 
        '''  Then from the node the AppSetting value is extracted, it is encrypted and then value set again and the Web.Config file is saved.
        ''' </summary>
        ''' <param name="key">Key name</param>
        Public Shared Sub EncryptAppSetting(key As String)
            'Dim path As String = Server.MapPath("~/Web.Config")
            Dim path As String = AppDomain.CurrentDomain.BaseDirectory & "Web.Config"
            Dim doc As New XmlDocument()
            doc.Load(path)
            Dim list As XmlNodeList = doc.DocumentElement.SelectNodes(String.Format("appSettings/add[@key='{0}']", key))

            If list.Count = 1 Then
                Dim node As XmlNode = list(0)
                Dim value As String = node.Attributes("value").Value
                node.Attributes("value").Value = Encrypt(value)
                doc.Save(path)
            End If
        End Sub

        Private shared Function Encrypt(clearText As String) As String
            'Dim EncryptionKey As String = "MAKV2SPBNI99212"

            Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                 &H65, &H64, &H76, &H65, &H64, &H65,
                 &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                        cs.Write(clearBytes, 0, clearBytes.Length)
                        cs.Close()
                    End Using
                    clearText = Convert.ToBase64String(ms.ToArray())
                End Using
            End Using
            Return clearText
        End Function

#End Region

#Region "Decrypt"

        ''' <summary>
        '''  Decrypt AppSetting value in Web.Config or App.Config file. 
        '''  This function accepts the name of the AppSetting Key as parameter. 
        '''  It first reads the Web.Config file using XmlDocument and the node is traversed using the name of the AppSetting key. 
        '''  Then from the node the AppSetting value is extracted, it is decrypted and then value set again and the Web.Config file is saved.
        ''' </summary>
        ''' <param name="key">Key name</param>
        Public Shared Sub DecryptAppSetting(Key As String)
            'Dim path As String = Server.MapPath("~/Web.Config")
            Dim path As String = AppDomain.CurrentDomain.BaseDirectory & "Web.Config"
            Dim doc As New XmlDocument()
            doc.Load(path)
            Dim list As XmlNodeList = doc.DocumentElement.SelectNodes(String.Format("appSettings/add[@key='{0}']", Key))

            If list.Count = 1 Then
                Dim node As XmlNode = list(0)
                Dim value As String = node.Attributes("value").Value
                node.Attributes("value").Value = Decrypt(value)
                doc.Save(path)
            End If
        End Sub

        Private Shared Function Decrypt(cipherText As String) As String
            Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                 &H65, &H64, &H76, &H65, &H64, &H65,
                 &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        cs.Write(cipherBytes, 0, cipherBytes.Length)
                        cs.Close()
                    End Using
                    cipherText = Encoding.Unicode.GetString(ms.ToArray())
                End Using
            End Using
            Return cipherText
        End Function

#End Region

#End Region


    End Class

End Namespace


