Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.DutyCalendar

    Public Class DutyLegend
        Inherits System.Web.UI.UserControl

#Region "Remove Button"

        Public ReadOnly Property VirtualPathRemoveStaff As String
            Get
                Dim ReturnValue As String = "#"

                If DutyId > 0 And QueryStringRemoveButton.Length > 0 Then
                    Dim QueryString As String = QueryStringRemoveButton

                    NasLib.Functions.Web.QueryString.ModifyQueryStringValue(QueryString, MyRequest._DutyId, DutyId)
                    ReturnValue = VirtualPathRemoveButton & "?" & QueryString
                End If

                Return ResolveUrl(ReturnValue)
            End Get
        End Property

        Public Property VirtualPathRemoveButton As String
            Get
                Return gVirtualPathRemoveButton.Text
            End Get
            Set(value As String)
                gVirtualPathRemoveButton.Text = value
            End Set
        End Property

        Public Property QueryStringRemoveButton As String
            Get
                Return gQueryStringRemoveButton.Text
            End Get
            Set(value As String)
                gQueryStringRemoveButton.Text = value
            End Set
        End Property

        Public Property DutyId As Integer
            Get
                Return gDutyId.Text
            End Get
            Set(value As Integer)
                gDutyId.Text = value
            End Set
        End Property

        Public Property ButtonVisible As Boolean
            Get
                Return PanelButton.Visible
            End Get
            Set(value As Boolean)
                PanelButton.Visible = value
            End Set
        End Property

#End Region


        Public Property Text As String
            Get
                Return lblLegend.Text
            End Get
            Set(value As String)
                lblLegend.Text = value
            End Set
        End Property

        Public Property BgColor As String
            Get
                Return gBgColor.Text
            End Get
            Set(value As String)
                gBgColor.Text = value
            End Set
        End Property

        Public ReadOnly Property Colors As String
            Get
                Return FgColor & " " & BgColor
            End Get
        End Property

        Public Property FgColor As String
            Get
                Return gFgColor.Text
            End Get
            Set(value As String)
                gFgColor.Text = value
            End Set
        End Property

        Public Property ToolTip As String
            Get
                Return lblLegend.ToolTip
            End Get
            Set(value As String)
                lblLegend.ToolTip = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace