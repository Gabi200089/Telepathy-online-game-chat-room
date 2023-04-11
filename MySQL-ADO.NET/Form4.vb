Imports MySql.Data.MySqlClient
'先去下載安裝 MySQL Connector 在執行此程式的電腦上
'https://dev.mysql.com/downloads/connector/net/
'然後把MySql.Data.dll 匯入專案參考 (C:\Program Files (x86)\MySQL\MySQL Connector Net 8.0.11\Assemblies\v4.5.2)
Imports System.IO
Imports System.Net.Sockets
Public Class Form4
    Public msn As Integer = 0
    Public Fb(msn) As Button
    Dim Fp(msn) As PictureBox
    Dim Fh(msn) As PictureBox
    Public Fl(msn) As Label
    Public MyIP As String
    '連線所需參數
    Public Client As TcpClient
    Public RX As StreamReader
    Public TX As StreamWriter
    '關掉伺服器(0:正常 ; 1:關掉)
    Public CloseClient As Integer = 0
    Public Chatn As String = ""
    Public NewIN As Integer = 0
    Public iamIn As Integer = 0
    Public ChoosePlayer As String = "0"
    Dim BeforeCPnum As Integer = 0
    Dim Challenge As Integer = 0
    Public RndPlay As Integer = 0
    Dim soundvolume As Integer = 50
    Dim ss11 As Integer = 0
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        main.AxWindowsMediaPlayer1.settings.volume = soundvolume

        GroupBox1.BackColor = Color.FromArgb(229, 230, 218)
        Me.BackColor = Color.FromArgb(255, 255, 226)

        CheckForIllegalCrossThreadCalls = False

        Try
            Client = New TcpClient("172.20.10.9", 4305)
            If Client.GetStream.CanRead = True Then
                RX = New StreamReader(Client.GetStream)
                TX = New StreamWriter(Client.GetStream)
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Connected)
            End If
            UserIp(Client.Client.LocalEndPoint.ToString, "On")
            MyIP = Client.Client.LocalEndPoint.ToString
            FriendList()
            Form2.Hide()
        Catch ex As Exception
        End Try
        Timer1.Enabled = True
        Timer2.Enabled = True
        SendToServer()

    End Sub
#Region "連線"
    Function Connected()
        If RX.BaseStream.CanRead = True Then
            Try
                While RX.BaseStream.CanRead = True
                    Dim RawData As String = RX.ReadLine
                    If RawData = "NewIn" Then
                        NewIN = 1
                    ElseIf RawData = "Fight" Then
                        Button1.Text = "Start"
                    Else
                        Dim c As String = FindName(RawData)
                        For d As Integer = 0 To msn - 1
                            If Fb(d) IsNot Nothing Then
                                If Fb(d).Text.Trim() = c Then
                                    If c = Chatn Then
                                        Button1.Text = "1"
                                    Else
                                        Fl(d).Text += 1
                                        Fl(d).Tag = "0"
                                    End If
                                End If
                            End If
                        Next
                    End If
                End While
            Catch ex As Exception
                Client.Close()
            End Try
        End If
        Return True
    End Function
#End Region
#Region "我的IP"
    Function UserIp(x As String, y As String)
        '建立連線字串
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "UPDATE info SET IP = '" + x + "',Online='" + y + "' WHERE Name='" + Me.Text + "';"

        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString

            Try
                '開啟資料庫連線
                Connection.Open()

                MyCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using
        Return True
    End Function
#End Region
#Region "誰寄給我(用IP找名字)"
    Function FindName(x As String)
        '建立連線字串
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT Name FROM info WHERE IP='" + x + "';"

        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString

            Try
                '開啟資料庫連線
                Connection.Open()

                Dim dataReader2 As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader2.Read()
                    Return dataReader2(0).ToString
                Loop
                dataReader2.Close()
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using
    End Function
#End Region
#Region "要傳訊息的對象(從名字找IP)"
    Function RerIp(x As String)
        '建立連線字串
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT IP FROM info WHERE Name='" + x + "';"

        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString

            Try
                '開啟資料庫連線
                Connection.Open()

                Dim dataReader2 As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader2.Read()
                    Return dataReader2(0).ToString
                    Exit Do
                Loop
                dataReader2.Close()
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using
    End Function
