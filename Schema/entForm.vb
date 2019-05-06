Imports System.Xml

Public Class entForm

    Private FormNav As New entNav
    Private this As XmlNode

    Sub New(ByRef node As XmlNode)

        this = node
        With node
            For Each sf As XmlNode In .SelectNodes("NavigationProperty")
                FormNav.Add(sf)

            Next
        End With

    End Sub

    Public Shadows Function tostring()

        Using t As New entTemplate(My.Resources.txtForm)
            With this
                t.ReplaceDirective("FORM", .Attributes("Name").Value)
                t.ReplaceDirective("NAV", FormNav.tostring)

            End With

            Return t.toString

        End Using

    End Function


End Class

Public Class entNav : Inherits List(Of XmlNode)

    Public Shadows Function tostring()

        Dim ret As New Text.StringBuilder
        For Each o As XmlNode In Me
            With o
                ret.AppendFormat(
                    ", {0}{1}{0}",
                    Chr(34),
                    .Attributes("Name").Value
                )

            End With

        Next

        Return ret.ToString

    End Function

End Class