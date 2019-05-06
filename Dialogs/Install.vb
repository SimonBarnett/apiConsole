Imports System.IO
Imports System.Xml

Public Class Install

    Private Sub Install_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToParent()

    End Sub

    Private Enum eTemplateType
        ItemTemplates
        ProjectTemplates
    End Enum

    Private ReadOnly Property TemplateFolders() As List(Of DirectoryInfo)
        Get
            Dim ret As New List(Of DirectoryInfo)
            For Each d As DirectoryInfo In New DirectoryInfo(
                Path.Combine(
                    Environment.ExpandEnvironmentVariables("%userprofile%"),
                    "Documents"
                )
            ).GetDirectories
                If InStr(d.Name, "Visual Studio") > 0 Then
                    Dim t As New DirectoryInfo(Path.Combine(d.FullName, "Templates"))
                    If t.Exists Then ret.Add(t)

                End If
            Next

            If ret.Count = 0 Then
                Throw New Exception("Visual Studio Template folder not found.")
            End If
            Return ret

        End Get
    End Property

    Private ReadOnly Property thisDir As String
        Get
            Return Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly.Location
            )

        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If RadioButton1.Checked Then
            System.Diagnostics.Process.Start(
                Path.Combine(thisDir, "Install\urlRewrite\urlrewrite2.exe")
            )
        End If

        If RadioButton2.Checked Then
            Dim f As FileInfo
            Dim d As New DirectoryInfo(thisDir)
            With d
                f = New FileInfo(
                        Path.Combine(
                            .FullName,
                            "addLogin.sql"
                        )
                    )
                With f
                    If .Exists Then .Delete()
                End With

                Using sw As New StreamWriter(
                    Path.Combine(
                        .FullName,
                        "addLogin.sql"
                    )
                )
                    sw.Write(My.Resources.addLogin)

                End Using

                System.Diagnostics.Process.Start(
                     Path.Combine(
                        .FullName,
                        "addLogin.sql"
                    )
                )

            End With

        End If

        If RadioButton3.Checked Then
            Dim t As DirectoryInfo
            Dim f As FileInfo
            Try
                For Each d As DirectoryInfo In TemplateFolders
                    t = New DirectoryInfo(
                        Path.Combine(
                            d.FullName,
                            eTemplateType.ProjectTemplates.ToString
                        )
                    )
                    With t
                        If .Exists Then
                            f = New FileInfo(
                                Path.Combine(
                                    .FullName,
                                    "API_Feed_project.zip"
                                )
                            )
                            With f
                                If .Exists Then .Delete()
                            End With

                            File.WriteAllBytes(
                                Path.Combine(
                                    .FullName,
                                    "API_Feed_project.zip"
                                ),
                                My.Resources.API_Feed_project
                            )

                            f = New FileInfo(
                                Path.Combine(
                                    .FullName,
                                    "API_Handler_Project.zip"
                                )
                            )
                            With f
                                If .Exists Then .Delete()
                            End With

                            File.WriteAllBytes(
                                Path.Combine(
                                    .FullName,
                                    "API_Handler_Project.zip"
                                ),
                                My.Resources.API_Handler_Project
                            )
                        End If
                    End With

                    t = New DirectoryInfo(
                        Path.Combine(
                            d.FullName,
                            eTemplateType.ItemTemplates.ToString
                        )
                    )
                    With t
                        If .Exists Then
                            f = New FileInfo(
                                Path.Combine(
                                    .FullName,
                                    "API_Feed_item.zip"
                                )
                            )
                            With f
                                If .Exists Then .Delete()
                            End With

                            File.WriteAllBytes(
                                Path.Combine(
                                    .FullName,
                                    "API_Feed_item.zip"
                                ),
                                My.Resources.API_Feed_item
                            )

                            f = New FileInfo(
                                Path.Combine(
                                    .FullName,
                                    "API_Handler_item.zip"
                                )
                            )
                            With f
                                If .Exists Then .Delete()
                            End With

                            File.WriteAllBytes(
                                Path.Combine(
                                    .FullName,
                                    "API_Handler_item.zip"
                                ),
                                My.Resources.API_Handler_item
                            )

                        End If
                    End With

                Next

                MsgBox("Templates installed ok.")

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If

        If RadioButton5.Checked Then
            Try
                My.Computer.FileSystem.CopyDirectory(
                Path.Combine(
                    thisDir,
                    "web\iis"
                ),
                Path.Combine(
                    "c:\inetpub",
                    "api"
                ),
                True
            )
                MsgBox("Ok.")

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If

        If RadioButton6.Checked Then
            Dim d As New DirectoryInfo(
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.Windows
                    ),
                    "Sysnative\inetsrv\config"
                )
            )
            Dim str As String
            With d
                If .Exists Then
                    Dim f As New FileInfo(Path.Combine(d.FullName, "applicationHost.config"))
                    With f
                        If .Exists Then
                            Using sr As New StreamReader(.FullName)
                                str = sr.ReadToEnd

                            End Using

                            Dim doc As New XmlDocument
                            doc.LoadXml(str)
                            doc.Save(String.Format("{0}.old", .FullName))

                            For Each a As XmlNode In doc.SelectNodes("//add[@path='*.ashx']")
                                a.Attributes("verb").Value = "GET,HEAD,POST,DEBUG,VIEW,PATCH"
                                Beep()
                            Next

                            Dim appPool As XmlNode = doc.SelectSingleNode("//applicationPools")
                            If appPool.SelectSingleNode("add[@name='API']") Is Nothing Then

                                Dim m As XmlNode = doc.CreateNode(XmlNodeType.Element, "processModel", "")
                                With m
                                    With .Attributes
                                        .Append(doc.CreateAttribute("identityType"))
                                    End With
                                    .Attributes("identityType").Value = "NetworkService"
                                End With

                                Dim n As XmlNode = doc.CreateNode(XmlNodeType.Element, "add", "")
                                With n
                                    With .Attributes
                                        .Append(doc.CreateAttribute("name"))
                                        .Append(doc.CreateAttribute("autoStart"))
                                        .Append(doc.CreateAttribute("managedRuntimeVersion"))
                                    End With
                                    .Attributes("name").Value = "API"
                                    .Attributes("autoStart").Value = "true"
                                    .Attributes("managedRuntimeVersion").Value = "v4.0"
                                    .AppendChild(m)

                                End With

                                appPool.AppendChild(n)

                            End If

                            Dim priWeb As XmlNode = doc.SelectSingleNode("//sites/site[@id='1']")
                            If priWeb.SelectSingleNode("application[@applicationPool='API']") Is Nothing Then

                                Dim m As XmlNode = doc.CreateNode(XmlNodeType.Element, "virtualDirectory", "")
                                With m
                                    With .Attributes
                                        .Append(doc.CreateAttribute("path"))
                                        .Append(doc.CreateAttribute("physicalPath"))
                                    End With
                                    .Attributes("path").Value = "/"
                                    .Attributes("physicalPath").Value = "c:\inetpub\api"

                                End With

                                Dim n As XmlNode = doc.CreateNode(XmlNodeType.Element, "application", "")
                                With n
                                    With .Attributes
                                        .Append(doc.CreateAttribute("path"))
                                        .Append(doc.CreateAttribute("applicationPool"))
                                    End With
                                    .Attributes("path").Value = "/api"
                                    .Attributes("applicationPool").Value = "API"
                                    .AppendChild(m)

                                End With

                                priWeb.AppendChild(n)

                            End If
                            doc.Save(.FullName)

                            Dim di As New DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Sysnative\inetsrv"))
                            With di
                                If .Exists Then
                                    Dim fi As New FileInfo(
                                        Path.Combine(
                                            .FullName,
                                            "InetMgr.exe"
                                        )
                                    )

                                    If fi.Exists Then
                                        System.Diagnostics.Process.Start(
                                            fi.FullName
                                        )

                                    Else
                                        MsgBox("IIS Manager was not found.")

                                    End If

                                Else
                                    MsgBox("IIS Manager was not found.")

                                End If

                            End With

                        Else
                            MsgBox("Missing applicationHost.config.")

                        End If

                    End With

                Else
                    MsgBox("Missing applicationHost.config.")

                End If

            End With

        End If

        If RadioButton7.Checked Then
            Dim d As New DirectoryInfo(Path.Combine(thisDir, "Install\vs"))
            With d
                If Not .Exists Then
                    MsgBox("Missing Install\vs folder")

                Else
                    For Each f As FileInfo In .GetFiles
                        System.Diagnostics.Process.Start(f.FullName)

                    Next

                End If

            End With

        End If

    End Sub

End Class