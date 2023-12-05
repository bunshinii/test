Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.Patrons.Table

    ''' <summary>
    ''' This is a table base class base on table 'pat_info'
    ''' </summary>
    Public Class PatInfo

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "pat_info"
        End Function



        'List all field in the table here
        Private Enum eFieldName
            id
            patron_name
            patron_id
            patron_ic
            patron_email
            patron_phone
            patron_type_id
            stud_program_id
            stud_program_lvl_id
            stud_campus_id
            stud_faculty_id
            stud_studymode_id
            staf_department_id
            staf_position_id
            staf_type_id
            isactive
        End Enum

#End Region

#Region "Table Fields Properties"

#Region "id"

        Public Shared Function Id(PatronId As String, PatronsConnectionString As String) As Integer
            Dim MyFieldName As String = eFieldName.id.ToString
            Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

            Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
            If Not IsNumeric(MyStr) Then MyStr = 0
            Return MyStr
        End Function

#End Region

#Region "patron_name"

        Public Shared Property PatronName(ByVal _id As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PatronName(ByVal PatronId As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_name.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "patron_id"

        Public Shared Property PatronId(ByVal _id As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PatronId(ByVal _PatronId As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "patron_ic"

        Public Shared Property PatronIC(ByVal _id As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_ic.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_ic.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PatronIC(ByVal _PatronId As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_ic.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_ic.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "patron_email"

        Public Shared Property PatronEmail(ByVal _id As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_email.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_email.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PatronEmail(ByVal _PatronId As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_email.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_email.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "patron_phone"

        Public Shared Property PatronPhone(ByVal _id As Integer, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_phone.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_phone.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PatronPhone(ByVal _PatronId As String, PatronsConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.patron_phone.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = eFieldName.patron_phone.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "patron_type_id"

        Public Shared Property PatronTypeId(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.patron_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.patron_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property PatronTypeId(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.patron_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.patron_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "stud_program_id"

        Public Shared Property StudentProgramId(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_program_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_program_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property StudentProgramId(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_program_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_program_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "stud_program_lvl_id"

        Public Shared Property StudentProgramLevelId(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_program_lvl_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_program_lvl_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property StudentProgramLevelId(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_program_lvl_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_program_lvl_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "stud_campus_id"

        Public Shared Property StudentCampusId(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_campus_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_campus_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property StudentCampusId(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_campus_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_campus_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "stud_faculty_id"

        Public Shared Property StudentFacultyId(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_faculty_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_faculty_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property StudentFacultyId(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_faculty_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_faculty_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "stud_studymode_id"

        Public Shared Property StudentStudyModeId(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_studymode_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_studymode_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property StudentStudyModeId(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.stud_studymode_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.stud_studymode_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "staf_department_id"

        Public Shared Property StaffDepartmentId(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.staf_department_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.staf_department_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property StaffDepartmentId(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.staf_department_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.staf_department_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "staf_position_id"

        Public Shared Property StaffPositionId(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.staf_position_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.staf_position_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property StaffPositionId(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.staf_position_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.staf_position_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#Region "staf_type"

        Public Shared Property StaffType(ByVal _Id As Integer, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.staf_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.staf_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

        Public Shared Property StaffType(ByVal PatronId As String, PatronsConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = eFieldName.staf_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , PatronsConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = eFieldName.staf_type_id.ToString
                Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, PatronsConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(PatronId As String, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(_Id As Integer, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, _Id)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExistedIC(IcNo As String, PatronsConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.patron_ic.ToString, IcNo)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, PatronsConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(PatronsConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , PatronsConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function PatronInsert( _
                _PatronName As String, _
                _PatronId As String, _
                _PatronIC As String, _
                _PatronEmail As String, _
                _PatronPhone As String, _
                _PatronTypeId As Integer, _
                _StudentProgramId As Integer, _
                _StudentProgramLevelId As Integer, _
                _StudentCampusId As Integer, _
                _StudentFacultyId As Integer, _
                _StudentStudyModeId As Integer, _
                _StaffDepartmentId As Integer, _
                _StaffPositionId As Integer, _
                _StaffTypeId As Integer, _
                _PatronsConnectionString As String _
                ) As String

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.patron_name.ToString, _
                eFieldName.patron_id.ToString, _
                eFieldName.patron_ic.ToString, _
                eFieldName.patron_email.ToString, _
                eFieldName.patron_phone.ToString, _
                eFieldName.patron_type_id.ToString, _
                eFieldName.stud_program_id.ToString, _
                eFieldName.stud_program_lvl_id.ToString, _
                eFieldName.stud_campus_id.ToString, _
                eFieldName.stud_faculty_id.ToString, _
                eFieldName.stud_studymode_id.ToString, _
                eFieldName.staf_department_id.ToString, _
                eFieldName.staf_position_id.ToString, _
                eFieldName.staf_type_id.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                _PatronName, _
                _PatronId, _
                _PatronIC, _
                _PatronEmail, _
                _PatronPhone, _
                _PatronTypeId, _
                _StudentProgramId, _
                _StudentProgramLevelId, _
                _StudentCampusId, _
                _StudentFacultyId, _
                _StudentStudyModeId, _
                _StaffDepartmentId, _
                _StaffPositionId, _
                _StaffTypeId _
                )

            Return MyCmd.CmdInsert2(TableName, MyFieldsName, MyFieldsValue, _PatronsConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function PatronDelete(_Id As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, _Id)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function PatronDelete(PatronId As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.patron_id.ToString, PatronId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTables"

#Region "Get All Users"

        ''' <summary>
        ''' Geat All Patrons with paging. Column(id,patron_id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllPatrons(PageIndex As Integer, PageSize As Integer, PatronsConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.patron_id.ToString, _
                eFieldName.patron_name.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.patron_name.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, PatronsConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


