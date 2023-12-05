Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'my_users_profile'
    ''' </summary>
    Public Class UsersProfile

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "my_users_profile"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            id                  'Primary
            name                'Index, Unique
            full_name
            nick
            grade
            position_id
            'department_tree    'Not used 
            phone
            phone_ext
            fax
            handphone
            website
            blogspot
            facebook
            twitter
            picture
            birthDate
            regDate
            expDate
            branch_id       'Index
            satellite_id    'Index
            department_id   'Index
            division_id     'Index
            unit_id         'Index
            sta_department_id
            stu_campus_id
            stu_faculty_id
            stu_program_id
            stu_level
            stu_mode
            email
            ic_passport     'Index
            gender_id       'Index
            marriage_id     'Index
            seq_no
            address1
            address2
            address3
            postcode
            city
            state
            country
            isfirsttime
            lastUpdateDate  'Index

            ''    Multiple Field Index
            '1.   id, branch_id
            '2.   id, satellite_id
            '3.   id, department_id
            '4.   id, division_id
            '5.   id, unit_id

        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

        'Optional                               '<-------------------------------------- Optional
        ''' <summary>
        ''' Get UserId from Table 'my_aspnet_users' by username
        ''' </summary>
        Private Shared Function UserId1(Username As String, ProviderConnectionString As String) As Integer
            Return NasLib.Database.MySql.Provider.Table.Users.UserId(Username, ProviderConnectionString)
        End Function

        Private Shared Function GenerateBlankProfileData(Username As String, ProviderConnectionString As String) As Integer
            GenerateBlankProfileData = -1

            If Users.IsExisted(Username, ProviderConnectionString) Then
                Dim _UserId As Integer = Users.Id(Username, ProviderConnectionString)
                Return ProfileInsert(_UserId, Username, ProviderConnectionString)
            End If

        End Function

        Private Shared Function GenerateBlankProfileData(UserId As Integer, ProviderConnectionString As String) As Integer
            GenerateBlankProfileData = -1

            If Users.IsExisted(UserId, ProviderConnectionString) Then
                Dim PatronId As String = Users.Username(UserId, ProviderConnectionString)
                Return ProfileInsert(UserId, PatronId, ProviderConnectionString)
            End If

        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function UserId(Username As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
            Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

        Public Shared Function Id(Username As String, ProviderConnectionString As String) As Integer
            Dim MyFieldName As String = FieldName(eFieldName.id)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
            Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            Return MyStr
        End Function

#End Region

#Region "Name"

        Public Shared Property Username(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "full_name"

        Public Shared Property FullName(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.full_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.full_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property FullName(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.full_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.full_name)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "nick"

        Public Shared Property Nick(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.nick)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.nick)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Nick(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.nick)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.nick)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Check if the Nick is already existed
        ''' </summary>
        Public Shared Function IsNickAvailable(ByVal _Nick As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.nick), _Nick)
            Return Not MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#Region "grade"

        Public Shared ReadOnly Property GradeCode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _GradeId As Integer = GradeId(UserId, ProviderConnectionString)
                Return Table.UsersPositionGrade.Grade(_GradeId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property GradeCode(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _GradeId As Integer = GradeId(Username, ProviderConnectionString)
                Return Table.UsersPositionGrade.Grade(_GradeId, ProviderConnectionString)
            End Get
        End Property

        ''' <summary>
        ''' GradeId
        ''' </summary>
        Public Shared Property GradeId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' GradeId
        ''' </summary>
        Public Shared Property GradeId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.grade)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "position_id"

        Public Shared ReadOnly Property PositionName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _PositionId As Integer = PositionId(UserId, ProviderConnectionString)
                Return Table.UsersPosition.Position(_PositionId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property PositionName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _PositionId As Integer = PositionId(Username, ProviderConnectionString)
                Return Table.UsersPosition.Position(_PositionId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property PositionId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.position_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.position_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PositionId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.position_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.position_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "phone"

        Public Shared Property Phone(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.phone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.phone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Phone(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.phone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.phone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "phone_ext"

        Public Shared Property PhoneExt(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.phone_ext)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.phone_ext)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PhoneExt(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.phone_ext)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.phone_ext)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "fax"

        Public Shared Property Fax(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.fax)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.fax)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Fax(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.fax)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.fax)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "handphone"

        Public Shared Property Handphone(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.handphone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.handphone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Handphone(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.handphone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.handphone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "website"

        Public Shared Property Website(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.website)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.website)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Website(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.website)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.website)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "blogspot"

        Public Shared Property Blogspot(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.blogspot)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.blogspot)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Blogspot(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.blogspot)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.blogspot)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "facebook"

        Public Shared Property Facebook(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.facebook)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.facebook)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Facebook(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.facebook)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.facebook)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "twitter"

        Public Shared Property Twitter(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.twitter)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.twitter)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Twitter(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.twitter)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.twitter)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "picture"

        Public Shared Property Picture(ByVal UserId As Integer, ProviderConnectionString As String) As Byte()
            Get
                Dim MyFieldName As String = FieldName(eFieldName.picture)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                Return MyCmd.CmdSelectBlob(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
            Set(value As Byte())
                Dim MyFieldName As String = FieldName(eFieldName.picture)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                MyCmd.CmdUpdateBlob(TableName, MyFieldName, value, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Picture(ByVal Username As String, ProviderConnectionString As String) As Byte()
            Get
                Dim MyFieldName As String = FieldName(eFieldName.picture)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                Return MyCmd.CmdSelectBlob(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
            Set(value As Byte())
                Dim MyFieldName As String = FieldName(eFieldName.picture)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                MyCmd.CmdUpdateBlob(TableName, MyFieldName, value, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared ReadOnly Property PictureSize(ByVal UserId As Integer, ProviderConnectionString As String) As Long
            Get
                Dim MyFieldName As String = FieldName(eFieldName.picture)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                Return MyCmd.CmdSelectBlobSize(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property PictureSize(ByVal Username As String, ProviderConnectionString As String) As Long
            Get
                Dim MyFieldName As String = FieldName(eFieldName.picture)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                Return MyCmd.CmdSelectBlobSize(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
        End Property

#End Region

#Region "birthDate"
        Public Shared Function IsBirthDateAvailable(ByVal UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim ReturnValue As Boolean = False

            Dim MyFieldName As String = FieldName(eFieldName.birthDate)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

            Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

            If IsDate(MyStr) Then ReturnValue = True
            Return ReturnValue
        End Function

        ''' <summary>
        ''' Get user birthdate.
        ''' If error use within If statement with IsBirthDateAvailable().
        ''' Must convert into string to prevent error.
        ''' </summary>
        Public Shared Property BirthDate(ByVal UserId As Integer, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.birthDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.birthDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property BirthDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.birthDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.birthDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "regDate"

        Public Shared Property RegistrationDate(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.regDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.regDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = ""
                If IsDate(value) Then MyFieldValue = Format(CDate(value), "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property RegistrationDate(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.regDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.regDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = ""
                If IsDate(value) Then MyFieldValue = Format(CDate(value), "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "expDate"

        Public Shared Property ExpireDate(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.expDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.expDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = ""
                If IsDate(value) Then MyFieldValue = Format(CDate(value), "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ExpireDate(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.expDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect2(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.expDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = ""
                If IsDate(value) Then MyFieldValue = Format(CDate(value), "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "branch_id"

        Public Shared Property BranchId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branch_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branch_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property BranchId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.branch_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.branch_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared ReadOnly Property BranchName(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim BranchId As Integer = Table.UsersProfile.BranchId(Username, ProviderConnectionString)
                Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property BranchName(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim BranchId As Integer = Table.UsersProfile.BranchId(UserId, ProviderConnectionString)
                Return Table.OfficeBranch.Branch(BranchId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property BranchInitial(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim BranchId As Integer = Table.UsersProfile.BranchInitial(Username, ProviderConnectionString)
                Return Table.OfficeBranch.BranchInitial(BranchId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property BranchInitial(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim BranchId As Integer = Table.UsersProfile.BranchInitial(UserId, ProviderConnectionString)
                Return Table.OfficeBranch.BranchInitial(BranchId, ProviderConnectionString)
            End Get
        End Property

#End Region

#Region "satellite_id"

        Public Shared Property SatelliteId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.satellite_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.satellite_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property SatelliteId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.satellite_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.satellite_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared ReadOnly Property SatelliteName(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim SatelliteId As Integer = Table.UsersProfile.SatelliteId(Username, ProviderConnectionString)
                Return Table.OfficeSatellite.Satellite(SatelliteId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property SatelliteName(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim SatelliteId As Integer = Table.UsersProfile.SatelliteId(UserId, ProviderConnectionString)
                Return Table.OfficeSatellite.Satellite(SatelliteId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property SatelliteInitial(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim SatelliteId As Integer = Table.UsersProfile.SatelliteId(Username, ProviderConnectionString)
                Return Table.OfficeSatellite.Initial(SatelliteId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property SatelliteInitial(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim SatelliteId As Integer = Table.UsersProfile.SatelliteId(UserId, ProviderConnectionString)
                Return Table.OfficeSatellite.Initial(SatelliteId, ProviderConnectionString)
            End Get
        End Property

#End Region

#Region "department_id"

        Public Shared ReadOnly Property DepartmentName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _DepartmentId As Integer = DepartmentId(UserId, ProviderConnectionString)
                Return Table.OfficeDepartment.Department(_DepartmentId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property DepartmentName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _DepartmentId As Integer = DepartmentId(Username, ProviderConnectionString)
                Return Table.OfficeDepartment.Department(_DepartmentId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property DepartmentInitial(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _DepartmentId As Integer = DepartmentId(Username, ProviderConnectionString)
                Return Table.OfficeDepartment.Initial(_DepartmentId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property DepartmentId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.department_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.department_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property DepartmentId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.department_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.department_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "division_id"

        Public Shared ReadOnly Property DivisionName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _DivisionId As Integer = DivisionId(UserId, ProviderConnectionString)
                Return Table.OfficeDivision.Division(_DivisionId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property DivisionName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _DivisionId As Integer = DivisionId(Username, ProviderConnectionString)
                Return Table.OfficeDivision.Division(_DivisionId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property DivisionInitial(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _DivisionId As Integer = DivisionId(Username, ProviderConnectionString)
                Return Table.OfficeDivision.Initial(_DivisionId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property DivisionId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.division_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.division_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property DivisionId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.division_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.division_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "unit_id"

        Public Shared ReadOnly Property UnitName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _UnitId As Integer = UnitId(UserId, ProviderConnectionString)
                Return Table.OfficeUnit.Unit(_UnitId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property UnitName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _UnitId As Integer = UnitId(Username, ProviderConnectionString)
                Return Table.OfficeUnit.Unit(_UnitId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property UnitInitial(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _UnitId As Integer = UnitId(Username, ProviderConnectionString)
                Return Table.OfficeUnit.Initial(_UnitId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property UnitId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.unit_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.unit_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property UnitId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.unit_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.unit_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "sta_department_id"

        ''' <summary>
        ''' Get Staff Department Name
        ''' </summary>
        Public Shared ReadOnly Property StaffDepartmentName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _DeptId As Integer = StaffDepartmentId(UserId, ProviderConnectionString)
                Return Table.StafDepartment.DeptName(_DeptId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StaffDepartmentName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _DeptId As Integer = StaffDepartmentId(Username, ProviderConnectionString)
                Return Table.StafDepartment.DeptName(_DeptId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StaffDepartmentCode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _DepartmentId As Integer = StaffDepartmentId(UserId, ProviderConnectionString)
                Return Table.StafDepartment.DeptCode(_DepartmentId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property StaffDepartmentCode(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _DepartmentId As Integer = StaffDepartmentId(Username, ProviderConnectionString)
                Return Table.StafDepartment.DeptCode(_DepartmentId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property StaffDepartmentId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.sta_department_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.sta_department_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property StaffDepartmentId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.sta_department_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.sta_department_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "stu_campus_id"

        ''' <summary>
        ''' Get Student Campus Name
        ''' </summary>
        Public Shared ReadOnly Property CampusName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _campusId As Integer = CampusId(UserId, ProviderConnectionString)
                Return Table.StudCampus.CampusName(_campusId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property CampusName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _CampusId As Integer = CampusId(Username, ProviderConnectionString)
                Return Table.StudCampus.CampusName(_CampusId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property CampusCode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _campusId As Integer = CampusId(UserId, ProviderConnectionString)
                Return Table.StudCampus.CampusCode(_campusId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property CampusCode(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _CampusId As Integer = CampusId(Username, ProviderConnectionString)
                Return Table.StudCampus.CampusCode(_CampusId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property CampusId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_campus_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_campus_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property CampusId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_campus_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_campus_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "stu_faculty_id"

        ''' <summary>
        ''' Get Student Faculty Name
        ''' </summary>
        Public Shared ReadOnly Property FacultyName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _FacultyId As Integer = FacultyId(UserId, ProviderConnectionString)
                Return Table.StudFaculty.FacultyName(_FacultyId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property FacultyName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _FacultyId As Integer = FacultyId(Username, ProviderConnectionString)
                Return Table.StudFaculty.FacultyName(_FacultyId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property FacultyCode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _FacultyId As Integer = FacultyId(UserId, ProviderConnectionString)
                Return Table.StudFaculty.FacultyCode(_FacultyId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property FacultyCode(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _FacultyId As Integer = FacultyId(Username, ProviderConnectionString)
                Return Table.StudFaculty.FacultyCode(_FacultyId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property FacultyId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_faculty_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_faculty_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property FacultyId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_faculty_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_faculty_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "stu_program_id"

        ''' <summary>
        ''' Get Student Program Name
        ''' </summary>
        Public Shared ReadOnly Property ProgramName(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _ProgramId As Integer = ProgramId(UserId, ProviderConnectionString)
                Return Table.StudProgram.ProgramDesc(_ProgramId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property ProgramName(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _ProgramId As Integer = ProgramId(Username, ProviderConnectionString)
                Return Table.StudProgram.ProgramDesc(_ProgramId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property ProgramCode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _ProgramId As Integer = ProgramId(UserId, ProviderConnectionString)
                Return Table.StudProgram.ProgramCode(_ProgramId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property ProgramCode(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _ProgramId As Integer = ProgramId(Username, ProviderConnectionString)
                Return Table.StudProgram.ProgramCode(_ProgramId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property ProgramId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_program_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_program_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ProgramId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_program_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_program_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "stu_level_id"

        ''' <summary>
        ''' Get Student Program Name
        ''' </summary>
        Public Shared ReadOnly Property LevelDesc(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _LevelId As Integer = LevelId(UserId, ProviderConnectionString)
                Return Table.StudProgramLevel.LevelDesc(_LevelId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property LevelDesc(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _LevelId As Integer = LevelId(Username, ProviderConnectionString)
                Return Table.StudProgramLevel.LevelDesc(_LevelId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property LevelCode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _LevelId As Integer = LevelId(UserId, ProviderConnectionString)
                Return Table.StudProgramLevel.LevelCode(_LevelId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property LevelCode(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _LevelId As Integer = LevelId(Username, ProviderConnectionString)
                Return Table.StudProgramLevel.LevelCode(_LevelId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property LevelId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_level)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_level)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LevelId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_level)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_level)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "stu_mode_id"

        ''' <summary>
        ''' Get Student Mode Name
        ''' </summary>
        Public Shared ReadOnly Property ModeDesc(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _ModeId As Integer = ModeId(UserId, ProviderConnectionString)
                Return Table.StudMode.ModDesc(_ModeId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property ModeDesc(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _ModeId As Integer = ModeId(Username, ProviderConnectionString)
                Return Table.StudMode.ModDesc(_ModeId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property ModeCode(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim _ModeId As Integer = ModeId(UserId, ProviderConnectionString)
                Return Table.StudMode.ModeCode(_ModeId, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property ModeCode(Username As String, ProviderConnectionString As String) As String
            Get
                Dim _ModeId As Integer = ModeId(Username, ProviderConnectionString)
                Return Table.StudMode.ModeCode(_ModeId, ProviderConnectionString)
            End Get
        End Property

        Public Shared Property ModeId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_mode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_mode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ModeId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.stu_mode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.stu_mode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "email"

        Public Shared Property Email(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Email(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "ic_passport"

        Public Shared Property Passport(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.ic_passport)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.ic_passport)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Passport(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.ic_passport)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.ic_passport)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "gender_id"

        Public Shared Property GenderId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.gender_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.gender_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property GenderId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.gender_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.gender_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared ReadOnly Property GenderDesc(Username As String, ProviderConnectionString As String) As String
            Get
                Dim GenderId_ As Integer = GenderId(Username, ProviderConnectionString)
                Return Table.UsersGender.Gender(GenderId_, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property GenderDesc(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim GenderId_ As Integer = GenderId(UserId, ProviderConnectionString)
                Return Table.UsersGender.Gender(GenderId_, ProviderConnectionString)
            End Get
        End Property

#End Region

#Region "marriage_id"

        Public Shared Property MarriageId(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.marriage_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.marriage_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property MarriageId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.marriage_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.marriage_id)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared ReadOnly Property MarriageDesc(Username As String, ProviderConnectionString As String) As String
            Get
                Dim MarriageId_ As Integer = MarriageId(Username, ProviderConnectionString)
                Return Table.UsersMarriage.Marriage(MarriageId_, ProviderConnectionString)
            End Get
        End Property

        Public Shared ReadOnly Property MarriageDesc(UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MarriageId_ As Integer = MarriageId(UserId, ProviderConnectionString)
                Return Table.UsersMarriage.Marriage(MarriageId_, ProviderConnectionString)
            End Get
        End Property

#End Region

#Region "seq_no"

        ''' <summary>
        ''' For sorting porpose only. Not unique
        ''' </summary>
        Public Shared Property SequenceNo(ByVal UserId As Integer, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.seq_no)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.seq_no)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Same as SequenceNo()
        ''' </summary>
        Public Shared Property seq_no(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.seq_no)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.seq_no)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "address1"

        Public Shared Property Address1(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.address1)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.address1)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Address1(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.address1)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.address1)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "address2"

        Public Shared Property Address2(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.address2)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.address2)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Address2(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.address2)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.address2)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "address3"

        Public Shared Property Address3(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.address3)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.address3)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Address3(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.address3)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.address3)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "postcode"

        Public Shared Property Postcode(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.postcode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.postcode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Postcode(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.postcode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.postcode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "city"

        Public Shared Property City(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.city)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.city)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property City(ByVal Username As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.city)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.city)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "state"

        Public Shared Property State(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.state)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.state)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property State(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.state)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), UserName)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserName, ProviderConnectionString) Then GenerateBlankProfileData(UserName, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.state)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), UserName)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserName, ProviderConnectionString) Then GenerateBlankProfileData(UserName, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "country"

        Public Shared Property Country(ByVal UserId As Integer, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.country)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.country)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Country(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.country)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), UserName)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserName, ProviderConnectionString) Then GenerateBlankProfileData(UserName, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.country)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), UserName)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserName, ProviderConnectionString) Then GenerateBlankProfileData(UserName, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "isfirsttime"

        Public Shared Property IsFirstTime(ByVal UserId As Integer, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isfirsttime)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyInt As Integer = MyCmd.CmdSelect0(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)

                Dim ReturnValue As Boolean = True
                If MyInt = 0 Then ReturnValue = False
                Return ReturnValue
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isfirsttime)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property IsFirstTime(ByVal Username As String, ProviderConnectionString As String) As Boolean
            Get
                Dim MyFieldName As String = FieldName(eFieldName.isfirsttime)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Return MyCmd.CmdSelectBool(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
            Set(value As Boolean)
                Dim MyFieldName As String = FieldName(eFieldName.isfirsttime)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "lastUpdateDate"

        Public Shared Property LastUpdateDate(ByVal UserId As Integer, ProviderConnectionString As String) As Date
            Get
                Dim MyFieldName As String = FieldName(eFieldName.lastUpdateDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Date)
                Dim MyFieldName As String = FieldName(eFieldName.lastUpdateDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(UserId, ProviderConnectionString) Then GenerateBlankProfileData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LastUpdateDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.lastUpdateDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.lastUpdateDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                If Not IsExisted(Username, ProviderConnectionString) Then GenerateBlankProfileData(Username, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.id.ToString, UserId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(Username As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.name.ToString, Username)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsPictureExisted(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyFieldName As String = eFieldName.picture.ToString

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, UserId), _
                CriteriaNotNull(eFieldName.picture.ToString) _
                )

            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function IsPictureExisted(Username As String, ProviderConnectionString As String) As Boolean
            Dim MyFieldName As String = eFieldName.picture.ToString

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                CriteriaNotNull(eFieldName.picture.ToString) _
                )

            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function


        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Filtered Count
        ''' </summary>
        ''' <param name="Keyword">Search Keyword</param>
        Public Shared Function Count(Keyword As String, ProviderConnectionString As String) As Integer
            Dim MyCriterias As String = CriteriasOR(CriteriaLike(eFieldName.name.ToString, String.Format("%{0}%", Keyword)), CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", Keyword)))

            Return MyCmd.CmdCount(TableName, MyCriterias, ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        ''' <summary>
        ''' Insert data into table 'my_users_profile'
        ''' </summary>
        Public Shared Function ProfileInsert(UserId As Integer, Username As String, FullName As String, ProviderConnectionString As String) As Integer
            Dim LastUpdateDate As Date = Now

            Dim MyFullName As String = Functions.String.Cases.CamelCase(FullName.Trim)

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.full_name.ToString, _
                eFieldName.lastUpdateDate.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                UserId, _
                Username, _
                MyFullName, _
                LastUpdateDate _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function ProfileInsert(UserId As Integer, Username As String, ProviderConnectionString As String) As Integer
            Dim FullName As String = ""
            Return ProfileInsert(UserId, Username, FullName, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ProfileDelete(UserId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.id), UserId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function ProfileDelete(Username As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.name), Username)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "DataTable"

        ''' <summary>
        ''' Get a single row for a user with specified field
        ''' </summary>
        ''' <param name="Username">Username or PatronId</param>
        ''' <param name="FieldName_">Fieldnames as array</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function SingleUserData(Username As String, FieldName_() As String, ProviderConnectionString As String) As DataTable
            '' All Fields
            'id, name, full_name, nick, grade, position_id, department_tree, phone, phone_ext, fax, handphone, website, blogspot, 
            'Facebook, Twitter, Picture, BirthDate, regDate, expDate, branch_id, satellite_id, department_id, division_id, unit_id, 
            'sta_department_id, stu_campus_id, stu_faculty_id, stu_program_id, stu_level, stu_mode, Email, ic_passport, gender_id, 
            'marriage_id, seq_no, Address1, Address2, Address3, Postcode, City, State, Country, IsFirstTime, LastUpdateDate

            Dim MyFields As String = FieldNames(FieldName_)
            Dim MyCriteria As String = Criteria(eFieldName.name.ToString, Username)

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, , ProviderConnectionString)
        End Function

        ''' <summary>
        ''' For searching purpose.
        ''' Searching Username, Fullname and Passport fields.
        ''' Return Columns (name, full_name, ic_passport).
        ''' </summary>
        Public Shared Function SearchUser(Keyword As String, ProviderConnectionString As String) As DataTable

            Dim MyFields As String = FieldNames( _
                eFieldName.name.ToString, _
                eFieldName.full_name.ToString, _
                eFieldName.ic_passport.ToString _
                )

            Dim MyCriteria As String = CriteriasOR( _
                Criteria(eFieldName.name.ToString, Keyword), _
                CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", Keyword)), _
                Criteria(eFieldName.ic_passport.ToString, Keyword) _
                )

            Dim Other As String = OrderBy(eFieldName.full_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

#Region "Get All Users"

        ''' <summary>
        ''' Geat All Users. Column(id,name,full_name)
        ''' </summary>
        Public Shared Function GetAllUsers(ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.name.ToString,
                eFieldName.full_name.ToString
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString, True)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, ProviderConnectionString)
        End Function

        Public Shared Function GetAllUsersByRank(ProviderConnectionString As String) As DataTable

            Dim IncludeTableNameLeft As String = TableName() & "."

            Dim MyFields As String = FieldNames(
                IncludeTableNameLeft & eFieldName.id.ToString,
                IncludeTableNameLeft & eFieldName.name.ToString,
                IncludeTableNameLeft & eFieldName.full_name.ToString
                )

            Dim MainTableKey As String = IncludeTableNameLeft & eFieldName.position_id.ToString
            Dim JoinTableName As String = "my_users_position"
            Dim JoinTableKey As String = JoinTableName & "." & "id"
            Dim JoinTableOrder1 As String = JoinTableName & "." & "rankNo"
            Dim JoinTableOrder2 As String = IncludeTableNameLeft & eFieldName.position_id.ToString
            Dim JoinTableOrder3 As String = IncludeTableNameLeft & eFieldName.full_name.ToString

            Dim Other As String = OrdersBy(OrderBy(JoinTableOrder1, False), OrderBy(JoinTableOrder2, False), OrderBy(JoinTableOrder3, True))

            Return MyCmd.CmdSelectTableLeftJoin(TableName, MainTableKey, JoinTableName, JoinTableKey, MyFields, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All Users with paging. Column(id,name,full_name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsers(PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.full_name.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Users with paging and filter. Column(id,name,full_name)
        ''' </summary>
        ''' <param name="Keyword">Search Keyword</param>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page (0 = no limit)</param>
        Public Shared Function GetAllUsers(Keyword As String, PageIndex As Integer, PageSize As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.full_name.ToString _
                )

            Dim MyCriterias As String = CriteriasOR(CriteriaLike(eFieldName.name.ToString, String.Format("%{0}%", Keyword)), CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", Keyword)))

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.full_name.ToString, True, RowCount, StartRowIndex)

            If PageSize = 0 Then Other = OrderBy(eFieldName.full_name.ToString)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriterias, Other, ProviderConnectionString)
        End Function



#End Region

#Region "Search"

        ''' <summary>
        ''' Count Staff by 3 'OR' criterias.
        ''' </summary>
        ''' <param name="SearchCriteria">PatronId OR Passport OR Name</param>
        ''' <param name="CriteriaIndex">Search By one of the criterias: (1 = BP_NO_PEKERJA; 2 = BP_NO_KP; 3 = BP_NAMA; Other = All three simultanously but very slow)</param>
        Public Shared Function SearchUsersCount(SearchCriteria As String, CriteriaIndex As Integer, DBLibraryConnectionString As String) As Integer

            Dim MyCriteria As String = Nothing

            Select Case CriteriaIndex
                Case 1
                    MyCriteria = Criteria(eFieldName.name.ToString, SearchCriteria)
                Case 2
                    MyCriteria = Criteria(eFieldName.ic_passport.ToString, SearchCriteria)
                Case 3
                    MyCriteria = CriteriaLike(eFieldName.full_name.ToString, "%" & SearchCriteria & "%")
                Case Else
                    MyCriteria = CriteriasOR( _
                        Criteria(eFieldName.name.ToString, SearchCriteria), _
                        Criteria(eFieldName.ic_passport.ToString, SearchCriteria), _
                        CriteriaLike(eFieldName.full_name.ToString, "%" & SearchCriteria & "%") _
                    )
            End Select

            Return MyCmd.CmdCount(TableName, MyCriteria, DBLibraryConnectionString)
        End Function


        ''' <summary>
        ''' Search Staff by 3 OR criterias.
        ''' 5 Columns (name, full_name, branch_id, department_id, position_id)
        ''' </summary>
        ''' <param name="SearchCriteria">PatronId OR Passport OR Name</param>
        ''' <param name="CriteriaIndex">Search By one of the criterias: (1 = name; 2 = ic_passport; 3 = full_name; Other = All three simultanously but very slow)</param>
        Public Shared Function SearchUsers(SearchCriteria As String, CriteriaIndex As Integer, MaxResult As Integer, DBLibraryConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.name.ToString, _
                eFieldName.full_name.ToString, _
                eFieldName.branch_id.ToString, _
                eFieldName.department_id.ToString, _
                eFieldName.position_id.ToString _
                )

            Dim MyCriteria As String = Nothing

            Select Case CriteriaIndex
                Case 1
                    MyCriteria = Criteria(eFieldName.name.ToString, SearchCriteria)
                Case 2
                    MyCriteria = Criteria(eFieldName.ic_passport.ToString, SearchCriteria)
                Case 3
                    MyCriteria = CriteriaLike(eFieldName.full_name.ToString, "%" & SearchCriteria & "%")
                Case Else
                    MyCriteria = CriteriasOR( _
                        Criteria(eFieldName.name.ToString, SearchCriteria), _
                        Criteria(eFieldName.ic_passport.ToString, SearchCriteria), _
                        CriteriaLike(eFieldName.full_name.ToString, "%" & SearchCriteria & "%") _
                    )
            End Select

            Dim Other As String = Limit(MaxResult)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)
        End Function

#End Region

#End Region

#Region "Join Functions"

#Region "User Is In Location"

        ''' <summary>
        ''' Check if user is in Branch
        ''' </summary>
        Public Shared Function IsInBranch(UserId As Integer, BranchId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, UserId), _
                Criteria(eFieldName.branch_id.ToString, BranchId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Branch
        ''' </summary>
        Public Shared Function IsInBranch(Username As String, BranchId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.branch_id.ToString, BranchId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Branch
        ''' </summary>
        Public Shared Function IsInBranch(Username As String, BranchCode As String, ProviderConnectionString As String) As Boolean
            Dim BranchId As Integer = OfficeBranch.IdByBranchCode(BranchCode, ProviderConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.branch_id.ToString, BranchId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Satellite
        ''' </summary>
        Public Shared Function IsInSatellite(Username As String, SatelliteId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.satellite_id.ToString, SatelliteId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Satellite
        ''' </summary>
        Public Shared Function IsInSatellite(Username As String, SatelliteInitial As String, ProviderConnectionString As String) As Boolean
            Dim SatelliteId As Integer = Table.OfficeSatellite.Id(SatelliteInitial, ProviderConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.satellite_id.ToString, SatelliteId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Satellite
        ''' </summary>
        Public Shared Function IsInSatellite(Username As Integer, SatelliteId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.satellite_id.ToString, SatelliteId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Department
        ''' </summary>
        Public Shared Function IsInDepartment(UserId As Integer, DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, UserId), _
                Criteria(eFieldName.department_id.ToString, DepartmentId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Department
        ''' </summary>
        Public Shared Function IsInDepartment(UserId As Integer, DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Dim DepartmentId As Integer = Table.OfficeDepartment.Initial(UserId, ProviderConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, UserId), _
                Criteria(eFieldName.department_id.ToString, DepartmentId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Department
        ''' </summary>
        Public Shared Function IsInDepartment(Username As String, DepartmentInitial As String, ProviderConnectionString As String) As Boolean
            Dim DepartmentId As Integer = Table.OfficeDepartment.Initial(Username, ProviderConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.department_id.ToString, DepartmentId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Department
        ''' </summary>
        Public Shared Function IsInDepartment(Username As String, DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.department_id.ToString, DepartmentId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Division
        ''' </summary>
        Public Shared Function IsInDivision(UserId As Integer, DivisionId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, UserId), _
                Criteria(eFieldName.division_id.ToString, DivisionId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Division
        ''' </summary>
        Public Shared Function IsInDivision(Username As String, DivisionInitial_ As String, ProviderConnectionString As String) As Boolean
            Dim DivisionId As Integer = Table.OfficeDivision.Id(DivisionInitial_, ProviderConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.division_id.ToString, DivisionId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Division
        ''' </summary>
        Public Shared Function IsInDivision(Username As String, DivisionId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.division_id.ToString, DivisionId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Unit
        ''' </summary>
        Public Shared Function IsInUnit(UserId As Integer, UnitId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.id.ToString, UserId), _
                Criteria(eFieldName.unit_id.ToString, UnitId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Unit
        ''' </summary>
        Public Shared Function IsInUnit(Username As String, UnitInitial As String, ProviderConnectionString As String) As Boolean
            Dim UnitId As Integer = Table.OfficeUnit.Id(UnitInitial, ProviderConnectionString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.unit_id.ToString, UnitId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Unit
        ''' </summary>
        Public Shared Function IsInUnit(Username As String, UnitId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, Username), _
                Criteria(eFieldName.unit_id.ToString, UnitId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

#End Region

#Region "Has Users In Location"

        ''' <summary>
        ''' Check if Branch has users in it
        ''' </summary>
        Public Shared Function HasUsersInBranch(BranchId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.branch_id.ToString, BranchId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if Satellite has users in it
        ''' </summary>
        Public Shared Function HasUsersInSatellite(SatelliteId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.satellite_id.ToString, SatelliteId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if Department has users in it
        ''' </summary>
        Public Shared Function HasUsersInDepartment(DepartmentId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.department_id.ToString, DepartmentId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if Division has users in it
        ''' </summary>
        Public Shared Function HasUsersInDivision(DivisionId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.division_id.ToString, DivisionId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if Unit has users in it
        ''' </summary>
        Public Shared Function HasUsersInUnit(UnitId As Integer, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.unit_id.ToString, UnitId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#Region "Count Users In Location"

#Region "Branch"

        ''' <summary>
        ''' Count if Branch has users in it
        ''' </summary>
        Public Shared Function CountUsersInBranch(BranchId As Integer, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.branch_id.ToString, BranchId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInBranch(BranchId As Integer, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.position_id.ToString, _
                eFieldName.branch_id.ToString, _
                eFieldName.satellite_id.ToString, _
                eFieldName.department_id.ToString, _
                eFieldName.division_id.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.branch_id.ToString, BranchId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInBranch(BranchId As Integer, HideChildUsers As Boolean, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            If HideChildUsers Then
                Dim MyFields As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.name.ToString,
                eFieldName.position_id.ToString,
                eFieldName.branch_id.ToString,
                eFieldName.satellite_id.ToString,
                eFieldName.department_id.ToString,
                eFieldName.division_id.ToString
                )

                Dim Other As String = OrderBy(eFieldName.name.ToString)

                Dim MyCriteria As String = CriteriasAND(
                    Criteria(eFieldName.branch_id.ToString, BranchId),
                    Criteria(eFieldName.department_id.ToString, 0)
                    )

                Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
            Else
                Return GetUsersInBranch(BranchId, ProviderConnectionString)
            End If
        End Function

        Public Shared Function GetUsersInBranchOrderByRank(BranchId As Integer, HideChildUsers As Boolean, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim IncludeTableNameLeft As String = TableName() & "."

            If HideChildUsers Then
                Dim MyFields As String = FieldNames(
                IncludeTableNameLeft & eFieldName.id.ToString,
                IncludeTableNameLeft & eFieldName.name.ToString,
                IncludeTableNameLeft & eFieldName.position_id.ToString,
                IncludeTableNameLeft & eFieldName.branch_id.ToString,
                IncludeTableNameLeft & eFieldName.satellite_id.ToString,
                IncludeTableNameLeft & eFieldName.department_id.ToString,
                IncludeTableNameLeft & eFieldName.division_id.ToString
                )

                Dim MyCriteria As String = CriteriasAND(
                    Criteria(IncludeTableNameLeft & eFieldName.branch_id.ToString, BranchId),
                    Criteria(IncludeTableNameLeft & eFieldName.department_id.ToString, 0)
                    )

                Dim MainTableKey As String = IncludeTableNameLeft & eFieldName.position_id.ToString
                Dim JoinTableName As String = "my_users_position"
                Dim JoinTableKey As String = JoinTableName & "." & "id"
                Dim JoinTableOrder1 As String = JoinTableName & "." & "rankNo"
                Dim JoinTableOrder2 As String = IncludeTableNameLeft & eFieldName.position_id.ToString
                Dim JoinTableOrder3 As String = IncludeTableNameLeft & eFieldName.full_name.ToString

                Dim Other As String = OrdersBy(OrderBy(JoinTableOrder1, False), OrderBy(JoinTableOrder2, False), OrderBy(JoinTableOrder3, True))

                Return MyCmd.CmdSelectTableLeftJoin(TableName, MainTableKey, JoinTableName, JoinTableKey, MyFields, MyCriteria, Other, ProviderConnectionString)
            Else
                Return GetUsersInBranchOrderByRank(BranchId, False, ProviderConnectionString)
            End If
        End Function

#Region "Search Branch"

        Public Shared Function SearchUsersInBranchByPatronId(BranchId As Integer, PatronId As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, PatronId), _
                Criteria(eFieldName.branch_id.ToString, BranchId) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInBranchByPatronIc(BranchId As Integer, PatronIc As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.ic_passport.ToString, PatronIc), _
                Criteria(eFieldName.branch_id.ToString, BranchId) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInBranchByPatronName(BranchId As Integer, PatronName As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, 100)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronName)), _
                Criteria(eFieldName.branch_id.ToString, BranchId) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInBranchByAll(BranchId As Integer, PatronKey As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, 100)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriasOR( _
                    CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronKey)), _
                    Criteria(eFieldName.name.ToString, PatronKey), _
                    Criteria(eFieldName.ic_passport.ToString, PatronKey)
                    ), _
                Criteria(eFieldName.branch_id.ToString, BranchId) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Satellite"

        ''' <summary>
        ''' Count if Satellite has users in it
        ''' </summary>
        Public Shared Function CountUsersInSatellite(SatelliteId As Integer, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.satellite_id.ToString, SatelliteId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInSatellite(SatelliteId As Integer, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.position_id.ToString, _
                eFieldName.branch_id.ToString, _
                eFieldName.satellite_id.ToString, _
                eFieldName.department_id.ToString, _
                eFieldName.division_id.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.satellite_id.ToString, SatelliteId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInSatellite(SatelliteId As Integer, PatronId As String, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim MyFields As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.name.ToString,
                eFieldName.position_id.ToString,
                eFieldName.branch_id.ToString,
                eFieldName.satellite_id.ToString,
                eFieldName.department_id.ToString,
                eFieldName.division_id.ToString
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND(
                Criteria(eFieldName.name.ToString, PatronId),
                Criteria(eFieldName.satellite_id.ToString, SatelliteId)
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInSatelliteByRank(SatelliteId As Integer, HideChildUsers As Boolean, ProviderConnectionString As String) As DataTable
            If HideChildUsers Then
                '' Fields
                'id, name, position_id, branch_id, satellite_id, department_id, division_id

                Dim IncludeTableNameLeft As String = TableName() & "."

                Dim MyFields As String = FieldNames(
                    IncludeTableNameLeft & eFieldName.id.ToString,
                    IncludeTableNameLeft & eFieldName.name.ToString,
                    IncludeTableNameLeft & eFieldName.position_id.ToString,
                    IncludeTableNameLeft & eFieldName.branch_id.ToString,
                    IncludeTableNameLeft & eFieldName.satellite_id.ToString,
                    IncludeTableNameLeft & eFieldName.department_id.ToString,
                    IncludeTableNameLeft & eFieldName.division_id.ToString
                    )

                Dim MainTableKey As String = IncludeTableNameLeft & eFieldName.position_id.ToString
                Dim JoinTableName As String = "my_users_position"
                Dim JoinTableKey As String = JoinTableName & "." & "id"
                Dim JoinTableOrder1 As String = JoinTableName & "." & "rankNo"
                Dim JoinTableOrder2 As String = IncludeTableNameLeft & eFieldName.position_id.ToString
                Dim JoinTableOrder3 As String = IncludeTableNameLeft & eFieldName.full_name.ToString

                Dim Other As String = OrdersBy(OrderBy(JoinTableOrder1, False), OrderBy(JoinTableOrder2, False), OrderBy(JoinTableOrder3, True))

                Dim MyCriteria As String = CriteriasAND(
                        Criteria(IncludeTableNameLeft & eFieldName.satellite_id.ToString, SatelliteId),
                        Criteria(IncludeTableNameLeft & eFieldName.unit_id.ToString, 0)
                    )

                Return MyCmd.CmdSelectTableLeftJoin(TableName, MainTableKey, JoinTableName, JoinTableKey, MyFields, MyCriteria, Other, ProviderConnectionString)
            Else
                Return GetUsersInSatelliteByRank(SatelliteId, False, ProviderConnectionString)
            End If
        End Function

#Region "Search Satellite"

        Public Shared Function SearchUsersInSatelliteByPatronId(SatelliteId_ As Integer, PatronId As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, PatronId), _
                Criteria(eFieldName.satellite_id.ToString, SatelliteId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInSatelliteByPatronIc(SatelliteId_ As Integer, PatronIc As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.ic_passport.ToString, PatronIc), _
                Criteria(eFieldName.satellite_id.ToString, SatelliteId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInSatelliteByPatronName(SatelliteId_ As Integer, PatronName As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, 100)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronName)), _
                Criteria(eFieldName.satellite_id.ToString, SatelliteId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInSatelliteByAll(SatelliteId_ As Integer, PatronKey As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, 100)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriasOR( _
                    CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronKey)), _
                    Criteria(eFieldName.name.ToString, PatronKey), _
                    Criteria(eFieldName.ic_passport.ToString, PatronKey)
                    ), _
                Criteria(eFieldName.satellite_id.ToString, SatelliteId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Department"

        ''' <summary>
        ''' Count if Department has users in it
        ''' </summary>
        Public Shared Function CountUsersInDepartment(DepartmentId As Integer, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.department_id.ToString, DepartmentId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInDepartment(DepartmentId As Integer, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.position_id.ToString, _
                eFieldName.branch_id.ToString, _
                eFieldName.satellite_id.ToString, _
                eFieldName.department_id.ToString, _
                eFieldName.division_id.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.department_id.ToString, DepartmentId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInDepartment(DepartmentId As Integer, PatronId As String, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.position_id.ToString, _
                eFieldName.branch_id.ToString, _
                eFieldName.satellite_id.ToString, _
                eFieldName.department_id.ToString, _
                eFieldName.division_id.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, PatronId), _
                Criteria(eFieldName.department_id.ToString, DepartmentId) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInDepartment(DepartmentId As Integer, HideChildUsers As Boolean, ProviderConnectionString As String) As DataTable
            If HideChildUsers Then
                '' Fields
                'id, name, position_id, branch_id, satellite_id, department_id, division_id

                Dim MyFields As String = FieldNames(
                    eFieldName.id.ToString,
                    eFieldName.name.ToString,
                    eFieldName.position_id.ToString,
                    eFieldName.branch_id.ToString,
                    eFieldName.satellite_id.ToString,
                    eFieldName.department_id.ToString,
                    eFieldName.division_id.ToString
                    )

                Dim Other As String = OrderBy(eFieldName.name.ToString)

                Dim MyCriteria As String = CriteriasAND(
                    Criteria(eFieldName.department_id.ToString, DepartmentId),
                    Criteria(eFieldName.division_id.ToString, 0)
                    )

                Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
            Else
                Return GetUsersInDepartment(DepartmentId, ProviderConnectionString)
            End If
        End Function

        Public Shared Function GetUsersInDepartmentOrderByRank(DepartmentId As Integer, HideChildUsers As Boolean, ProviderConnectionString As String) As DataTable
            If HideChildUsers Then
                '' Fields
                'id, name, position_id, branch_id, satellite_id, department_id, division_id

                Dim IncludeTableNameLeft As String = TableName() & "."

                Dim MyFields As String = FieldNames(
                    IncludeTableNameLeft & eFieldName.id.ToString,
                    IncludeTableNameLeft & eFieldName.name.ToString,
                    IncludeTableNameLeft & eFieldName.position_id.ToString,
                    IncludeTableNameLeft & eFieldName.branch_id.ToString,
                    IncludeTableNameLeft & eFieldName.satellite_id.ToString,
                    IncludeTableNameLeft & eFieldName.department_id.ToString,
                    IncludeTableNameLeft & eFieldName.division_id.ToString
                    )

                Dim MainTableKey As String = IncludeTableNameLeft & eFieldName.position_id.ToString
                Dim JoinTableName As String = "my_users_position"
                Dim JoinTableKey As String = JoinTableName & "." & "id"
                Dim JoinTableOrder1 As String = JoinTableName & "." & "rankNo"
                Dim JoinTableOrder2 As String = IncludeTableNameLeft & eFieldName.position_id.ToString
                Dim JoinTableOrder3 As String = IncludeTableNameLeft & eFieldName.full_name.ToString

                Dim Other As String = OrdersBy(OrderBy(JoinTableOrder1, False), OrderBy(JoinTableOrder2, False), OrderBy(JoinTableOrder3, True))

                Dim MyCriteria As String = CriteriasAND(
                    Criteria(IncludeTableNameLeft & eFieldName.department_id.ToString, DepartmentId),
                    Criteria(IncludeTableNameLeft & eFieldName.division_id.ToString, 0)
                    )

                Return MyCmd.CmdSelectTableLeftJoin(TableName, MainTableKey, JoinTableName, JoinTableKey, MyFields, MyCriteria, Other, ProviderConnectionString)
            Else
                Return GetUsersInDepartmentOrderByRank(DepartmentId, False, ProviderConnectionString)
            End If
        End Function

#Region "Search Department"

        Public Shared Function SearchUsersInDepartmentByPatronId(DepartmentId_ As Integer, PatronId As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, PatronId), _
                Criteria(eFieldName.department_id.ToString, DepartmentId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInDepartmentByPatronIc(DepartmentId_ As Integer, PatronIc As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.ic_passport.ToString, PatronIc), _
                Criteria(eFieldName.department_id.ToString, DepartmentId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInDepartmentByPatronName(DepartmentId_ As Integer, PatronName As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, 100)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronName)), _
                Criteria(eFieldName.department_id.ToString, DepartmentId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInDepartmentByAll(DepartmentId_ As Integer, PatronKey As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, 100)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriasOR( _
                    CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronKey)), _
                    Criteria(eFieldName.name.ToString, PatronKey), _
                    Criteria(eFieldName.ic_passport.ToString, PatronKey)
                    ), _
                Criteria(eFieldName.department_id.ToString, DepartmentId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Division"

        ''' <summary>
        ''' Count if Division has users in it
        ''' </summary>
        Public Shared Function CountUsersInDivision(DivisionId As Integer, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.division_id.ToString, DivisionId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All user in a division by DivisionId.
        ''' </summary>
        Public Shared Function GetUsersInDivision(DivisionId As Integer, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.position_id.ToString, _
                eFieldName.branch_id.ToString, _
                eFieldName.satellite_id.ToString, _
                eFieldName.department_id.ToString, _
                eFieldName.division_id.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.division_id.ToString, DivisionId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInDivision(DivisionId As Integer, PatronId As String, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.position_id.ToString, _
                eFieldName.branch_id.ToString, _
                eFieldName.satellite_id.ToString, _
                eFieldName.department_id.ToString, _
                eFieldName.division_id.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                    Criteria(eFieldName.name.ToString, PatronId), _
                    Criteria(eFieldName.division_id.ToString, DivisionId) _
                    )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get All user in a division with/without users in any unit by DivisionId.
        ''' </summary>
        ''' <param name="HideChildUsers">Hides unit in any unit?</param>
        ''' <returns></returns>
        Public Shared Function GetUsersInDivision(DivisionId As Integer, HideChildUsers As Boolean, ProviderConnectionString As String) As DataTable
            If HideChildUsers Then
                '' Fields
                'id, name, position_id, branch_id, satellite_id, department_id, division_id

                Dim MyFields As String = FieldNames(
                    eFieldName.id.ToString,
                    eFieldName.name.ToString,
                    eFieldName.position_id.ToString,
                    eFieldName.branch_id.ToString,
                    eFieldName.satellite_id.ToString,
                    eFieldName.department_id.ToString,
                    eFieldName.division_id.ToString
                    )

                Dim Other As String = OrderBy(eFieldName.name.ToString)

                Dim MyCriteria As String = CriteriasAND(
                    Criteria(eFieldName.division_id.ToString, DivisionId),
                    Criteria(eFieldName.unit_id.ToString, 0)
                    )

                Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
            Else
                Return GetUsersInDivision(DivisionId, ProviderConnectionString)
            End If
        End Function

        Public Shared Function GetUsersInDivisionByRank(DivisionId As Integer, HideChildUsers As Boolean, ProviderConnectionString As String) As DataTable
            If HideChildUsers Then
                '' Fields
                'id, name, position_id, branch_id, satellite_id, department_id, division_id

                Dim IncludeTableNameLeft As String = TableName() & "."

                Dim MyFields As String = FieldNames(
                    IncludeTableNameLeft & eFieldName.id.ToString,
                    IncludeTableNameLeft & eFieldName.name.ToString,
                    IncludeTableNameLeft & eFieldName.position_id.ToString,
                    IncludeTableNameLeft & eFieldName.branch_id.ToString,
                    IncludeTableNameLeft & eFieldName.satellite_id.ToString,
                    IncludeTableNameLeft & eFieldName.department_id.ToString,
                    IncludeTableNameLeft & eFieldName.division_id.ToString
                    )

                Dim MainTableKey As String = IncludeTableNameLeft & eFieldName.position_id.ToString
                Dim JoinTableName As String = "my_users_position"
                Dim JoinTableKey As String = JoinTableName & "." & "id"
                Dim JoinTableOrder1 As String = JoinTableName & "." & "rankNo"
                Dim JoinTableOrder2 As String = IncludeTableNameLeft & eFieldName.position_id.ToString
                Dim JoinTableOrder3 As String = IncludeTableNameLeft & eFieldName.full_name.ToString

                Dim Other As String = OrdersBy(OrderBy(JoinTableOrder1, False), OrderBy(JoinTableOrder2, False), OrderBy(JoinTableOrder3, True))

                Dim MyCriteria As String = CriteriasAND(
                    Criteria(IncludeTableNameLeft & eFieldName.division_id.ToString, DivisionId),
                    Criteria(IncludeTableNameLeft & eFieldName.unit_id.ToString, 0)
                    )

                Return MyCmd.CmdSelectTableLeftJoin(TableName, MainTableKey, JoinTableName, JoinTableKey, MyFields, MyCriteria, Other, ProviderConnectionString)
            Else
                Return GetUsersInDivisionByRank(DivisionId, False, ProviderConnectionString)
            End If
        End Function

#Region "Search Division"

        Public Shared Function SearchUsersInDivisionByPatronId(DivisionId_ As Integer, PatronId As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, PatronId), _
                Criteria(eFieldName.division_id.ToString, DivisionId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInDivisionByPatronIc(DivisionId_ As Integer, PatronIc As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.ic_passport.ToString, PatronIc), _
                Criteria(eFieldName.division_id.ToString, DivisionId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInDivisionByPatronName(DivisionId_ As Integer, PatronName As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, 100)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronName)), _
                Criteria(eFieldName.division_id.ToString, DivisionId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInDivisionByAll(DivisionId_ As Integer, PatronKey As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderByLimit(eFieldName.name.ToString, True, 100)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriasOR( _
                    CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronKey)), _
                    Criteria(eFieldName.name.ToString, PatronKey), _
                    Criteria(eFieldName.ic_passport.ToString, PatronKey)
                    ), _
                Criteria(eFieldName.division_id.ToString, DivisionId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Unit"

        ''' <summary>
        ''' Count if Unit has users in it
        ''' </summary>
        Public Shared Function CountUsersInUnit(UnitId As Integer, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.unit_id.ToString, UnitId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Get users in a unit. columns (id, name)
        ''' </summary>
        Public Shared Function GetUsersInUnit(UnitId As Integer, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim MyFields As String = FieldNames(
                eFieldName.id.ToString,
                eFieldName.name.ToString,
                eFieldName.position_id.ToString,
                eFieldName.branch_id.ToString,
                eFieldName.satellite_id.ToString,
                eFieldName.department_id.ToString,
                eFieldName.division_id.ToString
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.unit_id.ToString, UnitId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInUnitByRank(UnitId As Integer, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim IncludeTableNameLeft As String = TableName() & "."

            Dim MyFields As String = FieldNames(
                IncludeTableNameLeft & eFieldName.id.ToString,
                IncludeTableNameLeft & eFieldName.name.ToString,
                IncludeTableNameLeft & eFieldName.position_id.ToString,
                IncludeTableNameLeft & eFieldName.branch_id.ToString,
                IncludeTableNameLeft & eFieldName.satellite_id.ToString,
                IncludeTableNameLeft & eFieldName.department_id.ToString,
                IncludeTableNameLeft & eFieldName.division_id.ToString
                )

            Dim MainTableKey As String = IncludeTableNameLeft & eFieldName.position_id.ToString
            Dim JoinTableName As String = "my_users_position"
            Dim JoinTableKey As String = JoinTableName & "." & "id"
            Dim JoinTableOrder1 As String = JoinTableName & "." & "rankNo"
            Dim JoinTableOrder2 As String = IncludeTableNameLeft & eFieldName.position_id.ToString
            Dim JoinTableOrder3 As String = IncludeTableNameLeft & eFieldName.full_name.ToString

            Dim Other As String = OrdersBy(OrderBy(JoinTableOrder1, False), OrderBy(JoinTableOrder2, False), OrderBy(JoinTableOrder3, True))

            Dim MyCriteria As String = Criteria(IncludeTableNameLeft & eFieldName.unit_id.ToString, UnitId)
            Return MyCmd.CmdSelectTableLeftJoin(TableName, MainTableKey, JoinTableName, JoinTableKey, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInUnit(UnitId As Integer, Patronid As String, ProviderConnectionString As String) As DataTable
            '' Fields
            'id, name, position_id, branch_id, satellite_id, department_id, division_id

            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString, _
                eFieldName.position_id.ToString, _
                eFieldName.branch_id.ToString, _
                eFieldName.satellite_id.ToString, _
                eFieldName.department_id.ToString, _
                eFieldName.division_id.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                    Criteria(eFieldName.name.ToString, Patronid), _
                    Criteria(eFieldName.unit_id.ToString, UnitId) _
                    )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

#Region "Search Unit"

        Public Shared Function SearchUsersInUnitByPatronId(UnitId_ As Integer, PatronId As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.name.ToString, PatronId), _
                Criteria(eFieldName.unit_id.ToString, UnitId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInUnitByPatronIc(UnitId_ As Integer, PatronIc As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.ic_passport.ToString, PatronIc), _
                Criteria(eFieldName.unit_id.ToString, UnitId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInUnitByPatronName(UnitId_ As Integer, PatronName As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronName)), _
                Criteria(eFieldName.unit_id.ToString, UnitId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        Public Shared Function SearchUsersInUnitByAll(UnitId_ As Integer, PatronKey As String, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.id.ToString, _
                eFieldName.name.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.name.ToString)

            Dim MyCriteria As String = CriteriasAND( _
                CriteriasOR( _
                    CriteriaLike(eFieldName.full_name.ToString, String.Format("%{0}%", PatronKey)), _
                    Criteria(eFieldName.name.ToString, PatronKey), _
                    Criteria(eFieldName.ic_passport.ToString, PatronKey)
                    ), _
                Criteria(eFieldName.unit_id.ToString, UnitId_) _
                )

            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

#End Region

#End Region

#Region "Alternate Functions"

        ''' <summary>
        ''' Get Nick, but if the Nick is empty, the Fullname will be returned
        ''' </summary>
        Public Shared Function NickOrFullname(UserId As Integer, ProvidersConnectionString As String) As String
            Dim ReturnValue As String = Nothing
            Dim Nick_ As String = Nick(UserId, ProvidersConnectionString)

            If Nick_.Length > 0 Then
                ReturnValue = Nick_
            Else

                Dim Fullname_ As String = FullName(UserId, ProvidersConnectionString)
                ReturnValue = Fullname_
            End If

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Get Nick, but if the Nick is empty, the Fullname will be returned
        ''' </summary>
        Public Shared Function NickOrFullname(Username As String, ProvidersConnectionString As String) As String
            Dim ReturnValue As String = Nothing
            Dim Nick_ As String = Nick(Username, ProvidersConnectionString)

            If Nick_.Length > 0 Then
                ReturnValue = Nick_
            Else

                Dim Fullname_ As String = FullName(Username, ProvidersConnectionString)
                ReturnValue = Fullname_
            End If

            Return ReturnValue
        End Function

#End Region

    End Class

End Namespace


