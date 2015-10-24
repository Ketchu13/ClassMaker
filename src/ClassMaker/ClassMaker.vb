Public Class ClassHelper

#Region "Enums"
    ''' <summary>
    ''' Programming language
    ''' </summary>
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
#End Region

#Region "Fields"
    Private meCurrentLang As Language

    Private meNamespaceSrc As String
    Private meClassNameSrc As String
    Private meInheritSrc As String
    Private meProperties As String

    Private meCurrentDesignPat As String

    Private meCurrentFields() As String
    Private meCreatorFields() As String

    Private meIsNamespaceRqd As Boolean
    Private meCheckInherit As Boolean
    Private meCheckBoxFields As Boolean
    Private meCheckBoxCreators As Boolean
#End Region
#Region "New"
    Public Sub New(
                  ByVal thisCurrentLang As Language,
                  ByVal thisCurrentFields() As String,
                  ByVal thisNamespaceSrc As String,
                  ByVal thisClassNameSrc As String,
                  ByVal thisInheritSrc As String,
                  ByVal thisCurrentDesignPat As String,
                  ByVal thisCheckInherit As Boolean,
                  ByVal thisIsNamespaceRqd As Boolean,
                  ByVal thisCheckBoxFields As Boolean,
                  ByVal thisCheckBoxCreators As Boolean,
                  ByVal thisCreatorFields() As String
                  )

        Me.Lang = thisCurrentLang
        Me.NamespaceSrc = thisNamespaceSrc
        Me.ClassNameSrc = thisClassNameSrc
        Me.InheritSrc = thisInheritSrc
        Me.CurrentFields = thisCurrentFields

        Me.meCurrentDesignPat = thisCurrentDesignPat 'todo 

        Me.CheckInherit = thisCheckInherit
        Me.IsNamespaceRqd = thisIsNamespaceRqd
        Me.CheckBoxFields = thisCheckBoxFields
        Me.CheckBoxCreators = thisCheckBoxCreators
        Me.CreatorFields = thisCreatorFields

    End Sub
#End Region

#Region "Properties"
    ''' <summary>
    ''' Gets or sets the lang.
    ''' </summary>
    ''' <value>The lang.</value>
    Public Property Lang As Language
        Get
            Return meCurrentLang
        End Get
        Set(value As Language)
            meCurrentLang = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the namespace SRC.
    ''' </summary>
    ''' <value>The namespace SRC.</value>
    Public Property NamespaceSrc As String
        Get
            Return meNamespaceSrc
        End Get
        Set(value As String)
            meNamespaceSrc = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the class name SRC.
    ''' </summary>
    ''' <value>The class name SRC.</value>
    Public Property ClassNameSrc As String
        Get
            Return meClassNameSrc
        End Get
        Set(value As String)
            meClassNameSrc = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the inherit SRC.
    ''' </summary>
    ''' <value>The inherit SRC.</value>
    Public Property InheritSrc As String
        Get
            Return meInheritSrc
        End Get
        Set(value As String)
            meInheritSrc = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the current fields.
    ''' </summary>
    ''' <value>The current fields.</value>
    Public Property CurrentFields As String()
        Get
            Return meCurrentFields
        End Get
        Set(value As String())
            meCurrentFields = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the creator fields.
    ''' </summary>
    ''' <value>The creator fields.</value>
    Public Property CreatorFields As String()
        Get
            Return meCreatorFields
        End Get
        Set(value As String())
            meCreatorFields = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the current design pat.
    ''' </summary>
    ''' <value>The current design pat.</value>
    Public Property CurrentDesignPat As String
        Get
            Return meCurrentDesignPat
        End Get
        Set(value As String)
            meCurrentDesignPat = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [check inherit].
    ''' </summary>
    ''' <value><c>true</c> if [check inherit]; otherwise, <c>false</c>.</value>
    Public Property CheckInherit As Boolean
        Get
            Return meCheckInherit
        End Get
        Set(value As Boolean)
            meCheckInherit = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [check box creators].
    ''' </summary>
    ''' <value><c>true</c> if [check box creators]; otherwise, <c>false</c>.</value>
    Public Property CheckBoxCreators As Boolean
        Get
            Return meCheckBoxCreators
        End Get
        Set(value As Boolean)
            meCheckBoxCreators = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets a value indicating whether this instance is namespace RQD.
    ''' </summary>
    ''' <value>
    ''' <c>true</c> if this instance is namespace RQD; otherwise, <c>false</c>.
    ''' </value>
    Public Property IsNamespaceRqd As Boolean
        Get
            Return meIsNamespaceRqd
        End Get
        Set(value As Boolean)
            meIsNamespaceRqd = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [check box fields].
    ''' </summary>
    ''' <value><c>true</c> if [check box fields]; otherwise, <c>false</c>.</value>
    Public Property CheckBoxFields As Boolean
        Get
            Return meCheckBoxFields
        End Get
        Set(value As Boolean)
            meCheckBoxFields = value
        End Set
    End Property

#End Region
#Region "Methods"
    ''' <summary>
    ''' Writes the imports block.
    ''' </summary>
    ''' <returns></returns>
    Public Function WriteImports() As String
        Dim importStr As String = Nothing

        Select Case Lang

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

            Case Language.Java
                'todo

            Case Language.Php
                'todo   
        End Select

        Return importStr
    End Function

    ''' <summary>
    ''' Writes the header block.
    ''' </summary>
    ''' <returns></returns>
    Public Function WriteHeader() As String
        Dim header As String = Nothing

        Select Case Lang
            Case Language.VBNet
                If IsNamespaceRqd Then
                    header = "Namespace " & meNamespaceSrc & vbCrLf
                End If
                header &= vbTab & "Public Class " & meClassNameSrc & vbCrLf
                If CheckInherit = True Then
                    header &= vbTab & vbTab & "Inherits " & meInheritSrc & vbCrLf & vbCrLf
                End If

            Case Language.CSharp
                If IsNamespaceRqd Then
                    header = "Namespace " & meNamespaceSrc & " {" & vbCrLf
                End If
                header &= vbTab & "public Class " & meClassNameSrc
                If CheckInherit = True Then
                    header &= " : " & meInheritSrc
                End If
                header &= " {" & vbCrLf & vbCrLf

            Case Language.Python
                header = "class " & meClassNameSrc
                If CheckInherit = True Then
                    header &= "(" & meInheritSrc & ")" & vbCrLf
                Else
                    header &= "(object):" & vbCrLf
                End If
            Case Language.Java
                If IsNamespaceRqd Then
                    header = "package " & meNamespaceSrc & ";" & vbCrLf
                End If
                header &= "public Class " & meClassNameSrc
                If CheckInherit = True Then
                    header &= " extends " & meInheritSrc
                End If
                header &= " {" & vbCrLf & vbCrLf

            Case Language.Php
                'todo

        End Select

        Return header
    End Function 'header

    ''' <summary>
    ''' Writes the fields block.
    ''' </summary>
    ''' <returns></returns>
    Public Function WriteFields() As String
        Dim fields As String = Nothing

        For i As Integer = 0 To UBound(meCurrentFields)
            Dim thisType As String = "String"
            Dim strField() As String = Split(meCurrentFields(i), "#")
            Dim varName As String = meCurrentFields(i)

            If Not strField Is Nothing Then
                thisType = strField(1)
                varName = strField(0)
            End If

            Select Case Lang

                Case Language.VBNet
                    fields &= vbTab & vbTab & "Private me" & varName & " as " & thisType & vbCrLf

                Case Language.CSharp
                    thisType = thisType.ToLower
                    fields &= vbTab & vbTab & "private " & thisType & " me" & varName & ";" & vbCrLf

                Case Language.Python
                    'todo  
                Case Language.Java
                    fields &= vbTab & vbTab & "private " & thisType & " me" & varName & ";" & vbCrLf

                Case Language.Php
                    fields = Nothing

            End Select
        Next

        Return fields & vbCrLf
    End Function 'fields

    ''' <summary>
    ''' Writes the properties block.
    ''' </summary>
    ''' <returns>The properties block string</returns>
    Public Function WriteProperties() As String
        Dim properties As String = Nothing

        For i As Integer = 0 To UBound(meCurrentFields)
            Dim thisType As String = "String"
            Dim strField() As String = Split(meCurrentFields(i), "#")
            Dim varName As String = meCurrentFields(i)

            If Not strField Is Nothing Then
                thisType = strField(1)
                varName = strField(0)
            End If

            Select Case Lang
                'Todo replace vtab by 4 spaces
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
                    properties &= vbTab & vbTab & "public " & thisType & " " & varName & " {" & vbCrLf &
                        vbTab & vbTab & vbTab & "get { return this.me" & varName & "; }" & vbCrLf &
                        vbTab & vbTab & vbTab & "set { this.me" & varName & " = value; }" & vbCrLf &
                        vbTab & vbTab & "}" & vbCrLf & vbCrLf

                Case Language.Python
                    'todo  

                Case Language.Java
                    'todo  factorize
                    thisType = Replace(thisType, "Boolean", "boolean")
                    thisType = Replace(thisType, "Integer", "int")
                    thisType = Replace(thisType, "single", "float")
                    thisType = Replace(thisType, "Object", "Object")
                    properties &= vbTab & vbTab & "public final " & thisType & " get" & varName & "() {" & vbCrLf &
                        vbTab & vbTab & vbTab & " return me" & varName & ";" & vbCrLf & vbTab & vbTab & " }" & vbCrLf &
                        vbTab & vbTab & "public final " & thisType & " set" & varName & "(" & thisType & " value) {" & vbCrLf &
                        vbTab & vbTab & vbTab & " me" & varName & " = value;" & vbCrLf &
                        vbTab & vbTab & " }" & vbCrLf & vbCrLf


                Case Language.Php
                    properties = Nothing

            End Select
        Next

        Return properties
    End Function

    ''' <summary>
    ''' Writes the footer block.
    ''' </summary>
    ''' <returns>The footer block string</returns>
    Public Function WriteFooter() As String
        Dim footer As String = Nothing

        Select Case Lang
            Case Language.VBNet
                If IsNamespaceRqd Then
                    footer &= vbTab & "End Class" & vbCrLf
                    footer &= "End Namespace" & vbCrLf
                Else
                    footer &= "End Class" & vbCrLf
                End If

            Case Language.CSharp
                If IsNamespaceRqd Then
                    footer &= vbTab & "}" & vbCrLf
                End If
                footer &= "}" & vbCrLf

            Case Language.Python
                'todo  

            Case Language.Java
                footer &= "}" & vbCrLf

            Case Language.Php
                footer = Nothing

        End Select


        Return footer
    End Function

    ''' <summary>
    ''' Writes the creators block.
    ''' </summary>
    ''' <returns>The creator block string</returns>
    Public Function WriteCreators() As String
        Dim creators As String = Nothing
        Dim header As String = Nothing
        Dim content As String = Nothing
        Dim footer As String = Nothing

        For i As Integer = 0 To UBound(meCreatorFields)

            Select Case Lang

                Case Language.VBNet
                    If IsNamespaceRqd Then
                    End If
                    header &= vbTab & vbTab & "Public Sub New("

                Case Language.CSharp
                    If IsNamespaceRqd Then
                    End If
                    header &= vbTab & vbTab & "Public " & meClassNameSrc & "("

                Case Language.Python
                    header = vbTab & "def __init__(self,"

                Case Language.Java
                    header &= vbTab & vbTab & "Public " & meClassNameSrc & "("

                Case Language.Php
                    'todo   
            End Select

            Dim strType() As String = Split(meCreatorFields(i), ";")
            'todo
            For j As Integer = 0 To UBound(strType)
                Dim strType2() As String = Split(strType(j), "#")
                Dim varName As String = strType2(0)
                Dim varType As String = strType2(1)

                If j > 0 And j <= UBound(strType) Then
                    header &= ", "
                End If

                Select Case Lang

                    Case Language.VBNet
                        If IsNamespaceRqd Then
                            'todo   
                        End If
                        header &= "ByVal this" & varName & " As " & varType
                        content &= vbTab & vbTab & vbTab & "Me" & varName & " = this" & varName & vbCrLf
                        If j >= UBound(strType) Then
                            header &= ")" & vbCrLf
                        End If

                    Case Language.CSharp
                        If IsNamespaceRqd Then
                            'todo   
                        End If
                        header &= varType & " this" & varName
                        content &= vbTab & vbTab & vbTab & "this.Me" & varName & " = this" & varName & ";" & vbCrLf
                        If j >= UBound(strType) Then
                            header &= ")"
                            If CheckBoxCreators = True Then
                                header &= ":" & meInheritSrc & " {" & vbCrLf
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

                    Case Language.Java
                        header &= varType & " this" & varName
                        content &= vbTab & vbTab & vbTab & "me" & varName & " = this" & varName & ";" & vbCrLf
                        If j >= UBound(strType) Then
                            header &= ") {" & vbCrLf
                        End If

                    Case Language.Php
                        'todo   

                End Select
            Next

            Select Case Lang
                Case Language.VBNet
                    If IsNamespaceRqd Then
                    End If
                    footer = vbTab & vbTab & "End Sub" & vbCrLf & vbCrLf

                Case Language.CSharp
                    If IsNamespaceRqd Then
                    End If
                    footer = vbTab & vbTab & "}" & vbCrLf & vbCrLf

                Case Language.Python
                    'todo   

                Case Language.Java
                    footer = vbTab & vbTab & "}" & vbCrLf & vbCrLf

                Case Language.Php
                    'todo   

            End Select

            creators &= header & content & footer
        Next

        Return creators
    End Function

    ''' <summary>
    ''' Writes the class.
    ''' </summary>
    ''' <returns></returns>
    Public Function WriteClass()

        Dim str As String = WriteImports() & WriteHeader()
        If CheckBoxFields = True Then
            str &= WriteFields()
        End If
        If CheckBoxCreators = True Then
            str &= WriteCreators()
        End If
        If CheckBoxFields = True Then
            str &= WriteProperties()
        End If
        str &= WriteFooter()

        Return str
    End Function

    ''' <summary>
    ''' Translates the type to the specified runtime.
    ''' </summary>
    ''' <param name="thisType">Type to rename</param>
    ''' <returns>the the converted type</returns>
    Public Function TranslateTypeRef(ByVal thisType As String) As String

        Dim properties As String = Nothing
        'todo use lowercase first letter for primitives and uppercase for class
        Select Case Lang
            Case Language.VBNet
                Select Case thisType.ToLower
                    Case "bool", "boolean"
                        Return "Boolean"
                    Case "byte"
                        Return "Byte"
                    Case "char"
                        Return "Char"
                    Case "decimal"
                        Return "Decimal"
                    Case "double"
                        Return "Double"
                    Case "dynamic"
                        Return "Object"
                    Case "integer"
                        Return "Integer"
                    Case "long"
                        Return "Long"
                    Case "object"
                        Return "Object"
                    Case "sbyte"
                        Return "Sbyte"
                    Case "single", "float"
                        Return "Single"
                    Case "str", "string"
                        Return "String"
                    Case "uinteger"
                        Return "UInteger"
                    Case "ulong"
                        Return "ULong"
                    Case "ushort"
                        Return "UShort"
                    Case "var"
                        Return "Object"
                End Select

            Case Language.CSharp
                Select Case thisType.ToLower
                    Case "boolean"
                        Return "bool"
                    Case "integer"
                        Return "int"
                    Case "object"
                        Return "dynamic"
                    Case "single"
                        Return "float"
                    Case "str", "string"
                        Return "string"
                    Case "uinteger"
                        Return "uint"


                End Select

            Case Language.Java
                'todo 

            Case Language.Php
                'todo

        End Select
        Return Nothing
    End Function 'convert type

#End Region

End Class