#End Region
#Region "傳送資料給Server"
    Function SendToServer()
        Try
            If CloseClient = 0 Then
                If iamIn = 0 Then
                    TX.WriteLine(Client.Client.LocalEndPoint.ToString + ";NewIn")
                    TX.Flush()
                    iamIn = 1
                ElseIf Challenge = 1 Then
                    TX.WriteLine(RerIp(ChoosePlayer) + ";Fight")
                    TX.Flush()
                    Challenge = 0
                Else
                    TX.WriteLine(Client.Client.LocalEndPoint.ToString + ";" + RerIp(Chatn))
                    TX.Flush()
                End If
            ElseIf CloseClient = 1 Then
                TX.WriteLine(Client.Client.LocalEndPoint.ToString + ";" + "Close")
                TX.Flush()
                CloseClient = 0
            End If
        Catch ex As Exception

        End Try
    End Function
#End Region

#Region "好友列表刷新"
    Function FriendList()
        GroupBox1.Controls.Clear()
        '建立連線字串
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        'Dim QueryString As String = "SELECT SFname,SImg From list WHERE CFname='" + Me.Text + "';"
        Dim QueryString As String = "SELECT list.New, info.Name, info.Online, info.HeadPic FROM list, info WHERE list.SFname=info.Name AND list.CFname ='" + FindName(MyIP) + "';"
        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString


            Try
                '開啟資料庫連線
                Connection.Open()

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Dim a As Integer = 0
                While dataReader.Read()
                    a += 1
                End While
                dataReader.Close()
                Lf(a)
                Dim dataReader2 As MySqlDataReader = MyCommand.ExecuteReader()
                Dim b As Integer = 0
                While dataReader2.Read()
                    CreateF(dataReader2(1).ToString, b, dataReader2(0).ToString, dataReader2(3).ToString, dataReader2(2).ToString)
                    b += 1
                End While
                dataReader2.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try

        End Using
        Return True
    End Function
#End Region
#Region "重設好友陣列長度"
    Function Lf(x As String)
        msn = x
        ReDim Fb(msn)
        ReDim Fp(msn)
        ReDim Fh(msn)
        ReDim Fl(msn)
        Return True
    End Function
#End Region
#Region "建立好友列表"
    Function CreateF(tx As String, y As String, z As Integer, h As String, o As String)
        Dim Text1 As String = tx
        '頭貼
        Fp(y) = New PictureBox
        With Fp(y)
            .AutoSize = False
            .Size = New Size(50, 50)
            .Top = 20 + (60 * y)
            .Left = 5
            .BackgroundImage = My.Resources.ResourceManager.GetObject(h)
            .BackgroundImageLayout = ImageLayout.Stretch
        End With
        '上線 (On , Off)
        Fh(y) = New PictureBox
        With Fh(y)
            .AutoSize = False
            .Size = New Size(15, 15)
            .Top = 37 + (60 * y)
            .Left = 60
            .Tag = o
            .BackgroundImage = My.Resources.ResourceManager.GetObject(o)
            .BackgroundImageLayout = ImageLayout.Stretch
        End With
        Fb(y) = New Button
        With Fb(y)
            .AutoSize = False
            .Size = New Size(140, 50)
            .Font = New Font(New FontFamily("微軟正黑體"), 9, FontStyle.Bold)
            .Top = 20 + (60 * y)
            .Left = 55
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            .Text = "      " + Text1
            .Tag = y
            .BackColor = Color.Empty
        End With
        Fl(y) = New Label
        With Fl(y)
            .Text = z
            .Tag = "0"
        End With
        If Fl(y).Text = "0" Then
            Fl(y).Tag = "-1"
        End If

        GroupBox1.Controls.Add(Fp(y))
        GroupBox1.Controls.Add(Fb(y))
        GroupBox1.Controls.Add(Fh(y))
        AddHandler(Fb(y).Click), AddressOf Fb_Click

        Fp(y).BringToFront()
        Fb(y).BringToFront()
        Fh(y).BringToFront()
        Return True
    End Function
#End Region
    Private Sub Fb_Click(sender As Object, e As EventArgs)
        Dim g As Button = sender
        If Fh(g.Tag).Tag = "On" Then
            ChoosePlayer = g.Text.Trim()
            Fb(BeforeCPnum).BackColor = Color.Empty
            BeforeCPnum = g.Tag
            g.BackColor = Color.Yellow
        ElseIf Fh(g.Tag).Tag = "Off" Then
            MsgBox("未上線", MsgBoxStyle.OkOnly And MsgBoxResult.Ok, "無法選擇")
        End If
    End Sub
