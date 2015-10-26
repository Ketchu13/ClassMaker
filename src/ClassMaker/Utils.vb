Public Class Utils

    ''' <summary>
    ''' Sets the clipboard data.
    ''' </summary>
    ''' <param name="value">The value to write</param>
    Public Sub SetToClipboard(ByVal value As Object)
        Clipboard.SetDataObject(value)
    End Sub

    ''' <summary>
    ''' Gets the clipboard data.
    ''' </summary>
    ''' <returns>Clipboard data</returns>
    Public Function GetToClipboard()
        Return Clipboard.GetDataObject()
    End Function

    ''' <summary>
    ''' Updates the class properties.
    ''' </summary>
    ''' <param name="objectRef">The object to update</param>
    ''' <param name="procName">Name of the proc to update</param>
    ''' <param name="args">The new value</param>
    Public Sub UpdClassProcs(ByRef objectRef As Object, procName As String, ByVal args As Object)
        CallByName(objectRef, procName, CallType.Set, args)
    End Sub

    ''' <summary>
    ''' Trims the specified text box2.
    ''' </summary>
    ''' <param name="textBox2">The text box2.</param>
    ''' <param name="arg">The arg.</param>
    Public Sub Trim(ByRef textBox2 As RichTextBox, ByVal arg As String)
        Dim str As String = Nothing
        For i As Integer = 0 To textBox2.Lines.Count - 1
            str &= If(arg.Equals("Start"), textBox2.Lines(i).TrimStart & vbCrLf, textBox2.Lines(i).TrimEnd & vbCrLf)
        Next
        textBox2.Text = str
    End Sub

    ''' <summary>
    ''' Select all text in the specified richtextbox.
    ''' </summary>
    ''' <param name="textBoxX">The richtextbox</param>
    Public Sub Txt2SelAll(ByRef textBoxX As RichTextBox)
        textBoxX.Focus()
        textBoxX.SelectAll()
    End Sub

    ''' <summary>
    ''' Open the generated class in Visual Studio.
    ''' </summary>
    ''' <param name="thisLang">The lang.</param>
    ''' <param name="thisClassTxt">The class src.</param>
    ''' <param name="thisClassName">Name of the specified class to open in VS.</param>
    Public Sub OpenInVS(ByVal thisLang As String, ByRef thisClassTxt As RichTextBox, ByVal thisClassName As String)

        Dim path As String = Application.StartupPath & "\temp\" & thisLang & "\" & thisClassName & "."
        Dim ext As String = ".txt"

        Select Case thisLang
            Case "vbnet",
                 "csharp",
                 "python"
                ext = Mid(thisLang, 1, 2)

            Case "java",
                 "php"
                ext = thisLang

            Case ClassHelper.Language.Cpp
                ext = "h"

            Case ClassHelper.Language.Arduino_Java
                'todo

            Case ClassHelper.Language.Arduino_C
                'ino, h

        End Select
        path &= ext

        Try
            thisClassTxt.SaveFile(path)
            Process.Start("devenv", path)
        Catch ex As Exception
            Console.WriteLine("OpenInVS error: " & ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
End Class
