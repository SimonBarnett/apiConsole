Public Class baseForm : Inherits Form

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _id = System.Guid.NewGuid.ToString
    End Sub
#Region "Public Properties"

    Private _id As String
    Public ReadOnly Property ID As String
        Get
            Return _id
        End Get
    End Property

    Private _formType As eFormType
    Public Property FormType As eFormType
        Get
            Return _formType
        End Get
        Set(value As enums.eFormType)
            _formType = value
        End Set
    End Property

    Private _epType As epType
    Public Property epType As epType
        Get
            Return _epType
        End Get
        Set(value As epType)
            _epType = value
        End Set
    End Property

    Private _Server As String = Nothing
    Public Property server As String
        Get
            Return _Server
        End Get
        Set(value As String)
            _Server = value
        End Set
    End Property

    Private _Environment As String
    Public Property Environment As String
        Get
            Return _Environment
        End Get
        Set(value As String)
            _Environment = value
        End Set
    End Property

    Private _Endpoint As String
    Public Property EndPoint As String
        Get
            Return _Endpoint
        End Get
        Set(value As String)
            _Endpoint = value
        End Set
    End Property

    Public ReadOnly Property url As String
        Get
            Return String.Format(
                "{0}/api/{1}/{2}",
                server,
                Environment,
                EndPoint
            )
        End Get
    End Property

#End Region

    Public Overridable ReadOnly Property Activity As Boolean

End Class