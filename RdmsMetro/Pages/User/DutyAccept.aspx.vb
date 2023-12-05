Public Class DutyAccept
    Inherits System.Web.UI.Page

#Region "Properties"

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

#End Region

#Region "functions"

    Private Function OnDutyOfficerId() As String
        Dim ReturnValue As String = ""

        Dim DutyId_ As Integer = DutyId
        If DutyId_ > 0 Then
            Dim StaffId_ As String = MyModules.Database.DutyStaff.StaffId(DutyId_)
            ReturnValue = StaffId_
        End If

        Return ReturnValue
    End Function

#End Region

#Region "Notification"

    Private Sub SendNotificationAccept(ReceiverId_ As String)
        'Just Swap
        Dim OwnerId As String = MyModules.Functions.QueryString.MyRequest.OwnerId
        Dim OwnerName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(OwnerId, ProvidersConnectionString)
        Dim ReceiverId As String = ReceiverId_
        Dim ReceiverName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(ReceiverId, ProvidersConnectionString)

        Dim MessageTitle As String = "Duty Change Accepted"
        Dim MessageText As String = String.Format("Your Duty Change Request has been Accepted by '{0}'.", OwnerName)

        MyModules.Database.Notification.NoteAdd(ReceiverId, MessageTitle, MessageText)

    End Sub

    Private Sub SendNotificationReject(ReceiverId_ As String)
        'Just Swap
        Dim OwnerId As String = MyModules.Functions.QueryString.MyRequest.OwnerId
        Dim OwnerName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(OwnerId, ProvidersConnectionString)
        Dim ReceiverId As String = ReceiverId_
        Dim ReceiverName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(ReceiverId, ProvidersConnectionString)

        Dim MessageTitle As String = "Duty Change Rejected"
        Dim MessageText As String = String.Format("Your Duty Change Request has been Rejected by '{0}'.", OwnerName)

        MyModules.Database.Notification.NoteAdd(ReceiverId, MessageTitle, MessageText)
    End Sub

#Region "Template"

    ''Run the code below to send notification
    ''Send Notification
    'Dim SenderId As String = MyModules.Database.DutyRequest.SenderIdByDutyId(DutyId_)
    'SendNotificationReject(SenderId)

#End Region

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Staff1.StaffId = OnDutyOfficerId()

        Dim DutyTypeId As Integer = MyModules.Database.DutyStaff.DutyTypeId(DutyId)

        lblDutyTypeName.Text = MyModules.Database.DutyType.DutyTypeName(DutyTypeId)
        lblDutyTypeDesc.Text = MyModules.Database.DutyType.DutyNote(DutyTypeId)
        lblLocation.Text = MyModules.Database.DutyStaff.SatelliteName(DutyId)
        lblBranch.Text = MyModules.Database.DutyStaff.BranchName(DutyId)

    End Sub

    Private Sub btnAccept_ServerClick(sender As Object, e As EventArgs) Handles btnAccept.ServerClick
        Dim DutyId_ As Integer = DutyId

        'Send Notification
        Dim SenderId As String = MyModules.Database.DutyRequest.SenderIdByDutyId(DutyId_)
        SendNotificationAccept(SenderId)

        MyModules.Database.DutyRequest.RequestDeleteByDutyId(DutyId_)
        MyModules.Database.DutyStaff.StaffId(DutyId_) = MyModules.Functions.QueryString.MyRequest.OwnerId
        Response.Redirect("~/Pages/User/Duty.aspx", True)
    End Sub

    Private Sub btnReject_ServerClick(sender As Object, e As EventArgs) Handles btnReject.ServerClick
        Dim DutyId_ As Integer = DutyId

        'Send Notification
        Dim SenderId As String = MyModules.Database.DutyRequest.SenderIdByDutyId(DutyId_)
        SendNotificationReject(SenderId)

        MyModules.Database.DutyRequest.RejectedByDutyId(DutyId_) = DutyId_
        Response.Redirect("~/Pages/User/DashBoard.aspx", True)
    End Sub
End Class