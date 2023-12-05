Namespace Functions.Desktop

    Public Class Architecture

        ''' <summary>
        ''' Get if system architecture is 64 bit?
        ''' Using a .Net 4.0 function
        ''' </summary>
        Public Shared Function Is64Bit() As Boolean
            Return Environment.Is64BitOperatingSystem
        End Function

        ''' <summary>
        ''' Get if system architecture is 64 bit?
        ''' By checking a Special Folder. Only work in 'Any CPU' project
        ''' </summary>
        Public Shared Function Is64Bit2() As Boolean
            Is64Bit2 = False

            'Check for the SystemX86 variable. If is not 'SYSTEM32' then the Operating System is x64 (SystemX86 = SYSWOW64)
            If Not Environment.GetFolderPath(Environment.SpecialFolder.SystemX86).ToUpper().Contains("SYSTEM32") Then
                Is64Bit2 = True
            End If
        End Function

        ''' <summary>
        ''' Get if system architecture is 64 bit?
        ''' By checking Memory pointer size
        ''' </summary>
        Public Shared Function Is64Bit3() As Boolean
            'IntPtr.Size’ always will be eight when the process is running in memory as x64, 
            'but only will work if your project was made using the ‘AnyCPU’ platform.

            Is64Bit3 = False
            If IntPtr.Size = 8 Then Is64Bit3 = True
        End Function

    End Class

End Namespace


