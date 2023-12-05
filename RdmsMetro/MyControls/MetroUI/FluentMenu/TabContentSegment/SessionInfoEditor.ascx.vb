Namespace MyControls.MetroUI.FluentMenu.TabContentSegment

    Public Class SessionInfoEditor
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property SessionId As String
            Get
                Return lblSessionId.Text
            End Get
            Set(value As String)
                If Not IsPostBack Then
                    LoadSessionData(value)
                    lblSessionId.Text = value
                End If
            End Set
        End Property

        Public Property TimeStart As Date
            Get
                Dim StartDate As Date = Format(CDate(txtTimeStart.Text), "yyyy-MM-dd 00:00:00")

                StartDate = StartDate.AddHours(ddStartHour.SelectedValue).AddMinutes(ddStartMinute.SelectedValue).AddSeconds(ddStartSecond.SelectedValue)
                Return StartDate
            End Get
            Set(value As Date)
                txtTimeStart.Text = Format(value, "yyyy-MM-dd HH:mm:ss")
                ddStartHour.SelectedValue = Hour(value)
                ddStartMinute.SelectedValue = Minute(value)
                ddStartSecond.SelectedValue = Second(value)
            End Set
        End Property

        ''' <summary>
        ''' Use to validate time textbox if it really is a time.
        ''' </summary>
        Public ReadOnly Property ValidateTimeStartText As Boolean
            Get
                Return IsDate(txtTimeStart.Text)
            End Get
        End Property

        Public Property TimeEnd As Date
            Get
                Dim EndDate As Date = Format(CDate(txtTimeStart.Text), "yyyy-MM-dd 00:00:00")

                EndDate = EndDate.AddHours(ddEndHour.SelectedValue).AddMinutes(ddEndMinute.SelectedValue).AddSeconds(ddEndSecond.SelectedValue)
                Return EndDate
            End Get
            Set(value As Date)
                'txtTimeStart.Text = Format(value, "yyyy-MM-dd HH:mm:ss")
                ddEndHour.SelectedValue = Hour(value)
                ddEndMinute.SelectedValue = Minute(value)
                ddEndSecond.SelectedValue = Second(value)
            End Set
        End Property

        Public Property Duration As String
            Get
                Return lblDuration.Text
            End Get
            Set(value As String)
                lblDuration.Text = value
            End Set
        End Property

#End Region

#Region "Session Reload for Editor"

        Public Sub LoadSessionData(SessionId_ As String)

            Dim MyFields As String() = {"timeStart", "timeEnd"}
            Dim SessionTable As DataTable = MyModules.Database.RdmsQuestions.GetQuestionSession(SessionId_, MyFields)

            Dim DateStart As Date = CDate(SessionTable(0)("timeStart"))
            Dim DateEnd As Date = CDate(SessionTable(0)("timeEnd"))

            'TimeStart
            txtTimeStart.Text = Format(DateStart, "dd MMM yyyy")
            ddStartHour.SelectedValue = DateStart.Hour
            ddStartMinute.SelectedValue = DateStart.Minute
            ddStartSecond.SelectedValue = DateStart.Second

            'TimeEnd
            ddEndHour.SelectedValue = DateEnd.Hour
            ddEndMinute.SelectedValue = DateEnd.Minute
            ddEndSecond.SelectedValue = DateEnd.Second

            SessionTable.Dispose()
        End Sub

#End Region

        Private Sub ReCalculate()
            Dim StartDate As Date = String.Format("{0} {1}:{2}:{3}", txtTimeStart.Text, ddStartHour.Text, ddStartMinute.Text, ddStartSecond.Text)
            Dim EndDate As Date = String.Format("{0} {1}:{2}:{3}", txtTimeStart.Text, ddEndHour.Text, ddEndMinute.Text, ddEndSecond.Text)
            Dim Duration_ As TimeSpan = EndDate.Subtract(StartDate)

            If Duration_ < TimeSpan.FromSeconds(0) Then
                lblDurationMsg.Visible = True
                lblDuration.ForeColor = Drawing.Color.Red
            Else
                lblDurationMsg.Visible = False
                lblDuration.ForeColor = Drawing.Color.Black
            End If

            lblDuration.Text = Duration_.ToString
        End Sub

        Private Sub ValidationRules()
            'Must put on PageLoad

            'Range Validation Setting
            Dim CurrentMonthDay As Integer = Day(Now)



            Dim FirstMonthDay As Date = Now.AddDays(-CurrentMonthDay + 1)
            Dim LastMonthDay As Date = FirstMonthDay.AddMonths(1).AddDays(-1)

            'Dim FirstYearDay As New DateTime(DateTime.Now.Year, 1, 1)   '<---------- Only Temporary until problem solved. Comment this these two lines if problem solved
            'txtTimeStartExt.StartDate = FirstYearDay                    '<---------- Only Temporary until problem solved. Comment this these two lines if problem solved - Notes:Problem already solved (nash)

            txtTimeStartExt.StartDate = FirstMonthDay                  '<---------- Only Temporary until problem solved. Uncomment this if problem solved

            txtTimeStartExt.EndDate = LastMonthDay
            txtTimeStartVal.MinimumValue = FirstMonthDay.ToShortDateString
            txtTimeStartVal.MaximumValue = LastMonthDay.ToShortDateString
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            ValidationRules()

            If Not IsPostBack Then ReCalculate()
        End Sub

        Private Sub btnReCalc_ServerClick() Handles btnReCalc.ServerClick
            ReCalculate()
        End Sub

    End Class

End Namespace

