Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class Yearly2
    Inherits System.Web.UI.Page

    Private Sub LoadMyControls()
        If MyRequest.GetChkPatron Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByPatron = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByPatron.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudFaculty Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByFaculty = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByFaculty.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudProgram Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByProgramme = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByProgramme.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudCampus Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByCampus = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByCampus.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudLevel Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByStudLevel = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByStudLevel.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudMode Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByStudMode = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByStudMode.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStafDept Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByStaffDepartment = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByStaffDepartment.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStafType Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByStaffType = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByStaffType.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkOfficer Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByOfficer = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByOfficer.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkBranch Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByBranch = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByBranch.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkSatellite Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.BySatellite = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\BySatellite.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkDepartment Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByDepartment = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByDepartment.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkDivision Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByDivision = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByDivision.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkUnit Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Yearly.ByUnit = LoadControl("~\MyControls\Rdms\Reports\Statistics\Yearly\ByUnit.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If MyRequest.GetPrinterFriendly Then
            PanelPrepared.Visible = True
            lblFullname.Text = MyFullName
            lblPosition.Text = MyPosition
            lblDepartment.Text = MyDepartmentName
            lblDivision.Text = MyDivisionName
            lblUnit.Text = MyUnitName

            PanelNoPrint.Visible = False
        Else
            PanelPrepared.Visible = False
            PanelNoPrint.Visible = True
        End If

        LoadMyControls()

    End Sub

    Private Sub Daily_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If MyRequest.GetPrinterFriendly Then Me.MasterPageFile = "~/Masters/Blank.Master"
    End Sub

End Class