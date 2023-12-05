
Namespace Functions.Desktop

    Public Class Taskbar

#Region "How to use"

        '=============================================================================================================================================================
        ' HOW TO USE
        ' ==========
        '
        ' 1. Put GetTaskbarId() at form startup
        '
        ' 2. Then call ShowTaskbar() or HideTaskBar()
        '
        '=============================================================================================================================================================

#End Region

#Region "Show / Hide TaskBar"

        Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
        Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
        Const SWP_HIDEWINDOW = &H80
        Const SWP_SHOWWINDOW = &H40
        Shared taskBar As Integer

        Public Shared Sub HideTaskBar()
            Debug.Write(SetWindowPos(taskBar, 0&, 0&, 0&, 0&, 0&, SWP_HIDEWINDOW))
        End Sub

        Public Shared Sub ShowTaskbar()
            Debug.Write(SetWindowPos(taskBar, 0&, 0&, 0&, 0&, 0&, SWP_SHOWWINDOW))
        End Sub

        ''' <summary>
        ''' Put this at form startup
        ''' </summary>
        Public Shared Sub GetTaskbarId()
            taskBar = FindWindow("Shell_traywnd", "")
        End Sub

#End Region

    End Class

End Namespace

