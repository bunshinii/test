Namespace MyControls.Rdms.Tables.DutyCalendar

    Public Class DutyLegendItem
        Inherits System.Web.UI.UserControl

        Public Property DutyTypeName As String
            Get
                Return lblDutyType.Text
            End Get
            Set(value As String)
                lblDutyType.Text = value
            End Set
        End Property

        Public Property DutyTypeNote As String
            Get
                Return lblNote.Text
            End Get
            Set(value As String)
                lblNote.Text = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

