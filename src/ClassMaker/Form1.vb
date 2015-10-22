Imports System.Reflection

Public Class Form1
    Public Enum Language
        VBNet = 0
        CSharp = 1
        Python = 2
        Php = 3
    End Enum


    Public Function WriteImports(ByVal lang As Language) As String
        Dim import As String = Nothing
        Select Case lang
            Case Language.VBNet
                import = "Imports System.Collections.Generic" & vbCrLf & _
                       "Imports System.Drawing" & vbCrLf & _
                       "Imports System.IO" & vbCrLf & vbCrLf

            Case Language.CSharp
                import = "using System.Collections.Generic;" & vbCrLf & _
                       "using System.Drawing;" & vbCrLf & _
                       "using System.IO;" & vbCrLf & vbCrLf

            Case Language.Python
                import = "import struct" & vbCrLf & _
                    "import getopt" & vbCrLf & _
                    "import sys" & vbCrLf & _
                    "import os" & vbCrLf & vbCrLf

            Case Language.Php
                import = Nothing

        End Select
        Return import
    End Function

    Public Function WriteHeader(ByVal thislang As Language, ByVal isNamespace As Boolean) As String
        Dim header As String = Nothing

        Select Case thislang
            Case Language.VBNet
                If isNamespace Then
                    header = "Namespace " & TextBox6.Text & vbCrLf
                End If
                header &= vbTab & "Public Class " & TextBox5.Text & vbCrLf
                If CheckBox1.Checked = True Then
                    header &= vbTab & vbTab & vbTab & "Inherits " & TextBox4.Text & vbCrLf & vbCrLf
                End If

            Case Language.CSharp
                If isNamespace Then
                    header = "Namespace " & TextBox6.Text & "{" & vbCrLf
                End If
                header &= vbTab & "public Class " & TextBox5.Text
                If CheckBox1.Checked = True Then
                    header &= " : " & TextBox4.Text
                End If
                header &= " {" & vbCrLf & vbCrLf


            Case Language.Python
                header = "class " & TextBox5.Text
                If CheckBox1.Checked = True Then
                    header &= "(" & TextBox4.Text & ")" & vbCrLf
                Else
                    header &= "(object):" & vbCrLf
                End If


            Case Language.Php
                header = Nothing

        End Select
        Return header
    End Function

    Public Function WriteFields(ByVal thisLang As Language, ByVal thisFields() As String) As String
        Dim fields As String = Nothing


        For i As Integer = 0 To UBound(thisFields)
            Dim thisType As String = "String"
            Dim strField() As String = Split(thisFields(i), "#")
            Dim varName As String = thisFields(i)

            If Not strField Is Nothing Then
                thisType = strField(1)
                varName = strField(0)
            End If
            Select Case thisLang
                Case Language.VBNet
                    fields &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

                Case Language.CSharp
                    fields &= vbTab & vbTab & "Private " & thisType & " me" & varName & ";" & vbCrLf

                Case Language.Python
                    'todo   fields &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

                Case Language.Php
                    fields = Nothing

            End Select
        Next

        Return fields & vbCrLf
    End Function

    Public Function WriteProperties(ByVal thisLang As Language, ByVal thisFields() As String) As String
        Dim Properties As String = Nothing


        For i As Integer = 0 To UBound(thisFields)
            Dim thisType As String = "String"
            Dim strField() As String = Split(thisFields(i), "#")
            Dim varName As String = thisFields(i)

            If Not strField Is Nothing Then
                thisType = strField(1)
                varName = strField(0)
            End If
            Select Case thisLang
                Case Language.VBNet
                    Properties &= vbTab & vbTab & "Public Property " & varName & "() as " & thisType & vbCrLf & _
                            vbTab & vbTab & vbTab & "Get" & vbCrLf & _
                            vbTab & vbTab & vbTab & vbTab & "Return me" & varName & vbCrLf & _
                            vbTab & vbTab & vbTab & "End Get" & vbCrLf & _
                            vbTab & vbTab & vbTab & "Set(value as " & thisType & ")" & vbCrLf & _
                            vbTab & vbTab & vbTab & vbTab & "me" & varName & " = value" & vbCrLf & _
                            vbTab & vbTab & vbTab & "End Set" & vbCrLf & _
                            vbTab & vbTab & "End Property" & vbCrLf & vbCrLf

                Case Language.CSharp
                    thisType = Replace(thisType, "Boolean", "bool")
                    thisType = Replace(thisType, "Single", "float")
                    thisType = Replace(thisType, "Object", "var")
                    Properties &= vbTab & vbTab & "public " & thisType & " " & varName & " {" & vbCrLf & _
                        vbTab & vbTab & vbTab & "get { return this.me" & varName & "; }" & vbCrLf & _
                        vbTab & vbTab & vbTab & "set { this.me" & varName & " = value; }" & vbCrLf & _
                        vbTab & vbTab & "}" & vbCrLf & vbCrLf

                Case Language.Python
                    'todo   fields &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

                Case Language.Php
                    Properties = Nothing

            End Select
        Next

        Return Properties
    End Function

    Public Function WriteFooter(ByVal thisLang As Language, ByVal isNamespace As Boolean) As String
        Dim footer As String = Nothing

        Select Case thisLang
            Case Language.VBNet
                If isNamespace Then
                    footer &= vbTab & vbTab & "End Class" & vbCrLf
                    footer &= vbTab & "End Namespace" & vbCrLf
                Else
                    footer &= vbTab & "End Class" & vbCrLf
                End If

            Case Language.CSharp
                If isNamespace Then
                    footer &= vbTab & vbTab & "}" & vbCrLf
                End If
                footer &= vbTab & "}" & vbCrLf

            Case Language.Python
                'todo   footer &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

            Case Language.Php
                footer = Nothing

        End Select


        Return footer
    End Function

    Public Function WriteCreators(ByVal thisLang As Language, ByVal isNamespace As Boolean, ByVal thisFields() As String) As String
        Dim Creators As String = Nothing

        Dim header As String = Nothing
        Dim content As String = Nothing
        Dim footer As String = Nothing



        For i As Integer = 0 To UBound(thisFields)
            Select Case thisLang
                Case Language.VBNet
                    If isNamespace Then
                    End If
                    header &= vbTab & vbTab & "Public Sub New("

                Case Language.CSharp
                    If isNamespace Then
                    End If
                    header &= vbTab & vbTab & "public " & TextBox5.Text & "("

                Case Language.Python
                    header = vbTab & "def __init__(self,"

                Case Language.Php


            End Select
            Dim strType() As String = Split(thisFields(i), ";")
            'todo
            For j As Integer = 0 To UBound(strType)
                Dim strType2() As String = Split(strType(j), "#")
                Dim varName As String = strType2(0)
                Dim varType As String = strType2(1)
                If j > 0 And j <= UBound(strType) Then
                    header &= ", "
                End If
                Select Case thisLang
                    Case Language.VBNet
                        If isNamespace Then
                        End If
                        header &= "Byval this" & varName & " as " & varType
                        content &= vbTab & vbTab & vbTab & "me" & varName & " = this" & varName & vbCrLf
                        If j >= UBound(strType) Then
                            header &= ")" & vbCrLf
                           
                        End If

                    Case Language.CSharp
                        If isNamespace Then
                        End If

                        header &= varType & " this" & varName
                        content &= vbTab & vbTab & vbTab & "this.me" & varName & " = this" & varName & ";" & vbCrLf
                        If j >= UBound(strType) Then
                            header &= ")"
                            If CheckBox2.Checked = True Then
                                header &= ":" & TextBox4.Text & " {" & vbCrLf
                            Else
                                header &= " {" & vbCrLf
                            End If
                        End If

                    Case Language.Python
                        header &= "this" & varName ', ThisDug, thisEntrance):"
                        content &= vbTab & vbTab & "self._me" & varName & " = this" & varName & vbCrLf
                        If j >= UBound(strType) Then
                            header &= "):" & vbCrLf
                        End If

                    Case Language.Php


                End Select

            Next

            Select Case thisLang
                Case Language.VBNet
                    If isNamespace Then
                    End If
                    footer = vbTab & vbTab & "End Sub" & vbCrLf & vbCrLf

                Case Language.CSharp
                    If isNamespace Then
                    End If
                    footer = vbTab & vbTab & "}" & vbCrLf & vbCrLf

                Case Language.Python
                    'todo   footer &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

                Case Language.Php
                    footer = Nothing

            End Select
            Creators &= header & content & footer
        Next
        Return Creators
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click, Button3.Click, Button2.Click
        Dim str1() As String = Split(Replace(TextBox1.Text, vbTab, "#"), vbCrLf)
        Dim str2() As String = Split(Replace(TextBox3.Text, vbTab, "#"), vbCrLf)
        Dim lang As Language = ComboBox1.SelectedIndex
        TextBox2.Text = WriteImports(lang) & WriteHeader(lang, CheckBox5.Checked) & WriteFields(lang, str1) & WriteCreators(lang, CheckBox5.Checked, str2) & _
            WriteProperties(lang, str1) & WriteFooter(lang, CheckBox5.Checked)

    End Sub

  

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0

    End Sub

    
End Class
