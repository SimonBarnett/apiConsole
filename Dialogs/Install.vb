Imports System.IO

Public Class Install

    Private Sub Install_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToParent()

    End Sub

    Private Enum eTemplateType
        ItemTemplates
        ProjectTemplates
    End Enum

    Private ReadOnly Property TemplateFolder(TemplateType As eTemplateType) As DirectoryInfo
        Get
            Return New DirectoryInfo(
                Path.Combine(
                    Path.Combine(
                        Environment.ExpandEnvironmentVariables("%userprofile%"),
                        "Documents\Visual Studio 2017\Templates"
                    ),
                    TemplateType.ToString
                )
            )
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
            System.Diagnostics.Process.Start(
                Path.Combine(thisDir, "Install\node.js\node-v10.13.0-x64.msi")
            )
        End If

        If RadioButton3.Checked Then
            With TemplateFolder(eTemplateType.ProjectTemplates)
                If .Exists Then
                    File.WriteAllBytes(
                    Path.Combine(
                        .FullName,
                        "API_Feed_project.zip"
                    ),
                    My.Resources.API_Feed_project
                )
                    File.WriteAllBytes(
                    Path.Combine(
                        .FullName,
                        "API_Handler_Project.zip"
                    ),
                    My.Resources.API_Handler_Project
                )

                Else
                    MsgBox(
                        String.Format(
                            "VS ProjectTemplates location not found: {0}",
                            .FullName
                        )
                    )
                    Exit Sub

                End If

            End With

            With TemplateFolder(eTemplateType.ItemTemplates)
                If .Exists Then
                    File.WriteAllBytes(
                    Path.Combine(
                        .FullName,
                        "API_Feed_item.zip"
                    ),
                    My.Resources.API_Feed_item
                )
                    File.WriteAllBytes(
                    Path.Combine(
                        .FullName,
                        "API_Handler_item.zip"
                    ),
                    My.Resources.API_Handler_item
                )

                Else
                    MsgBox(
                        String.Format(
                            "VS ItemTemplates location not found: {0}",
                            .FullName
                        )
                    )
                    Exit Sub

                End If

            End With

            MsgBox("Templates installed ok.")

        End If

        If RadioButton4.Checked Then
            With FolderBrowserDialog1
                .RootFolder = Environment.SpecialFolder.MyComputer
                .SelectedPath = "C:\inetpub"
                .ShowNewFolderButton = False
                If .ShowDialog = DialogResult.OK Then
                    My.Computer.FileSystem.CopyDirectory(
                        Path.Combine(
                            thisDir,
                            "web\node.js"
                        ),
                        Path.Combine(
                            .SelectedPath,
                            "mobile6"
                        ),
                        True
                    )
                End If

                System.Diagnostics.Process.Start(
                    "NODE",
                    Path.Combine(
                        .SelectedPath,
                        "mobile6/install.js"
                    )
                )

            End With

        End If

        If RadioButton5.Checked Then
            With FolderBrowserDialog1
                .RootFolder = Environment.SpecialFolder.MyComputer
                .SelectedPath = "C:\inetpub"
                .ShowNewFolderButton = False
                If .ShowDialog = DialogResult.OK Then
                    My.Computer.FileSystem.CopyDirectory(
                        Path.Combine(
                            thisDir,
                            "web\iis"
                        ),
                        Path.Combine(
                            .SelectedPath,
                            "api"
                        ),
                        True
                    )
                End If
            End With
        End If

        If RadioButton6.Checked Then
            System.Diagnostics.Process.Start(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "inetsrv\config")
            )
        End If



    End Sub

End Class