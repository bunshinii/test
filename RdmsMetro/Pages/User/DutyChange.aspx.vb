Public Class DutyChange
    Inherits System.Web.UI.Page


#Region "Notification"

    Private Sub SendNotification(ReceiverId_ As String)
        Dim OwnerId As String = MyModules.Functions.QueryString.MyRequest.OwnerId
        Dim OwnerName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(OwnerId, ProvidersConnectionString)

        Dim ReceiverId As String = ReceiverId_
        Dim MessageTitle As String = "Duty Change Canceled"
        Dim MessageText As String = String.Format("A Duty Change Request sent to you has been canceled by '{0}'.", OwnerName)

        MyModules.Database.Notification.NoteAdd(ReceiverId, MessageTitle, MessageText)
    End Sub

#End Region

    Private ReadOnly Property DutyId As Integer
        Get
            Return MyModules.Functions.QueryString.MyRequest.GetDutyId
        End Get
    End Property

    Public ReadOnly Property DutyDate As String
        Get
            Dim ReturnValue As String = "ERROR"
            Dim DutyId_ As Integer = DutyId

            If DutyId_ > 0 Then
                Dim DutyDate_ As Date = MyModules.Database.DutyStaff.DutyDate(DutyId_)
                ReturnValue = Format(DutyDate_, "dd MMMM yyyy")
            End If

            Return ReturnValue
        End Get
    End Property

    Private Function OnDutyOfficerId() As String
        Dim ReturnValue As String = ""

        Dim DutyId_ As Integer = DutyId
        If DutyId_ > 0 Then
            Dim StaffId_ As String = MyModules.Database.DutyStaff.StaffId(DutyId_)
            ReturnValue = StaffId_
        End If

        Return ReturnValue
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Staff1.StaffId = OnDutyOfficerId()

        Dim DutyTypeId As Integer = MyModules.Database.DutyStaff.DutyTypeId(DutyId)

        lblDutyTypeName.Text = MyModules.Database.DutyType.DutyTypeName(DutyTypeId)
        lblDutyTypeDesc.Text = MyModules.Database.DutyType.DutyNote(DutyTypeId)
        lblLocation.Text = MyModules.Database.DutyStaff.SatelliteName(DutyId)
        lblBranch.Text = MyModules.Database.DutyStaff.BranchName(DutyId)

        Dim IsRequested As Boolean = MyModules.Database.DutyRequest.IsDutyRequested(DutyId)
        If IsRequested Then
            PanelReciever.Visible = True

            Dim RecieverId As String = MyModules.Database.DutyRequest.ReceiverIdByDutyId(DutyId)
            Dim MyControl As MyControls.Rdms.User.Staff = LoadControl("~\MyControls\Rdms\User\Staff.ascx")
            MyControl.StaffId = RecieverId
            phReceived.Controls.Add(MyControl)

            Dim IsRejected As Boolean = MyModules.Database.DutyRequest.IsDutyRejected(DutyId)
            If IsRejected Then
                lblStatus.Text = "Your request has been rejected"
                lblStatus.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim DutyId_ As Integer = DutyId

        Dim ReceiverId As String = MyModules.Database.DutyRequest.ReceiverIdByDutyId(DutyId_)
        SendNotification(ReceiverId)

        MyModules.Database.DutyRequest.RequestDeleteByDutyId(DutyId_)
        Response.Redirect("~/Pages/User/Duty.aspx")
    End Sub
End Class