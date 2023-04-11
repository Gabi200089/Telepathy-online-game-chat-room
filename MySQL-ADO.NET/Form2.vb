Imports MySql.Data.MySqlClient
'先去下載安裝 MySQL Connector 在執行此程式的電腦上
'https://dev.mysql.com/downloads/connector/net/
'然後把MySql.Data.dll 匯入專案參考 (C:\Program Files (x86)\MySQL\MySQL Connector Net 8.0.11\Assemblies\v4.5.2)
Imports System.IO
Imports System.Net.Sockets

Public Class Form2
#Region "參數"
    Dim total As Integer = 0
    Dim prex As Integer = 0     '前一個位置X
    Dim prey As Integer = 0     '前一個位置Y
    Dim mn As Integer = 0       '聊天框數
    Dim msn As Integer = 0      '好友數
    Dim P(mn) As PictureBox     '聊天框陣列
    Dim L(mn) As Label          '聊天內容陣列
    Public Fb(msn) As Button       '好友名陣列
    Dim Fp(msn) As PictureBox   '好友圖陣列
    Public Fl(msn) As Label        '好友New陣列
    Dim Fh(msn) As PictureBox
    Dim Fn As Integer = 0
    '現在的聊天對象
    Dim SendChat As Integer = 0 'NEW數量(+1,+2...)
    'Dim WithEvents socket As Socket

    '關掉伺服器(0:正常 ; 1:關掉)
    Dim CloseClient As Integer = 0
    Dim ShowImg As Integer = 0
#End Region
#Region "FORM LOAD"
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If Form4.Fl(0) IsNot Nothing Then
            Form4.Fl(0).Text = "0"
            Form4.Fl(0).Tag = "-1"
        End If
        FriendList()
        Find()
        If Fb(0) IsNot Nothing Then
            Fb(0).BackColor = Color.Yellow
        End If

        If Fl(0) IsNot Nothing Then
            Fl(0).Text = "0"
        End If

        NewOut()

        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub
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
        Dim QueryString As String = "SELECT list.New, info.Name, info.Online, info.HeadPic FROM list, info WHERE list.SFname=info.Name AND list.CFname ='" + Me.Text + "';"

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
                If Form4.Fb(0) IsNot Nothing Then
                    Form4.Chatn = Form4.Fb(0).Text.Trim()
                End If
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
        ReDim Fl(msn)
        ReDim Fh(msn)
        Return True
    End Function
#End Region

    Private Sub Fp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        data.name = Fb(sender.name.ToString).Name
        'MsgBox(Fb(sender.name.ToString).Text)
        'data.name = "Yan"
        data.Show()
    End Sub
#Region "建立好友列表"
    Function CreateF(tx As String, y As String, z As Integer, h As String, o As String)
        Dim Text1 As String = tx

        Fp(y) = New PictureBox
        With Fp(y)
            .AutoSize = False
            .Size = New Size(50, 50)
            .Top = 20 + (60 * y)
            .Left = 5
            .Name = y
            .BackgroundImage = My.Resources.ResourceManager.GetObject(h)
            .BackgroundImageLayout = ImageLayout.Stretch
            AddHandler Fp(y).Click, AddressOf Fp_Click
        End With
        Fh(y) = New PictureBox
        With Fh(y)
            .AutoSize = False
            .Size = New Size(15, 15)
            .Top = 37 + (60 * y)
            .Left = 60
            .BackgroundImage = My.Resources.ResourceManager.GetObject(o)
            .BackgroundImageLayout = ImageLayout.Stretch
            .BackColor = Color.Transparent
        End With
        Fl(y) = New Label
        With Fl(y)
            .AutoSize = True
            .Size = New Size(14, 15)
            .Font = New Font(New FontFamily("微軟正黑體"), 9, FontStyle.Bold)
            .Top = 35 + (60 * y)
            .Left = 170
            .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            .Text = z
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
            .Name = Text1
            .Tag = y
            .BackColor = Color.Empty
        End With

        GroupBox1.Controls.Add(Fp(y))
        GroupBox1.Controls.Add(Fl(y))
        GroupBox1.Controls.Add(Fb(y))
        GroupBox1.Controls.Add(Fh(y))
        AddHandler(Fb(y).Click), AddressOf Fb_Click '所有物件事件統一指向同一Sub

        Fp(y).BringToFront()
        Fb(y).BringToFront()
        Fl(y).BringToFront()
        Fh(y).BringToFront()
        Return True
    End Function
