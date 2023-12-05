Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.DBLibrary

    Public Class Patron

#Region "Table Fields Properties"

#Region "FROM StaffActiv"

#Region "BP_NAMA"

        Public Shared Function GetPatronName(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.Nama(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.Fullname(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

#End Region

#Region "BP_NO_KP"

        Public Shared Function GetPatronIc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.NoIc(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.IcNo(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

#End Region

#Region "BK_JAB_SEKARANG_DESC"

        Public Shared Function GetPatronDepartment(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.JabatanSekarangDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

        Public Shared Function GetPatronDepartmentCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.JabatanSekarang(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "BK_JAW_JENIS"

        Public Shared Function GetPatronPosition(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.JawatanSekarangDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

        Public Shared Function GetPatronPositionCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.JawatanSekarang(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Position Type. A = Akademik, P = Pentadbiran, Z = Duno. For staff only
        ''' </summary>
        ''' <returns>A, P, Z or Null</returns>
        Public Shared Function GetPatronPositionType(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.JawatanJenis(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Returns 'Staff' Or 'Student' or nothing
        ''' </summary>
        Public Shared Function GetPatronType(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If IsStaff(PatronId, DBLibraryConnectionString) Then ReturnValue = "staff"
            If IsStudent(PatronId, DBLibraryConnectionString) Then ReturnValue = "student"

            Return ReturnValue
        End Function

#End Region

#Region "AL_ALAMAT"

        Public Shared Function GetPatronAddress1(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.Alamat1(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.PermanentAdd1(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

        Public Shared Function GetPatronAddress2(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.Alamat2(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.PermanentAdd2(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

        Public Shared Function GetPatronAddress3(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.Alamat3(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "AL_POSKOD"

        Public Shared Function GetPatronPostcode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.Postkod(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.PermanentPostcode(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

#End Region

#Region "AL_BANDAR"

        Public Shared Function GetPatronCity(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.Bandar(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.PermanentCity(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

#End Region

#Region "AL_NEGERI"

        Public Shared Function GetPatronState(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.Negeri(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.PermanentStateDesc(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

#End Region

#Region "AL_NEGARA"

        Public Shared Function GetPatronCountry(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.Negara(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "BK_TELEFON"

        Public Shared Function GetPatronPhone(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.Telefon(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.HandPhoneNo(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

#End Region

#Region "BP_EMAIL"

        Public Shared Function GetPatronEmail(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.Email(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.OfficialEmail(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

#End Region

#Region "BP_TJANGKA_BSARA"

        Public Shared Function GetPatronExpiryDate(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.TarikhJangkaBersara(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "BK_REKOD_STATUS"

        ''' <summary>
        ''' Get patron status. Aktive or Inactive
        ''' </summary>
        Public Shared Function GetPatronStatus(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = "Inactive"

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                If Table.StaffActiv.RekodStatus(PatronId, DBLibraryConnectionString) = "1" Then ReturnValue = "Active"
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                    If Table.StudActiv.ProcessStatusCode(PatronId, DBLibraryConnectionString) = "-1" Then ReturnValue = "Active"
                End If
            End If

            Return ReturnValue
        End Function

#End Region

#Region "BK_TARIKH_LAHIR"

        ''' <summary>
        ''' Get birthday as string. then must convert to date manualy
        ''' </summary>
        Public Shared Function GetPatronBirthDay(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.TarikhLahir(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                    ReturnValue = Table.StudActiv.DOB(PatronId, DBLibraryConnectionString)
            End If

            Return ReturnValue
        End Function

#End Region

#Region "BK_TARIKH_MASUK"

        Public Shared Function GetPatronRegistrationDate(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StaffActiv.TarikhMasuk(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "BK_REKOD_STATUS_DESC"

        Public Shared Function GetPatronStatusDesc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                ReturnValue = Table.StaffActiv.RekodStatusDesc(PatronId, DBLibraryConnectionString)
            Else
                If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                    ReturnValue = Table.StudActiv.ProcessStatusDesc(PatronId, DBLibraryConnectionString)
                End If
            End If

            Return ReturnValue
        End Function

#End Region

#End Region

#Region "From StudActiv"

#Region "CAMPUS_CODE"

        Public Shared Function GetPatronCampusCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.CampusCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "CAMPUS_DESC"

        Public Shared Function GetPatronCampusDesc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.CampusDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "PROGRAM_CODE"

        Public Shared Function GetPatronProgramCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.ProgramCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "PROGRAM_DESC"

        Public Shared Function GetPatronProgramDesc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.ProgramDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "FACULTY_CODE"

        Public Shared Function GetPatronFacultyCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.FacultyCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "FACULTY_DESC"

        Public Shared Function GetPatronFacultyDesc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.FacultyDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "PROGRAMLEVEL_CODE"

        Public Shared Function GetPatronProgramLevelCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.ProgramLevelCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "PROGRAMLEVEL_DESC"

        Public Shared Function GetPatronProgramLevelDesc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.ProgramLevelDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "STUDYMODE_CODE"

        Public Shared Function GetPatronStudyModeCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.StudyModeCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "STUDYMODE_DESC"

        Public Shared Function GetPatronStudyModeDesc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.StudyModeDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "RACE_CODE"

        Public Shared Function GetPatronRaceCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.RaceCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "RACE_DESC"

        Public Shared Function GetPatronRaceDesc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.RaceDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "PLACE_OF_BIRTH"

        Public Shared Function GetPatronPlaceOfBirth(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.PlaceOfBirth(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "INTAKE_SEM_CODE"

        Public Shared Function GetPatronIntakeSemCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.IntakeSemCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "INTAKE_SEM_DESC"

        Public Shared Function GetPatronIntakeSemDesc(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.IntakeSemDesc(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "DATE_RELOAD"

        Public Shared Function GetPatronDateReload(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.DateReload(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function
#End Region

#Region "CONVO_CODE"

        Public Shared Function GetPatronConvoCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.ConvoCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#Region "STATUS_HEA_CODE"

        Public Shared Function GetPatronStatusHeaCode(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then _
                ReturnValue = Table.StudActiv.StatusHeaCode(PatronId, DBLibraryConnectionString)

            Return ReturnValue
        End Function

#End Region

#End Region

#Region "From StudPhoto"

        Public Shared Function IsPhotoExisted(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Return Table.StudPhoto.IsExisted(PatronId, DBLibraryConnectionString)
        End Function


        Public Shared Function GetPatronPicSize(ByVal PatronId As String, Optional ByVal DBLibraryConnectionString As String = "") As Integer
            Dim ReturnValue As Integer = 0
            If IsPhotoExisted(PatronId, DBLibraryConnectionString) Then ReturnValue = Table.StudPhoto.PhotoSize(PatronId, DBLibraryConnectionString)
            Return ReturnValue
        End Function

        Public Shared Function GetPatronPicture(ByVal PatronId As String, Optional ByVal DBLibraryConnectionString As String = "") As Byte()
            Dim ReturnValue As Byte() = Nothing
            If IsPhotoExisted(PatronId, DBLibraryConnectionString) Then ReturnValue = Table.StudPhoto.Photo(PatronId, DBLibraryConnectionString)
            Return ReturnValue
        End Function

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsStaff(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function IsLibraryStaff(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            If Table.StaffActiv.IsExisted(PatronId, DBLibraryConnectionString) Then
                If Table.StaffActiv.JabatanSekarang(PatronId, DBLibraryConnectionString) = "A0401" Then ReturnValue = True
            End If

            Return ReturnValue
        End Function

        Public Shared Function IsStudent(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If Table.StudActiv.IsExisted(PatronId, DBLibraryConnectionString) Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function IsStudentActive(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If Table.StudActiv.IsPatronActive(PatronId, DBLibraryConnectionString) Then ReturnValue = True
            Return ReturnValue
        End Function

        ''' <summary>
        ''' Note: Username = PatronId in DBLibrary
        ''' </summary>
        ''' <param name="PatronId">Note: Username = PatronId in DBLibrary</param>
        ''' <param name="DBLibraryConnectionString">BDLibraryConnectionString</param>
        Public Shared Function IsExisted(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If IsStaff(PatronId, DBLibraryConnectionString) Or IsStudent(PatronId, DBLibraryConnectionString) Then ReturnValue = True
            Return ReturnValue
        End Function

        ''' <summary>
        ''' Active is only checked for students. Staffs are always considered as active.
        ''' </summary>
        Public Shared Function IsExisted(PatronId As String, ActiveOnly As Boolean, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If IsStaff(PatronId, DBLibraryConnectionString) Or (IsStudent(PatronId, DBLibraryConnectionString) And IsStudentActive(PatronId, DBLibraryConnectionString)) Then ReturnValue = True
            Return ReturnValue
        End Function

        ''' <summary>
        ''' Active is only checked for students. Staffs are always considered as active.
        ''' </summary>
        Public Shared Function IsActive(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False
            If IsStaff(PatronId, DBLibraryConnectionString) Or IsStudentActive(PatronId, DBLibraryConnectionString) Then ReturnValue = True
            Return ReturnValue
        End Function

        Public Shared Function CountStaff(DBLibraryConnectionString As String) As Integer
            Return Table.StaffActiv.Count(DBLibraryConnectionString)
        End Function

        Public Shared Function CountStudent(DBLibraryConnectionString As String) As Integer
            Return Table.StudActiv.Count(DBLibraryConnectionString)
        End Function

        Public Shared Function Count(DBLibraryConnectionString As String) As Integer
            Dim StaffCount As Integer = CountStaff(DBLibraryConnectionString)
            Dim StudentCount As Integer = CountStudent(DBLibraryConnectionString)
            Return StaffCount + StudentCount
        End Function

        Public Shared Function CountStaffActive(DBLibraryConnectionString As String) As Integer
            Return Table.StaffActiv.CountActive(DBLibraryConnectionString)
        End Function

        Public Shared Function CountStudentActive(DBLibraryConnectionString As String) As Integer
            Return Table.StudActiv.CountActive(DBLibraryConnectionString)
        End Function

        Public Shared Function CountActive(DBLibraryConnectionString As String) As Integer
            Dim StaffCount As Integer = CountStaffActive(DBLibraryConnectionString)
            Dim StudentCount As Integer = CountStudentActive(DBLibraryConnectionString)
            Return StaffCount + StudentCount
        End Function

        Public Shared Function IsPatronActive(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim IsStaffActive As Boolean = Table.StaffActiv.IsPatronActive(PatronId, DBLibraryConnectionString)
            Dim IsStudentActive As Boolean = Table.StudActiv.IsPatronActive(PatronId, DBLibraryConnectionString)

            If IsStaffActive Or IsStudentActive Then ReturnValue = True

            Return ReturnValue
        End Function

#End Region

#Region "Extra Functions"

        ''' <summary>
        ''' Get one role assign to this user by priority. Return NOTHING if no role.
        ''' </summary>
        Public Shared Function GetPatronRoles(PatronId As String, DBLibraryConnectionString As String) As String
            Dim ReturnValue As String = Nothing

            'Sort Descending by priority
            If IsStudent(PatronId, DBLibraryConnectionString) Then ReturnValue = "Student"
            If IsStaff(PatronId, DBLibraryConnectionString) Then ReturnValue = "Staff"

            Return ReturnValue
        End Function

        Public Shared Function GetPatronAspnetRole(ByVal PatronId As String, Optional ByVal DBLibraryConnectionString As String = "") As String
            Return GetPatronRoles(PatronId, DBLibraryConnectionString)
        End Function

        ''' <summary>
        ''' Check is Patron IDis Matched with Patron IC
        ''' </summary>
        ''' <param name="PatronId">Patron ID</param>
        ''' <param name="GivenPassport">Passport No</param>
        Public Shared Function IsMatchCredential(ByVal PatronId As String, GivenPassport As String, DBLibraryConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim IsPatronExisted As Boolean = IsExisted(PatronId, DBLibraryConnectionString)
            If IsPatronExisted Then
                Dim Passport As String = GetPatronIc(PatronId, DBLibraryConnectionString)
                If GivenPassport = Passport Then ReturnValue = True
            End If

            Return ReturnValue
        End Function

#End Region

    End Class

End Namespace


