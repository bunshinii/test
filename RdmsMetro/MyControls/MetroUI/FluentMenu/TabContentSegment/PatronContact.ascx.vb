Namespace MyControls.MetroUI.FluentMenu.TabContentSegment

    Public Class PatronContact
        Inherits System.Web.UI.UserControl

        Public Property PatronId As String
            Get
                Return lblPatronId.Text
            End Get
            Set(value As String)
                lblPatronId.Text = value
                LoadData()
            End Set
        End Property

        Private Sub LoadData()
            Dim IsStudent As Boolean = NasLib.Database.MySql.CustomProvider.DBLibrary.Patron.IsStudent(PatronId, DbLibraryConnectionString)
            Dim IsStaff As Boolean = False

            If IsStudent Then
                LoadStudentData()
            Else
                IsStaff = NasLib.Database.MySql.CustomProvider.DBLibrary.Patron.IsStaff(PatronId, DbLibraryConnectionString)
                If IsStaff Then LoadStaffData()
            End If

        End Sub

        Private Sub LoadStudentData()

            'STUDENTID, HANDPHONE_NO, OFFICIAL_EMAIL
            Dim PatronTable As DataTable = NasLib.Database.MySql.CustomProvider.DBLibrary.Table.StudActiv.GetSinglePatronInfoContact(PatronId, DbLibraryConnectionString)

            If PatronTable.Rows.Count > 0 Then
                lblPhone.Text = PatronTable(0)("HANDPHONE_NO")
                lblEmail.Text = PatronTable(0)("OFFICIAL_EMAIL")
            End If

            PatronTable.Dispose()

        End Sub

        Private Sub LoadStaffData()

            'BP_NO_PEKERJA, BK_TELEFON, BP_EMAIL
            Dim PatronTable As DataTable = NasLib.Database.MySql.CustomProvider.DBLibrary.Table.StaffActiv.GetSinglePatronInfoContact(PatronId, DbLibraryConnectionString)

            If PatronTable.Rows.Count > 0 Then
                lblPhone.Text = PatronTable(0)("BK_TELEFON")
                lblEmail.Text = PatronTable(0)("BP_EMAIL")
            End If

            PatronTable.Dispose()

        End Sub

    End Class

End Namespace

