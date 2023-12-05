Namespace MyControls.MetroUI.FluentMenu.TabContentSegment

    Public Class PatronPhoto
        Inherits System.Web.UI.UserControl

        Public Property PatronId As String
            Get
                Return gPatronId.Text
            End Get
            Set(value As String)
                gPatronId.Text = value
                Image1.ImageUrl = PicProviderLink(value)
            End Set
        End Property

        Public ReadOnly Property Tooltip As String
            Get
                Dim ReturnValue As String = ""
                If PatronId.Length > 0 Then ReturnValue = NasLib.Database.MySql.CustomProvider.DBLibrary.Patron.GetPatronName(PatronId, DbLibraryConnectionString).ToString.Trim
                Return ReturnValue
            End Get
        End Property


    End Class

End Namespace

