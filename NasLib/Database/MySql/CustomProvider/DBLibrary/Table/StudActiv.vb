Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.DBLibrary.Table

    ''' <summary>
    ''' This is a table base class base on table 'stud_activ'
    ''' </summary>
    Public Class StudActiv

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "stud_activ"
        End Function

        'List all field in the table here
        Private Enum eFieldName
            STUDENTID               'Primary Key
            ICNO                    'Index
            NAME                    'Index (sort)
            PROCESS_STATUS_CODE     'Index
            PROCESS_STATUS_DESC
            CAMPUS_CODE             'Index
            CAMPUS_DESC
            PROGRAM_CODE            'Index
            PROGRAM_DESC
            FACULTY_CODE            'Index
            FACULTY_DESC
            PROGRAMLEVEL_CODE       'Index
            PROGRAMLEVEL_DESC
            STUDYMODE_CODE          'Index
            STUDYMODE_DESC
            RACE_CODE               'Index
            RACE_DESC
            DOB                     'Index
            PLACE_OF_BIRTH
            PERMANENT_ADD1
            PERMANENT_ADD2
            PERMANENT_POSTCODE
            PERMANENT_CITY
            PERMANENT_STATE_CODE
            PERMANENT_STATE_DESC
            HANDPHONE_NO
            OFFICIAL_EMAIL
            INTAKE_SEM_CODE
            INTAKE_SEM_DESC
            DATE_RELOAD
            CONVO_CODE
            STATUS_HEA_CODE         'Index

            '' Multiple Field Index:
            '  STUDENTID, PROCESS_STATUS_CODE
        End Enum

#End Region

#Region "Table Fields Properties"

#Region "id"

        Public Shared ReadOnly Property Id(ByVal PatronIC As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.STUDENTID.ToString
                Dim MyCriteria As String = Criteria(eFieldName.ICNO.ToString, PatronIC)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "STUDENTID"

        Public Shared ReadOnly Property StudentId(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.STUDENTID.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

        Public Shared ReadOnly Property PatronId(ByVal _PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.STUDENTID.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, _PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

        Public Shared ReadOnly Property PatronIdByIc(ByVal _PatronIC As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.STUDENTID.ToString
                Dim MyCriteria As String = Criteria(eFieldName.ICNO.ToString, _PatronIC)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "ICNO"

        Public Shared ReadOnly Property IcNo(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.ICNO.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "NAME"

        Public Shared ReadOnly Property Fullname(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.NAME.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr.Trim
            End Get
        End Property

#End Region

#Region "PROCESS_STATUS_CODE"

        Public Shared ReadOnly Property ProcessStatusCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PROCESS_STATUS_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PROCESS_STATUS_DESC"

        Public Shared ReadOnly Property ProcessStatusDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PROCESS_STATUS_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "CAMPUS_CODE"

        Public Shared ReadOnly Property CampusCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.CAMPUS_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "CAMPUS_DESC"

        Public Shared ReadOnly Property CampusDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.CAMPUS_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PROGRAM_CODE"

        Public Shared ReadOnly Property ProgramCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PROGRAM_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PROGRAM_DESC"

        Public Shared ReadOnly Property ProgramDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PROGRAM_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "FACULTY_CODE"

        Public Shared ReadOnly Property FacultyCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.FACULTY_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "FACULTY_DESC"

        Public Shared ReadOnly Property FacultyDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.FACULTY_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PROGRAMLEVEL_CODE"

        Public Shared ReadOnly Property ProgramLevelCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PROGRAMLEVEL_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PROGRAMLEVEL_DESC"

        Public Shared ReadOnly Property ProgramLevelDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PROGRAMLEVEL_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "STUDYMODE_CODE"

        Public Shared ReadOnly Property StudyModeCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.STUDYMODE_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "STUDYMODE_DESC"

        Public Shared ReadOnly Property StudyModeDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.STUDYMODE_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "RACE_CODE"

        Public Shared ReadOnly Property RaceCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.RACE_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "RACE_DESC"

        Public Shared ReadOnly Property RaceDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.RACE_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "DOB"

        Public Shared ReadOnly Property DOB(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.DOB.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                'Correcting date
                If Not String.IsNullOrEmpty(MyStr) Then
                    MyStr = Functions.Dates.Correction.MyToUs(MyStr)
                End If

                Return MyStr
            End Get
        End Property

#End Region

#Region "PLACE_OF_BIRTH"

        Public Shared ReadOnly Property PlaceOfBirth(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PLACE_OF_BIRTH.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PERMANENT_ADD1"

        Public Shared ReadOnly Property PermanentAdd1(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PERMANENT_ADD1.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PERMANENT_ADD2"

        Public Shared ReadOnly Property PermanentAdd2(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PERMANENT_ADD2.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PERMANENT_POSTCODE"

        Public Shared ReadOnly Property PermanentPostcode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PERMANENT_POSTCODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PERMANENT_CITY"

        Public Shared ReadOnly Property PermanentCity(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PERMANENT_CITY.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PERMANENT_STATE_CODE"

        Public Shared ReadOnly Property PermanentStateCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PERMANENT_STATE_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "PERMANENT_STATE_DESC"

        Public Shared ReadOnly Property PermanentStateDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.PERMANENT_STATE_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "HANDPHONE_NO"

        Public Shared ReadOnly Property HandPhoneNo(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.HANDPHONE_NO.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "OFFICIAL_EMAIL"

        Public Shared ReadOnly Property OfficialEmail(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.OFFICIAL_EMAIL.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "INTAKE_SEM_CODE"

        Public Shared ReadOnly Property IntakeSemCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.INTAKE_SEM_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "INTAKE_SEM_DESC"

        Public Shared ReadOnly Property IntakeSemDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.INTAKE_SEM_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "DATE_RELOAD"

        Public Shared ReadOnly Property DateReload(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.DATE_RELOAD.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "CONVO_CODE"

        Public Shared ReadOnly Property ConvoCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.CONVO_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "STATUS_HEA_CODE"

        Public Shared ReadOnly Property StatusHeaCode(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.STATUS_HEA_CODE.ToString
                Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExistedIC(IcNo As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.ICNO.ToString, IcNo)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(DBLibraryConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , DBLibraryConnectionString)
        End Function

#End Region

#Region "Extra Functions"

        Public Shared Function IsPatronActive(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.STUDENTID.ToString, PatronId), _
                CriteriaNot(eFieldName.PROCESS_STATUS_CODE.ToString, "-1") _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function CountActive(DBLibraryConnectionString As String) As Integer
            Dim MyCriteria As String = CriteriaNot(eFieldName.PROCESS_STATUS_CODE.ToString, "-1")

            Return MyCmd.CmdCount(TableName, MyCriteria, DBLibraryConnectionString)
        End Function

        Public Shared Function CountNotActive(DBLibraryConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.PROCESS_STATUS_CODE.ToString, "-1")

            Return MyCmd.CmdCount(TableName, MyCriteria, DBLibraryConnectionString)
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
                Dim Passport As String = IcNo(PatronId, DBLibraryConnectionString)
                If GivenPassport = Passport Then ReturnValue = True
            End If

            Return ReturnValue
        End Function

#End Region

#Region "DataTables"

#Region "Get All Users"

        ''' <summary>
        ''' Geat All Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsers(PageIndex As Integer, PageSize As Integer, DBLibraryConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.STUDENTID.ToString, _
                eFieldName.NAME.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.NAME.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, DBLibraryConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsersActive(PageIndex As Integer, PageSize As Integer, DBLibraryConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.STUDENTID.ToString, _
                eFieldName.NAME.ToString _
                )

            Dim MyCriteria As String = CriteriaNot(eFieldName.PROCESS_STATUS_CODE.ToString, "-1")

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.NAME.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)
        End Function

#End Region

#Region "Search"

        ''' <summary>
        ''' Count Student by 3 OR criterias.
        ''' 5 Columns (NAME, FACULTY_DESC, PROGRAM_DESC, STUDENTID, PROCESS_STATUS_CODE)
        ''' </summary>
        ''' <param name="SearchCriteria">PatronId OR Passport OR Name</param>
        ''' <param name="CriteriaIndex">Search By one of the criterias: (1 = STUDENTID; 2 = ICNO; 3 = NAME; Other = All three simultanously but very slow)</param>
        Public Shared Function SearchUsersCount(SearchCriteria As String, CriteriaIndex As Integer, DBLibraryConnectionString As String) As Integer

            Dim MyCriteria As String = Nothing

            Select Case CriteriaIndex
                Case 1
                    MyCriteria = Criteria(eFieldName.STUDENTID.ToString, SearchCriteria)
                Case 2
                    MyCriteria = Criteria(eFieldName.ICNO.ToString, SearchCriteria)
                Case 3
                    MyCriteria = CriteriaLike(eFieldName.NAME.ToString, "%" & SearchCriteria & "%")
                Case Else
                    MyCriteria = CriteriasOR( _
                        Criteria(eFieldName.STUDENTID.ToString, SearchCriteria), _
                        Criteria(eFieldName.ICNO.ToString, SearchCriteria), _
                        CriteriaLike(eFieldName.NAME.ToString, "%" & SearchCriteria & "%") _
                    )
            End Select

            Return MyCmd.CmdCount(TableName, MyCriteria, DBLibraryConnectionString)
        End Function

        ''' <summary>
        ''' Search Student by 3 OR criterias.
        ''' 5 Columns (NAME, FACULTY_DESC, PROGRAM_DESC, STUDENTID, PROCESS_STATUS_CODE)
        ''' </summary>
        ''' <param name="SearchCriteria">PatronId OR Passport OR Name</param>
        ''' <param name="CriteriaIndex">Search By one of the criterias: (1 = STUDENTID; 2 = ICNO; 3 = NAME; Other = All three simultanously but very slow)</param>
        Public Shared Function SearchUsers(SearchCriteria As String, CriteriaIndex As Integer, MaxResult As Integer, DBLibraryConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.NAME.ToString, _
                eFieldName.FACULTY_DESC.ToString, _
                eFieldName.PROGRAM_DESC.ToString, _
                eFieldName.STUDENTID.ToString, _
                eFieldName.PROCESS_STATUS_CODE.ToString
                )

            Dim MyCriteria As String = Nothing

            Select Case CriteriaIndex
                Case 1
                    MyCriteria = Criteria(eFieldName.STUDENTID.ToString, SearchCriteria)
                Case 2
                    MyCriteria = Criteria(eFieldName.ICNO.ToString, SearchCriteria)
                Case 3
                    MyCriteria = CriteriaLike(eFieldName.NAME.ToString, "%" & SearchCriteria & "%")
                Case Else
                    MyCriteria = CriteriasOR( _
                        Criteria(eFieldName.STUDENTID.ToString, SearchCriteria), _
                        Criteria(eFieldName.ICNO.ToString, SearchCriteria), _
                        CriteriaLike(eFieldName.NAME.ToString, "%" & SearchCriteria & "%") _
                    )
            End Select


            Dim Other As String = Limit(MaxResult)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)
        End Function

#End Region

#Region "Single Patron Info"

        ''' <summary>
        ''' Get a single row in database for a single patron.
        ''' 17 Columns (STUDENTID, ICNO, NAME, FACULTY_CODE, FACULTY_DESC, PROGRAM_CODE, PROGRAM_DESC, CAMPUS_CODE, CAMPUS_DESC, 
        ''' PROGRAMLEVEL_CODE, PROGRAMLEVEL_DESC, STUDYMODE_CODE, STUDYMODE_DESC, PROCESS_STATUS_CODE, PROCESS_STATUS_DESC, 
        ''' HANDPHONE_NO, OFFICIAL_EMAIL)
        ''' </summary>
        Public Shared Function GetSinglePatronInfo(PatronId As String, DBLibraryConnectionString As String) As DataTable

            Dim MyFieldName As String = FieldNames( _
                eFieldName.STUDENTID.ToString, _
                eFieldName.ICNO.ToString, _
                eFieldName.NAME.ToString, _
                eFieldName.FACULTY_CODE.ToString, _
                 eFieldName.FACULTY_DESC.ToString, _
                eFieldName.PROGRAM_CODE.ToString, _
                eFieldName.PROGRAM_DESC.ToString, _
                eFieldName.CAMPUS_CODE.ToString, _
                eFieldName.CAMPUS_DESC.ToString, _
                eFieldName.PROGRAMLEVEL_CODE.ToString, _
                eFieldName.PROGRAMLEVEL_DESC.ToString, _
                eFieldName.STUDYMODE_CODE.ToString, _
                eFieldName.STUDYMODE_DESC.ToString, _
                eFieldName.PROCESS_STATUS_CODE.ToString, _
                eFieldName.PROCESS_STATUS_DESC.ToString, _
                eFieldName.HANDPHONE_NO.ToString, _
                eFieldName.OFFICIAL_EMAIL.ToString _
                )

            Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

            Dim Other As String = Limit(1)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)

        End Function

        ''' <summary>
        ''' Get a single row in database for a single patron.
        ''' ''' 3 Columns (STUDENTID, HANDPHONE_NO, OFFICIAL_EMAIL, CAMPUS_DESC)
        ''' </summary>
        ''' <param name="PatronId"></param>
        ''' <param name="DBLibraryConnectionString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetSinglePatronInfoContact(PatronId As String, DBLibraryConnectionString As String) As DataTable

            Dim MyFieldName As String = FieldNames( _
                eFieldName.STUDENTID.ToString, _
                eFieldName.HANDPHONE_NO.ToString, _
                eFieldName.OFFICIAL_EMAIL.ToString _
                )

            Dim MyCriteria As String = Criteria(eFieldName.STUDENTID.ToString, PatronId)

            Dim Other As String = Limit(1)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)

        End Function


#End Region

#End Region

    End Class

End Namespace