#End Region
#Region "點擊觸發聊天框"
    Private Sub Fb_Click(sender As Object, e As EventArgs)
        Dim g As Button = sender
        NewOut()
        Form4.Chatn = g.Text.Trim()
        Fb(Fn).BackColor = Color.Empty
        Form4.Fl(g.Tag).Tag = "-1"
        g.BackColor = Color.Yellow
        Fn = g.Tag
        Find()
        NewOut()
    End Sub
#End Region
#Region "好友列表滾輪"
    Private Sub GroupBox1_MouseWheel(sender As Object, e As MouseEventArgs)
        'Label1.Text = P(mn - 1).Top.ToString + "," + P(mn - 1).Width.ToString + "," + P(mn - 1).Height.ToString + "," + e.Delta.ToString
        If msn > 0 Then
            If Fp(msn - 1).Top + Fp(msn - 1).Height + e.Delta >= 420 And Fp(0).Top + e.Delta <= 20 Then
                If Fp(0).Top = 20 And e.Delta < 0 Then
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top += e.Delta
                        Fl(i).Top += e.Delta
                        Fb(i).Top += e.Delta
                        Fh(i).Top += e.Delta
                    Next
                ElseIf Fp(msn - 1).Top + Fp(msn - 1).Height = 420 And e.Delta > 0 Then
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top += e.Delta
                        Fl(i).Top += e.Delta
                        Fb(i).Top += e.Delta
                        Fh(i).Top += e.Delta
                    Next
                ElseIf Fp(0).Top < 20 And Fp(msn - 1).Top + Fp(msn - 1).Height > 420 Then
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top += e.Delta
                        Fl(i).Top += e.Delta
                        Fb(i).Top += e.Delta
                        Fh(i).Top += e.Delta
                    Next
                End If
            ElseIf Fp(0).Top + e.Delta > 20 Then
                Dim dis As Integer = 20 - Fp(0).Top
                Do While Fp(0).Top < 20
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top += dis
                        Fl(i).Top += dis
                        Fb(i).Top += dis
                        Fh(i).Top += dis
                    Next
                Loop
            ElseIf Fp(msn - 1).Top + Fp(msn - 1).Height + e.Delta < 420 Then
                Dim dis As Integer = Fp(msn - 1).Top + Fp(msn - 1).Height - 420
                Do While Fp(msn - 1).Top + Fp(msn - 1).Height > 420
                    For i As Integer = 0 To msn - 1
                        Fp(i).Top -= dis
                        Fl(i).Top -= dis
                        Fb(i).Top -= dis
                        Fh(i).Top -= dis
                    Next
                Loop
            End If
        End If
        'MsgBox("Get", MsgBoxStyle.YesNo, "uu")
    End Sub
#End Region

