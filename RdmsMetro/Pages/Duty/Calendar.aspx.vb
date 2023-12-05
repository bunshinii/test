Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class Calendar
    Inherits System.Web.UI.Page

#Region "Public Properties"

    Private ReadOnly Property GetMonth As Integer
        Get
            Dim MyMonth_ As Integer = MyRequest.GetMonth

            Dim ReturnValue As Integer = 0
            If MyMonth_ = 0 Then
                ReturnValue = Month(Now)
            Else
                ReturnValue = MyMonth_
            End If

            Return ReturnValue
        End Get
    End Property

    Private ReadOnly Property GetYear As Integer
        Get
            Dim MyYear_ As Integer = MyRequest.GetYear

            Dim ReturnValue As Integer = 0
            If MyYear_ = 0 Then
                ReturnValue = Year(Now)
            Else
                ReturnValue = MyYear_
            End If

            Return ReturnValue
        End Get
    End Property

    Private ReadOnly Property SatelliteInitial As String
        Get
            Dim MyStr As String = MyRequest.GetSatInit

            If MyStr.Length = 0 Then Response.Redirect("~/")
            Return MyStr
        End Get
    End Property

    Private Function SatelliteName() As String
        Dim SatInit As String = SatelliteInitial

        If SatInit.Length > 0 Then
            SatelliteName = NasLib.Database.MySql.Provider.Table.OfficeSatellite.Satellite(SatInit, ProvidersConnectionString)
        Else
            SatelliteName = ""
            Response.Redirect("~/")
        End If

    End Function

#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim YearNo As Integer = GetYear
        Dim MonthNo As Integer = GetMonth

        MonthlyContainer1.SatelliteInitial = SatelliteInitial
        If YearNo = 0 Or MonthNo = 0 Then
            MonthlyContainer1.YearNo = Format(Now, "yyy")
            MonthlyContainer1.MonthNo = Format(Now, "MM")
        Else
            MonthlyContainer1.YearNo = YearNo
            MonthlyContainer1.MonthNo = MonthNo
        End If

        lblSattellite.Text = SatelliteName()
    End Sub

End Class