Namespace Functions.Dates

    Public Class Correction

#Region "MY to"

        ''' <summary>
        ''' Correct Malaysian date 'dd/MM/yyy' to US date 'dd MMMM yyy'
        ''' </summary>
        ''' <param name="TheDate">format 'dd/MM/yyy' only</param>
        Public Shared Function MyToUs(TheDate As String) As String
            Dim MyDate() As String = TheDate.Split("/")

            Dim CorrectedDate As String = String.Format("{0} {1} {2}", MyDate(0), MonthName(MyDate(1)), MyDate(2))
            Return CorrectedDate
        End Function

#End Region

#Region "RSS format to"

        ''' <summary>
        ''' Correct RSS date format to MySQL 24 hours format.
        ''' eg "1/22/2014 02:18:14 PM" to "2014-01-22 14:18:14"
        ''' </summary>
        ''' <param name="TheDate">format 'M/d/yyy hh:mm:ss ampm' only</param>
        ''' <remarks>For XML RSS Views that required date as string</remarks>
        Public Shared Function RssToMySql(TheDate As String) As Date
            Dim ReturnValue As String = Nothing

            
            If IsDate(TheDate) Then

                ReturnValue = TheDate

            Else

                Dim MyFullDate() As String = TheDate.Split(" ")

                Dim MyDate() As String = MyFullDate(0).Split("/")
                Dim MyYear As Integer = MyDate(2)
                Dim MyMonth As Integer = MyDate(0)
                Dim MyDay As Integer = MyDate(1)

                Dim MyTime12() As String = MyFullDate(1).Split(":")
                Dim MyAmPm As String = MyFullDate(2)

                Dim MyTimeH As Integer = MyTime12(0)
                Dim MyTimeM As Integer = MyTime12(1)
                Dim MyTimeS As Integer = MyTime12(2)

                If MyAmPm = "PM" Then
                    Select Case MyTimeH
                        Case 1 To 11
                            MyTimeH = MyTimeH + 12
                        Case 12
                            MyTimeH = 12
                        Case Else
                            MyTimeH = 0
                    End Select

                ElseIf MyAmPm = "AM" Then
                    Select Case MyTimeH
                        Case 12
                            MyTimeH = 0
                    End Select

                End If

                Dim MyCorrectedDate As String = String.Format("{0}-{1}-{2}", MyYear, MyMonth, MyDay)
                Dim MyCorrectedTime As String = String.Format("{0}:{1}:{2}", MyTimeH, MyTimeM, MyTimeS)
                Dim MyCorrectedDateTime As Date = String.Format("{0} {1}", MyCorrectedDate, MyCorrectedTime)

                ReturnValue = MyCorrectedDate

                If Not IsDate(ReturnValue) Then TheDate = Date.ParseExact(ReturnValue, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)

            End If

            
            Return ReturnValue
        End Function

        ''' <summary>
        ''' Correct US date 24 hours to US 12 hours format.
        ''' eg "1/22/2014 14:18:14" to "2014-01-22 02:18:14 PM"
        ''' </summary>
        ''' <param name="TheDate">format 'M/d/yyy hh:mm:ss ampm' only</param>
        ''' <remarks>For XML RSS Views that required date as string</remarks>
        Public Shared Function Us24ToUs12(TheDate As Date) As String
            Return Microsoft.VisualBasic.Strings.Format(TheDate, "M/d/yyy hh:mm:ss tt")
        End Function

#End Region

    End Class

End Namespace


