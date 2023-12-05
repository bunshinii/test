Imports Rdms_Metro.MyModules.Functions.QueryString

Namespace MyControls.Rdms.DutyCalendar

    Public Class DutyTypeButton
        Inherits System.Web.UI.UserControl

#Region "Requirements"

        ''1. Must Add this button in "<div class="listview"></div>"

#End Region

#Region "Public Properties"

#Region "Virtual Path"

        ''' <summary>
        ''' Link for this button to redirect.
        ''' </summary>
        Public ReadOnly Property AbsolutePath As String
            Get
                Dim ReturnValue As String = "#"

                If Not VirtualPath = "~/" Or VirtualPath.Length > 2 Then

                    NasLib.Functions.Web.QueryString.ModifyQueryStringValue(QueryString, MyRequest._DutyTypeId, DutyTypeId)
                    ReturnValue = ResolveUrl(VirtualPath & "?" & QueryString)

                End If

                Return ReturnValue
            End Get
        End Property

        ''' <summary>
        ''' VirtualPath for this button to redirect
        ''' </summary>
        Public Property VirtualPath As String
            Get
                Return gVirtualPath.Text
            End Get
            Set(value As String)
                gVirtualPath.Text = value
            End Set
        End Property

        Public Property QueryString As String
            Get
                Return gQueryString.Text
            End Get
            Set(value As String)
                gQueryString.Text = value
            End Set
        End Property

#End Region

#Region "Color"

        Public ReadOnly Property Colors As String
            Get
                Return BackGroundColor & " " & ForeGroundColor
            End Get
        End Property


        Public Property BackGroundColor As String
            Get
                Return gBgColor.Text
            End Get
            Set(value As String)
                gBgColor.Text = value
            End Set
        End Property

        Public Property ForeGroundColor As String
            Get
                Return gFgColor.Text
            End Get
            Set(value As String)
                gFgColor.Text = value
            End Set
        End Property

#End Region

#Region "Normal"

        Public Property DutyName As String
            Get
                Return lblName.Text
            End Get
            Set(value As String)
                lblName.Text = value
            End Set
        End Property

        Public Property DutyTypeId As String
            Get
                Return gDutyTypeId.Text
            End Get
            Set(value As String)
                gDutyTypeId.Text = value
            End Set
        End Property

        Public Property ToolTip As String
            Get
                Return gToolTip.Text
            End Get
            Set(value As String)
                gToolTip.Text = value
            End Set
        End Property

#End Region

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

