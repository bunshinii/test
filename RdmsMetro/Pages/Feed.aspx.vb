Imports Rdms_Metro.MyModules.Functions.QueryString

Public Class Feed
    Inherits System.Web.UI.Page

    Private ReadOnly Property BranchId As Integer
        Get
            Return MyRequest.GetBranchId
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BranchId_ As Integer = BranchId

        SimpleContainer.IsFullView = True
        If BranchId_ > 0 Then SimpleContainer.BranchId = BranchId_
    End Sub

End Class