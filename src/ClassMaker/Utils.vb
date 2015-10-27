Public Class Utils
    private meCurrentFile as string
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
    Public sub OpenInVS(ByVal thisLang As classhelper.language, ByRef thisClassTxt As RichTextBox, ByVal thisClassName As String) 
       if SaveThisClassAs(thisClassTxt,thisClassName, thislang.value__) then
  Try
            Process.Start("devenv", meCurrentFile)
        Catch ex As Exception
            Console.WriteLine("OpenInVS error: " & ex.Message & " " & ex.StackTrace)
        End Try
       End If
  
    End sub
    
    ''' <summary>
    ''' Saves the specified textbox.
    ''' </summary>
    ''' <param name="thisClassTxtBx">The class TXTbx.</param>
    public function  SaveThisClassAs(byref thisClassTxtBx as Richtextbox, byval thisClassName as string, byval optional index as integer = 5) as boolean
         dim savefileD as new savefiledialog()
            with savefileD
                .Filter = "Visual Basic files (*.vb)|*.vb|" & 
                          "CSharp files (*.cs)|*.cs|" & 
                          "Python files (*.py)|*.py|" & 
                          "Java files (*.java)|*.java|" &
                          "Txt files (*.txt)|*.txt|" & 
                          "All files (*.*)|*.*"
                .FilterIndex = index
            .filename = thisClassName
                .RestoreDirectory = True
            end with
        If savefileD.ShowDialog() = DialogResult.OK Then
            meCurrentFile = savefileD.filename
            SaveThisClass(thisClassTxtBx )
            return true
            else
            return false
        End If        
   End function

    ''' <summary>
    ''' Saves the specified textbox.
    ''' </summary>
    ''' <param name="thisClassTxtBx">The class TXTbx.</param>
    ''' <param name="path">The path.</param>
    public sub  SaveThisClass(byref thisClassTxtBx as Richtextbox, byval optional thisClassName as string = nothing)
       if mecurrentfile is nothing then
          SaveThisClassAs(thisClassTxtBx,  thisClassName )
       else
            thisClassTxtBx.SaveFile(meCurrentFile,richtextboxstreamtype.PlainText)
       End If
   End sub

    ''' <summary>
    ''' Clear the TXTbox.
    ''' </summary>
    ''' <param name="parent">The parent.</param>
    Public sub  ClearTxtBox( ByVal parent As Control) 
      try
        If parent IsNot Nothing Then
            For Each child As Control In parent.Controls
                If child.GetType Is gettype(textbox) Then
                   dim txtB as textbox = child
                    txtb.clear
                End If
            Next
        End If
        
      Catch ex As Exception
            msgbox(ex.message)
      End Try      
    End sub

    ''' <summary>
    ''' News the class.
    ''' </summary>
    ''' <param name="thisForm">The this form.</param>
    public sub NewClass(byref thisForm as form)
        meCurrentFile = Nothing
        ClearTxtBox(thisform.controls(0))
    End sub

    ''' <summary>
    ''' Gets the ext.
    ''' </summary>
    ''' <param name="thisLang">The this lang.</param>
    ''' <returns></returns>
    public function  GetExt(byval thisLang as string) as string
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
        return  ext

    End function
End Class
