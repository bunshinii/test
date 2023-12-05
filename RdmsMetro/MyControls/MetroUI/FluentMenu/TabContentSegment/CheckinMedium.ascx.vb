Namespace MyControls.MetroUI.FluentMenu.TabContentSegment

    Public Class CheckinMedium
        Inherits System.Web.UI.UserControl


        Public Property MediumId As Integer
            Get
                Return ddMedium.SelectedValue
            End Get
            Set(value As Integer)
                LoadDdMedium()
                ddMedium.SelectedValue = value
            End Set
        End Property

        Private Sub LoadDdMedium()
            Dim Mediumtable As DataTable = MyModules.Database.RdmsMedium.GetAllMediums()

            If Mediumtable.Rows.Count > 0 Then
                For i As Integer = 0 To Mediumtable.Rows.Count - 1
                    Dim MyItem As New ListItem
                    MyItem.Value = Mediumtable(i)(0)
                    MyItem.Text = Mediumtable(i)(1)

                    ddMedium.Items.Add(MyItem)
                Next

            End If

            Mediumtable.Dispose()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                If Not ddMedium.Items.Count > 0 Then
                    LoadDdMedium()
                End If

            End If
        End Sub

    End Class

End Namespace

