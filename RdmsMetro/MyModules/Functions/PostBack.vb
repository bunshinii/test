﻿Namespace MyModules.Functions.PostBack

    Module PostBack

        '''<summary>
        ''' Gets the ID of the post back control.
        ''' See: http://geekswithblogs.net/mahesh/archive/2006/06/27/83264.aspx
        ''' </summary>
        ''' <param name = "page">The page.</param>
        ''' <returns></returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function GetPostBackControlId(page As Page) As String
            If Not page.IsPostBack Then
                Return String.Empty
            End If

            Dim control As Control = Nothing
            ' first we will check the "__EVENTTARGET" because if post back made by the controls
            ' which used "_doPostBack" function also available in Request.Form collection.
            Dim controlName As String = page.Request.Params("__EVENTTARGET")
            If Not [String].IsNullOrEmpty(controlName) Then
                control = page.FindControl(controlName)
            Else
                ' if __EVENTTARGET is null, the control is a button type and we need to
                ' iterate over the form collection to find it

                ' ReSharper disable TooWideLocalVariableScope
                Dim controlId As String
                Dim foundControl As Control
                ' ReSharper restore TooWideLocalVariableScope

                For Each ctl As String In page.Request.Form
                    ' handle ImageButton they having an additional "quasi-property" 
                    ' in their Id which identifies mouse x and y coordinates
                    If ctl.EndsWith(".x") OrElse ctl.EndsWith(".y") Then
                        controlId = ctl.Substring(0, ctl.Length - 2)
                        foundControl = page.FindControl(controlId)
                    Else
                        foundControl = page.FindControl(ctl)
                    End If

                    If Not (TypeOf foundControl Is Button OrElse TypeOf foundControl Is ImageButton) Then
                        Continue For
                    End If

                    control = foundControl
                    Exit For
                Next
            End If

            Return If(control Is Nothing, [String].Empty, control.ID)
        End Function

        ''' <summary>
        ''' Gets the ID of the post back control.
        ''' See: http://geekswithblogs.net/mahesh/archive/2006/06/27/83264.aspx
        ''' </summary>
        ''' <param name = "page">The page.</param>
        ''' <returns></returns>
        <System.Runtime.CompilerServices.Extension> _
        Public Function GetPostBackControlUniqueId(page As Page) As String
            If Not page.IsPostBack Then
                Return String.Empty
            End If

            Dim control As Control = Nothing
            ' first we will check the "__EVENTTARGET" because if post back made by the controls
            ' which used "_doPostBack" function also available in Request.Form collection.
            Dim controlName As String = page.Request.Params("__EVENTTARGET")
            If Not [String].IsNullOrEmpty(controlName) Then
                control = page.FindControl(controlName)
            Else
                ' if __EVENTTARGET is null, the control is a button type and we need to
                ' iterate over the form collection to find it

                ' ReSharper disable TooWideLocalVariableScope
                Dim controlId As String
                Dim foundControl As Control
                ' ReSharper restore TooWideLocalVariableScope

                For Each ctl As String In page.Request.Form
                    ' handle ImageButton they having an additional "quasi-property" 
                    ' in their Id which identifies mouse x and y coordinates
                    If ctl.EndsWith(".x") OrElse ctl.EndsWith(".y") Then
                        controlId = ctl.Substring(0, ctl.Length - 2)
                        foundControl = page.FindControl(controlId)
                    Else
                        foundControl = page.FindControl(ctl)
                    End If

                    If Not (TypeOf foundControl Is Button OrElse TypeOf foundControl Is ImageButton) Then
                        Continue For
                    End If

                    control = foundControl
                    Exit For
                Next
            End If

            Return If(control Is Nothing, [String].Empty, control.UniqueID)
        End Function

    End Module


End Namespace

