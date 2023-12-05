Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class Daily2
    Inherits System.Web.UI.Page


    Private Sub LoadMyControls()
        If MyRequest.GetChkPatron Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByPatron = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByPatron.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudFaculty Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByFaculty = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByFaculty.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudProgram Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByProgramme = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByProgramme.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudCampus Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByCampus = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByCampus.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudLevel Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByStudLevel = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByStudLevel.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStudMode Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByStudMode = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByStudMode.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStafDept Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByStaffDepartment = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByStaffDepartment.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkStafType Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByStaffType = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByStaffType.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkOfficer Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByOfficer = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByOfficer.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkBranch Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByBranch = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByBranch.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkSatellite Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.BySatellite = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\BySatellite.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkDepartment Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByDepartment = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByDepartment.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkDivision Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByDivision = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByDivision.ascx")
            PlaceHolder1.Controls.Add(Mycontrol)
        End If
        If MyRequest.GetChkUnit Then
            Dim Mycontrol As MyControls.Rdms.Reports.Statistics.Daily.ByUnit = LoadControl("~\MyControls\Rdms\Reports\Statistics\Daily\ByUnit.ascx")
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