#Region "聊天框刷新"
    Function Find()
        Panel1.Controls.Clear()
        '建立連線字串
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT SCname,CCname,Content From chat WHERE (SCname='" + Me.Text + "' AND CCname='" + Form4.Chatn + "')OR(CCname='" + Me.Text + "' AND SCname='" + Form4.Chatn + "') ORDER BY Time DESC;"

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
                Lp(a)
                Dim dataReader2 As MySqlDataReader = MyCommand.ExecuteReader()
                Dim b As Integer = 0
                While dataReader2.Read()
                    If dataReader2(0) = Me.Text Then
                        If dataReader2(2) = "Love1.png" Then
                            Create("", b, 385, "Love1")
                        ElseIf dataReader2(2) = "Love2.png" Then
                            Create("", b, 385, "Love2")
                        ElseIf dataReader2(2) = "Love3.png" Then
                            Create("", b, 385, "Love3")
                        ElseIf dataReader2(2) = "Love4.png" Then
                            Create("", b, 385, "Love4")
                        ElseIf dataReader2(2) = "可樂.gif" Then
                            Create("", b, 385, "可樂")
                        ElseIf dataReader2(2) = "茄子.gif" Then
                            Create("", b, 385, "茄子")
                        ElseIf dataReader2(2) = "香菇.gif" Then
                            Create("", b, 385, "香菇")
                        ElseIf dataReader2(2) = "sticker1.png" Then
                            Create("", b, 385, "sticker1")
                        ElseIf dataReader2(2) = "sticker2.png" Then
                            Create("", b, 385, "sticker2")
                        ElseIf dataReader2(2) = "sticker3.png" Then
                            Create("", b, 385, "sticker3")
                        ElseIf dataReader2(2) = "sticker4.png" Then
                            Create("", b, 385, "sticker4")
                        ElseIf dataReader2(2) = "sticker5.png" Then
                            Create("", b, 385, "sticker5")
                        ElseIf dataReader2(2) = "sticker6.png" Then
                            Create("", b, 385, "sticker6")
                        ElseIf dataReader2(2) = "sticker7.png" Then
                            Create("", b, 385, "sticker7")
                        ElseIf dataReader2(2) = "sticker8.png" Then
                            Create("", b, 385, "sticker8")
                        ElseIf dataReader2(2) = "sticker9.png" Then
                            Create("", b, 385, "sticker9")
                        ElseIf dataReader2(2) = "sticker10.png" Then
                            Create("", b, 385, "sticker10")
                        ElseIf dataReader2(2) = "sticker11.png" Then
                            Create("", b, 385, "sticker11")
                        ElseIf dataReader2(2) = "sticker12.png" Then
                            Create("", b, 385, "sticker12")
                        Else
                            Create(dataReader2(2).ToString, b, 310, "message6")
                        End If
                    Else
                        If dataReader2(2) = "Love1.png" Then
                            Create("", b, 0, "Love1")
                        ElseIf dataReader2(2) = "Love2.png" Then
                            Create("", b, 0, "Love2")
                        ElseIf dataReader2(2) = "Love3.png" Then
                            Create("", b, 0, "Love3")
                        ElseIf dataReader2(2) = "Love4.png" Then
                            Create("", b, 0, "Love4")
                        ElseIf dataReader2(2) = "可樂.gif" Then
                            Create("", b, 0, "可樂")
                        ElseIf dataReader2(2) = "茄子.gif" Then
                            Create("", b, 0, "茄子")
                        ElseIf dataReader2(2) = "香菇.gif" Then
                            Create("", b, 0, "香菇")
                        ElseIf dataReader2(2) = "sticker1.png" Then
                            Create("", b, 0, "sticker1")
                        ElseIf dataReader2(2) = "sticker2.png" Then
                            Create("", b, 0, "sticker2")
                        ElseIf dataReader2(2) = "sticker3.png" Then
                            Create("", b, 0, "sticker3")
                        ElseIf dataReader2(2) = "sticker4.png" Then
                            Create("", b, 0, "sticker4")
                        ElseIf dataReader2(2) = "sticker5.png" Then
                            Create("", b, 0, "sticker5")
                        ElseIf dataReader2(2) = "sticker6.png" Then
                            Create("", b, 0, "sticker6")
                        ElseIf dataReader2(2) = "sticker7.png" Then
                            Create("", b, 0, "sticker7")
                        ElseIf dataReader2(2) = "sticker8.png" Then
                            Create("", b, 0, "sticker8")
                        ElseIf dataReader2(2) = "sticker9.png" Then
                            Create("", b, 0, "sticker9")
                        ElseIf dataReader2(2) = "sticker10.png" Then
                            Create("", b, 0, "sticker10")
                        ElseIf dataReader2(2) = "sticker11.png" Then
                            Create("", b, 0, "sticker11")
                        ElseIf dataReader2(2) = "sticker12.png" Then
                            Create("", b, 0, "sticker12")
                        Else
                            Create(dataReader2(2).ToString, b, 0, "message4")
                        End If
                    End If

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
#Region "重設聊天框陣列長度"
    Function Lp(x As String)
        mn = x
        ReDim P(mn)
        ReDim L(mn)

        Return True
    End Function

