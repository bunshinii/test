﻿
Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        RouteConfig.RegisterRoutes(RouteTable.Routes)

        'Initialize ConnectionStrings
        NasLib.GlobalSetting.ProvidersConnectionString = ProvidersConnectionString
        NasLib.GlobalSetting.DbLibraryConnectionString = DbLibraryConnectionString
        NasLib.GlobalSetting.MyAppConnectionString = MyAppConnectionString
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub
End Class