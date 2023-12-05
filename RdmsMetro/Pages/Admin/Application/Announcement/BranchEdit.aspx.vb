Public Class BranchEdit
    Inherits System.Web.UI.Page

    Public ReadOnly Property BranchId As Integer
        Get
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.BranchId(MyOwnId, ProvidersConnectionString)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim BranchId_ As Integer = BranchId
        BranchEditor1.BranchId = BranchId_
    End Sub

End Class