#Region "好友列表滾輪"
    Private Sub GroupBox1_MouseWheel(sender As Object, e As MouseEventArgs)
        'Button3.Text = P(mn - 1).Top.ToString + "," + P(mn - 1).Width.ToString + "," + P(mn - 1).Height.ToString + "," + e.Delta.ToString
        If msn > 0 Then
            If Fp(msn - 1).Top + Fp(msn - 1).Height + e.Delta >= 370 And Fp(0).Top + e.Delta <= 20 Then
                If Fp(0).Top = 20 And e.Delta < 0 Then
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top += e.Delta
                        Fb(i).Top += e.Delta
                        Fh(i).Top += e.Delta
                    Next
                ElseIf Fp(msn - 1).Top + Fp(msn - 1).Height = 370 And e.Delta > 0 Then
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top += e.Delta
                        Fb(i).Top += e.Delta
                        Fh(i).Top += e.Delta
                    Next
                ElseIf Fp(0).Top < 20 And Fp(msn - 1).Top + Fp(msn - 1).Height > 370 Then
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top += e.Delta
                        Fb(i).Top += e.Delta
                        Fh(i).Top += e.Delta
                    Next
                End If
            ElseIf Fp(0).Top + e.Delta > 20 Then
                Dim dis As Integer = 20 - Fp(0).Top
                Do While Fp(0).Top < 20
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top += dis
                        Fb(i).Top += dis
                        Fh(i).Top += dis
                    Next
                Loop
            ElseIf Fp(msn - 1).Top + Fp(msn - 1).Height + e.Delta < 370 Then
                Dim dis As Integer = Fp(msn - 1).Top + Fp(msn - 1).Height - 370
                Do While Fp(msn - 1).Top + Fp(msn - 1).Height > 370
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top -= dis
                        Fb(i).Top -= dis
                        Fh(i).Top -= dis
                    Next
                Loop
            End If
        End If
    End Sub
#End Region
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'alen
        UserIp(MyIP, "Ing")
        iamIn = 0
        SendToServer()
        Form5.Close()
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Text = Me.Text
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UserIp(Client.Client.LocalEndPoint.ToString, "Off")
        iamIn = 0
        SendToServer()
        CloseClient = 1
        SendToServer()
        If CloseClient = 0 Then
            Client.Close()
            login.Show()
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If NewIN = 1 Then
            FriendList()
            Form2.FriendList()
            NewIN = 0
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Fh(BeforeCPnum).Tag = "On" Then
            Challenge = 1
            Me.Hide()
            Form6.Show()
            SendToServer()
            UserIp(MyIP, "Ing")
            iamIn = 0
            SendToServer()
        Else
            MsgBox("選擇的玩家未上線", MsgBoxStyle.OkOnly And MsgBoxResult.Ok, "無法選擇")
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Button1.Text = "Start" Then
            Button1.Text = ""
            Timer3.Enabled = True
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub Form4_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            FriendList()
        ElseIf Me.Visible = False Then
            FriendList()
        End If
    End Sub
    Private Sub volumedown_Click(sender As Object, e As EventArgs) Handles volumedown.Click
        If soundvolume > 0 Then
            soundvolume -= 10
            main.AxWindowsMediaPlayer1.settings.volume = soundvolume
        End If
    End Sub

    Private Sub volumeup_Click(sender As Object, e As EventArgs) Handles volumeup.Click
        If soundvolume < 100 Then
            soundvolume += 10
            main.AxWindowsMediaPlayer1.settings.volume = soundvolume
        End If
    End Sub

    Private Sub volumeoff_Click(sender As Object, e As EventArgs) Handles volumeoff.Click
        main.AxWindowsMediaPlayer1.Ctlcontrols.pause()
        volumeoff.Visible = False
        volumeon.Visible = True
    End Sub
    Private Sub volumeon_Click(sender As Object, e As EventArgs) Handles volumeon.Click
        main.AxWindowsMediaPlayer1.Ctlcontrols.play()
        volumeon.Visible = False
        volumeoff.Visible = True
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        ss11 += 1
        If ss11 = 3 Then
            Me.Hide()
            Form7.ssplay = MyIP
            Form7.Show()
            Form7.BringToFront()
            ss11 = 0
            Timer3.Enabled = False
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class