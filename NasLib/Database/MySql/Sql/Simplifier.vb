Namespace Database.MySql.Sql

    Public Class Simplifier

        'Just import the namespace.

#Region "MySql Command Simplifier"

#Region "FieldName"


        ''' <summary>
        ''' Combine many FieldNames into one string. Better 'eFieldName' enum with '.ToString'. Auto comma
        ''' </summary>
        ''' <remarks>For auto comma purpose only</remarks>
        Public Shared Function FieldNames(ParamArray FieldsName()) As String
            Dim MyStr As String = Nothing

            Dim FieldCount As Integer = FieldsName.Count
            For i As Integer = 0 To FieldCount - 1
                If i = 0 Then
                    MyStr = MyStr & FieldsName(i)
                Else
                    MyStr = MyStr & "," & FieldsName(i)
                End If
            Next

            Return MyStr
        End Function

        Public Shared Function FieldNamesToArray(ParamArray FieldsName()) As String()
            Dim MyStr As String = Nothing

            Dim FieldCount As Integer = FieldsName.Count
            For i As Integer = 0 To FieldCount - 1
                If i = 0 Then
                    MyStr = MyStr & FieldsName(i)
                Else
                    MyStr = MyStr & "," & FieldsName(i)
                End If
            Next

            Return MyStr.Split(",")
        End Function

        ''' <summary>
        ''' Split commas to array
        ''' </summary>
        Public Shared Function FieldNamesToArray(FieldsNames As String) As String()
            Dim MyStr As String = Nothing

            Return MyStr.Split(",")
        End Function

        ''' <summary>
        ''' Generate SET col_name1=@param1, [ col_name2=@param2, ... ] string for UPDATE multiple values with parameters.
        ''' the SET string is not included.
        ''' </summary>
        Public Shared Function UpdsateSet(ParamArray FieldsName()) As String

            Dim MyStr As String = Nothing
            Dim FieldCount As Integer = FieldsName.Count

            For i As Integer = 0 To FieldCount - 1
                If i = 0 Then
                    MyStr = MyStr & String.Format("{0} = @Param{1}", FieldsName(i), i)
                Else
                    MyStr = MyStr & "," & String.Format("{0} = @Param{1}", FieldsName(i), i)
                End If
            Next

            Return MyStr

        End Function

#End Region

#Region "FieldValue"

        ''' <summary>
        ''' Combine many FieldValue into one string. Cannot use with FieldValue() function. Auto comma. Make sure no comma in the value.
        ''' Also auto quote. Will able to process many different data types.
        ''' </summary>
        ''' <remarks>For auto comma and auto quote purpose only</remarks>
        Public Shared Function FieldValues(ParamArray TheValue() As Object) As String

            Dim MyStr As String = Nothing

            Dim ValueCount As Integer = TheValue.Count
            For i As Integer = 0 To ValueCount - 1
                Dim ObjType As String = TheValue(i).GetType.ToString
                Dim ObjValue As String = TheValue(i).ToString

                Select Case ObjType
                    Case "System.String"
                        ObjValue = String.Format("'{0}'", FieldValue(FieldValue(CStr(TheValue(i)))))
                    Case "System.Boolean"
                        ObjValue = String.Format("'{0}'", FieldValue(FieldValue(CBool(TheValue(i)))))
                    Case "System.Int32"
                        ObjValue = String.Format("'{0}'", FieldValue(FieldValue(CInt(TheValue(i)))))
                    Case "System.Int64"
                        ObjValue = String.Format("'{0}'", FieldValue(FieldValue(CLng(TheValue(i)))))
                    Case "System.Short"
                        ObjValue = String.Format("'{0}'", FieldValue(FieldValue(CShort(TheValue(i)))))
                    Case "System.Single"
                        ObjValue = String.Format("'{0}'", FieldValue(FieldValue(CSng(TheValue(i)))))
                    Case "System.DateTime"
                        ObjValue = String.Format("'{0}'", FieldValue(FieldValue(CDate(TheValue(i)))))
                    Case "System.Guid"
                        Dim MyGuid As New Guid(TheValue(i).ToString)
                        ObjValue = String.Format("'{0}'", FieldValue(FieldValue(MyGuid)))
                    Case Else
                        ObjValue = FieldValue(CStr(TheValue(i)))
                End Select

                If i = 0 Then
                    MyStr = MyStr & ObjValue
                Else
                    MyStr = MyStr & "," & ObjValue
                End If

            Next

            Return MyStr

        End Function

        Public Shared Function FieldValuesToArray(ParamArray TheValue() As Object) As String()

            Dim ValueCount As Integer = TheValue.Count
            Dim MyStr(ValueCount - 1) As String

            For i As Integer = 0 To ValueCount - 1
                Dim ObjType As String = TheValue(i).GetType.ToString
                Dim ObjValue As String = TheValue(i).ToString

                Select Case ObjType
                    Case "System.String"
                        ObjValue = String.Format("{0}", FieldValue(FieldValue(CStr(TheValue(i)))))
                    Case "System.Boolean"
                        ObjValue = String.Format("{0}", FieldValue(FieldValue(CBool(TheValue(i)))))
                    Case "System.Int32"
                        ObjValue = String.Format("{0}", FieldValue(FieldValue(CInt(TheValue(i)))))
                    Case "System.Int64"
                        ObjValue = String.Format("{0}", FieldValue(FieldValue(CLng(TheValue(i)))))
                    Case "System.Short"
                        ObjValue = String.Format("{0}", FieldValue(FieldValue(CShort(TheValue(i)))))
                    Case "System.Single"
                        ObjValue = String.Format("{0}", FieldValue(FieldValue(CSng(TheValue(i)))))
                    Case "System.DateTime"
                        ObjValue = String.Format("{0}", FieldValue(FieldValue(CDate(TheValue(i)))))
                    Case "System.Guid"
                        Dim MyGuid As New Guid(TheValue(i).ToString)
                        ObjValue = String.Format("{0}", FieldValue(FieldValue(MyGuid)))
                    Case Else
                        ObjValue = FieldValue(CStr(TheValue(i)))
                End Select

                MyStr(i) = ObjValue

            Next

            Return MyStr

        End Function

