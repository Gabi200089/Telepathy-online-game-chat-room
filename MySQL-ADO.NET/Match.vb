Public Class Match
    Private Sub Match_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(255, 255, 226)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Form4.Text = TextBox1.Text
        Form4.Show()
        Me.Hide()
    End Sub
End Class