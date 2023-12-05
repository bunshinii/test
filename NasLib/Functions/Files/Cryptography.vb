Imports System.IO
Imports System.Security.Cryptography

Namespace Functions.Files

    Public Class Cryptography

        Private Shared EncryptionKey As String = "N4SHF1L3S"

        Public Shared Sub Encrypt(inputFilePath As String, outputfilePath As String)
            'Dim EncryptionKey As String = "MAKV2SPBNI99212"
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using fs As New FileStream(outputfilePath, FileMode.Create)
                    Using cs As New CryptoStream(fs, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                        Using fsInput As New FileStream(inputFilePath, FileMode.Open)
                            Dim data As Integer
                            While (Assign(data, fsInput.ReadByte())) <> -1
                                cs.WriteByte(CByte(data))
                            End While
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Public Shared Sub Decrypt(inputFilePath As String, outputfilePath As String)
            'Dim EncryptionKey As String = "MAKV2SPBNI99212"
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using fs As New FileStream(inputFilePath, FileMode.Open)
                    Using cs As New CryptoStream(fs, encryptor.CreateDecryptor(), CryptoStreamMode.Read)
                        Using fsOutput As New FileStream(outputfilePath, FileMode.Create)
                            Dim data As Integer
                            While (Assign(data, cs.ReadByte())) <> -1
                                fsOutput.WriteByte(CByte(data))
                            End While
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Shared Function Assign(Of T)(ByRef source As T, ByVal value As T) As T
            source = value
            Return value
        End Function


    End Class

End Namespace
