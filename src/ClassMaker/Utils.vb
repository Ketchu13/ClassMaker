Imports System.IO

Public Class Utils
    Private meCurrentFile As String
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
    Public Sub OpenInVS(ByVal thisLang As ClassHelper.Language, ByRef thisClassTxt As RichTextBox, ByVal thisClassName As String)
        If SaveThisClassAs(thisClassTxt, thisClassName, thisLang.value__) Then
            Try
                Process.Start("devenv", meCurrentFile)
            Catch ex As Exception
                Console.WriteLine("OpenInVS error: " & ex.Message & " " & ex.StackTrace)
            End Try
        End If

    End Sub

    ''' <summary>
    ''' Saves the specified textbox.
    ''' </summary>
    ''' <param name="thisClassTxtBx">The class TXTbx.</param>
    Public Function SaveThisClassAs(ByRef thisClassTxtBx As RichTextBox, ByVal thisClassName As String, ByVal Optional index As Integer = 5) As Boolean
        Dim savefileD As New SaveFileDialog()
        With savefileD
            .Filter = "Visual Basic files (*.vb)|*.vb|" &
                      "CSharp files (*.cs)|*.cs|" &
                      "Python files (*.py)|*.py|" &
                      "Java files (*.java)|*.java|" &
                      "Txt files (*.txt)|*.txt|" &
                      "All files (*.*)|*.*"
            .FilterIndex = index
            .FileName = thisClassName
            .RestoreDirectory = True
        End With
        If savefileD.ShowDialog() = DialogResult.OK Then
            meCurrentFile = savefileD.FileName
            SaveThisClass(thisClassTxtBx)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Saves the specified textbox.
    ''' </summary>
    ''' <param name="thisClassTxtBx">The class TXTbx.</param>
    ''' <param name="path">The path.</param>
    Public Sub SaveThisClass(ByRef thisClassTxtBx As RichTextBox, ByVal Optional thisClassName As String = Nothing)
        If meCurrentFile Is Nothing Then
            SaveThisClassAs(thisClassTxtBx, thisClassName)
        Else
            thisClassTxtBx.SaveFile(meCurrentFile, RichTextBoxStreamType.PlainText)
            thisClassTxtBx.
        End If
    End Sub

    ''' <summary>
    ''' Clear the TXTbox.
    ''' </summary>
    ''' <param name="parent">The parent.</param>
    Public Sub ClearTxtBox(ByVal parent As Control)
        Try
            If parent IsNot Nothing Then
                For Each child As Control In parent.Controls
                    If child.GetType Is GetType(TextBox) Then
                        Dim txtB As TextBox = child
                        txtB.Clear
                    End If
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' News the class.
    ''' </summary>
    ''' <param name="thisForm">The this form.</param>
    Public Sub NewClass(ByRef thisForm As Form)
        meCurrentFile = Nothing
        ClearTxtBox(thisForm.Controls(0))
    End Sub

    ''' <summary>
    ''' Gets the ext.
    ''' </summary>
    ''' <param name="thisLang">The this lang.</param>
    ''' <returns></returns>
    Public Function GetExt(ByVal thisLang As String) As String
        Dim ext As String = ".txt"

        Select Case thisLang
            Case "vbnet",
                 "csharp",
                 "python"
                ext = Mid(thisLang, 1, 2)

            Case "java",
                 "php"
                ext = thisLang

            Case "Cpp"
                ext = "h"
            'todo

            Case "arduino_c"
                ext = "h"
                'ino, h

        End Select
        Return ext

    End Function
    Public Sub Hilight(ByRef thisClassTxt As RichTextBox,  ByVal comment As String)
        Dim rchTemp As New RichTextBox()
        rchTemp.Text = thisClassTxt.Text
        rchTemp.SelectionStart = 0
        rchTemp.SelectionLength = rchTemp.text.length
        rchTemp.SelectionColor = Color.white

        Dim pos As Integer = 0
        Dim val As Integer = -1
        For Each str As String In meCurrentKeywords
            pos = 0
            val = -1
            Do
                val = rchTemp.Find(str, pos, RichTextBoxFinds.WholeWord)
                If Not (val = -1) Then
                    rchTemp.SelectionColor = Color.fromargb(&H569CD6)
                End If
                pos = val + 1
            Loop While Not (val = -1)
        Next
        pos = 0
        Do
            val = rchTemp.Find("""", pos, RichTextBoxFinds.None)
            Dim sellength As Integer = 0
            If Not (val = -1) Then
                sellength = rchTemp.Find("""", val + 1, RichTextBoxFinds.NoHighlight)
                sellength -= val
                rchTemp.SelectionStart = val
                rchTemp.SelectionLength = sellength + 1
                rchTemp.SelectionColor = Color.Red
            End If
            pos = val + sellength + 1
        Loop While Not (val = -1)
        pos = 0'Namespace
        Do
            val = rchTemp.Find("Namespace ", pos, RichTextBoxFinds.None)
            Dim sellength As Integer = 0
            If Not (val = -1) Then
                sellength = rchTemp.Find(chr(13), val + 1, RichTextBoxFinds.NoHighlight)
                sellength -= val+10
                rchTemp.SelectionStart = val+10
                rchTemp.SelectionLength = sellength + 1
                rchTemp.SelectionColor = Color.fromargb(&H4EC9B0)
            End If
            pos = val + sellength + 1
        Loop While Not (val = -1)
        pos = 0'Class
        Do
            val = rchTemp.Find("Class ", pos, RichTextBoxFinds.None)
            Dim sellength As Integer = 0
            If Not (val = -1) Then
                sellength = rchTemp.Find(chr(13), val + 1, RichTextBoxFinds.NoHighlight)
                sellength -= val+5
                rchTemp.SelectionStart = val+5
                rchTemp.SelectionLength = sellength + 1
                rchTemp.SelectionColor = Color.fromargb(&H4EC9B0)
            End If
            pos = val + sellength + 1
        Loop While Not (val = -1)
        pos = 0'byval byref
        Do
            val = rchTemp.Find("Byref ", pos, RichTextBoxFinds.None)
            Dim sellength As Integer = 0
            If Not (val = -1) Then
                sellength = rchTemp.Find("As", val + 1, RichTextBoxFinds.NoHighlight)
                sellength -= val+5
                rchTemp.SelectionStart = val+5
                rchTemp.SelectionLength = sellength 
                rchTemp.SelectionColor = Color.orange
            End If
            pos = val + sellength + 1
        Loop While Not (val = -1)
         pos = 0'byval byref
        Do
            val = rchTemp.Find("#", pos, RichTextBoxFinds.None)
            Dim sellength As Integer = 0
            If Not (val = -1) Then
                sellength = 1
                rchTemp.SelectionStart = val
                rchTemp.SelectionLength = sellength 
               rchtemp.SelectionFont = New Drawing.Font("Arial", 9, Drawing.FontStyle.Bold)
                rchTemp.SelectionColor = Color.purple
                
            End If
            pos = val + sellength + 1
        Loop While Not (val = -1)
         pos = 0'byval byref
        Do
            val = rchTemp.Find("Byval ", pos, RichTextBoxFinds.None)
            Dim sellength As Integer = 0
            
            If Not (val = -1) Then
                sellength = rchTemp.Find("As", val + 1, RichTextBoxFinds.NoHighlight)
                sellength -= val+6
                rchTemp.SelectionStart = val+6
                rchTemp.SelectionLength = sellength -1
                rchTemp.SelectionColor = Color.orange
                dim keyword as string = rchtemp.selectedText()
                dim posN as integer = val + 6 + sellength + 1
                dim valN as integer = 0
                do
                    dim selLengthtemp as integer = 0
                    valN = rchTemp.Find(keyword, posN, RichTextBoxFinds.None)
                    If Not (valN = -1) Then
                        sellength = len(keyword)
                        rchTemp.SelectionStart = ValN
                        rchTemp.SelectionLength = sellength
                        rchTemp.SelectionColor = Color.orange
                    end if
                     posN = valN + sellength + 1
                loop while Not (valN = -1)

            End If
            pos = val + sellength + 1
        Loop While Not (val = -1)
        pos = 0'byval byref
        Do
            val = rchTemp.Find("Set(", pos, RichTextBoxFinds.None)
            Dim sellength As Integer = 0
            If Not (val = -1) Then
                sellength = rchTemp.Find("As", val + 1, RichTextBoxFinds.NoHighlight)
                sellength -= val+4
                rchTemp.SelectionStart = val+4
                rchTemp.SelectionLength = sellength 
                rchTemp.SelectionColor = Color.orange
            End If
            pos = val + sellength + 1
        Loop While Not (val = -1)
        pos = 0
        Do
            val = rchTemp.Find(comment, pos, RichTextBoxFinds.None)
            If Not (val = -1) Then
                Dim sellength As Integer = rchTemp.Find(ChrW(13).ToString, val, RichTextBoxFinds.NoHighlight)
                sellength -= val
                rchTemp.SelectionStart = val
                rchTemp.SelectionLength = sellength
                rchTemp.SelectionColor = Color.Green
            End If
            pos = val + 1
        Loop While Not (val = -1)
        thisClassTxt.Rtf = rchTemp.Rtf
        thisClassTxt.SelectionStart = 0
        thisClassTxt.SelectionLength = 0
        thisClassTxt.Visible = True
    End Sub

    'Example usage below.
    private meCurrentKeyWords As  String()

    public Sub LoadVbKeywords()
   try
  dim f() as string = File.Readalllines(Application.StartupPath + "\VBkeywords.txt")
         meCurrentKeyWords = f
   Catch ex As Exception
console.writeline(ex.message)
   End Try
          
    End Sub
End Class
