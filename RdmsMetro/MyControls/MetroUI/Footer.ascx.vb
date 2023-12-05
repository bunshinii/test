Imports NasLib.Config.SQLite

Namespace MyControls.MetroUI

    Public Class Footer
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property Copyright() As String
            Get
                Return Configuration.Copyright
            End Get
            Set(value As String)
                Configuration.Copyright = value
            End Set
        End Property

        Public ReadOnly Property ApplicationName() As String
            Get
                Return Configuration.ApplicationName()
            End Get
        End Property

        Public ReadOnly Property ApplicationVersion() As String
            Get
                Return Configuration.ApplicationVersion()
            End Get
        End Property

        Public ReadOnly Property SiteName() As String
            Get
                Return Configuration.SiteName()
            End Get
        End Property

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            lblCopyright.Text = Copyright
            lblAppname.Text = ApplicationName
        End Sub

    End Class

End Namespace
