Namespace Functions.Web

    Public Class Postback

        ''' <summary>
        ''' Return ControlID that cause the postback.
        ''' Only work with Control with "AutoPostback = True" properties. Cannot work with Buttons.
        ''' Recommended to put in IF statement "IsPostback = True" 
        ''' </summary>
        Public Shared Function PostBackSourceElementID() As String
            'INFO: DO NOT USE THIS FUNCTION WITH ToolkitScriptManager. USE AsyncPostBackSourceElementID() INSTEAD

            Dim context As System.Web.HttpContext = System.Web.HttpContext.Current

            Dim EventTarget As String = context.Request.Form("__EVENTTARGET")
            Dim ControlID As String = String.Empty

            If Not String.IsNullOrEmpty(EventTarget) Then ControlID = EventTarget

            Return ControlID
        End Function

        ''' <summary>
        ''' DUMMY. READ COMMENT!!
        ''' Return Button ID that cause the postback.
        ''' Only work with Buttons.
        ''' Recommended to put in IF statement "IsPostback = True".
        ''' </summary>
        Public Shared Sub PostBackButtonElementID()
            'INFO: DO NOT USE THIS STEP WITH ToolkitScriptManager. USE AsyncPostBackSourceElementID() INSTEAD

            '=============================================
            ' How to get a Button PostBackSourceElementID
            '=============================================


            '1. PUT THIS EXACT SCRIPT INTO THE HEAD
            '
            ' <script type = "text/javascript" >
            '    Function() SetSource(SourceID) {
            '        var hidSourceID = document.getElementById("<%=CustomHiddenField.ClientID%>");
            '        hidSourceID.value = SourceID;
            '    }
            '</script>


            '2. PUT THIS EXACT SCRIPT INSIDE THE FORM TAG.
            '
            '<asp:HiddenField ID="CustomHiddenField" runat="server" />


            '3. PUT THIS EXACT FUNCTION INSIDE THE BACK END CODE
            '
            'Private Function PostBackButtonElementID() As String
            '    Dim ControlID As String = String.Empty
            '    ControlID = Request.Form(CustomHiddenField.UniqueID)
            '    Return ControlID
            'End Function


            '4. INSERT A BUTTON WITH ANY NAME WITH ATTRIBUTES LIKE EXAMPLE BELOW. WHERE OnClientClick="SetSource(this.id)" MUST BE EXACT.
            '
            '<asp:Button ID = "BtnName" runat="server" Text="Button Text" OnClientClick="SetSource(this.id)" onclick="Code_Behide_Function_Name" />

            'DONE
        End Sub

        ''' <summary>
        ''' DUMMY. READ COMMENT!!
        ''' Return Control ID that cause the postback.
        ''' Only work with ToolScriptManager (AJAX Enabled) site only.
        ''' Recommended to put in IF statement "IsPostback = True".
        ''' </summary>
        Public Shared Sub AsyncPostBackSourceElementID()
            'Copy MyMasterPage.vb module into the project.
            'Just call its function.

            'e.g usage
            'If AsyncPostBackSourceElementID_.Length = 0 Then SaveScript()
        End Sub






    End Class

End Namespace


