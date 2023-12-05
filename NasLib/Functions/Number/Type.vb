Namespace Functions.Number

    Public Class Type

#Region "Even / Odd"

        ''' <summary>
        ''' Check if the number is Odd
        ''' </summary>
        Public Shared Function IsOdd(Number As Long) As Boolean
            Dim ReturnValue As Boolean = False

            If Number Mod 2 > 0 Then
                ReturnValue = True
            Else
                ReturnValue = False
            End If

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Check if the number is Even
        ''' </summary>
        Public Shared Function IsEven(Number As Long) As Boolean
            Return Not IsOdd(Number)
        End Function

#End Region

#Region "Prime Number"

        ''' <summary>
        ''' Check if the number is a prime number
        ''' </summary>
        Public Shared Function IsPrime(TestPrime As Long) As Boolean
            Dim TestNum As Long
            Dim TestLimit As Long

            '   Eliminate even numbers
            If TestPrime Mod 2 = 0 Then
                IsPrime = False
                Exit Function
            End If


            '   Loop through ODD numbers starting with 3
            TestNum = 3
            TestLimit = TestPrime
            Do While TestLimit > TestNum

                If TestPrime Mod TestNum = 0 Then
                    '   Uncomment this if you really want to know
                    '   MsgBox "Divisible by " & TestNum   
                    IsPrime = False
                    Exit Function
                End If

                '   There's logic to this.  Think about it.
                TestLimit = TestPrime \ TestNum

                '   Remember, we only bother to check odd numbers
                TestNum = TestNum + 2
            Loop

            '   If we made it through the loop, the number is a prime.
            IsPrime = True
        End Function

#End Region

    End Class

End Namespace


