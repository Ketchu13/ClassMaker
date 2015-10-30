Imports System.Reflection

Namespace ClassMakerVBNet
    Public Class FormMain
#region "Fields"
        Private meClassHelper As ClassHelper
        Private meUtils As Utils
        
#End Region
        
        Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            meUtils = New Utils()
            ComboBox1.SelectedIndex = 0
            meUtils.LoadVbKeywords()
              meutils.hilight(fieldstxt,"'")
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            meClassHelper = New ClassHelper(ComboBox1.SelectedIndex,
                                            Split(replace(Replace(FieldsTxt.Text, vbTab, "#"),vblf & vblf, vblf), vbLf),
                                            NamespaceSrc.Text,
                                            ClassNameTxt.Text,
                                            InheritsTxt.Text,
                                            Nothing,
                                            CheckInherit.Checked,
                                            CheckNamespc.Checked,
                                            CheckBoxFields.Checked,
                                            CheckBoxCreators.Checked,
                                        Split(Replace(F4CreatorsTxt.Text, vbTab, "#"), vbCrLf))

            ClassTxt.Text = meClassHelper.WriteClass()
     meUtils.Hilight(ClassTxt ,"'")

        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
            meUtils.Txt2SelAll(ClassTxt)
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
            meUtils.SetToClipboard(ClassTxt.Text)
        End Sub

        Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
               meUtils.OpenInVS(meClassHelper.Lang, ClassTxt, meClassHelper.ClassNameSrc)
        End Sub

        Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
            If meClassHelper IsNot Nothing Then
                meClassHelper.Lang = ComboBox1.SelectedIndex
                if ComboBox1.SelectedIndex = classhelper.language.vbnet then
                    meUtils.LoadVbKeywords()
                End If
            End If
        End Sub

        Private Sub TxtSrc_TextChanged(sender As Object, e As EventArgs) Handles NamespaceSrc.TextChanged, InheritsTxt.TextChanged, ClassNameTxt.TextChanged
            If meClassHelper IsNot Nothing Then
                meUtils.UpdClassProcs(meClassHelper, sender.name, sender.value)
            End If
        End Sub

        Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
           meutils.NewClass(me)
           
        End Sub

        Private Sub ReplaceTabBy4SpacesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceTabBy4SpacesToolStripMenuItem.Click
            ClassTxt.Text = Replace(ClassTxt.Text, vbTab, "    ")
        End Sub

        Private Sub Replace4SpacesByTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Replace4SpacesByTabToolStripMenuItem.Click
            ClassTxt.Text = Replace(ClassTxt.Text, "    ", vbTab)
        End Sub

        Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
            meUtils.Txt2SelAll(ClassTxt)
        End Sub

        Private Sub SelectNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectNoneToolStripMenuItem.Click
            ClassTxt.SelectionStart = 0
            ClassTxt.SelectionLength = 0
        End Sub

        Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
            ClassTxt.Undo()
        End Sub

        Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
            ClassTxt.Redo()
        End Sub

        Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
            ClassTxt.Copy()
        End Sub

        Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
            ClassTxt.Paste()
        End Sub

        Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
            ClassTxt.Cut()
        End Sub

        Private Sub RemoveSpaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveSpaceToolStripMenuItem.Click, RemoveSpaceAtTheEndOfLinesToolStripMenuItem.Click
            If sender.name.Equals("RemoveSpaceToolStripMenuItem") Then
                meUtils.Trim(ClassTxt, "Start")
            Else
                meUtils.Trim(ClassTxt, "End")
            End If
        End Sub
        Private Sub GeneralNamingConventionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralNamingConventionMSDNToolStripMenuItem.Click
            Process.Start("https://msdn.microsoft.com/en-us/library/ms229002(v=vs.110).aspx")
        End Sub

        Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
            End
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

        Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
            meutils.SaveThisClass(ClassTxt)
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
            meutils.SaveThisClass(ClassTxt)
        End Sub

        Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
             meutils.SaveThisClassAs(ClassTxt, ClassNameTxt.text)
        End Sub

        Private Sub CheckNamespc_CheckedChanged(sender As Object, e As EventArgs) Handles CheckNamespc.CheckedChanged,
            CheckBoxFields.CheckedChanged, 
            CheckInherit.CheckedChanged,
            CheckBox4.CheckedChanged, 
            CheckBoxCreators.CheckedChanged
            if meclasshelper IsNot nothing then
              try
                    callbyname(meclasshelper,sender.name,calltype.set, sender.checked)
              Catch ex As Exception
                    console.writeline(ex.message)
              End Try
                   
            End If
        End Sub

        Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

        End Sub

        Private Sub FieldsTxt_TextChanged(sender As Object, e As EventArgs) Handles FieldsTxt.TextChanged
            meutils.hilight(fieldstxt,"'")

        End Sub

#End Region

    End Class
End Namespace