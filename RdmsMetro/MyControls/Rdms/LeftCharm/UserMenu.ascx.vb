Namespace MyControls.Rdms.LeftCharm

    Public Class UserMenu
        Inherits System.Web.UI.UserControl

        Public ReadOnly Property KivCount As Integer
            Get
                Return MyModules.Database.RdmsQuestions.GetQuestionKivCount()
            End Get
        End Property

        Public ReadOnly Property CaptionKivCount As String
            Get
                Dim ReturnValue As String = ""
                Dim KivCount_ As Integer = KivCount

                Select Case KivCount_
                    Case 0
                        ReturnValue = ""
                    Case 1 To 20
                        ReturnValue = String.Format("({0})", KivCount)
                    Case Is > 20
                        ReturnValue = "(10+)"
                End Select

                Return ReturnValue
            End Get
        End Property

        Public Property DashboardEyeVisible() As Boolean
            Get
                Return span1.Visible
            End Get
            Set(value As Boolean)
                span1.Visible = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim HasNotification As Boolean = MyModules.Database.Notification.IsExisted(MyOwnId)
            Dim HasChangeRequest As Boolean = MyModules.Database.DutyRequest.IsExisted(MyOwnId)

            If HasChangeRequest Or HasNotification Then
                span1.Visible = True
            Else
                span1.Visible = False
            End If
        End Sub

    End Class

End Namespace

