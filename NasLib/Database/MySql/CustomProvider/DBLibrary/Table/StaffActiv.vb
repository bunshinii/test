Imports NasLib.Database.MySql.Sql.Simplifier

Namespace Database.MySql.CustomProvider.DBLibrary.Table

    ''' <summary>
    ''' This is a table base class base on table 'staff_activ'
    ''' </summary>
    Public Class StaffActiv

        Private Shared MyCmd As New Sql.Commands

#Region "MySql Table Setting"

        '===========================================================================
        'Each Table Base class must have this region
        'Modify TableName() and DBField in this region as needed
        'Then add some property in "Get / Set Data" Region according to Table Fields

        'Dont forget to Imports NasLib.Database.MySql.Sql.Simplifier
        '===========================================================================

        Private Shared Function TableName() As String
            Return "staff_activ"
        End Function



        'List all field in the table here
        Private Enum eFieldName
            BP_NAMA                  'Index (sort)
            BP_NO_PEKERJA            'Primary Key
            BP_NO_KP                 'Index
            BK_JAB_HAKIKI            'Index
            BK_JAB_HAKIKI_DESC
            BK_JAB_SEKARANG
            BK_JAB_SEKARANG_DESC
            BK_JAW_JENIS
            AL_ALAMAT1
            AL_ALAMAT2
            AL_ALAMAT3
            AL_POSKOD
            AL_BANDAR
            AL_NEGERI
            AL_NEGARA
            BK_TELEFON
            BP_EMAIL
            BP_TJANGKA_BSARA
            BK_REKOD_STATUS         'Index
            BK_JAW_HAKIKI           'Index
            BK_JAW_HAKIKI_DESC
            BK_JAW_SEKARANG
            BK_JAW_SEKARANG_DESC
            BK_TARIKH_LAHIR         'Index
            BK_TARIKH_MASUK         'Index
            BK_REKOD_STATUS_DESC

            '' Multiple Field Index:
            '  BP_NO_PEKERJA, BK_REKOD_STATUS
        End Enum

#End Region

#Region "Table Fields Properties"

#Region "id"

        Public Shared ReadOnly Property PatronId(ByVal PatronIc As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BP_NO_PEKERJA.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_KP.ToString, PatronIc)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BP_NAMA"

        Public Shared ReadOnly Property Nama(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BP_NAMA.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr.Trim
            End Get
        End Property

        ''' <summary>
        ''' Trimmed Camel Case
        ''' </summary>
        Public Shared ReadOnly Property Nama1(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Return NasLib.Functions.String.Cases.CamelCase(Nama(PatronId, DBLibraryConnectionString).Trim)
            End Get
        End Property

#End Region

#Region "BP_NO_PEKERJA"

        Public Shared ReadOnly Property NoPekerja(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BP_NO_PEKERJA.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

        ''' <summary>
        ''' Removed Leading Zeros
        ''' </summary>
        Public Shared ReadOnly Property NoPekerja1(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                If IsNumeric(PatronId.Trim) Then PatronId = Int(PatronId)
                Return NoPekerja(PatronId, DBLibraryConnectionString)
            End Get
        End Property

#End Region

#Region "BP_NO_KP"

        Public Shared ReadOnly Property NoIc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BP_NO_KP.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAB_HAKIKI"

        Public Shared ReadOnly Property Jabatan(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAB_HAKIKI.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAB_HAKIKI_DESC"

        Public Shared ReadOnly Property JabatanDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAB_HAKIKI_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAB_SEKARANG"

        Public Shared ReadOnly Property JabatanSekarang(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAB_SEKARANG.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAB_SEKARANG_DESC"

        Public Shared ReadOnly Property JabatanSekarangDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAB_SEKARANG_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAW_JENIS"

        Public Shared ReadOnly Property JawatanJenis(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAW_JENIS.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "AL_ALAMAT1"

        Public Shared ReadOnly Property Alamat1(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.AL_ALAMAT1.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

        ''' <summary>
        ''' Trimmed Camel Case
        ''' </summary>
        Public Shared ReadOnly Property Alamat1a(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Return NasLib.Functions.String.Cases.CamelCase(Alamat1(PatronId, DBLibraryConnectionString).Trim)
            End Get
        End Property

#End Region

#Region "AL_ALAMAT2"

        Public Shared ReadOnly Property Alamat2(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.AL_ALAMAT2.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

        ''' <summary>
        ''' Trimmed Camel Case
        ''' </summary>
        Public Shared ReadOnly Property Alamat2a(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Return NasLib.Functions.String.Cases.CamelCase(Alamat2(PatronId, DBLibraryConnectionString).Trim)
            End Get
        End Property

#End Region

#Region "AL_ALAMAT3"

        Public Shared ReadOnly Property Alamat3(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.AL_ALAMAT3.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

        ''' <summary>
        ''' Trimmed Camel Case
        ''' </summary>
        Public Shared ReadOnly Property Alamat3a(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim Alamat3_ As String = Alamat3(PatronId, DBLibraryConnectionString)
                If Alamat3_.Length > 0 Then
                    Alamat3_ = Alamat3_.Trim
                    Alamat3_ = NasLib.Functions.String.Cases.CamelCase(Alamat3_)
                End If

                Return Alamat3_
            End Get
        End Property

#End Region

#Region "AL_POSKOD"

        Public Shared ReadOnly Property Postkod(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.AL_POSKOD.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

#End Region

#Region "AL_BANDAR"

        Public Shared ReadOnly Property Bandar(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.AL_BANDAR.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

        ''' <summary>
        ''' Trimmed Camel Case
        ''' </summary>
        Public Shared ReadOnly Property Bandar1(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Return NasLib.Functions.String.Cases.CamelCase(Bandar(PatronId, DBLibraryConnectionString).Trim)
            End Get
        End Property

#End Region

#Region "AL_NEGERI"

        Public Shared ReadOnly Property Negeri(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.AL_NEGERI.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

        ''' <summary>
        ''' Trimmed Camel Case
        ''' </summary>
        Public Shared ReadOnly Property Negeri1(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Return NasLib.Functions.String.Cases.CamelCase(Negeri(PatronId, DBLibraryConnectionString).Trim)
            End Get
        End Property

#End Region

#Region "AL_NEGARA"

        Public Shared ReadOnly Property Negara(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.AL_NEGARA.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

        ''' <summary>
        ''' Trimmed Camel Case
        ''' </summary>
        Public Shared ReadOnly Property Negara1(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Return NasLib.Functions.String.Cases.CamelCase(Negara(PatronId, DBLibraryConnectionString).Trim)
            End Get
        End Property

#End Region

#Region "BK_TELEFON"

        Public Shared ReadOnly Property Telefon(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_TELEFON.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

#End Region

#Region "BP_EMAIL"

        Public Shared ReadOnly Property Email(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BP_EMAIL.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

#End Region

#Region "BP_TJANGKA_BSARA"

        Public Shared ReadOnly Property TarikhJangkaBersara(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BP_TJANGKA_BSARA.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_REKOD_STATUS"

        Public Shared ReadOnly Property RekodStatus(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_REKOD_STATUS.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAW_HAKIKI"

        Public Shared ReadOnly Property Jawatan(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAW_HAKIKI.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAW_HAKIKI_DESC"

        Public Shared ReadOnly Property JawatanDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAW_HAKIKI_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAW_SEKARANG"

        Public Shared ReadOnly Property JawatanSekarang(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAW_SEKARANG.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_JAW_SEKARANG_DESC"

        Public Shared ReadOnly Property JawatanSekarangDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_JAW_SEKARANG_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

        Public Shared ReadOnly Property JawatanSekarangDesc1(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Return NasLib.Functions.String.Cases.CamelCase(JawatanSekarangDesc(PatronId, DBLibraryConnectionString).Trim)
            End Get
        End Property
#End Region

#Region "BK_TARIKH_LAHIR"

        Public Shared ReadOnly Property TarikhLahir(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_TARIKH_LAHIR.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_TARIKH_MASUK"

        Public Shared ReadOnly Property TarikhMasuk(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_TARIKH_MASUK.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)

                If MyStr = Nothing Then MyStr = ""
                Return MyStr
            End Get
        End Property

#End Region

#Region "BK_REKOD_STATUS_DESC"

        Public Shared ReadOnly Property RekodStatusDesc(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim MyFieldName As String = eFieldName.BK_REKOD_STATUS_DESC.ToString
                Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

                Dim MyStr As String = MyCmd.CmdSelect(TableName, MyFieldName, 0, MyCriteria, , DBLibraryConnectionString)
                Return MyStr
            End Get
        End Property

#End Region

#Region "JANTINA"

        ''' <summary>
        ''' Get the Patron Gender by thier IC No (Odd or Even).
        ''' Return "Lelaki or Perempuan or empty"
        ''' </summary>
        Public Shared ReadOnly Property Jantina(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim ReturnValue As String = ""

                Dim Passport As String = NoIc(PatronId, DBLibraryConnectionString)
                If IsNumeric(Passport) Then Passport = CLng(Passport)

                If Functions.Number.Type.IsEven(CLng(Passport)) Then
                    ReturnValue = "Perempuan"
                Else
                    ReturnValue = "Lelaki"
                End If

                Return ReturnValue
            End Get
        End Property

        ''' <summary>
        ''' Get the Patron Gender by thier IC No (Odd or Even).
        ''' Return "Male or Female or empty"
        ''' </summary>
        Public Shared ReadOnly Property Gender(ByVal PatronId As String, DBLibraryConnectionString As String) As String
            Get
                Dim ReturnValue As String = ""

                Dim Passport As String = NoIc(PatronId, DBLibraryConnectionString)
                If IsNumeric(Passport) Then Passport = CLng(Passport)

                If Functions.Number.Type.IsEven(CLng(Passport)) Then
                    ReturnValue = "Female"
                Else
                    ReturnValue = "Male"
                End If

                Return ReturnValue
            End Get
        End Property

#End Region


#End Region

        'Modify Parameter name accordingly '<-------------------------------------- 4
#Region "Regular Functions"

        Public Shared Function IsExisted(PatronId As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)
            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function IsExistedIC(IcNo As String, DBLibraryConnectionString As String) As Boolean
            Dim MyCriteria As String = Criteria(eFieldName.BP_NO_KP.ToString, IcNo)
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
                Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId), _
                CriteriasOR(Criteria(eFieldName.BK_REKOD_STATUS.ToString, "1"), Criteria(eFieldName.BK_REKOD_STATUS.ToString, "A"), Criteria(eFieldName.BK_REKOD_STATUS.ToString, "C"), Criteria(eFieldName.BK_REKOD_STATUS.ToString, "D")) _
                )

            '1,3,A,C,D

            Dim MyBool As Boolean = MyCmd.CmdExisted(TableName, MyCriteria, DBLibraryConnectionString)
            Return MyBool
        End Function

        Public Shared Function CountActive(DBLibraryConnectionString As String) As Integer
            Dim MyCriteria As String = CriteriasOR(Criteria(eFieldName.BK_REKOD_STATUS.ToString, "1"), Criteria(eFieldName.BK_REKOD_STATUS.ToString, "A"), Criteria(eFieldName.BK_REKOD_STATUS.ToString, "C"), Criteria(eFieldName.BK_REKOD_STATUS.ToString, "D"))

            Return MyCmd.CmdCount(TableName, MyCriteria, DBLibraryConnectionString)
        End Function

        Public Shared Function CountNotActive(DBLibraryConnectionString As String) As Integer
            Dim MyCriteria As String = CriteriasOR(CriteriaNot(eFieldName.BK_REKOD_STATUS.ToString, "1"), CriteriaNot(eFieldName.BK_REKOD_STATUS.ToString, "A"), CriteriaNot(eFieldName.BK_REKOD_STATUS.ToString, "C"), CriteriaNot(eFieldName.BK_REKOD_STATUS.ToString, "D"))

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
                Dim Passport As String = NoIc(PatronId, DBLibraryConnectionString)
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
                eFieldName.BP_NO_PEKERJA.ToString, _
                eFieldName.BP_NAMA.ToString _
                )

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.BP_NAMA.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, , Other, DBLibraryConnectionString)
        End Function

        ''' <summary>
        ''' Geat All Users with paging. Column(id,name)
        ''' </summary>
        ''' <param name="PageIndex">Page number (Start with 0)</param>
        ''' <param name="PageSize">Number of rows in a page</param>
        Public Shared Function GetAllUsersActive(PageIndex As Integer, PageSize As Integer, DBLibraryConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.BP_NO_PEKERJA.ToString, _
                eFieldName.BP_NAMA.ToString _
                )

            Dim MyCriteria As String = Criteria(eFieldName.BK_REKOD_STATUS.ToString, "1")

            'Paging
            Dim StartRowIndex As Integer = PageSize * PageIndex
            Dim RowCount As Integer = PageSize
            Dim Other As String = OrderByLimit(eFieldName.BP_NAMA.ToString, True, RowCount, StartRowIndex)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)
        End Function

#End Region

#Region "Search"

        ''' <summary>
        ''' Count Staff by 3 'OR' criterias.
        ''' 5 Columns (BP_NAMA, BK_JAB_SEKARANG_DESC, BK_JAW_SEKARANG_DESC, BP_NO_PEKERJA, BK_REKOD_STATUS)
        ''' </summary>
        ''' <param name="SearchCriteria">PatronId OR Passport OR Name</param>
        ''' <param name="CriteriaIndex">Search By one of the criterias: (1 = BP_NO_PEKERJA; 2 = BP_NO_KP; 3 = BP_NAMA; Other = All three simultanously but very slow)</param>
        Public Shared Function SearchUsersCount(SearchCriteria As String, CriteriaIndex As Integer, DBLibraryConnectionString As String) As Integer

            Dim MyCriteria As String = Nothing

            Select Case CriteriaIndex
                Case 1
                    MyCriteria = Criteria(eFieldName.BP_NO_PEKERJA.ToString, SearchCriteria)
                Case 2
                    MyCriteria = Criteria(eFieldName.BP_NO_KP.ToString, SearchCriteria)
                Case 3
                    MyCriteria = CriteriaLike(eFieldName.BP_NAMA.ToString, "%" & SearchCriteria & "%")
                Case Else
                    MyCriteria = CriteriasOR( _
                        Criteria(eFieldName.BP_NO_PEKERJA.ToString, SearchCriteria), _
                        Criteria(eFieldName.BP_NO_KP.ToString, SearchCriteria), _
                        CriteriaLike(eFieldName.BP_NAMA.ToString, "%" & SearchCriteria & "%") _
                    )
            End Select

            Return MyCmd.CmdCount(TableName, MyCriteria, DBLibraryConnectionString)
        End Function


        ''' <summary>
        ''' Search Staff by 3 OR criterias.
        ''' 5 Columns (BP_NAMA, BK_JAB_SEKARANG_DESC, BK_JAW_SEKARANG_DESC, BP_NO_PEKERJA, BK_REKOD_STATUS)
        ''' </summary>
        ''' <param name="SearchCriteria">PatronId OR Passport OR Name</param>
        ''' <param name="CriteriaIndex">Search By one of the criterias: (1 = BP_NO_PEKERJA; 2 = BP_NO_KP; 3 = BP_NAMA; Other = All three simultanously but very slow)</param>
        Public Shared Function SearchUsers(SearchCriteria As String, CriteriaIndex As Integer, MaxResult As Integer, DBLibraryConnectionString As String) As DataTable
            Dim MyFieldName As String = FieldNames( _
                eFieldName.BP_NAMA.ToString, _
                eFieldName.BK_JAB_SEKARANG_DESC.ToString, _
                eFieldName.BK_JAW_SEKARANG_DESC.ToString, _
                eFieldName.BP_NO_PEKERJA.ToString, _
                eFieldName.BK_REKOD_STATUS.ToString
                )

            Dim MyCriteria As String = Nothing

            Select Case CriteriaIndex
                Case 1
                    MyCriteria = Criteria(eFieldName.BP_NO_PEKERJA.ToString, SearchCriteria)
                Case 2
                    MyCriteria = Criteria(eFieldName.BP_NO_KP.ToString, SearchCriteria)
                Case 3
                    MyCriteria = CriteriaLike(eFieldName.BP_NAMA.ToString, "%" & SearchCriteria & "%")
                Case Else
                    MyCriteria = CriteriasOR( _
                        Criteria(eFieldName.BP_NO_PEKERJA.ToString, SearchCriteria), _
                        Criteria(eFieldName.BP_NO_KP.ToString, SearchCriteria), _
                        CriteriaLike(eFieldName.BP_NAMA.ToString, "%" & SearchCriteria & "%") _
                    )
            End Select


            Dim Other As String = Limit(MaxResult)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)
        End Function

#End Region

#Region "Single Patron Info"

        ''' <summary>
        ''' Get a single row in database for a single patron.
        ''' ''' 12 Columns (BP_NO_PEKERJA, BP_NAMA, BP_NO_KP, BK_TELEFON, BP_EMAIL, BK_JAW_JENIS, BK_JAB_SEKARANG, BK_JAB_SEKARANG_DESC, BK_JAW_SEKARANG, BK_JAW_SEKARANG_DESC, BK_REKOD_STATUS, BK_REKOD_STATUS_DESC)
        ''' </summary>
        ''' <param name="PatronId"></param>
        ''' <param name="DBLibraryConnectionString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetSinglePatronInfo(PatronId As String, DBLibraryConnectionString As String) As DataTable

            Dim MyFieldName As String = FieldNames( _
                eFieldName.BP_NO_PEKERJA.ToString, _
                eFieldName.BP_NAMA.ToString, _
                eFieldName.BP_NO_KP.ToString, _
                eFieldName.BK_TELEFON.ToString, _
                eFieldName.BP_EMAIL.ToString, _
                eFieldName.BK_JAW_JENIS.ToString, _
                eFieldName.BK_JAB_SEKARANG.ToString, _
                eFieldName.BK_JAB_SEKARANG_DESC.ToString, _
                eFieldName.BK_JAW_SEKARANG.ToString, _
                eFieldName.BK_JAW_SEKARANG_DESC.ToString, _
                eFieldName.BK_REKOD_STATUS.ToString, _
                eFieldName.BK_REKOD_STATUS_DESC.ToString _
                )

            Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

            Dim Other As String = Limit(1)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)

        End Function

        ''' <summary>
        ''' Get a single row in database for a single patron.
        ''' ''' 3 Columns (BP_NO_PEKERJA, BK_TELEFON, BP_EMAIL)
        ''' </summary>
        ''' <param name="PatronId"></param>
        ''' <param name="DBLibraryConnectionString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetSinglePatronInfoContact(PatronId As String, DBLibraryConnectionString As String) As DataTable

            Dim MyFieldName As String = FieldNames( _
                eFieldName.BP_NO_PEKERJA.ToString, _
                eFieldName.BK_TELEFON.ToString, _
                eFieldName.BP_EMAIL.ToString _
                )

            Dim MyCriteria As String = Criteria(eFieldName.BP_NO_PEKERJA.ToString, PatronId)

            Dim Other As String = Limit(1)

            Return MyCmd.CmdSelectTable(TableName, MyFieldName, MyCriteria, Other, DBLibraryConnectionString)

        End Function

#End Region

#End Region

    End Class

End Namespace


