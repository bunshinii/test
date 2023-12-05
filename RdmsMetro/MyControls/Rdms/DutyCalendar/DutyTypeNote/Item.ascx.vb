Namespace MyControls.Rdms.DutyCalendar.DutyTypeNote

    Public Class Item
        Inherits System.Web.UI.UserControl

#Region "Requirements"

        '' Must add in <table> tag
        '' Becase this is table row

#End Region

#Region "Public Properties"

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

        Public Property DutyName As String
            Get
                Return lblName.Text
            End Get
            Set(value As String)
                lblName.Text = value
            End Set
        End Property

        Public Property DutyDescription As String
            Get
                Return lblDecription.Text
            End Get
            Set(value As String)
                lblDecription.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Load
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public WriteOnly Property Initiate As Boolean
            Set(value As Boolean)



            End Set
        End Property


#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

    End Class

End Namespace

