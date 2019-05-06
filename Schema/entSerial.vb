Imports System.Xml

Public Class entSerial

    Private prop As New entSerialProp
    Private this As XmlNode

    Sub New(ByRef node As XmlNode)

        this = node
        With node
            For Each p As XmlNode In .SelectNodes("Property")
                prop.Add(p)
            Next

        End With


    End Sub

    Shadows Function toString() As String
        Using t As New entTemplate(My.Resources.txtSerial)
            With this
                t.ReplaceDirective("#FORM#", .Attributes("Name").Value)

            End With

            t.ReplaceDirective("PROPERTIES", prop.tostring)

            Return t.toString

        End Using

    End Function

End Class

Public Class entSerialProp : Inherits List(Of XmlNode)

    Public Shadows Function tostring()

        Dim ret As New Text.StringBuilder
        For Each o As XmlNode In Me
            With o
                Using t As New entTemplate(My.Resources.txtSerialProp)

                    t.ReplaceDirective("PROPERTYNAME", .Attributes("Name").Value)

                    Select Case .Attributes("Type").Value.ToLower
                        Case "Edm.Decimal".ToLower
                            t.ReplaceDirective("RETURNTYPE", "Decimal?")
                        Case "Edm.Int64".ToLower
                            t.ReplaceDirective("RETURNTYPE", "Integer?")
                        Case "Edm.DateTimeOffset".ToLower
                            t.ReplaceDirective("RETURNTYPE", "Date?")
                        Case Else '"Edm.String".ToLower
                            t.ReplaceDirective("RETURNTYPE", "String")

                    End Select

                    ret.Append(t.toString)

                End Using

            End With

        Next

        Return ret.ToString

    End Function

End Class
