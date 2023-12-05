Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class Monthly2
    Inherits System.Web.UI.Page

    Private Sub LoadMyControls()
        If MyRequest.GetChkPatron Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByPatron = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByPatron.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudFaculty Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByFaculty = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByFaculty.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudProgram Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByProgramme = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByProgramme.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudCampus Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByCampus = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByCampus.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudLevel Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByStudLevel = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByStudLevel.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudMode Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByStudMode = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByStudMode.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStafDept Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByStaffDepartment = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByStaffDepartment.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStafType Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByStaffType = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByStaffType.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkOfficer Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByOfficer = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByOfficer.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkBranch Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByBranch = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByBranch.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkSatellite Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.BySatellite = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\BySatellite.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkDepartment Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByDepartment = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByDepartment.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkDivision Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByDivision = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByDivision.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkUnit Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Monthly.ByUnit = LoadControl("~\MyControls\Rdms\Reports\Statistics\Monthly\ByUnit.ascx")
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