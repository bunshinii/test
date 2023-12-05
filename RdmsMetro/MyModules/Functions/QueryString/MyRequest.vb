Imports NasLib.Functions.Web.QueryString

Namespace MyModules.Functions.QueryString.MyRequest

    ''' <summary>
    ''' List of of possible QueryStrings in this application here to standardise the key.
    ''' All the Function below is to Get the QueryString Value by the functions name (e.g.'id').
    ''' its like the function 'Request("id")'. Must match the number of QueryString with the "Request" region and the "QueryString Settings" region.
    ''' </summary>
    Module MyRequest
        '1. Imports Rdms_Metro.MyModules.Functions.QueryString

        Public Function OwnerId() As String
            Return HttpContext.Current.User.Identity.Name
        End Function

#Region "QueryString Settings"
        '2. List of of possible QueryStrings in this application here
        'Variable must be declared as Strings

        Public _PrinterFriendly As String = "print"

        Public _Id As String = "id"
        Public _DutyId As String = "dutyid"
        Public _DutyTypeId As String = "dutytypeid"
        Public _SenderId As String = "senderId"""
        Public _ReceiverId As String = "receiverid"
        Public _PatronId As String = "patronid"
        Public _Success As String = "success"
        Public _Code As String = "code"
        Public _SatelliteInitial As String = "sat"
        Public _SessionId As String = "sessionid"
        Public _Day As String = "d"
        Public _Month As String = "m"
        Public _Year As String = "y"
        Public _BranchId As String = "branch"
        Public _SatelliteId As String = "satid"
        Public _DepartmentId As String = "deptid"
        Public _DivisionId As String = "divid"
        Public _UnitId As String = "unitid"
        Public _Url As String = "url"
        Public _OfficerId As String = "officer"
        Public _CustomPatronId As String = "cuspatronid"

        'Students and staff
        Public _StudBranchId As String = "sbranch"
        Public _StudFacultyCode As String = "sfac"
        Public _StudProgramCode As String = "spro"
        Public _StudLevelCode As String = "slvl"
        Public _StudModeCode As String = "smode"
        Public _StudCampusCode As String = "scam"
        Public _StafDepartmentCode As String = "sdept"
        Public _StafTypeCode As String = "stype"

        'For generating statistics
        Public _ListingMode As String = "list"
        Public _FilterMode As String = "filter"
        Public _FilterModeEnabled As String = "filterenabled"
        Public _HourlyDisplayEnabled As String = "hourdisp"

        'Snippet
        Public _SnippetType As String = "snip"

        'Stat option
        Public _chkPatron As String = "chkPatron"
        Public _chkStudFaculty As String = "chkStudFaculty"
        Public _chkStudProgram As String = "chkStudProgram"
        Public _chkStudCampus As String = "chkStudCampus"
        Public _chkStudLevel As String = "chkStudLevel"
        Public _chkStudMode As String = "chkStudMode"
        Public _chkStafDept As String = "chkStafDept"
        Public _chkStafType As String = "chkStafType"
        Public _chkCusPatron As String = "chkCusPatron"

        Public _chkOfficer As String = "chkOfficer"
        Public _chkBranch As String = "chkBranch"
        Public _chkSatellite As String = "chkSatellite"
        Public _chkDepartment As String = "chkDepartment"
        Public _chkDivision As String = "chkDivision"
        Public _chkUnit As String = "chkUnit"


#End Region

#Region "Request"
        '3. Match the number of functions below with the number of variables in "QueryString Settings" region
        'PLEASE match function names with the 'Add' region and PLEASE the watch the 'As' types

        Public Function GetPrinterFriendly() As Boolean
            Return RequestBool(_PrinterFriendly)
        End Function

        Public Function GetId() As Integer
            Return RequestInt(_Id)
        End Function

        Public Function GetDutyId() As Integer
            Return RequestInt(_DutyId)
        End Function

        Public Function GetDutyTypeId() As Integer
            Return RequestInt(_DutyTypeId)
        End Function

        Public Function GetSenderId() As String
            Return RequestStr(_SenderId)
        End Function

        Public Function GetReceiverId() As String
            Return RequestStr(_ReceiverId)
        End Function

        Public Function GetPatronId() As String
            Return RequestStr(_PatronId)
        End Function

        Public Function GetSuccess() As Boolean
            Return RequestBool(_Success)
        End Function

        Public Function GetCode() As Integer
            Return RequestInt(_Code)
        End Function

        Public Function GetSatInit() As String
            Return RequestStr(_SatelliteInitial)
        End Function

        Public Function GetSessionid() As String
            Return RequestStr(_SessionId)
        End Function

        Public Function GetDay() As Integer
            Return RequestInt(_Day)
        End Function

        Public Function GetMonth() As Integer
            Return RequestInt(_Month)
        End Function

        Public Function GetYear() As Integer
            Return RequestInt(_Year)
        End Function

        ''' <summary>
        ''' A combination of GetDay, GetMonth and GetYear.
        ''' Return "yyy-MM-dd" as string format.
        ''' Return empty string if error
        ''' </summary>
        Public Function GetDate() As String
            Dim ReturnValue As String = ""

            'Try
            '    Dim MyDate As Date = String.Format("{0}-{1}-{2} 00:00:00", GetYear, GetMonth, GetDay)
            '    ReturnValue = Format(MyDate, "yyy-MM-dd")
            'Catch ex As Exception
            '    Dim message As String = ex.Message
            'End Try

            Dim TheDate_ As Date

            If Date.TryParse(String.Format("{0}-{1}-{2} 00:00:00", GetYear, GetMonth, GetDay), TheDate_) Then
                ReturnValue = Format(TheDate_, "yyyy-MM-dd")
            End If

            Return ReturnValue
        End Function

        Public Function GetBranchId() As Integer
            Return RequestInt(_BranchId)
        End Function

        Public Function GetSatelliteId() As Integer
            Return RequestInt(_SatelliteId)
        End Function

        Public Function GetDepartmentId() As Integer
            Return RequestInt(_DepartmentId)
        End Function

        Public Function GetDivisionId() As Integer
            Return RequestInt(_DivisionId)
        End Function

        Public Function GetUnitId() As Integer
            Return RequestInt(_UnitId)
        End Function

        ''' <summary>
        ''' Already use URL Decode on Get.
        ''' Must use URL Encode on the value to Set.
        ''' </summary>
        Public Function GetURL() As Integer
            Return HttpUtility.UrlDecode(RequestStr(_Url))
        End Function

        Public Function GetOfficerId() As String
            Return RequestStr(_OfficerId)
        End Function

        Public Function GetCustomPatronId() As String
            Return RequestStr(_CustomPatronId)
        End Function

        Public Function GetChkCustomPatronId() As Boolean
            Dim ReturnValue As Boolean = False

            If String.IsNullOrEmpty(RequestStr(_CustomPatronId)) Then
                ReturnValue = False
            Else
                ReturnValue = True
            End If

            Return ReturnValue
        End Function

