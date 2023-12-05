Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Functions

Public Class DutyChangeProcess
    Inherits System.Web.UI.Page

    Private ReadOnly Property VirtualPath As String
        Get
            Return "~/Pages/User/Duty.aspx"
        End Get
    End Property

#Region "Checks"

    Private Sub CheckZeroRequest(ReceiverId As String)
        If ReceiverId.Length = 0 Then
            MyResponse.Redirect(VirtualPath)
        End If
    End Sub

    Private Sub CheckOwnRequest(ReceiverId As String)
        If MyRequest.OwnerId = ReceiverId Then
            Dim MyKeys() As String = {MyRequest._Success, MyRequest._Code}
            Dim MyVals() As String = {False, 1}
            MyResponse.Redirect(VirtualPath, MyKeys, MyVals)
        End If
    End Sub

    Private Sub CheckDoubleRequest(ReceiverId As String, DutyId As Integer)
        Dim IsExisted As Boolean = MyModules.Database.DutyRequest.IsExisted(ReceiverId, DutyId)

        If IsExisted Then
            Dim MyKeys() As String = {MyRequest._Success, MyRequest._Code, MyRequest._ReceiverId, MyRequest._DutyId}
            Dim MyVals() As String = {False, 2, ReceiverId, DutyId}
            MyResponse.Redirect(VirtualPath, MyKeys, MyVals)
        End If
    End Sub

#End Region

#Region "Notification"

    Private Sub SendNotification(ReceiverId_ As String)
        Dim OwnerId As String = MyRequest.OwnerId
        Dim OwnerName As String = NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(OwnerId, ProvidersConnectionString)

        Dim ReceiverId As String = ReceiverId_
        Dim MessageTitle As String = "Duty Change Request"
        Dim MessageText As String = String.Format("A Duty Change Request has been sent to you by '{0}'.", OwnerName)

        MyModules.Database.Notification.NoteAdd(ReceiverId, MessageTitle, MessageText)
    End Sub

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        

        Dim DutyId As Integer = MyRequest.GetDutyId
        If DutyId = 0 Then MyResponse.Redirect(VirtualPath)

        Dim DutyDate As Date = MyModules.Database.DutyStaff.DutyDate(DutyId)

        Dim ReceiverId As String = MyRequest.GetReceiverId

        CheckZeroRequest(ReceiverId)
        CheckOwnRequest(ReceiverId)
        CheckDoubleRequest(ReceiverId, DutyId)

        Dim IsExisted As Boolean = MyModules.Database.DutyRequest.IsDutyExisted(DutyId)
        If IsExisted Then
            MyModules.Database.DutyRequest.ReceiverIdByDutyId(DutyId) = ReceiverId
            MyModules.Database.DutyRequest.RequestDateByDutyId(DutyId) = Now
            MyModules.Database.DutyRequest.RejectedByDutyId(DutyId) = False
        Else
            MyModules.Database.DutyRequest.RequestAdd(MyRequest.GetDutyId, MyRequest.OwnerId, ReceiverId, DutyDate)
        End If

        SendNotification(ReceiverId)

        MyResponse.Redirect(VirtualPath, {MyRequest._Success, MyRequest._ReceiverId}, {True, ReceiverId})


    End Sub

End Class