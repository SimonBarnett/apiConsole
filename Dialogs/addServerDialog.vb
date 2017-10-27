Imports System.Windows.Forms

Public Class addServerDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_Prot.SelectedIndexChanged

    End Sub

    Public ReadOnly Property url
        Get
            Return String.Format("{0}{1}" _
                , lst_Prot.Selecteditem,
                txt_Url.Text
            )
        End Get
    End Property

    Private Sub txt_Url_TextChanged(sender As Object, e As EventArgs) Handles txt_Url.TextChanged

    End Sub
End Class
