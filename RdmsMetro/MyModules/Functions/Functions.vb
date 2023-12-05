Namespace MyModules.Functions

    Module Functions

#Region "User"

        Public Function CurrentUsername() As String
            Return HttpContext.Current.User.Identity.Name
        End Function

        Public Function UserFullname(Username As String) As String
            Return NasLib.Database.MySql.Provider.Table.UsersProfile.FullName(Username, ProvidersConnectionString)
        End Function

#End Region



    End Module

End Namespace