#Region "Value Types"

        Public Shared Function FieldValue(TheValue As String) As String
            Dim MyStr As String = String.Format("{0}", TheValue)
            Return MyStr
        End Function

        Public Shared Function FieldValue(TheValue As Integer) As String
            Dim MyStr As String = String.Format("{0}", CInt(TheValue))
            Return MyStr
        End Function

        Public Shared Function FieldValue(TheValue As Guid) As String
            Dim MyStr As String = String.Format("{0}", TheValue.ToString)
            Return MyStr
        End Function

        Public Shared Function FieldValue(TheValue As Short) As String
            Dim MyStr As String = String.Format("{0}", TheValue)
            Return MyStr
        End Function

        Public Shared Function FieldValue(TheValue As Long) As String
            Dim MyStr As String = String.Format("{0}", TheValue)
            Return MyStr
        End Function

        Public Shared Function FieldValue(TheValue As Single) As String
            Dim MyStr As String = String.Format("{0}", TheValue)
            Return MyStr
        End Function

        ''' <summary>
        ''' This function will also convert the date to MySql Date Format.
        ''' </summary>
        Public Shared Function FieldValue(TheValue As Date) As String
            Dim MyStr As String = String.Format("{0}", CStr(Format(TheValue, "yyy-MM-dd HH:mm:ss")))
            Return MyStr
        End Function

        Public Shared Function FieldValue(TheValue As Boolean) As String
            Dim MyValue As Integer = 0
            If TheValue Then MyValue = 1
            Dim MyStr As String = String.Format("{0}", MyValue)
            Return MyStr
        End Function

#End Region

#End Region

#Region "Criterias"

        ''' <summary>
        ''' Put AND between many Criteria() functions. Only usable when using Criteria() in this functions
        ''' </summary>
        ''' <param name="Criteria">Criteria() function value</param>
        Public Shared Function CriteriasAND(ParamArray Criteria() As String) As String

            Dim MyStr As String = Nothing

            Dim CriteriaCount As Integer = Criteria.Count
            For i As Integer = 0 To CriteriaCount - 1
                Dim CriteriaValue As String = Criteria(i).ToString

                If i = 0 Then
                    MyStr = CriteriaValue
                Else
                    MyStr = MyStr & " AND " & CriteriaValue
                End If

            Next

            Return String.Format("({0})", MyStr)

        End Function

        ''' <summary>
        ''' Put OR between many Criteria() functions. Only usable when using Criteria() in this functions
        ''' </summary>
        ''' <param name="Criteria">Criteria() function value</param>
        Public Shared Function CriteriasOR(ParamArray Criteria() As String) As String

            Dim MyStr As String = Nothing

            Dim CriteriaCount As Integer = Criteria.Count
            For i As Integer = 0 To CriteriaCount - 1
                Dim CriteriaValue As String = Criteria(i).ToString

                If i = 0 Then
                    MyStr = CriteriaValue
                Else
                    MyStr = MyStr & " OR " & CriteriaValue
                End If

            Next

            Return String.Format("({0})", MyStr)

        End Function

#Region "Criteria Equal"

        ''' <summary>Criteria Is Null</summary>
        ''' <param name="FieldName">Field Name</param>
        Public Shared Function CriteriaNull(FieldName As String) As String
            Dim MyStr As String = String.Format("({0} IS NULL)", FieldName.ToString)
            Return MyStr
        End Function

        ''' <summary>Criteria Is Not Empty</summary>
        ''' <param name="FieldName">Field Name</param>
        Public Shared Function CriteriaEmpty(FieldName As String) As String
            Dim MyStr As String = String.Format("({0} = """")", FieldName.ToString)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        ''' <param name="IsCaseSensitif">Case Sensitive?. the Table Charset must be set to 'utf8'</param>
        Public Shared Function Criteria(FieldName As String, Value As String, Optional IsCaseSensitif As Boolean = False) As String
            Dim CaseSensitive As String = Nothing
            If IsCaseSensitif Then CaseSensitive = " COLLATE latin1_bin"

            Dim MyStr As String = String.Format("({0} = '{1}'{2})", FieldName.ToString, Value, CaseSensitive)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function Criteria(FieldName As String, Value As Integer) As String
            Dim MyStr As String = String.Format("({0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function Criteria(FieldName As String, Value As Guid) As String
            Dim MyStr As String = String.Format("({0} = '{1}')", FieldName.ToString, Value.ToString)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function Criteria(FieldName As String, Value As Short) As String
            Dim MyStr As String = String.Format("({0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function Criteria(FieldName As String, Value As Long) As String
            Dim MyStr As String = String.Format("({0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function Criteria(FieldName As String, Value As Single) As String
            Dim MyStr As String = String.Format("({0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal. Time Included</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function Criteria(FieldName As String, Value As Date) As String
            Dim MyValue As String = String.Format("{0}", CStr(Format(Value, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("({0} = '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function Criteria(FieldName As String, Value As Boolean) As String
            Dim MyValue As Integer = 0
            If Value Then MyValue = 1

            Dim MyStr As String = String.Format("({0} = '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Equal. Time NOT Included</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaDate(FieldName As String, Value As Date) As String
            Dim MyValue As String = String.Format("{0}", CStr(Format(Value, "yyy-MM-dd")))

            Dim MyStr As String = String.Format("(DATE({0}) = '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

        ''' <summary>
        ''' Get Week result within the month
        ''' Dont misunderstand with week no in a year.
        ''' </summary>
        ''' <param name="FieldName_">MySql FieldName</param>
        ''' <param name="WeekNoInMonth">Value just from 1 to 5 only</param>
        Public Shared Function CriteriaWeek(FieldName_ As String, WeekNoInMonth As Integer) As String
            Dim SelectWeek As String = ""
            Select Case WeekNoInMonth
                Case 0
                    SelectWeek = ""
                Case 1
                    SelectWeek = String.Format("DAY({0}) BETWEEN '1' AND '7'", FieldName_)
                Case 2
                    SelectWeek = String.Format("DAY({0}) BETWEEN '8' AND '14'", FieldName_)
                Case 3
                    SelectWeek = String.Format("DAY({0}) BETWEEN '15' AND '21'", FieldName_)
                Case 4
                    SelectWeek = String.Format("DAY({0}) BETWEEN '22' AND '28'", FieldName_)
                Case Else
                    SelectWeek = String.Format("DAY({0}) BETWEEN '29' AND '31'", FieldName_)
            End Select

            Return SelectWeek
        End Function

#End Region

#Region "Criteria Not Equal"

        ''' <summary>Criteria Is Not Null</summary>
        ''' <param name="FieldName">Field Name</param>
        Public Shared Function CriteriaNotNull(FieldName As String) As String
            Dim MyStr As String = String.Format("({0} IS NOT NULL)", FieldName.ToString)
            Return MyStr
        End Function

        ''' <summary>Criteria Is Not Empty</summary>
        ''' <param name="FieldName">Field Name</param>
        Public Shared Function CriteriaNotEmpty(FieldName As String) As String
            Dim MyStr As String = String.Format("({0} != """")", FieldName.ToString)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNot(FieldName As String, Value As String) As String
            Dim MyStr As String = String.Format("(NOT {0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNot(FieldName As String, Value As Integer) As String
            Dim MyStr As String = String.Format("(NOT {0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNot(FieldName As String, Value As Guid) As String
            Dim MyStr As String = String.Format("(NOT {0} = '{1}')", FieldName.ToString, Value.ToString)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNot(FieldName As String, Value As Short) As String
            Dim MyStr As String = String.Format("(NOT {0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNot(FieldName As String, Value As Long) As String
            Dim MyStr As String = String.Format("(NOT {0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNot(FieldName As String, Value As Single) As String
            Dim MyStr As String = String.Format("(NOT {0} = '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal. Time included</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNot(FieldName As String, Value As Date) As String
            Dim MyValue As String = String.Format("{0}", CStr(Format(Value, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("(NOT {0} = '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNot(FieldName As String, Value As Boolean) As String
            Dim MyValue As Integer = 0
            If Value Then MyValue = 1

            Dim MyStr As String = String.Format("(NOT {0} = '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Not Equal. time NOT included</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaNotDate(FieldName As String, Value As Date) As String
            Dim MyValue As String = String.Format("{0}", CStr(Format(Value, "yyy-MM-dd")))

            Dim MyStr As String = String.Format("(NOT DATE({0}) = '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

#End Region

#Region "Criteria Greater Than"

        ''' <summary>Criteria Greater Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaGreater(FieldName As String, Value As Integer) As String
            Dim MyStr As String = String.Format("({0} > '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Greater Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaGreater(FieldName As String, Value As Short) As String
            Dim MyStr As String = String.Format("({0} > '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Greater Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaGreater(FieldName As String, Value As Long) As String
            Dim MyStr As String = String.Format("({0} > '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Greater Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaGreater(FieldName As String, Value As Single) As String
            Dim MyStr As String = String.Format("({0} > '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Greater Than. Time Included</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaGreater(FieldName As String, Value As Date) As String
            Dim MyValue As String = String.Format("{0}", CStr(Format(Value, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("({0} >= '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Greater Than. Time Not Included</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaGreaterDate(FieldName As String, Value As Date) As String
            Dim MyValue As String = String.Format("{0}", CStr(Format(Value, "yyy-MM-dd 00:00:00")))

            Dim MyStr As String = String.Format("({0} >= '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

#End Region

#Region "Criteria Less Than"

        ''' <summary>Criteria Less Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaLess(FieldName As String, Value As Integer) As String
            Dim MyStr As String = String.Format("({0} < '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Less Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaLess(FieldName As String, Value As Guid) As String
            Dim MyStr As String = String.Format("({0} < '{1}')", FieldName.ToString, Value.ToString)
            Return MyStr
        End Function

        ''' <summary>Criteria Less Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaLess(FieldName As String, Value As Short) As String
            Dim MyStr As String = String.Format("({0} < '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Less Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaLess(FieldName As String, Value As Long) As String
            Dim MyStr As String = String.Format("({0} < '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Less Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaLess(FieldName As String, Value As Single) As String
            Dim MyStr As String = String.Format("({0} < '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Less Than</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. No need to wrap in quotes</param>
        Public Shared Function CriteriaLess(FieldName As String, Value As Date) As String
            Dim MyValue As String = String.Format("'{0}'", CStr(Format(Value, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("({0} < '{1}')", FieldName.ToString, MyValue)
            Return MyStr
        End Function

#End Region

#Region "Criteria Between"

        ''' <summary>Criteria Between Two Values</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Value</param>
        ''' <param name="LargerValue">Put Larger Value</param>
        Public Shared Function CriteriaBetween(FieldName As String, SmallerValue As Integer, LargerValue As Integer) As String
            Dim MyStr As String = String.Format("({0} BETWEEN '{1}' AND '{2}')", FieldName.ToString, SmallerValue, LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Values</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Value</param>
        ''' <param name="LargerValue">Put Larger Value</param>
        Public Shared Function CriteriaBetween(FieldName As String, SmallerValue As Short, LargerValue As Short) As String
            Dim MyStr As String = String.Format("({0} BETWEEN '{1}' AND '{2}')", FieldName.ToString, SmallerValue, LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Values</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Value</param>
        ''' <param name="LargerValue">Put Larger Value</param>
        Public Shared Function CriteriaBetween(FieldName As String, SmallerValue As Long, LargerValue As Long) As String
            Dim MyStr As String = String.Format("({0} BETWEEN '{1}' AND '{2}')", FieldName.ToString, SmallerValue, LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Values</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Value</param>
        ''' <param name="LargerValue">Put Larger Value</param>
        Public Shared Function CriteriaBetween(FieldName As String, SmallerValue As Single, LargerValue As Single) As String
            Dim MyStr As String = String.Format("({0} BETWEEN '{1}' AND '{2}')", FieldName.ToString, SmallerValue, LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Dates. Time included</summary>
        ''' <param name="FieldName">Date Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Date</param>
        ''' <param name="LargerValue">Put Larger Date</param>
        Public Shared Function CriteriaBetween(FieldName As String, SmallerValue As Date, LargerValue As Date) As String
            Dim _SmallerValue As String = String.Format("{0}", CStr(Format(SmallerValue, "yyy-MM-dd HH:mm:ss")))
            Dim _LargerValue As String = String.Format("{0}", CStr(Format(LargerValue, "yyy-MM-dd HH:mm:ss")))

            If _LargerValue < _SmallerValue Then
                Dim TempLargerValue As Date = _SmallerValue
                _LargerValue = _SmallerValue
                _SmallerValue = TempLargerValue
            End If

            Dim MyStr As String = String.Format("({0} BETWEEN '{1}' AND '{2}')", FieldName.ToString, _SmallerValue, _LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Dates. No Time included</summary>
        ''' <param name="FieldName">Date Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Date</param>
        ''' <param name="LargerValue">Put Larger Date</param>
        Public Shared Function CriteriaBetweenDates(FieldName As String, SmallerValue As Date, LargerValue As Date) As String
            Dim _SmallerValue As String = Nothing
            Dim _LargerValue As String = Nothing

            If LargerValue > SmallerValue Then
                _SmallerValue = String.Format("{0}", CStr(Format(SmallerValue, "yyy-MM-dd")))
                _LargerValue = String.Format("{0}", CStr(Format(LargerValue, "yyy-MM-dd")))
            Else
                _SmallerValue = String.Format("{0}", CStr(Format(LargerValue, "yyy-MM-dd")))
                _LargerValue = String.Format("{0}", CStr(Format(SmallerValue, "yyy-MM-dd")))
            End If

            Dim MyStr As String = String.Format("({0} BETWEEN DATE('{1}') AND DATE('{2}'))", FieldName.ToString, _SmallerValue, _LargerValue)
            Return MyStr
        End Function

#End Region

#Region "Criteria On a Date"

        ''' <summary>Criteria On a Date</summary>
        Public Shared Function CriteriaOnDate(DateFieldName As String, OnDate As Date) As String
            Dim MyStr As String = String.Format("((YEAR({0}) = '{1}') AND (MONTH({0}) = '{2}') AND (DAY({0}) = '{3}'))", DateFieldName, Year(OnDate), Month(OnDate), DateAndTime.Day(OnDate))
            Return MyStr.Replace("''''", "''")
        End Function

#End Region

#Region "Criteria Between Dates"

        ''' <summary>Criteria Between Dates from Two fields</summary>
        ''' <param name="DateFieldName1">Field Name for Start Date</param>
        ''' <param name="StartDate">Start Date</param>
        ''' ''' <param name="DateFieldName2">Field Name for End Date</param>
        ''' <param name="EndDate">End Date</param>
        Public Shared Function CriteriaBetweenDates(DateFieldName1 As String, StartDate As Date, DateFieldName2 As String, EndDate As Date) As String
            Dim _SmallerValue As String = String.Format("{0}", CStr(Format(StartDate, "yyy-MM-dd HH:mm:ss")))
            Dim _LargerValue As String = String.Format("{0}", CStr(Format(EndDate, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("(({0} <= '{1}') AND ({2} >= '{3}'))", DateFieldName1.ToString, _SmallerValue, DateFieldName2.ToString, _LargerValue)
            Return MyStr.Replace("''''", "''")
        End Function

#End Region

#Region "Criteria On Date Range"

        ''' <summary>Criteria Between Dates from Two fields with only one value</summary>
        ''' <param name="DateFieldName1">Field Name for Start Date</param>
        ''' ''' <param name="DateFieldName2">Field Name for End Date</param>
        ''' <param name="theDate">Now() or other specified date</param>
        Public Shared Function CriteriaBetweenDateRange(DateFieldName1 As String, DateFieldName2 As String, theDate As Date) As String
            Dim _DateValue As String = String.Format("{0}", CStr(Format(theDate, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("(({0} <= '{2}') AND ({1} >= '{2}'))", DateFieldName1.ToString, DateFieldName2.ToString, _DateValue)
            Return MyStr.Replace("''''", "''")
        End Function

#End Region

#Region "Criteria Not Between"

        ''' <summary>Criteria Not Between Two Values</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Value</param>
        ''' <param name="LargerValue">Put Larger Value</param>
        Public Shared Function CriteriaNotBetween(FieldName As String, SmallerValue As Integer, LargerValue As Integer) As String
            Dim MyStr As String = String.Format("({0} NOT BETWEEN '{1}' AND '{2}')", FieldName.ToString, SmallerValue, LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Values</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Value</param>
        ''' <param name="LargerValue">Put Larger Value</param>
        Public Shared Function CriteriaNotBetween(FieldName As String, SmallerValue As Short, LargerValue As Short) As String
            Dim MyStr As String = String.Format("({0} NOT BETWEEN '{1}' AND '{2}')", FieldName.ToString, SmallerValue, LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Values</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Value</param>
        ''' <param name="LargerValue">Put Larger Value</param>
        Public Shared Function CriteriaNotBetween(FieldName As String, SmallerValue As Long, LargerValue As Long) As String
            Dim MyStr As String = String.Format("({0} NOT BETWEEN '{1}' AND '{2}')", FieldName.ToString, SmallerValue, LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Values</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Value</param>
        ''' <param name="LargerValue">Put Larger Value</param>
        Public Shared Function CriteriaNotBetween(FieldName As String, SmallerValue As Single, LargerValue As Single) As String
            Dim MyStr As String = String.Format("({0} NOT BETWEEN '{1}' AND '{2}')", FieldName.ToString, SmallerValue, LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria Between Two Dates. Time Included</summary>
        ''' <param name="FieldName">Date Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Date</param>
        ''' <param name="LargerValue">Put Larger Date</param>
        Public Shared Function CriteriaNotBetween(FieldName As String, SmallerValue As Date, LargerValue As Date) As String
            Dim _SmallerValue As String = String.Format("'{0}'", CStr(Format(SmallerValue, "yyy-MM-dd HH:mm:ss")))
            Dim _LargerValue As String = String.Format("'{0}'", CStr(Format(LargerValue, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("({0} NOT BETWEEN '{1}' AND '{2}')", FieldName.ToString, _SmallerValue, _LargerValue)
            Return MyStr
        End Function

        ''' <summary>Criteria NOT Between Two Dates within the same field. No Time included</summary>
        ''' <param name="FieldName">Date Field Name</param>
        ''' <param name="SmallerValue">Put Smaller Date</param>
        ''' <param name="LargerValue">Put Larger Date</param>
        Public Shared Function CriteriaNotBetweenDates(FieldName As String, SmallerValue As Date, LargerValue As Date) As String
            Dim _SmallerValue As String = String.Format("{0}", CStr(Format(SmallerValue, "yyy-MM-dd")))
            Dim _LargerValue As String = String.Format("{0}", CStr(Format(LargerValue, "yyy-MM-dd")))

            If _LargerValue < _SmallerValue Then
                Dim TempLargerValue As Date = _SmallerValue
                _LargerValue = _SmallerValue
                _SmallerValue = TempLargerValue
            End If

            Dim MyStr As String = String.Format("({0} NOT BETWEEN DATE('{1}') AND DATE('{2}'))", FieldName.ToString, _SmallerValue, _LargerValue)
            Return MyStr
        End Function

#End Region

#Region "Criteria Not On a Date"

        ''' <summary>Criteria On a Date</summary>
        Public Shared Function CriteriaNotOnDate(DateFieldName As String, OnDate As Date) As String
            Dim MyStr As String = String.Format("(NOT((YEAR({0}) = '{1}') AND (MONTH({0}) = '{2}') AND (DAY({0}) = '{3}')))", DateFieldName, Year(OnDate), Month(OnDate), DateAndTime.Day(OnDate))
            Return MyStr.Replace("''''", "''")
        End Function

#End Region

#Region "Criteria Not Between Dates"

        ''' <summary>Criteria Not Between Dates from Two fields</summary>
        ''' <param name="DateFieldName1">Field Name for Start Date</param>
        ''' <param name="StartDate">Start Date</param>
        ''' ''' <param name="DateFieldName2">Field Name for End Date</param>
        ''' <param name="EndDate">End Date</param>
        Public Shared Function CriteriaNotBetweenDates(DateFieldName1 As String, StartDate As Date, DateFieldName2 As String, EndDate As Date) As String
            Dim _SmallerValue As String = String.Format("{0}", CStr(Format(StartDate, "yyy-MM-dd HH:mm:ss")))
            Dim _LargerValue As String = String.Format("{0}", CStr(Format(EndDate, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("(({0} >= '{1}') AND ({2} <= '{3}'))", DateFieldName1.ToString, _SmallerValue, DateFieldName2.ToString, _LargerValue)
            Return MyStr.Replace("''''", "''")
        End Function

#End Region

#Region "Criteria Not On Date Range"

        ''' <summary>Criteria Not Between Dates from Two fields with only one value</summary>
        ''' <param name="DateFieldName1">Field Name for Start Date</param>
        ''' ''' <param name="DateFieldName2">Field Name for End Date</param>
        ''' <param name="theDate">Now() or other specified date</param>
        Public Shared Function CriteriaNotBetweenDateRange(DateFieldName1 As String, DateFieldName2 As String, theDate As Date) As String
            Dim _DateValue As String = String.Format("{0}", CStr(Format(theDate, "yyy-MM-dd HH:mm:ss")))

            Dim MyStr As String = String.Format("(({0} >= '{2}') AND ({1} <= '{2}'))", DateFieldName1.ToString, DateFieldName2.ToString, _DateValue)
            Return MyStr.Replace("''''", "''")
        End Function

#End Region

#Region "CriteriaLike"

        ''' <summary>Criteria Like</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. Put '%' where needed. No need to wrap in quotes</param>
        Public Shared Function CriteriaLike(FieldName As String, Value As String) As String
            Dim MyStr As String = String.Format("({0} LIKE '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Like</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. Put '%' where needed. No need to wrap in quotes</param>
        Public Shared Function CriteriaLike(FieldName As String, Value As Guid) As String
            Dim MyStr As String = String.Format("({0} LIKE '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

#End Region

#Region "CriteriaNotLike"

        ''' <summary>Criteria Like</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. Put '%' where needed. No need to wrap in quotes</param>
        Public Shared Function CriteriaNotLike(FieldName As String, Value As String) As String
            Dim MyStr As String = String.Format("({0} NOT LIKE '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

        ''' <summary>Criteria Like</summary>
        ''' <param name="FieldName">Field Name</param>
        ''' <param name="Value">Field Value to compare. Put '%' where needed. No need to wrap in quotes</param>
        Public Shared Function CriteriaNotLike(FieldName As String, Value As Guid) As String
            Dim MyStr As String = String.Format("({0} NOT LIKE '{1}')", FieldName.ToString, Value)
            Return MyStr
        End Function

#End Region

#End Region

#Region "Group By"
        'Group By must be put before Order By. can combine function like this "GroupBy(fieldname) & OrdeyBy(fieldname)"

        Public Shared Function GroupBy(FieldName As String) As String
            Dim OrderAsc As String = ""

            Dim MyStr As String = String.Format("GROUP BY `{0}` ", FieldName)
            Return MyStr
        End Function

#End Region

#Region "OrderBy Limit"

        Public Shared Function OrderBy(FieldName As String, Optional IsAscending As Boolean = True) As String
            Dim OrderAsc As String = " ASC"
            If Not IsAscending Then OrderAsc = " DESC"

            Dim MyStr As String = String.Format("ORDER BY {0}{1}", FieldName.ToString, OrderAsc)
            Return MyStr
        End Function

        ''' <summary>
        ''' Put many sets of OrderBy
        ''' </summary>
        Public Shared Function OrdersBy(ParamArray OrderBy() As String) As String
            Dim MyStr As String = Nothing

            Dim FieldCount As Integer = OrderBy.Count
            For i As Integer = 0 To FieldCount - 1
                If i = 0 Then
                    MyStr = MyStr & OrderBy(i)
                Else
                    MyStr = MyStr & "," & OrderBy(i)
                End If
            Next

            Return MyStr.Replace(",ORDER BY ", ",")
        End Function

        Public Shared Function Limit(RowCount As Integer) As String
            Dim MyStr As String = String.Format("LIMIT {0}", RowCount)
            Return MyStr
        End Function

        Public Shared Function Limit(RowCount As Integer, StartRowIndex As Integer) As String
            Dim MyStr As String = String.Format("LIMIT {0}, {1}", StartRowIndex, RowCount)
            Return MyStr
        End Function

        Public Shared Function OrderByLimit(FieldName As String, IsAscending As Boolean, RowCount As Integer)
            Return OrderBy(FieldName, IsAscending) & " " & Limit(RowCount)
        End Function

        Public Shared Function OrderByLimit(FieldName As String, IsAscending As Boolean, RowCount As Integer, StartRowIndex As Integer)
            Return OrderBy(FieldName, IsAscending) & " " & Limit(RowCount, StartRowIndex)
        End Function

#End Region

#Region "Sql Functions"


        Public Shared Function FunctionCount(FieldName_ As String, Optional FieldAlias As String = "") As String
            Dim MyStr As String = String.Format("COUNT({0})", FieldName_)

            If FieldAlias.Length > 0 Then
                MyStr = MyStr & " AS " & FieldAlias
            End If

            Return MyStr
        End Function

        ''' <summary>
        ''' Functionalize a field with MySql HOUR()
        ''' </summary>
        ''' <param name="FieldName_">MySql FieldName</param>
        Public Shared Function FunctionHour(FieldName_ As String) As String

            Dim MyStr As String = String.Format("HOUR({0})", FieldName_)

            Return MyStr
        End Function

        ''' <summary>
        ''' Functionalize a field with MySql DATE()
        ''' </summary>
        ''' <param name="FieldName_">MySql FieldName</param>
        Public Shared Function FunctionDate(FieldName_ As String) As String

            Dim MyStr As String = String.Format("DATE({0})", FieldName_)

            Return MyStr
        End Function

        ''' <summary>
        ''' Functionalize a field with MySql Month()
        ''' </summary>
        ''' <param name="FieldName_">MySql FieldName</param>
        Public Shared Function FunctionDay(FieldName_ As String) As String

            Dim MyStr As String = String.Format("DAY({0})", FieldName_)

            Return MyStr
        End Function

        ''' <summary>
        ''' Functionalize a field with MySql Month()
        ''' </summary>
        ''' <param name="FieldName_">MySql FieldName</param>
        Public Shared Function FunctionMonth(FieldName_ As String) As String

            Dim MyStr As String = String.Format("MONTH({0})", FieldName_)

            Return MyStr
        End Function

        ''' <summary>
        ''' Functionalize a field with MySql Year()
        ''' </summary>
        ''' <param name="FieldName_">MySql FieldName</param>
        Public Shared Function FunctionYear(FieldName_ As String) As String

            Dim MyStr As String = String.Format("YEAR({0})", FieldName_)

            Return MyStr
        End Function

#End Region

#End Region

    End Class

End Namespace