#End Region
#Region "建立聊天框"
    Function Create(tx As String, y As String, z As Integer, r As String)
        Dim Text1 As String = tx

        Dim str As String() = Split(Text1, vbLf)
        If Text1 = "" Then
            If y = 0 Then
                P(0) = New PictureBox
                With P(0)
                    .AutoSize = False
                    .Size = New Size(140, 140)
                    .Top = 340 - 140 - 10
                    .Left = 10 + z
                    .Image = My.Resources.ResourceManager.GetObject(r)
                    .SizeMode = PictureBoxSizeMode.StretchImage
                End With
                L(0) = New Label
                With L(0)
                    .AutoSize = True
                    .Size = New Size(20, 20)
                    .Font = New Font(New FontFamily("微軟正黑體"), 10, FontStyle.Bold)
                    .Top = 358 - 140 - 10
                    .Left = 10 + z
                    .Text = "0"
                    .Visible = False
                End With
            Else
                P(y) = New PictureBox
                With P(y)
                    .AutoSize = False
                    .Size = New Size(140, 140)
                    .Top = prex - 140 - 10
                    .Left = 10 + z
                    .Image = My.Resources.ResourceManager.GetObject(r)
                    .SizeMode = PictureBoxSizeMode.StretchImage
                End With
                L(y) = New Label
                With L(y)
                    .AutoSize = True
                    .Size = New Size(20, 20)
                    .Font = New Font(New FontFamily("微軟正黑體"), 10, FontStyle.Bold)
                    .Top = prey - 140 - 10
                    .Left = 10 + z
                    .Text = "0"
                    .Visible = False
                End With
            End If
        Else
            If y = 0 Then
                P(0) = New PictureBox
                With P(0)
                    .AutoSize = False
                    .Size = New Size(220, 36 + (20 * str.Length))
                    .Top = 340 - (20 * str.Length) - 36 - 10
                    .Left = 10 + z
                    .BackgroundImage = My.Resources.ResourceManager.GetObject(r)
                    .BackgroundImageLayout = ImageLayout.Stretch
                End With
                L(0) = New Label
                With L(0)
                    .AutoSize = True
                    .Size = New Size(20, 20)
                    .Font = New Font(New FontFamily("微軟正黑體"), 10, FontStyle.Bold)
                    .Top = 358 - (20 * str.Length) - 10 - 36
                    .Left = 25 + z
                    .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                    .Text = Text1
                    .BackColor = Color.FromArgb(230, 179, 198)
                End With
                If z = 0 Then
                    L(0).BackColor = Color.FromArgb(151, 185, 228)
                End If
            Else
                P(y) = New PictureBox
                With P(y)
                    .AutoSize = False
                    .Size = New Size(220, 36 + (20 * str.Length))
                    .Top = prex - (20 * str.Length) - 36 - 10
                    .Left = 10 + z
                    .BackgroundImage = My.Resources.ResourceManager.GetObject(r)
                    .BackgroundImageLayout = ImageLayout.Stretch
                End With
                L(y) = New Label
                With L(y)
                    .AutoSize = True
                    .Size = New Size(20, 20)
                    .Font = New Font(New FontFamily("微軟正黑體"), 10, FontStyle.Bold)
                    .Top = prey - (20 * str.Length) - 36 - 10
                    .Left = 25 + z
                    .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                    .Text = Text1
                    .BackColor = Color.FromArgb(230, 179, 198)
                End With
                If z = 0 Then
                    L(y).BackColor = Color.FromArgb(151, 185, 228)
                End If
            End If
        End If
        Panel1.Controls.Add(L(y))
        Panel1.Controls.Add(P(y))

        P(y).BringToFront()
        L(y).BringToFront()

        prex = P(y).Top
        prey = L(y).Top
        Return True
    End Function
#End Region
#Region "聊天框滾輪"
    Private Sub Panel1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Panel1.MouseWheel
        'Label1.Text = P(mn - 1).Top.ToString + "," + P(mn - 1).Width.ToString + "," + P(mn - 1).Height.ToString + "," + e.Delta.ToString
        If mn > 0 Then
            If P(mn - 1).Top + e.Delta <= 0 And P(0).Top + P(0).Height + e.Delta >= 330 Then
                If P(0).Top + P(0).Height = 330 And e.Delta > 0 Then
                    For i As Integer = 0 To mn - 1
                        P(i).Top += e.Delta
                        L(i).Top += e.Delta
                    Next
                ElseIf P(mn - 1).Top = 0 And e.Delta < 0 Then
                    For i As Integer = 0 To mn - 1
                        P(i).Top += e.Delta
                        L(i).Top += e.Delta
                    Next
                ElseIf P(mn - 1).Top < 0 And P(0).Top + P(0).Height > 330 Then
                    For i As Integer = 0 To mn - 1
                        P(i).Top += e.Delta
                        L(i).Top += e.Delta
                    Next
                End If
            ElseIf P(mn - 1).Top + e.Delta > 0 Then
                Dim dis As Integer = 0 - P(mn - 1).Top
                Do While P(mn - 1).Top < 0
                    For i As Integer = 0 To mn - 1
                        P(i).Top += dis
                        L(i).Top += dis
                    Next
                Loop
            ElseIf P(0).Top + P(0).Height + e.Delta < 330 Then
                Dim dis As Integer = 340 - P(0).Height - P(0).Top
                Do While P(0).Top > 340 - P(0).Height
                    For i As Integer = 0 To mn - 1
                        P(i).Top += dis
                        L(i).Top += dis
                    Next
                Loop
            End If
        End If
        'MsgBox("Get", MsgBoxStyle.YesNo, "uu")
    End Sub
