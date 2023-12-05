Imports System.Net

Namespace Functions.Desktop

    Public Class Process

        ''' <summary>
        ''' Start a process silently.
        ''' </summary>
        ''' <param name="FileName">Executable filename</param>
        ''' <param name="WaitForExit">Wait for exit</param>
        ''' <param name="Arguments">Argument parameter</param>
        Public Shared Function StartProcessHidden(FileName As String, WaitForExit As Boolean, Optional Arguments As String = "") As Integer
            Using myProc As New System.Diagnostics.Process()
                'Create a new object called myProc as Process.
                myProc.StartInfo.FileName = FileName
                'Give the process file name reveived by the method.
                myProc.StartInfo.Arguments = Arguments
                'Give the arguments received.
                myProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                'As hidden window style.
                myProc.StartInfo.CreateNoWindow = True
                'Create no window property as true.
                myProc.StartInfo.UseShellExecute = False
                'Disable the shellexecute since we do not want to see any window.
                myProc.Start()
                'Start the process.
                If WaitForExit Then
                    myProc.WaitForExit()
                End If
                'Wait for the process if the 'WaitForExit' was sent as true.
                'Return the exit code of the process to the method.
                Return myProc.ExitCode
            End Using
        End Function

        ''' <summary>
        ''' Start a process.
        ''' </summary>
        ''' <param name="FileName">Executable filename</param>
        ''' <param name="WaitForExit">Wait for exit</param>
        ''' <param name="Arguments">Argument parameter</param>
        Public Shared Function StartProcess(FileName As String, WaitForExit As Boolean, Optional Arguments As String = "") As Integer
            Using myProc As New System.Diagnostics.Process()
                'Create a new object called myProc as Process.
                myProc.StartInfo.FileName = FileName
                'Give the process file name reveived by the method.
                myProc.StartInfo.Arguments = Arguments
                'Give the arguments received.
                'myProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                'As hidden window style.
                myProc.StartInfo.CreateNoWindow = True
                'Create no window property as true.
                myProc.StartInfo.UseShellExecute = False
                'Disable the shellexecute since we do not want to see any window.
                myProc.Start()
                'Start the process.
                If WaitForExit Then
                    myProc.WaitForExit()
                End If
                'Wait for the process if the 'WaitForExit' was sent as true.
                'Return the exit code of the process to the method.
                Return myProc.ExitCode
            End Using
        End Function

    End Class

End Namespace


