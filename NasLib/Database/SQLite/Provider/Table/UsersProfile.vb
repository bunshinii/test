Imports NasLib.Database.SQLite.Sql.Simplifier

Namespace Database.SQLite.Provider.Table

    ''' <summary>
    ''' This is a table base class base on table 'users_profile'
    ''' </summary>
    Public Class UsersProfile

        Private Shared MyCmd As New Sql.Commands

#Region "SQLite Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.SQLite.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "users_profile"            '<-------------------------------------- 1 ' Modify TableName
        End Function


        Private Enum eFieldName
            'List all field in the table here   '<-------------------------------------- 2
            UserId
            Username
            FullName
            Nick
            GradeId
            PositionId
            Phone
            PhoneExt
            Fax
            Handphone
            Website
            Blogspot
            Facebook
            Twitter
            Picture
            BirthDate
            RegDate
            ExpDate
            BranchId
            SatelliteId
            DepartmentId
            DivisionId
            UnitId
            Email
            IcPassport
            GenderId
            MarriageId
            SeqNo
            Address1
            Address2
            Address3
            Postcode
            City
            State
            Country
            LastUpdateDate
        End Enum

        Private Shared Function FieldName(TheName As eFieldName) As String
            Dim MyStr As String = TheName.ToString
            Return MyStr
        End Function

        'Optional                               '<-------------------------------------- Optional
        ''' <summary>
        ''' Get UserId from Table 'my_aspnet_users' by username
        ''' </summary>
        Private Shared Function UserId1(Username As String, ProviderConnectionString As String) As Guid
            Return Table.Users.UserId(Username, ProviderConnectionString)
        End Function

#End Region

        'Create Property for each field          '<-------------------------------------- 3
#Region "Table Fields Properties"

#Region "id"

        Public Shared Function UserId(Username As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = FieldName(eFieldName.UserId)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.Username), Username)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

        Public Shared Function Id(Username As String, ProviderConnectionString As String) As Guid
            Dim MyFieldName As String = FieldName(eFieldName.UserId)
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.Username), Username)
            Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
            Return MyGuid
        End Function

#End Region

#Region "Name"

        Public Shared Property Username(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Username)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)

                Dim MyFieldName As String = FieldName(eFieldName.Username)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

#End Region

