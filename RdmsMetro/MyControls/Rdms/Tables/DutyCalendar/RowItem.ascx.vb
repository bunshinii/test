Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Tables.DutyCalendar

    Public Class RowItem
        Inherits System.Web.UI.UserControl

#Region "Table Field Public Properties"

        Public Property DutyId As Integer
            Get
                Return gDutyId.Text
            End Get
            Set(value As Integer)
                gDutyId.Text = value

                Dim IsRequested As Boolean = MyModules.Database.DutyRequest.IsDutyRequested(value)
                If IsRequested Then
                    Dim IsRejected As Boolean = MyModules.Database.DutyRequest.IsDutyRejected(value)
                    If IsRejected Then
                        spanRequestDenied.Visible = IsRejected
                        spanRequest.Visible = Not IsRejected
                    Else
                        spanRequest.Visible = IsRequested
                    End If
                End If

            End Set
        End Property

        Public Property No As Integer
            Get
                Return lblNo.Text
            End Get
            Set(value As Integer)
                lblNo.Text = value
            End Set
        End Property

        Public Property TheDate As Date
            Get
                Return lblDate.Text
            End Get
            Set(value As Date)
                lblDate.Text = Format(value, "dd MMM yyyy")
                lblNote.Text = NasLib.Functions.Dates.Convert.ToSynonim(value)
            End Set
        End Property

        Public Property DutyTypeId As Integer
            Get
                Return gDutyTypeId.Text
            End Get
            Set(value As Integer)
                gDutyTypeId.Text = value

                Dim DutyType As String = MyModules.Database.DutyType.DutyTypeName(value)
                Dim DutyNote As String = MyModules.Database.DutyType.DutyNote(value)
                lblType.Text = DutyType
                lblType.ToolTip = DutyNote
            End Set
        End Property

        Public Property SatelliteId As Integer
            Get
                Return gSetelliteId.Text
            End Get
            Set(value As Integer)
                gSetelliteId.Text = value

                Dim SatelliteInitial As String = NasLib.Database.MySql.Provider.Table.OfficeSatellite.Initial(value, ProvidersConnectionString)
                Dim SatelliteName As String = NasLib.Database.MySql.Provider.Table.OfficeSatellite.Satellite(value, ProvidersConnectionString)
                lblLocation.Text = SatelliteName
                lblLocation.ToolTip = SatelliteInitial.ToUpper
            End Set
        End Property

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Private Sub btnChange_ServerClick(sender As Object, e As EventArgs) Handles btnChange.ServerClick
            Dim VirtualPath As String = "~/Pages/User/DutyChange.aspx"
            MyResponse.Redirect(VirtualPath, MyRequest._DutyId, DutyId)
        End Sub
    End Class

End Namespace

