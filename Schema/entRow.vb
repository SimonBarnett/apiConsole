Imports System.Xml

Public Class entRow

    Private prop As New entProp
    Private nav As New entNavProp
    Private this As XmlNode

    Sub New(ByRef node As XmlNode)

        this = node
        With node
            For Each sf As XmlNode In .SelectNodes("NavigationProperty")
                nav.Add(sf)

            Next
            For Each p As XmlNode In .SelectNodes("Property")
                prop.Add(p)
            Next

        End With


    End Sub

    Shadows Function toString() As String
        Using t As New entTemplate(My.Resources.txtRow)
            With this
                t.ReplaceDirective("#FORM#", .Attributes("Name").Value)

            End With

            If nav.Count > 0 Then
                t.ReplaceDirective("SUBFORMS", nav.tostring)
            Else
                t.DeleteDirective("SUBFORMS")
            End If

            t.ReplaceDirective("PROPERTIES", prop.tostring)

            Return t.toString

        End Using

    End Function

End Class

Public Class entProp : Inherits List(Of XmlNode)

    Public Shadows Function tostring()

        Dim ret As New Text.StringBuilder
        For Each o As XmlNode In Me
            With o

                Dim att As New entAttrib
                Dim templ As String
                If Not .Attributes("ReadOnly") Is Nothing Then
                    If .Attributes("ReadOnly").Value.ToString = "1" Then
                        att.Add("ReadOnly", "True")
                        templ = My.Resources.txtPropertyReadOnly
                    Else
                        templ = My.Resources.txtProperty
                    End If
                Else
                    templ = My.Resources.txtProperty
                End If

                Using t As New entTemplate(templ)

                    t.ReplaceDirective("TITLE", .Attributes("Title").Value)
                    t.ReplaceDirective("PROPERTYNAME", .Attributes("Name").Value)
                    t.ReplaceDirective("FORMNAME", o.ParentNode.Attributes("Name").Value)

                    If Not o.ParentNode.SelectSingleNode(
                        String.Format(
                            "Key/PropertyRef[@Name='{0}']",
                            .Attributes("Name").Value
                        )
                    ) Is Nothing Then
                        att.Add("Key", "True")

                    End If

                    If Not .Attributes("Mandatory") Is Nothing Then
                        If .Attributes("Mandatory").Value.ToString = "1" Then
                            att.Add("mandatory", "True")

                        End If
                    End If

                    Select Case .Attributes("Type").Value.ToLower
                        Case "Edm.Decimal".ToLower
                            t.ReplaceDirective("RETURNTYPE", "Decimal")
                        Case "Edm.Int64".ToLower
                            t.ReplaceDirective("RETURNTYPE", "Integer")
                        Case "Edm.DateTimeOffset".ToLower
                            t.ReplaceDirective("RETURNTYPE", "Date")
                        Case Else '"Edm.String".ToLower
                            t.ReplaceDirective("RETURNTYPE", "String")
                            att.Add("length", .Attributes("MaxLength").Value)

                    End Select

                    t.ReplaceDirective("DIRECTIVES", att.tostring)

                    ret.Append(t.toString)

                End Using

            End With

        Next

        Return ret.ToString

    End Function

End Class

Public Class entAttrib : Inherits Dictionary(Of String, String)

    Public Shadows Function tostring()

        Dim ret As New Text.StringBuilder
        For Each k As String In Me.Keys
            ret.AppendFormat(", {0}:={1}", k, Me(k))

        Next

        Return ret.ToString

    End Function

End Class

Public Class entNavProp : Inherits List(Of XmlNode)

    Public Shadows Function tostring()

        Dim ret As New Text.StringBuilder
        For Each o As XmlNode In Me
            With o
                Using t As New entTemplate(My.Resources.txtSubForm)
                    t.ReplaceDirective("FORMNAME", .Attributes("Name").Value)
                    ret.Append(t.toString)

                End Using

            End With

        Next

        Return ret.ToString

    End Function

End Class