#Region "full_name"

        Public Shared Property FullName(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.FullName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.FullName)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property FullName(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return FullName(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                FullName(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "nick"

        Public Shared Property Nick(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Nick)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)


                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Nick)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Nick(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Nick(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Nick(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "grade"

        Public Shared Property Grade(ByVal UserId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.GradeId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.GradeId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Grade(ByVal Username As String, ProviderConnectionString As String) As Guid
            Get
                Return Grade(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                Grade(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "position_id"

        Public Shared Property PositionId(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PositionId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.PositionId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                ''If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PositionId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return PositionId(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                PositionId(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "phone"

        Public Shared Property Phone(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Phone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Phone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Phone(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Phone(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Phone(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "phone_ext"

        Public Shared Property PhoneExt(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.PhoneExt)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.PhoneExt)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property PhoneExt(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return PhoneExt(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                PhoneExt(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "fax"

        Public Shared Property Fax(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Fax)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Fax)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Fax(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Fax(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Fax(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "handphone"

        Public Shared Property Handphone(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Handphone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Handphone)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Handphone(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Handphone(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Handphone(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "website"

        Public Shared Property Website(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Website)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Website)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Website(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Website(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Website(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "blogspot"

        Public Shared Property Blogspot(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Blogspot)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Blogspot)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Blogspot(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Blogspot(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Blogspot(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "facebook"

        Public Shared Property Facebook(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Facebook)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Facebook)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Facebook(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Facebook(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Facebook(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "twitter"

        Public Shared Property Twitter(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Twitter)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Twitter)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Twitter(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Twitter(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Twitter(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "picture"

        Public Shared Property Picture(ByVal UserId As Guid, ProviderConnectionString As String) As Byte()
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Picture)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Return MyCmd.CmdSelectBlob(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
            End Get
            Set(value As Byte())
                Dim MyFieldName As String = FieldName(eFieldName.Picture)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdateBlob(TableName, MyFieldName, value, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Picture(ByVal UserName As String, ProviderConnectionString As String) As Byte()
            Get
                Return Picture(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Byte())
                Picture(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "birthDate"

        Public Shared Property BirthDate(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.BirthDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.BirthDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property BirthDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return BirthDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                BirthDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "regDate"

        Public Shared Property RegistrationDate(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.RegDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.RegDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property RegistrationDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return RegistrationDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                RegistrationDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "expDate"

        Public Shared Property ExpireDate(ByVal UserId As Guid, ProviderConnectionString As String) As DateTime
            Get
                Dim MyFieldName As String = FieldName(eFieldName.ExpDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As DateTime)
                Dim MyFieldName As String = FieldName(eFieldName.ExpDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property ExpireDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return ExpireDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                ExpireDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "BranchId"

        Public Shared Property BranchId(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.BranchId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property BranchId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return BranchId(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                BranchId(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "SatelliteId"

        Public Shared Property SatelliteId(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.SatelliteId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.SatelliteId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property SatelliteId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return SatelliteId(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                SatelliteId(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "DepartmentId"

        Public Shared Property DepartmentId(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.DepartmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.DepartmentId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property DepartmentId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return DepartmentId(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                DepartmentId(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "Divisionid"

        Public Shared Property DivisionId(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.DivisionId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.DivisionId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property DivisionId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return DivisionId(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                DivisionId(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "UnitId"

        Public Shared Property UnitId(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.UnitId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.UnitId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property UnitId(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return UnitId(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                UnitId(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "email"

        Public Shared Property Email(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Email)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Email(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Email(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Email(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "ic_passport"

        Public Shared Property Passport(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.IcPassport)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.IcPassport)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Passport(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Passport(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Passport(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "gender_id"

        Public Shared Property GenderId(ByVal UserId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.GenderId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.GenderId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property GenderId(ByVal Username As String, ProviderConnectionString As String) As Guid
            Get
                Return GenderId(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                GenderId(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "marriage_id"

        Public Shared Property MarriageId(ByVal UserId As Guid, ProviderConnectionString As String) As Guid
            Get
                Dim MyFieldName As String = FieldName(eFieldName.MarriageId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyGuid As New Guid(MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString))
                Return MyGuid
            End Get
            Set(value As Guid)
                Dim MyFieldName As String = FieldName(eFieldName.MarriageId)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property MarriageId(ByVal Username As String, ProviderConnectionString As String) As Guid
            Get
                Return MarriageId(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Guid)
                MarriageId(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "seq_no"

        ''' <summary>
        ''' For sorting porpose only. Not unique
        ''' </summary>
        Public Shared Property SequenceNo(ByVal UserId As Guid, ProviderConnectionString As String) As Integer
            Get
                Dim MyFieldName As String = FieldName(eFieldName.SeqNo)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Integer)
                Dim MyFieldName As String = FieldName(eFieldName.SeqNo)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        ''' <summary>
        ''' Same as SequenceNo()
        ''' </summary>
        Public Shared Property seq_no(ByVal Username As String, ProviderConnectionString As String) As Integer
            Get
                Return SequenceNo(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As Integer)
                SequenceNo(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "address1"

        Public Shared Property Address1(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Address1)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Address1)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Address1(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Address1(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Address1(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "address2"

        Public Shared Property Address2(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Address2)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Address2)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Address2(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Address2(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Address2(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "address3"

        Public Shared Property Address3(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Address3)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Address3)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Address3(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Address3(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Address3(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "postcode"

        Public Shared Property Postcode(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Postcode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Postcode)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Postcode(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Postcode(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Postcode(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "city"

        Public Shared Property City(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.City)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.City)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property City(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return City(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                City(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "state"

        Public Shared Property State(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.State)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.State)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property State(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return State(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                State(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "country"

        Public Shared Property Country(ByVal UserId As Guid, ProviderConnectionString As String) As String
            Get
                Dim MyFieldName As String = FieldName(eFieldName.Country)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As String)
                Dim MyFieldName As String = FieldName(eFieldName.Country)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = FieldValue(value)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                MyCmd.CmdUpdate3(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property Country(ByVal UserName As String, ProviderConnectionString As String) As String
            Get
                Return Country(UserId(UserName, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As String)
                Country(UserId(UserName, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#Region "lastUpdateDate"

        Public Shared Property LastUpdateDate(ByVal UserId As Guid, ProviderConnectionString As String) As Date
            Get
                Dim MyFieldName As String = FieldName(eFieldName.LastUpdateDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , ProviderConnectionString)
                Return MyStr
            End Get
            Set(value As Date)
                Dim MyFieldName As String = FieldName(eFieldName.LastUpdateDate)
                Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
                Dim MyFieldValue As String = Format(value, "yyy-MM-dd HH:mm:ss")

                'Auto generate blank data into the table if data not existed in the table.
                'If Not PKeyExisted(UserId, TableName, MyCriteria, ProviderConnectionString) Then PkGenerateBlankData(UserId, ProviderConnectionString)

                Dim MyStr As String = MyCmd.CmdUpdateDateTime(TableName, MyFieldName, MyFieldValue, MyCriteria, ProviderConnectionString)
            End Set
        End Property

        Public Shared Property LastUpdateDate(ByVal Username As String, ProviderConnectionString As String) As DateTime
            Get
                Return LastUpdateDate(UserId(Username, ProviderConnectionString), ProviderConnectionString)
            End Get
            Set(value As DateTime)
                LastUpdateDate(UserId(Username, ProviderConnectionString), ProviderConnectionString) = value
            End Set
        End Property

#End Region

#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(UserId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.UserId.ToString, UserId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExisted(Username As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.UserId.ToString, UserId(Username, ProviderConnectionString))
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        Public Shared Function Count(ProviderConnectionString As String) As Integer
            Return MyCmd.CmdCount(TableName, , ProviderConnectionString)
        End Function

#End Region

#Region "Table Operation"

#Region "Insert"

        Public Shared Function ProfileInsert(UserId As Guid, Username As String, FullName As String, ProviderConnectionString As String) As String
            Dim LastUpdateDate As Date = Now

            Dim MyFieldsName As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString, _
                eFieldName.FullName.ToString, _
                eFieldName.LastUpdateDate.ToString _
                )

            Dim MyFieldsValue As String = FieldValues( _
                UserId, _
                Username, _
                FullName, _
                LastUpdateDate _
                )

            Return MyCmd.CmdInsert(TableName, MyFieldsName, MyFieldsValue, ProviderConnectionString)
        End Function

        Public Shared Function ProfileInsert(UserId As Guid, Username As String, ProviderConnectionString As String) As Integer
            Dim FullName As String = ""
            Return ProfileInsert(UserId, Username, FullName, ProviderConnectionString)
        End Function

#End Region

#Region "Delete"

        Public Shared Function ProfileDelete(UserId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.UserId), UserId)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function ProfileDelete(Username As String, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(FieldName(eFieldName.Username), Username)
            Return MyCmd.CmdDelete(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#End Region

#Region "Join Functions"

#Region "User Is In Location"

        ''' <summary>
        ''' Check if user is in Branch
        ''' </summary>
        Public Shared Function IsInBranch(UserId As Guid, BranchId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.UserId.ToString, UserId), _
                Criteria(eFieldName.BranchId.ToString, BranchId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Satellite
        ''' </summary>
        Public Shared Function IsInSatellite(UserId As Guid, SatelliteId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.UserId.ToString, UserId), _
                Criteria(eFieldName.SatelliteId.ToString, SatelliteId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Department
        ''' </summary>
        Public Shared Function IsInDepartment(UserId As Guid, DepartmentId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.UserId.ToString, UserId), _
                Criteria(eFieldName.DepartmentId.ToString, DepartmentId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Division
        ''' </summary>
        Public Shared Function IsInDivision(UserId As Guid, DivisionId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.UserId.ToString, UserId), _
                Criteria(eFieldName.DivisionId.ToString, DivisionId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

        ''' <summary>
        ''' Check if user is in Unit
        ''' </summary>
        Public Shared Function IsInUnit(UserId As Guid, UnitId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = CriteriasAND( _
                Criteria(eFieldName.UserId.ToString, UserId), _
                Criteria(eFieldName.UnitId.ToString, UnitId) _
                )

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
            Return MyBool
        End Function

#End Region

#Region "Has Users In Location"

        ''' <summary>
        ''' Check if Branch has users in it
        ''' </summary>
        Public Shared Function HasUsersInBranch(BranchId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, BranchId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if Satellite has users in it
        ''' </summary>
        Public Shared Function HasUsersInSatellite(SatelliteId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.SatelliteId.ToString, SatelliteId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if Department has users in it
        ''' </summary>
        Public Shared Function HasUsersInDepartment(DepartmentId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.DepartmentId.ToString, DepartmentId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if Division has users in it
        ''' </summary>
        Public Shared Function HasUsersInDivision(DivisionId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.DivisionId.ToString, DivisionId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Check if Unit has users in it
        ''' </summary>
        Public Shared Function HasUsersInUnit(UnitId As Guid, ProviderConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.UnitId.ToString, UnitId)
            Return MyCmd.CmdExisted(TableName, MyCriteria, ProviderConnectionString)
        End Function

#End Region

#Region "Count Users In Location"

        ''' <summary>
        ''' Count if Branch has users in it
        ''' </summary>
        Public Shared Function CountUsersInBranch(BranchId As Guid, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, BranchId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInBranch(BranchId As Guid, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.Username.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.BranchId.ToString, BranchId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count if Satellite has users in it
        ''' </summary>
        Public Shared Function CountUsersInSatellite(SatelliteId As Guid, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.SatelliteId.ToString, SatelliteId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInSatellite(SatelliteId As Guid, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.Username.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.SatelliteId.ToString, SatelliteId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count if Department has users in it
        ''' </summary>
        Public Shared Function CountUsersInDepartment(DepartmentId As Guid, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.DepartmentId.ToString, DepartmentId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInDepartment(DepartmentId As Guid, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.Username.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.DepartmentId.ToString, DepartmentId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count if Division has users in it
        ''' </summary>
        Public Shared Function CountUsersInDivision(DivisionId As Guid, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.Divisionid.ToString, DivisionId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInDivision(DivisionId As Guid, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.Username.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.Divisionid.ToString, DivisionId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

        ''' <summary>
        ''' Count if Unit has users in it
        ''' </summary>
        Public Shared Function CountUsersInUnit(UnitId As Guid, ProviderConnectionString As String) As Integer
            Dim MyCriteria As String = Criteria(eFieldName.UnitId.ToString, UnitId)
            Return MyCmd.CmdCount(TableName, MyCriteria, ProviderConnectionString)
        End Function

        Public Shared Function GetUsersInUnit(UnitId As Guid, ProviderConnectionString As String) As DataTable
            Dim MyFields As String = FieldNames( _
                eFieldName.UserId.ToString, _
                eFieldName.Username.ToString _
                )

            Dim Other As String = OrderBy(eFieldName.Username.ToString)

            Dim MyCriteria As String = Criteria(eFieldName.UnitId.ToString, UnitId)
            Return MyCmd.CmdSelectTable(TableName, MyFields, MyCriteria, Other, ProviderConnectionString)
        End Function

#End Region

#End Region

    End Class

End Namespace


