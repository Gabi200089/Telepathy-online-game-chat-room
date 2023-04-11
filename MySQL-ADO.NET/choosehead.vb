Public Class choosehead
    Public choose As String
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        choose = "head1"
        register.PictureBox2.Image = My.Resources.choosehead1
        register.choose = "head1"
        Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        choose = "head2"
        register.PictureBox2.Image = My.Resources.choosehead2
        register.choose = "head2"
        Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        register.PictureBox2.Image = My.Resources.choosehead3
        choose = "head3"
        register.choose = "head3"
        Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        register.PictureBox2.Image = My.Resources.choosehead4
        choose = "head4"
        register.choose = "head4"
        Close()
    End Sub

    Private Sub choosehead_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        register.PictureBox2.Image = My.Resources.choosehead5
        choose = "head5"
        register.choose = "head5"
        Close()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        register.PictureBox2.Image = My.Resources.choosehead6
        choose = "head6"
        register.choose = "head6"
        Close()
    End Sub
End Class