Namespace Functions.Desktop

    Public Class Registry

        ''' <summary>
        ''' Disable Task Manager. Need Admninistrator access
        ''' </summary>
        Public Shared Property DisableTaskManager() As Boolean
            Get
                Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", "0")
            End Get
            Set(value As Boolean)
                Try
                    If value Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", "1", Microsoft.Win32.RegistryValueKind.DWord)
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", "0", Microsoft.Win32.RegistryValueKind.DWord)
                    End If
                Catch ex As Exception
                    MsgBox("Can't apply some of the settings. Need to run as administrator")
                End Try
            End Set
        End Property

        ''' <summary>
        ''' Disable Command Prompt. Require Run As Admninistrator
        ''' </summary>
        Public Shared Property DisableCommandPrompt() As Boolean
            Get
                Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System", "DisableCMD", "0")
            End Get
            Set(value As Boolean)
                Try
                    If value Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System", "DisableCMD", "1", Microsoft.Win32.RegistryValueKind.DWord)
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System", "DisableCMD", "0", Microsoft.Win32.RegistryValueKind.DWord)
                    End If
                Catch ex As Exception
                    MsgBox("Can't apply some of the settings. Need to run as administrator")
                End Try
            End Set
        End Property

        ''' <summary>
        ''' Disable Regedit. Need Administrator access
        ''' </summary>
        Public Shared Property DisableRegedit() As Boolean
            Get
                Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", "0")
            End Get
            Set(value As Boolean)
                Try
                    If value Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", "1", Microsoft.Win32.RegistryValueKind.DWord)
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", "0", Microsoft.Win32.RegistryValueKind.DWord)
                    End If
                Catch ex As Exception
                    MsgBox("Can't apply some of the settings. Need to run as administrator")
                End Try
            End Set
        End Property

    End Class

End Namespace


