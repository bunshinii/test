Namespace Database.SQLite

    Public Class GlobalVar

        Friend Shared ReadOnly Property UserOnlineSpan As TimeSpan
            Get
                Dim _Hour As Integer = 0
                Dim _Min As Integer = 15
                Dim _Sec As Integer = 0

                Dim OnlineSpan As New TimeSpan(_Hour, _Min, _Sec)
            End Get
        End Property

    End Class

End Namespace


