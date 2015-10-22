Imports System.Reflection

Namespace ClassMakerVBNet
    Public Class FormMain

        Public Enum Language
            VBNet = 0
            CSharp = 1
            Python = 2
            Php = 3
            Cpp = 4
            Java = 5
            Arduino_C = 6
            Arduino_Java = 7
        End Enum

        Public Function WriteImports(ByVal lang As Language) As String
            Dim importStr As String = Nothing

            Select Case lang

                Case Language.VBNet
                    importStr = "Imports System.Collections.Generic" & vbCrLf &
                           "Imports System.Drawing" & vbCrLf &
                           "Imports System.IO" & vbCrLf & vbCrLf

                Case Language.CSharp
                    importStr = "using System.Collections.Generic;" & vbCrLf &
                           "using System.Drawing;" & vbCrLf &
                           "using System.IO;" & vbCrLf & vbCrLf

                Case Language.Python
                    importStr = "import struct" & vbCrLf &
                        "import getopt" & vbCrLf &
                        "import sys" & vbCrLf &
                        "import os" & vbCrLf & vbCrLf

                Case Language.Php
                    'todo   

            End Select

            Return importStr
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
                    'todo

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
                        'todo  

                    Case Language.Php
                        fields = Nothing

                End Select
            Next

            Return fields & vbCrLf
        End Function
        Public Function WriteProperties(ByVal thisLang As Language, ByVal thisFields() As String) As String
            Dim properties As String = Nothing

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
                        properties &= vbTab & vbTab & "Public Property " & varName & "() as " & thisType & vbCrLf &
                                vbTab & vbTab & vbTab & "Get" & vbCrLf &
                                vbTab & vbTab & vbTab & vbTab & "Return me" & varName & vbCrLf &
                                vbTab & vbTab & vbTab & "End Get" & vbCrLf &
                                vbTab & vbTab & vbTab & "Set(value as " & thisType & ")" & vbCrLf &
                                vbTab & vbTab & vbTab & vbTab & "me" & varName & " = value" & vbCrLf &
                                vbTab & vbTab & vbTab & "End Set" & vbCrLf &
                                vbTab & vbTab & "End Property" & vbCrLf & vbCrLf

                    Case Language.CSharp
                        thisType = Replace(thisType, "Boolean", "bool")
                        thisType = Replace(thisType, "Single", "float")
                        thisType = Replace(thisType, "Object", "var")
                        properties &= vbTab & vbTab & "public " & thisType & " " & varName & " {" & vbCrLf &
                            vbTab & vbTab & vbTab & "get { return this.me" & varName & "; }" & vbCrLf &
                            vbTab & vbTab & vbTab & "set { this.me" & varName & " = value; }" & vbCrLf &
                            vbTab & vbTab & "}" & vbCrLf & vbCrLf

                    Case Language.Python
                        'todo  

                    Case Language.Php
                        properties = Nothing

                End Select
            Next

            Return properties
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
                    'todo  

                Case Language.Php
                    footer = Nothing

            End Select


            Return footer
        End Function
        Public Function WriteCreators(ByVal thisLang As Language, ByVal isNamespace As Boolean, ByVal thisFields() As String) As String
            Dim creators As String = Nothing
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
                        'todo   
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
                                'todo   
                            End If
                            header &= "Byval this" & varName & " as " & varType
                            content &= vbTab & vbTab & vbTab & "me" & varName & " = this" & varName & vbCrLf
                            If j >= UBound(strType) Then
                                header &= ")" & vbCrLf
                            End If

                        Case Language.CSharp
                            If isNamespace Then
                                'todo   
                            End If
                            header &= varType & " this" & varName
                            content &= vbTab & vbTab & vbTab & "this.me" & varName & " = this" & varName & ";" & vbCrLf
                            If j >= UBound(strType) Then
                                header &= ")"
                                If CheckBoxCreators.Checked = True Then
                                    header &= ":" & TextBox4.Text & " {" & vbCrLf
                                Else
                                    header &= " {" & vbCrLf
                                End If
                            End If

                        Case Language.Python
                            header &= "this" & varName
                            content &= vbTab & vbTab & "self._me" & varName & " = this" & varName & vbCrLf
                            If j >= UBound(strType) Then
                                header &= "):" & vbCrLf
                            End If

                        Case Language.Php
                            'todo   

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
                        'todo   

                    Case Language.Php
                        'todo   

                End Select

                creators &= header & content & footer
            Next

            Return creators
        End Function
        Private Sub WriteClass()
            Dim str1() As String = Split(Replace(TextBox1.Text, vbTab, "#"), vbCrLf)
            Dim str2() As String = Split(Replace(TextBox3.Text, vbTab, "#"), vbCrLf)
            Dim lang As Language = ComboBox1.SelectedIndex
            Dim str As String = WriteImports(lang) & WriteHeader(lang, CheckBox5.Checked)
            If CheckBoxFields.Checked = True Then
                str &= WriteFields(lang, str1)
            End If
            If CheckBoxCreators.Checked = True Then
                str &= WriteCreators(lang, CheckBox5.Checked, str2)
            End If
            If CheckBoxFields.Checked = True Then
                str &= WriteProperties(lang, str1)
            End If
            str = WriteFooter(lang, CheckBox5.Checked)
            TextBox2.Text = str
        End Sub
        Private Sub SetToClipboard(ByVal value As Object)
            Clipboard.SetDataObject(value)
        End Sub

        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
            WriteClass()
        End Sub

        Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            ComboBox1.SelectedIndex = 0
        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
            TextBox2.Focus()
            TextBox2.SelectAll()
        End Sub
        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
            SetToClipboard(TextBox2.Text)
        End Sub

