Imports Rdms_Metro.MyVariable.VariableKey

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MyFields() As String = {"patronId", "mediumId", "question", "timeStart"}
        Dim Questiontable As DataTable = MyModules.Database.RdmsQuestions.GetQuestionOnMonth("236340", 8, 2014, MyFields)

        GridView1.DataSource = Questiontable
        GridView1.DataBind()

    End Sub


End Class