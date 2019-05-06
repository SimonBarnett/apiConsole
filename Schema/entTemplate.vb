Public Class entTemplate : Implements IDisposable

    Private _template As String

    Sub New(Template As String)
        _template = Replace(Template, "#DATE#", Now.ToString("dd/MM/yyyy"))

    End Sub

    Private Sub DirName(ByRef Directive As String)
        Directive = Directive.ToUpper
        If Not String.Compare(Strings.Left(Directive, 1), "#") = 0 Then
            Directive = String.Format("#{0}", Directive)
        End If
        If Not String.Compare(Strings.Right(Directive, 1), "#") = 0 Then
            Directive = String.Format("{0}#", Directive)
        End If
    End Sub

    Public Sub ReplaceDirective(Directive As String, Value As String)
        DirName(Directive)
        _template = Replace(_template, Directive, Value,,, CompareMethod.Text)

    End Sub

    Public Sub DeleteDirective(Directive As String)
        DirName(Directive)
        _template = Replace(_template, vbCrLf & Directive, "",,, CompareMethod.Text)
    End Sub

    Shadows Function toString() As String
        Return _template

    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
