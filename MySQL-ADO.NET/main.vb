Public Class main
    Dim pic1 As New PictureBox
    Dim pic2 As New PictureBox
    Dim count As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        register.Show()
        Me.Hide()
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.URL = Application.StartupPath & "\song\universe.mp3"
        Me.Controls.Add(pic1)

        pic1.Image = My.Resources.night
        pic1.Size = New Size(818, 450)
        pic1.SizeMode = PictureBoxSizeMode.StretchImage
        pic1.Location = New Point(0, 0)
        Me.Controls.Add(pic2)
        pic2.Image = My.Resources.astro
        pic2.SizeMode = PictureBoxSizeMode.StretchImage
        pic2.Size = New Size(200, 140)
        pic2.BackColor = Color.Transparent
        pic2.Location = New Point(0, 180)
        pic1.SendToBack()
        pic2.Parent = pic1

        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 150
        count = count + 1
        If count = 1 Then
            pic2.Location = New Point(20, 180)
        ElseIf count = 2 Then
            pic2.Location = New Point(50, 190)
        ElseIf count = 3 Then
            pic2.Location = New Point(80, 180)
        ElseIf count = 4 Then
            pic2.Location = New Point(110, 180)
        ElseIf count = 5 Then
            pic2.Location = New Point(140, 170)
        ElseIf count = 6 Then
            pic2.Location = New Point(170, 160)
        ElseIf count = 7 Then
            pic2.Location = New Point(200, 150)
        ElseIf count = 8 Then
            pic2.Location = New Point(230, 140)
        ElseIf count = 9 Then
            pic2.Location = New Point(260, 150)
        ElseIf count = 10 Then
            pic2.Location = New Point(300, 160)
        ElseIf count = 11 Then
            pic2.Location = New Point(330, 180)
        ElseIf count = 12 Then
            pic2.Location = New Point(360, 190)
        ElseIf count = 13 Then
            pic2.Location = New Point(400, 190)
        ElseIf count = 14 Then
            pic2.Location = New Point(430, 180)
        ElseIf count = 15 Then
            pic2.Location = New Point(460, 170)
        ElseIf count = 16 Then
            pic2.Location = New Point(490, 160)
        ElseIf count = 17 Then
            pic2.Location = New Point(520, 150)
        ElseIf count = 18 Then
            pic2.Location = New Point(550, 140)
        ElseIf count = 19 Then
            pic2.Location = New Point(580, 140)
        ElseIf count = 20 Then
            pic2.Location = New Point(620, 130)
        ElseIf count = 21 Then
            pic2.Location = New Point(660, 120)
        ElseIf count = 22 Then
            pic2.Location = New Point(700, 110)
        ElseIf count = 23 Then
            pic2.Location = New Point(740, 100)
        ElseIf count = 24 Then
            pic2.Location = New Point(770, 90)
            AxWindowsMediaPlayer2.URL = Application.StartupPath & "\song\ufo.mp3"
        End If
        If count = 25 Then

            pic1.Image = My.Resources.space1
            pic2.Image = My.Resources.UFO
            pic2.Location = New Point(750, 200)
        ElseIf count = 26 Then
            pic2.Location = New Point(700, 200)
        ElseIf count = 27 Then
            pic2.Location = New Point(680, 190)
        ElseIf count = 28 Then
            pic2.Location = New Point(620, 170)
        ElseIf count = 29 Then
            pic2.Location = New Point(580, 150)
        ElseIf count = 30 Then
            pic2.Location = New Point(530, 180)
        ElseIf count = 31 Then
            pic2.Location = New Point(480, 180)
        ElseIf count = 32 Then
            pic2.Location = New Point(430, 170)
        ElseIf count = 33 Then
            pic2.Location = New Point(360, 170)
        ElseIf count = 34 Then
            pic2.Location = New Point(310, 160)
        ElseIf count = 35 Then
            pic2.Location = New Point(260, 160)
        ElseIf count = 36 Then
            pic2.Location = New Point(200, 160)
        ElseIf count = 37 Then
            pic2.Location = New Point(150, 170)
        ElseIf count = 38 Then
            pic2.Location = New Point(100, 180)
        ElseIf count = 39 Then
            pic2.Location = New Point(50, 190)
        ElseIf count = 40 Then
            pic2.Location = New Point(0, 190)
        ElseIf count = 41 Then
            pic2.Location = New Point(-50, 190)
        ElseIf count = 42 Then
            pic2.Location = New Point(-100, 190)
        ElseIf count = 43 Then
            pic2.Location = New Point(-150, 190)
        ElseIf count = 44 Then
            pic2.Location = New Point(-200, 190)
        ElseIf count = 45 Then
            Button1.Visible = True
            Button2.Visible = True
            pic1.Visible = False
            pic2.Visible = False
            AxWindowsMediaPlayer1.settings.autoStart = True
            AxWindowsMediaPlayer1.settings.setMode("Loop", True)
            AxWindowsMediaPlayer1.URL = Application.StartupPath & "\sounds\mainMenu.mp3"
            Me.BackgroundImage = My.Resources.首頁背景
        End If
    End Sub
End Class