#Region "Students"

        Public Function GetStudBranchId() As Integer
            Return RequestInt(_StudBranchId)
        End Function

        Public Function GetStudFacultyCode() As String
            Return RequestStr(_StudFacultyCode)
        End Function

        Public Function GetStudProgramCode() As String
            Return RequestStr(_StudProgramCode)
        End Function

        Public Function GetStudLevelCode() As String
            Return RequestStr(_StudLevelCode)
        End Function

        Public Function GetStudModeCode() As String
            Return RequestStr(_StudModeCode)
        End Function

        Public Function GetStudCampusCode() As String
            Return RequestStr(_StudCampusCode)
        End Function

        Public Function GetStafDepartmentCode() As String
            Return RequestStr(_StafDepartmentCode)
        End Function

        Public Function GetStafTypeCode() As String
            Return RequestStr(_StafTypeCode)
        End Function

#End Region

#Region "For generating statistics"

        ''' <summary>
        ''' Using Dropdown Index as integer. Do not use dropdown value
        ''' </summary>
        Public Function GetListingModeIndex() As Integer
            Return RequestInt(_ListingMode)
        End Function

        ''' <summary>
        ''' Using Dropdown Index as integer. Do not use dropdown value
        ''' </summary>
        Public Function GetFilterModeIndex() As Integer
            Return RequestInt(_FilterMode)
        End Function

        Public Function GetFilterModeEnabled() As Boolean
            Return RequestBool(_FilterModeEnabled)
        End Function

        Public Function GetHourlyDisplayEnabled() As Boolean
            Return RequestBool(_HourlyDisplayEnabled)
        End Function

#End Region

#Region "Snippet"

        Public Function GetSnippetType() As String
            Return RequestStr(_SnippetType)
        End Function

#End Region

#Region "Stats Option"

        Public Function GetChkPatron() As Boolean
            Return RequestBool(_chkPatron)
        End Function

        Public Function GetChkStudFaculty() As Boolean
            Return RequestBool(_chkStudFaculty)
        End Function

        Public Function GetChkStudProgram() As Boolean
            Return RequestBool(_chkStudProgram)
        End Function

        Public Function GetChkStudCampus() As Boolean
            Return RequestBool(_chkStudCampus)
        End Function

        Public Function GetChkStudLevel() As Boolean
            Return RequestBool(_chkStudLevel)
        End Function

        Public Function GetChkStudMode() As Boolean
            Return RequestBool(_chkStudMode)
        End Function

        Public Function GetChkStafDept() As Boolean
            Return RequestBool(_chkStafDept)
        End Function

        Public Function GetChkStafType() As Boolean
            Return RequestBool(_chkStafType)
        End Function

        Public Function GetChkOfficer() As Boolean
            Return RequestBool(_chkOfficer)
        End Function

        Public Function GetChkBranch() As Boolean
            Return RequestBool(_chkBranch)
        End Function

        Public Function GetChkSatellite() As Boolean
            Return RequestBool(_chkSatellite)
        End Function

        Public Function GetChkDepartment() As Boolean
            Return RequestBool(_chkDepartment)
        End Function

        Public Function GetChkDivision() As Boolean
            Return RequestBool(_chkDivision)
        End Function

        Public Function GetChkUnit() As Boolean
            Return RequestBool(_chkUnit)
        End Function

#End Region

#End Region

    End Module

End Namespace