#Region "Intellisense"
#Region "Intellisense Fields"
        Private findNodeResult As TreeNode = Nothing
        Private typed As String = ""
        Private wordMatched As Boolean = False
        Private assembly As Assembly
        Private namespaces As Hashtable
        Private nameSpaceNode As TreeNode
        Private foundNode As Boolean = False
        Private listBoxAutoComplete As ListBox
        Private currentPath As String
#End Region
        'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '    SetToClipboard(TextBox2.Text)
        '    'ReadAssembly("C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll")
        'End Sub

        'Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        '    'For Each nde As TreeNode In TreeView1.Nodes
        '    '    Console.WriteLine(nde.ToString)
        '    '    For Each nde1 As TreeNode In nde.Nodes
        '    '        Console.WriteLine(vbTab & nde1.ToString)
        '    '        For Each nde2 As TreeNode In nde1.Nodes
        '    '            Console.WriteLine(vbTab & vbTab & nde2.ToString)
        '    '            For Each nde3 As TreeNode In nde2.Nodes
        '    '                Console.WriteLine(vbTab & vbTab & vbTab & nde3.ToString)
        '    '            Next
        '    '        Next
        '    '    Next
        '    'Next

        'End Sub
        Private Sub AddMembers(treeNode As TreeNode, type As System.Type)
            ' Get all members except methods
            Dim memberInfo As MemberInfo() = type.GetMembers()
            For j As Integer = 0 To memberInfo.Length - 1
                If memberInfo(j).ReflectedType.IsPublic AndAlso memberInfo(j).MemberType <> MemberTypes.Method Then
                    Dim node As TreeNode = treeNode.Nodes.Add(memberInfo(j).Name)
                    node.Tag = memberInfo(j).MemberType
                End If
            Next

            ' Get all methods
            Dim methodInfo As MethodInfo() = type.GetMethods()
            For j As Integer = 0 To methodInfo.Length - 1
                Dim node As TreeNode = treeNode.Nodes.Add(methodInfo(j).Name)
                Dim parms As String = ""

                Dim parameterInfo As ParameterInfo() = methodInfo(j).GetParameters()
                For f As Integer = 0 To parameterInfo.Length - 1
                    parms += parameterInfo(f).ParameterType.ToString() & " " & parameterInfo(f).Name & ", "
                Next

                ' Knock off remaining ", "
                If parms.Length > 2 Then
                    parms = parms.Substring(0, parms.Length - 2)
                End If

                node.Tag = parms
            Next
        End Sub
        Private Sub SearchTree(treeNodes As TreeNodeCollection, path As String, continueUntilFind As Boolean)
            If Me.foundNode Then
                Return
            End If

            Dim p As String = ""
            Dim n As Integer = path.IndexOf(".")

            If n <> -1 Then
                p = path.Substring(0, n)
                If currentPath <> "" Then
                    currentPath += "." & p
                Else
                    currentPath = p
                End If

                ' Knock off the first part
                path = path.Remove(0, n + 1)
            Else
                currentPath += "." & path
            End If

            For i As Integer = 0 To treeNodes.Count - 1
                If treeNodes(i).FullPath = currentPath Then
                    If continueUntilFind Then
                        nameSpaceNode = treeNodes(i)
                    End If

                    nameSpaceNode = treeNodes(i)
                    Me.SearchTree(treeNodes(i).Nodes, path, continueUntilFind)

                ElseIf Not continueUntilFind Then
                    foundNode = True
                    Return
                End If
            Next
        End Sub
        Private Sub ReadAssembly(filename As String)

            Me.TreeView1.Nodes.Clear()
            namespaces = New Hashtable()
            assembly = Assembly.LoadFrom(filename)

            Dim assemblyTypes As Type() = assembly.GetTypes()
            Me.TreeView1.Nodes.Clear()

            ' Cycle through types
            For Each type As Type In assemblyTypes
                If type.[Namespace] IsNot Nothing Then
                    If namespaces.ContainsKey(type.[Namespace]) Then
                        ' Already got namespace, add the class to it
                        Dim treeNode As TreeNode = DirectCast(namespaces(type.[Namespace]), TreeNode)
                        treeNode = treeNode.Nodes.Add(type.Name)
                        Me.AddMembers(treeNode, type)

                        If type.IsClass Then
                            treeNode.Tag = MemberTypes.[Custom]
                        End If
                    Else
                        ' New namespace
                        Dim membersNode As TreeNode = Nothing

                        If type.[Namespace].IndexOf(".") <> -1 Then
                            ' Search for already existing parts of the namespace
                            nameSpaceNode = Nothing
                            foundNode = False

                            Me.currentPath = ""
                            SearchTree(Me.TreeView1.Nodes, type.[Namespace], False)

                            ' No existing namespace found
                            If nameSpaceNode Is Nothing Then
                                ' Add the namespace
                                Dim parts As String() = type.[Namespace].Split("."c)

                                Dim treeNode As TreeNode = TreeView1.Nodes.Add(parts(0))
                                Dim sNamespace As String = parts(0)

                                If Not namespaces.ContainsKey(sNamespace) Then
                                    namespaces.Add(sNamespace, treeNode)
                                End If

                                For i As Integer = 1 To parts.Length - 1
                                    treeNode = treeNode.Nodes.Add(parts(i))
                                    sNamespace += "." & parts(i)
                                    If Not namespaces.ContainsKey(sNamespace) Then
                                        namespaces.Add(sNamespace, treeNode)
                                    End If
                                Next

                                membersNode = treeNode.Nodes.Add(type.Name)
                            Else
                                ' Existing namespace, add this namespace to it,
                                ' and add the class
                                Dim parts As String() = type.[Namespace].Split("."c)
                                Dim newNamespaceNode As TreeNode = Nothing

                                If Not namespaces.ContainsKey(type.[Namespace]) Then
                                    newNamespaceNode = nameSpaceNode.Nodes.Add(parts(parts.Length - 1))
                                    namespaces.Add(type.[Namespace], newNamespaceNode)
                                Else
                                    newNamespaceNode = DirectCast(namespaces(type.[Namespace]), TreeNode)
                                End If

                                If newNamespaceNode IsNot Nothing Then
                                    membersNode = newNamespaceNode.Nodes.Add(type.Name)
                                    If type.IsClass Then
                                        membersNode.Tag = MemberTypes.[Custom]
                                    End If
                                End If

                            End If
                        Else
                            ' Single root namespace, add to root
                            membersNode = TreeView1.Nodes.Add(type.[Namespace])
                        End If

                        ' Add all members
                        If membersNode IsNot Nothing Then
                            Me.AddMembers(membersNode, type)
                        End If
                    End If

                End If
            Next
        End Sub

        Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
            'todo simple shell execute
        End Sub
#End Region

    End Class




End Namespace