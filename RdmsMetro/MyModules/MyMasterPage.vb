﻿
Namespace MyMasterPage

    Module MyMasterPage
        '' List All Controls in the root Masterpage that need to be controlled globally here in Public Property

#Region "Global Script Manager"

        ''' <summary>
        ''' Assumimg that the ToolkitScriptManager.ID = ToolkitScriptManager1.
        ''' And its in the root MasterPage
        ''' </summary>
        Public Property ToolkitScriptManager As AjaxControlToolkit.ToolkitScriptManager
            Get
                Dim Page As Page = HttpContext.Current.Handler
                Dim ToolkitScriptManager1 As AjaxControlToolkit.ToolkitScriptManager = DirectCast(Page.Master.FindControl("ToolkitScriptManager1"), AjaxControlToolkit.ToolkitScriptManager)
                Return ToolkitScriptManager1
            End Get
            Set(value As AjaxControlToolkit.ToolkitScriptManager)
                Dim Page As Page = HttpContext.Current.Handler
                Dim ToolkitScriptManager1 As AjaxControlToolkit.ToolkitScriptManager = DirectCast(Page.Master.FindControl("ToolkitScriptManager1"), AjaxControlToolkit.ToolkitScriptManager)
                ToolkitScriptManager1 = value
            End Set
        End Property

        Public ReadOnly Property AsyncPostBackSourceElementID As String
            Get
                Return ToolkitScriptManager.AsyncPostBackSourceElementID
            End Get
        End Property

        ''' <summary>
        ''' Use on Page_Load and Button postback event to only trigger functions inside only once if False.
        ''' </summary>
        Public ReadOnly Property AsyncPostBackByElement As Boolean
            Get
                Dim ReturnValue As Boolean = False
                If ToolkitScriptManager.AsyncPostBackSourceElementID.Length > 0 Then ReturnValue = True
                Return ReturnValue
            End Get
        End Property

#End Region

#Region "Update Progress"

        Public Property MasterUpdateProgress As System.Web.UI.UpdateProgress
            Get
                Dim Page As Page = HttpContext.Current.Handler
                Dim MyUpdateProgress As System.Web.UI.UpdateProgress = DirectCast(Page.Master.FindControl("UpdateProgress1"), System.Web.UI.UpdateProgress)
                Return MyUpdateProgress
            End Get
            Set(value As System.Web.UI.UpdateProgress)
                Dim Page As Page = HttpContext.Current.Handler
                Dim MyUpdateProgress As System.Web.UI.UpdateProgress = DirectCast(Page.Master.FindControl("UpdateProgress1"), System.Web.UI.UpdateProgress)
                MyUpdateProgress = value
            End Set
        End Property

        Public Property MasterCustomProgress As Panel
            Get
                Dim Page As Page = HttpContext.Current.Handler
                Dim MyUpdateProgress As Panel = DirectCast(Page.Master.FindControl("PanelProgress"), Panel)
                Return MyUpdateProgress
            End Get
            Set(value As Panel)
                Dim Page As Page = HttpContext.Current.Handler
                Dim MyUpdateProgress As Panel = DirectCast(Page.Master.FindControl("PanelProgress"), Panel)
                MyUpdateProgress = value
            End Set
        End Property

#End Region

    End Module

End Namespace

