Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.DutyCalendar.Monthly

    Public Class Container
        Inherits System.Web.UI.UserControl

#Region "Public Properties"

        Public Property MonthNo As Integer
            Get
                Return gMonthNo.Text
            End Get
            Set(value As Integer)
                gMonthNo.Text = value
                lblMonthName.Text = MonthName(value)

            End Set
        End Property

        Public Property YearNo As Integer
            Get
                Return lblYear.Text
            End Get
            Set(value As Integer)
                lblYear.Text = value
            End Set
        End Property

        Public Property SatelliteInitial As String
            Get
                Dim ReturnValue As String = ""
                Dim Initial As String = gSatInit.Text
                If Not String.IsNullOrEmpty(Initial) Then ReturnValue = Initial

                Return ReturnValue
            End Get
            Set(value As String)
                gSatInit.Text = value
            End Set
        End Property

#End Region

#Region "Functions"

        Private Function StartColumnOfTheMonth() As Integer
            Dim ReturnValue As Integer = 0

            Dim MonthNo_ As Integer = MonthNo
            Dim YearNo_ As Integer = YearNo

            Dim MyDate As Date = String.Format("{0}-{1}-{2}", YearNo_, MonthNo_, 1)

            Dim MyDayName As String = Format(MyDate, "ddd")

            Select Case MyDayName
                Case "Sun"
                    ReturnValue = 1
                Case "Mon"
                    ReturnValue = 2
                Case "Tue"
                    ReturnValue = 3
                Case "Wed"
                    ReturnValue = 4
                Case "Thu"
                    ReturnValue = 5
                Case "Fri"
                    ReturnValue = 6
                Case "Sat"
                    ReturnValue = 7
                Case Else
                    ReturnValue = 8
            End Select

            Return ReturnValue
        End Function


        Private Function LastDateOfTheMonth(MonthNo_ As Integer) As Integer
            Dim TheDate As Date = CDate(String.Format("{0}-{1}-01", YearNo, MonthNo_))
            TheDate = TheDate.AddMonths(1)
            TheDate = CDate(Format(TheDate, "yyy-MM-01"))
            TheDate = TheDate.AddDays(-1)

            Dim ReturnValue As String = Format(TheDate, "dd")
            Return ReturnValue
        End Function

        Private Function Istoday(DayNo As Integer) As Boolean
            Dim TodayNo As Integer = Format(Now, "dd")

            Istoday = False
            If TodayNo = DayNo Then Istoday = True
        End Function

        Private Function GetGeneratedDate(DayNo As Integer) As Date
            Dim MyYear As Integer = YearNo
            Dim MyMonth As Integer = MonthNo
            Dim MyDay As Integer = DayNo

            Dim MyDate As Date = String.Format("{0}-{1}-{2}", MyYear, MyMonth, MyDay)
            Return MyDate
        End Function

        Private Sub LoadLegend()
            'Legend
            Dim TypeTable As DataTable = MyModules.StaffDuty.DutyTypes

            Dim TypeCount As Integer = TypeTable.Rows.Count

            If TypeCount > 0 Then

                'id, duty_type, note, bgColor, foreColor
                For i As Integer = 0 To TypeCount - 1
                    Dim DutyTypeId As Integer = TypeTable(i)("id")

                    Dim MyLegends As MyControls.Rdms.DutyCalendar.Monthly.Legend = LoadControl("~/MyControls/Rdms/DutyCalendar/Monthly/Legend.ascx")
                    MyLegends.DutyTypeId = DutyTypeId
                    phLegend.Controls.Add(MyLegends)
                Next
            End If

            TypeTable.Dispose()
        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim StartColumnNo As Integer = StartColumnOfTheMonth()

            Dim LastDate As Integer = LastDateOfTheMonth(MonthNo)
            Dim LastColumnNo As Integer = StartColumnNo + LastDate

            Dim i2 As Integer = StartColumnNo - 1
            Dim i3 As Integer = 0
            For i As Integer = 1 To LastDate '35

                If i2 = 35 Then
                    i2 = 1
                ElseIf i2 > 35 Then
                    i2 = i2 + i3
                    i3 = i3 + 1
                Else
                    i2 = i2 + 1
                End If

                Dim MainContent As ContentPlaceHolder = DirectCast(Page.Master.FindControl("MainContent"), ContentPlaceHolder)
                Dim MonthlyContainer1 As MyControls.Rdms.DutyCalendar.Monthly.Container = DirectCast(MainContent.FindControl("MonthlyContainer1"), MyControls.Rdms.DutyCalendar.Monthly.Container)
                Dim MyPlaceHolder As PlaceHolder = DirectCast(MonthlyContainer1.FindControl("PlaceHolder" & i2), PlaceHolder)

                Dim MyControl As MyControls.Rdms.DutyCalendar.Monthly.Item = LoadControl("~/MyControls/Rdms/DutyCalendar/Monthly/Item.ascx")
                MyControl.TheDate = GetGeneratedDate(i)
                MyPlaceHolder.Controls.Add(MyControl)

            Next

            LoadLegend()
        End Sub

        Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev1.ServerClick
            Dim MyDate As Date = String.Format("{0}-{1}-1", YearNo, MonthNo)
            MyDate = MyDate.AddMonths(-1)
            'Response.Redirect(String.Format("~/Pages/Duty/Calendar.aspx?y={0}&m={1}&sat={2}", MyDate.Year, MyDate.Month, SatelliteInitial), True)

            Dim KeyArray() As String = {MyRequest._Year, MyRequest._Month, MyRequest._SatelliteInitial}
            Dim ValArray() As String = {MyDate.Year, MyDate.Month, SatelliteInitial}
            MyResponse.Redirect("~/Pages/Duty/Calendar.aspx", KeyArray, ValArray)
        End Sub

        Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext1.ServerClick
            Dim MyDate As Date = String.Format("{0}-{1}-1", YearNo, MonthNo)
            MyDate = MyDate.AddMonths(1)
            'Response.Redirect(String.Format("~/Pages/Duty/Calendar.aspx?y={0}&m={1}&sat={2}", MyDate.Year, MyDate.Month, SatelliteInitial), True)

            Dim KeyArray() As String = {MyRequest._Year, MyRequest._Month, MyRequest._SatelliteInitial}
            Dim ValArray() As String = {MyDate.Year, MyDate.Month, SatelliteInitial}
            MyResponse.Redirect("~/Pages/Duty/Calendar.aspx", KeyArray, ValArray)
        End Sub
    End Class

End Namespace

