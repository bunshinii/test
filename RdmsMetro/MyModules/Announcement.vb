Imports System.Web
Imports NasLib.Database.MySql.Sql.Simplifier

Namespace MyModules.Announcement

    Module ModGlobal

#Region "MySql Settings"
        Dim MyCmd As New NasLib.Database.MySql.Sql.Commands

        Dim TableName As String = "announcement"

        Private Enum eFieldName
            id
            broadcastTo
            announcement
            startDate
            endDate
        End Enum

        Friend Enum broadcastTo
            all
            branch
            satellite
            department
            division
            unit
            myself
        End Enum

#End Region


        Public Function GetAnnouncement(Id As Integer, myBroadcastTo As broadcastTo) As String
            Dim MyCriteria As String = CriteriasAND( _
                    Criteria(eFieldName.id.ToString, Id), _
                    Criteria(eFieldName.broadcastTo.ToString, myBroadcastTo.ToString), _
                    CriteriaBetweenDateRange(eFieldName.startDate.ToString, eFieldName.endDate.ToString, Now) _
                    )

            Dim ReturnValue As String = MyCmd.CmdSelect2(TableName, eFieldName.announcement.ToString, 0, MyCriteria, , MyAppConnectionString)
            If ReturnValue.Length > 0 Then ReturnValue = HttpUtility.HtmlDecode(ReturnValue)

            Return ReturnValue
        End Function

        Public WriteOnly Property SetSatelliteAnnouncement(SatelliteId As Integer, StartDate As Date, EndDate As Date) As String
            Set(value As String)

                Dim MyCriteria As String = Criteria(eFieldName.id.ToString, SatelliteId)

                MyCmd.CmdUpdate3(TableName, eFieldName.announcement.ToString, FieldValue(value), MyCriteria, MyAppConnectionString)
                MyCmd.CmdUpdate3(TableName, eFieldName.startDate.ToString, FieldValue(StartDate), MyCriteria, MyAppConnectionString)
                MyCmd.CmdUpdate3(TableName, eFieldName.startDate.ToString, FieldValue(EndDate), MyCriteria, MyAppConnectionString)
            End Set
        End Property

    End Module






End Namespace