#End Region

#Region "傳送鍵觸發"
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If RichTextBox1.Text = "" Then
        Else
            Dim Text1 As String = RichTextBox1.Text
            Dim Text2 As String = ""

            Dim str As String() = Split(Text1, vbLf)
            For i = 0 To str.Length - 1
                If str(i).Length > 12 Then
                    Dim k As Integer
                    If str(i).Length Mod 12 > 0 Then
                        k = 0
                    Else
                        k = 1
                    End If

                    For j = 0 To CInt(str(i).Length / 12) - k
                        If j < (str(i).Length / 12) - 1 Then
                            Text2 = Text2 + Mid(str(i), 1 + (12 * j), 12) + vbNewLine
                        Else
                            Text2 = Text2 + Mid(str(i), 1 + 12 * j, str(i).Length - (12 * j))
                        End If
                    Next
                Else
                    Text2 += str(i)
                End If
                If i = str.Length - 1 Then
                Else
                    Text2 += vbNewLine
                End If
            Next
            WriteIn(Text2)
            NewIn()
            Form4.SendToServer()
            RichTextBox1.Clear()

            Find()
        End If
    End Sub
#End Region
#Region "寫入資料庫"
    Function WriteIn(tx2 As String)

        '建立連線字串
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None
        '建立查詢字串
        Dim QueryString As String = "INSERT INTO chat(SCname,CCname,Content) VALUES ('" + Me.Text + "','" + Form4.Chatn + "','" + tx2 + "');"

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

#Region "New +1"
    Function NewIn()
        '建立連線字串
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None
        '建立查詢字串
        Dim QueryString1 As String = "SELECT New From list WHERE (SFname='" + Me.Text + "' AND CFname='" + Form4.Chatn + "');"
        '建立資料庫連線物件
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString1

            Try
                '開啟資料庫連線
                Connection.Open()

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Dim a As Integer = 0
                Do While dataReader.Read()
                    SendChat = dataReader(0)
                Loop
                dataReader.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()
            End Try
        End Using
        SendChat += 1
        Dim QueryString As String = "UPDATE list SET New = '" + SendChat.ToString + "' WHERE (SFname = '" + Me.Text + "' AND CFname = '" + Form4.Chatn + "');"

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
#Region "New -1"
    Function NewOut()
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "UPDATE list SET SFname = '" + Form4.Chatn + "', CFname = '" + Me.Text + "', New = '0' WHERE CFname = '" + Me.Text + "' AND SFname = '" + Form4.Chatn + "';"

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
#Region "New Msg"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i As Integer = 0 To msn - 1
            Fl(i).Text = Form4.Fl(i).Text
            If Form4.Fl(i).Tag = "-1" Then
                Fl(i).Visible = False
                Fl(i).Text = "0"
                Form4.Fl(i).Text = "0"
            Else
                Fl(i).Visible = True
            End If
        Next
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Form4.Button1.Text = "1" Then
            Find()
            Form4.Button1.Text = ""
        End If
    End Sub
#End Region
#Region "停止連線 EXIT"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ShowImg Mod 2 = 0 Then
            Form3.Show()
        Else
            Form3.Hide()
        End If
        ShowImg += 1
    End Sub

    Private Sub RichTextBox1_Enter(sender As Object, e As EventArgs)
        If RichTextBox1.Text = "" Then
        Else
            Dim Text1 As String = RichTextBox1.Text
            Dim Text2 As String = ""

            Dim str As String() = Split(Text1, vbLf)
            For i = 0 To str.Length - 1
                If str(i).Length > 12 Then
                    Dim k As Integer
                    If str(i).Length Mod 12 > 0 Then
                        k = 0
                    Else
                        k = 1
                    End If

                    For j = 0 To CInt(str(i).Length / 12) - k
                        If j < (str(i).Length / 12) - 1 Then
                            Text2 = Text2 + Mid(str(i), 1 + (12 * j), 12) + vbNewLine
                        Else
                            Text2 = Text2 + Mid(str(i), 1 + 12 * j, str(i).Length - (12 * j))
                        End If
                    Next
                Else
                    Text2 += str(i)
                End If
                If i = str.Length - 1 Then
                Else
                    Text2 += vbNewLine
                End If
            Next
            WriteIn(Text2)
            NewIn()
            Form4.SendToServer()
            RichTextBox1.Clear()

            Find()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
#End Region

End Class