Public Class frmFeed : Inherits baseForm

    Public Overrides ReadOnly Property activity As Boolean
        Get
            Return Me.WebBrowser.IsBusy
        End Get
    End Property

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, ExecuteToolStripMenuItem.Click
        WebBrowser.Navigate(String.Format("{0}?{1}", url, txtGET.Text))

        For Each f As baseForm In Me.MdiParent.MdiChildren
            With f
                If .server = Me.server _
                    And .Environment = Me.Environment _
                    And .EndPoint = Me.EndPoint _
                    And .FormType = eFormType.log Then
                    TryCast(f, frmLog).doRefresh(f, New EventArgs)
                    Exit For
                End If
            End With
        Next

    End Sub

    Private Sub txtGET_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGET.KeyDown
        If e.KeyData = Keys.Enter Then
            Button1_Click(sender, New System.EventArgs)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub


End Class