Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.Tables.Notification

    Public Class Container
        Inherits System.Web.UI.UserControl

        Private Sub LoadTable()
            'id, recieverId, messageTitle, messageText, messageDate
            Dim NoteTable As DataTable = MyModules.Database.Notification.GetAllNotes(MyRequest.OwnerId)
            Dim NoteCount As Integer = NoteTable.Rows.Count

            If NoteCount > 0 Then
                For i As Integer = 0 To NoteCount - 1
                    Dim MyControl As MyControls.Rdms.Tables.Notification.RowItem = LoadControl("~\MyControls\Rdms\Tables\Notification\RowItem.ascx")
                    MyControl.NoteId = NoteTable(i)("id")
                    MyControl.No = i + 1
                    MyControl.NoteTitle = NoteTable(i)("messageTitle")
                    MyControl.NoteMessage = NoteTable(i)("messageText")
                    MyControl.NoteDate = NoteTable(i)("messageDate")

                    PlaceHolder1.Controls.Add(MyControl)
                Next
            End If

            NoteTable.Dispose()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            LoadTable()
        End Sub

        Private Sub btnRead_ServerClick(sender As Object, e As EventArgs) Handles btnRead.ServerClick
            MyModules.Database.Notification.MarkAllAsRead(MyRequest.OwnerId)
            PanelContent.Visible = False
        End Sub
    End Class

End Namespace

