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
End Class
