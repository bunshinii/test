Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MyFields() As String = {"patronId", "mediumId", "timeStart", "question"}
        Dim Questiontable As DataTable = MyModules.Database.RdmsQuestions.GetQuestionOnMonth("236340", 8, 2014, MyFields)

        GridView1.DataSource = Questiontable
        GridView1.DataBind()
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub

End Class