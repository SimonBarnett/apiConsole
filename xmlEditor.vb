Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Xml
Imports Newtonsoft.Json

Public Class xmlEditor : Inherits RichTextBox

    Private Enum eLangauge
        xml
        json
    End Enum

    Private Const SB_HORZ As Integer = &H0
    Private Const SB_VERT As Integer = &H1
    Private Const WM_HSCROLL As Integer = &H114
    Private Const WM_VSCROLL As Integer = &H115
    Private Const SB_THUMBPOSITION As Integer = 4

    Private Const WM_USER As Integer = &H400
    Private Const EM_SETEVENTMASK As Integer = (WM_USER + 69)
    Private Const WM_SETREDRAW As Integer = &HB
    Private OldEventMask As IntPtr

    Private _internalRTB As New RichTextBox
    Private xmlDoc As New XmlDocument

    Public Event Execute(sender As Object, e As System.EventArgs)

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetScrollPos(hWnd As Integer, nBar As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function SetScrollPos(hWnd As IntPtr, nBar As Integer, nPos As Integer, bRedraw As Boolean) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function PostMessageA(hWnd As IntPtr, nBar As Integer, wParam As Integer, lParam As Integer) As Boolean
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    Public Sub BeginUpdate()
        SendMessage(Me.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero)
        OldEventMask = SendMessage(Me.Handle, EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero)
    End Sub

    Public Sub EndUpdate()
        SendMessage(Me.Handle, WM_SETREDRAW, 1, IntPtr.Zero)
        SendMessage(Me.Handle, EM_SETEVENTMASK, IntPtr.Zero, OldEventMask)
    End Sub

    Friend Property HScrollPos() As Integer
        Private Get
            Return GetScrollPos(CInt(Me.Handle), SB_HORZ)
        End Get
        Set
            SetScrollPos(Me.Handle, SB_HORZ, Value, True)
            PostMessageA(Me.Handle, WM_HSCROLL, SB_THUMBPOSITION + &H10000 * Value, 0)
        End Set
    End Property

    Friend Property VScrollPos() As Integer
        Private Get
            Return GetScrollPos(CInt(Me.Handle), SB_VERT)
        End Get
        Set
            SetScrollPos(Me.Handle, SB_VERT, Value, True)
            PostMessageA(Me.Handle, WM_VSCROLL, SB_THUMBPOSITION + &H10000 * Value, 0)
        End Set
    End Property

    Private _indentSp As Integer = 3
    Public Property IndentSp As Integer
        Get
            Return _indentSp
        End Get
        Set(value As Integer)
            _indentSp = value
        End Set
    End Property

    Private ReadOnly Property Langage As eLangauge
        Get
            Select Case Trim(Me.Text).Substring(0, 1)
                Case "{"
                    Return eLangauge.json

                Case Else
                    Return eLangauge.xml

            End Select

        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        With Me
            .Font = New Font("Consolas", 10)
            .WordWrap = False
            .AcceptsTab = True
        End With

    End Sub

    Public Sub Indent()

        With Me
            Dim p As Integer = .SelectionStart
            Dim l As Integer = .SelectionLength

            Try
                Select Case Langage
                    Case eLangauge.json
                        Using stringReader As New StringReader(Me.Text)
                            Using stringWriter As New StringWriter
                                Dim jsonreader As New JsonTextReader(stringReader)
                                Dim jsonwriter As New JsonTextWriter(stringWriter)
                                With jsonwriter
                                    .Formatting = Newtonsoft.Json.Formatting.Indented
                                    .WriteToken(jsonreader)

                                End With
                                Dim myEncoder As New System.Text.ASCIIEncoding
                                Dim ms As MemoryStream = New MemoryStream(myEncoder.GetBytes(stringWriter.ToString))
                                _internalRTB.LoadFile(ms, RichTextBoxStreamType.PlainText)
                                .Rtf = _internalRTB.Rtf

                            End Using
                        End Using

                    Case Else
                        xmlDoc.LoadXml(Me.Text)
                        Using ms As New System.IO.MemoryStream
                            Using xtw As New Xml.XmlTextWriter(ms, System.Text.Encoding.ASCII)
                                xtw.Indentation = _indentSp
                                xtw.Formatting = Xml.Formatting.Indented
                                xmlDoc.WriteContentTo(xtw)
                                xtw.Flush()

                                ms.Seek(0, System.IO.SeekOrigin.Begin)
                                _internalRTB.LoadFile(ms, RichTextBoxStreamType.PlainText)
                                .Rtf = _internalRTB.Rtf

                            End Using
                        End Using

                End Select

            Catch ex As Exception

            Finally
                .SelectionStart = p
                .SelectionLength = l
                Format()

            End Try

        End With

    End Sub

    Public Sub Format(Optional FromInternal As Boolean = False)

        With Me
            Dim p As Integer = .SelectionStart
            Dim l As Integer = .SelectionLength
            Dim VS As Integer = .VScrollPos
            Dim HS As Integer = .HScrollPos

            Try
                If Not FromInternal Then _internalRTB.Text = .Text

                If Not Langage = eLangauge.json Then HighlightRTF()
                BeginUpdate()
                .Rtf = _internalRTB.Rtf

            Catch ex As Exception

            Finally
                .SelectionStart = p
                .SelectionLength = l
                .VScrollPos = VS
                .HScrollPos = HS

                EndUpdate()

            End Try

        End With

    End Sub

    Private Function OpenTag() As Char
        Select Case Langage
            Case eLangauge.json
                Return Microsoft.VisualBasic.ChrW(123)
            Case Else
                Return Microsoft.VisualBasic.ChrW(60)
        End Select
    End Function

    Private Function CloseTag() As Char
        Select Case Langage
            Case eLangauge.json
                Return Microsoft.VisualBasic.ChrW(125)
            Case Else
                Return Microsoft.VisualBasic.ChrW(62)
        End Select
    End Function

    Private Function EqualTag() As Char
        Select Case Langage
            Case eLangauge.json
                Return Microsoft.VisualBasic.ChrW(58)
            Case Else
                Return Microsoft.VisualBasic.ChrW(61)
        End Select
    End Function

    Private Sub HighlightRTF()

        Dim k As Integer = 0
        Dim str As String = _internalRTB.Text & vbLf
        Dim en As Integer
        Dim st As Integer
        Dim lasten As Integer = -1


        While (k < str.Length)
            st = str.IndexOf(OpenTag, k)
            If (st < 0) Then
                Exit While
            End If

            If (lasten > 0) Then
                _internalRTB.Select((lasten + 1), (st - (lasten - 1)))
                _internalRTB.SelectionColor = HighlightColors.HC_INNERTEXT
            End If

            en = str.IndexOf(CloseTag, (st + 1))
            If (en < 0) Then
                Exit While
            End If

            k = (en + 1)
            lasten = en

            Dim nodeText As String = str.Substring((st + 1), (en _
                            - (st - 1)))
            Dim inString As Boolean = False
            Dim lastSt As Integer = -1
            Dim state As Integer = 0
            Dim startAtt As Integer = 0
            Dim startNodeName As Integer = 0
            Dim i As Integer = 0

            Do While (i < nodeText.Length)
                If quote(nodeText(i)) Then
                    inString = Not inString
                End If

                If (inString _
                            AndAlso quote(nodeText(i))) Then
                    lastSt = i
                ElseIf quote(nodeText(i)) Then
                    _internalRTB.Select((lastSt _
                                    + (st + 2)), (i _
                                    - (lastSt - 1)))
                    _internalRTB.SelectionColor = HighlightColors.HC_STRING
                End If

                Select Case (state)
                    Case 0
                        If Not Char.IsWhiteSpace(nodeText, i) Then
                            startNodeName = i
                            state = 1
                        End If

                    Case 1
                        If Char.IsWhiteSpace(nodeText, i) Then
                            _internalRTB.Select((startNodeName + st), ((i - startNodeName) _
                                            + 1))
                            _internalRTB.SelectionColor = HighlightColors.HC_NODE
                            state = 2
                        End If

                    Case 2
                        If Not Char.IsWhiteSpace(nodeText, i) Then
                            startAtt = i
                            state = 3
                        End If

                    Case 3
                        If (Char.IsWhiteSpace(nodeText, i) _
                                    OrElse (nodeText(i) = EqualTag())) Then
                            _internalRTB.Select((startAtt + st), ((i - startAtt) _
                                            + 1))
                            _internalRTB.SelectionColor = HighlightColors.HC_ATTRIBUTE
                            state = 4
                        End If

                    Case 4
                        If (quote(nodeText(i)) _
                                    AndAlso Not inString) Then
                            state = 2
                        End If

                End Select

                i = (i + 1)
            Loop

            If (state = 1) Then
                _internalRTB.Select((st + 1), nodeText.Length)
                _internalRTB.SelectionColor = HighlightColors.HC_NODE
            End If

        End While

    End Sub

    Function quote(str As String) As Boolean
        Select Case str
            Case Microsoft.VisualBasic.ChrW(34)
                Return True
            Case Microsoft.VisualBasic.ChrW(39)
                Return True
            Case Else
                Return False
        End Select
    End Function

    Private Sub xmlEditor_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        Format()

    End Sub

    Private Sub xmlEditor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        With Me
            Select Case e.KeyData
                Case Keys.F5
                    RaiseEvent Execute(Me, New EventArgs)
                    e.Handled = True
                    e.SuppressKeyPress = True

                Case Keys.Enter
                    e.Handled = True
                    e.SuppressKeyPress = True
                    doEnter()

                Case Else
                    ' ALT x
                    If (e.KeyCode And Not Keys.Modifiers) = Keys.X AndAlso e.Modifiers = Keys.Alt Then
                        RaiseEvent Execute(Me, New EventArgs)
                        e.Handled = True
                        e.SuppressKeyPress = True

                    End If

                    ' Shift Tab
                    If (e.KeyCode And Not Keys.Modifiers) = Keys.Tab AndAlso e.Modifiers = Keys.Shift Then
                        e.Handled = True
                        e.SuppressKeyPress = True
                        doTab(True)

                    End If
                    ' Tab
                    If (e.KeyCode And Not Keys.Modifiers) = Keys.Tab And Not e.Modifiers = Keys.Shift Then
                        e.Handled = True
                        e.SuppressKeyPress = True
                        doTab(False)

                    End If
            End Select

        End With

    End Sub

    Sub doEnter()

        SelectionLength = 0

        Dim selChange As Integer = 0
        Dim str As New StringBuilder

        str.Append(Text.Substring(0, SelectionStart))
        str.Append(vbLf)

        Try
            Dim lastLine As String = Text.Substring(0, SelectionStart).Substring(Text.Substring(0, SelectionStart).LastIndexOf(vbLf) + 1)
            While String.Compare(lastLine.Substring(0, 1), " ") = 0
                str.Append(" ")
                lastLine = lastLine.Substring(1)
                selChange += 1
            End While
        Catch ex As Exception

        End Try

        str.Append(Text.Substring(SelectionStart))
        _internalRTB.Text = str.ToString
        SelectionStart += 1 + selChange
        Format(True)

    End Sub

    Sub doTab(shift As Boolean)

        BeginUpdate()

        Do
            If SelectionStart = 0 Then Exit Do
            If String.Compare(Text.Substring(SelectionStart - 1, 1), vbLf) = 0 Then Exit Do
            SelectionStart -= 1
            SelectionLength += 1
        Loop

        Do
            If String.Compare(Text.Substring(SelectionStart + SelectionLength, 1), vbLf) = 0 Then Exit Do
            SelectionLength += 1
        Loop

        EndUpdate()

        Dim selChange As Integer = 0
        Dim str As New StringBuilder
        str.Append(Text.Substring(0, SelectionStart))
        For Each line As String In SelectedText.Split(vbLf)
            If shift Then
                For s As Integer = 1 To IndentSp
                    If line.Length > 0 Then
                        If line.Substring(0, 1) = " " Then
                            line = line.Substring(1)
                            selChange -= 1
                        End If
                    End If
                Next
                str.AppendFormat(
                    "{0}{1}",
                    line,
                    vbLf
                )
            Else
                str.AppendFormat(
                    "{0}{1}{2}",
                    Space(IndentSp),
                    line,
                    vbLf
                )
                selChange += IndentSp
            End If

        Next
        str.Append(Text.Substring(SelectionStart + SelectionLength + 1))
        _internalRTB.Text = str.ToString

        SelectionLength += selChange
        Me.HScrollPos = 0

        Format(True)

    End Sub

End Class
