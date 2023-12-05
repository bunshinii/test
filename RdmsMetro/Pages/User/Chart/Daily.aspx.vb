Imports Rdms_Metro.MyModules.Functions.QueryString
Imports NasLib.Database.MySql.Sql.Simplifier
Imports NasLib.Database.MySql

Public Class Daily1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MyMasterPage.MasterCustomProgress.Visible = True

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

    End Sub

    Private Sub Daily_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If MyRequest.GetPrinterFriendly Then Me.MasterPageFile = "~/Masters/Blank.Master"
    End Sub

End Class