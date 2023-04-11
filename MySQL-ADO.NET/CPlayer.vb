Imports System.IO
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient

Public Class CPlayer
    Dim Client As TcpClient
    Dim RX As StreamReader
    Dim TX As StreamWriter
    Dim choose As String = ""

    Dim j As Integer = 0
    Dim a(9)
    Dim topic As String
    Dim t3 As Integer = 0
    Dim travelQ(9) As String
    Dim travelA(9, 1) As String
    Dim foodQ(9) As String
    Dim foodA(9, 1) As String
    Dim ideaQ(9) As String
    Dim ideaA(9, 1) As String
    Dim brandQ(9) As String
    Dim brandA(9, 1) As String
    Dim otherQ(9) As String
    Dim otherA(9, 1) As String
    Dim time As Integer = 6
    Dim score As Integer = 0
    Dim stage As String = ""
    Dim time2 As Integer = 5

    Dim IPP As String = Form5.CtoS
    Dim SsStage As String = ""
    Dim SsTopic As String = ""
    Dim SsQnum As String = ""
    Dim Cchoose As String = ""
    Dim SsChoose As String = ""

    Public ssIP As String = ""
    Public ccIP As String = ""

    Public closeCP As Integer = 0
    Dim MsgFst As Integer = 0

    Private Sub CPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(0, 0)
        QLabel.Text = ""
        ButtonA1.Text = ""
        ButtonA2.Text = ""
        TLabel.Text = time2
        STopic.Text = ""
        Panel1.BringToFront()
        CheckForIllegalCrossThreadCalls = False

        Timer2.Enabled = True
        Try
            Dim str As String() = Split(IPP, ":")
            Client = New TcpClient(str(0), 4310)
            If Client.GetStream.CanRead = True Then
                RX = New StreamReader(Client.GetStream)
                TX = New StreamWriter(Client.GetStream)
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Connected)
            End If
        Catch ex As Exception
        End Try
#Region "Travel題目"
        travelQ(0) = "最想去的國家?"
        travelQ(1) = "如果要旅行會選擇?"
        travelQ(2) = "來嘉義旅遊必吃?"
        travelQ(3) = "偏好去哪裡旅遊?"
        travelQ(4) = "旅行喜歡?"
        travelQ(5) = "最想去的海島國家?"
        travelQ(6) = "旅行時間長短?"
        travelQ(7) = "選擇旅伴?"
        travelQ(8) = "假日出去玩?"
        travelQ(9) = "我想要去?"
#End Region
#Region "Travel答案"
        travelA(0, 0) = "日本"
        travelA(0, 1) = "韓國"
        travelA(1, 0) = "跟團"
        travelA(1, 1) = "自由行"
        travelA(2, 0) = "火雞肉飯"
        travelA(2, 1) = "砂鍋魚頭"
        travelA(3, 0) = "都市"
        travelA(3, 1) = "鄉村"
        travelA(4, 0) = "事先規劃"
        travelA(4, 1) = "說走就走"
        travelA(5, 0) = "峇厘島"
        travelA(5, 1) = "馬爾地夫"
        travelA(6, 0) = "兩天一夜"
        travelA(6, 1) = "四天三夜"
        travelA(7, 0) = "朋友"
        travelA(7, 1) = "家人"
        travelA(8, 0) = "遊樂園"
        travelA(8, 1) = "動物園"
        travelA(9, 0) = "山上"
        travelA(9, 1) = "海邊"
#End Region
#Region "Food題目"
        foodQ(0) = "薯條要吃?"
        foodQ(1) = "陽春麵要吃?"
        foodQ(2) = "Pocky要吃什麼口味?"
        foodQ(3) = "黑糖珍珠鮮奶要喝?"
        foodQ(4) = "嘉義豆花要吃?"
        foodQ(5) = "奶茶要加?"
        foodQ(6) = "天冷要吃?"
        foodQ(7) = "糖果喜歡吃?"
        foodQ(8) = "義大利麵加什麼醬?"
        foodQ(9) = "選一種主食?"
#End Region
#Region "Food答案"
        foodA(0, 0) = "麥當勞"
        foodA(0, 1) = "肯德基"
        foodA(1, 0) = "乾的"
        foodA(1, 1) = "濕的"
        foodA(2, 0) = "草莓"
        foodA(2, 1) = "巧克力"
        foodA(3, 0) = "老虎堂"
        foodA(3, 1) = "珍煮丹"
        foodA(4, 0) = "陳品豆花"
        foodA(4, 1) = "品安豆花"
        foodA(5, 0) = "大波霸"
        foodA(5, 1) = "小珍珠"
        foodA(6, 0) = "火鍋"
        foodA(6, 1) = "燒烤"
        foodA(7, 0) = "硬糖"
        foodA(7, 1) = "軟糖"
        foodA(8, 0) = "白醬"
        foodA(8, 1) = "紅醬"
        foodA(9, 0) = "飯"
        foodA(9, 1) = "麵"
#End Region
#Region "Idea題目"
        ideaQ(0) = "較偏好對象?"
        ideaQ(1) = "喜歡比自己?"
        ideaQ(2) = "希望對方為?"
        ideaQ(3) = "想選擇哪種對象?"
        ideaQ(4) = "第一眼會看?"
        ideaQ(5) = "較偏好以下何者?"
        ideaQ(6) = "比較喜歡何種類型?"
        ideaQ(7) = "喜歡以下何種個性的人?"
        ideaQ(8) = "以下何種人讓你最不能接受?"
        ideaQ(9) = "喜歡的女生類型"
#End Region
#Region "Idea答案"
        ideaA(0, 0) = "文青型"
        ideaA(0, 1) = "陽光型"
        ideaA(1, 0) = "年齡大"
        ideaA(1, 1) = "年齡小"
        ideaA(2, 0) = "霸氣外露"
        ideaA(2, 1) = "可愛小狗狗"
        ideaA(3, 0) = "好看的廢物(花瓶)"
        ideaA(3, 1) = "長相欠佳的能力者"
        ideaA(4, 0) = "臉"
        ideaA(4, 1) = "身材"
        ideaA(5, 0) = "有錢"
        ideaA(5, 1) = "有內涵"
        ideaA(6, 0) = "白裡透紅"
        ideaA(6, 1) = "健康小麥色"
        ideaA(7, 0) = "喜歡刺激、勇於冒險的人"
        ideaA(7, 1) = "穩健踏實、做好每一步的人"
        ideaA(8, 0) = "小氣又囉嗦的人"
        ideaA(8, 1) = "做事隨便的人"
        ideaA(9, 0) = "長髮"
        ideaA(9, 1) = "短髮"
#End Region
#Region "Brand題目"
        brandQ(0) = "汽車品牌?"
        brandQ(1) = "運動用品品牌?"
        brandQ(2) = "音樂平台?"
        brandQ(3) = "衛生紙品牌?"
        brandQ(4) = "量販店品牌?"
        brandQ(5) = "電腦品牌?"
        brandQ(6) = "國際精品?"
        brandQ(7) = "手機品牌?"
        brandQ(8) = "服飾品牌?"
        brandQ(9) = "百貨公司?"
#End Region
#Region "Brand答案"
        brandA(0, 0) = "BMW"
        brandA(0, 1) = "賓士"
        brandA(1, 0) = "Nike"
        brandA(1, 1) = "Adidas"
        brandA(2, 0) = "KKbox"
        brandA(2, 1) = "Spotify"
        brandA(3, 0) = "舒潔"
        brandA(3, 1) = "五月花"
        brandA(4, 0) = "家樂福"
        brandA(4, 1) = "大潤發"
        brandA(5, 0) = "Asus"
        brandA(5, 1) = "Acer"
        brandA(6, 0) = "Gucci"
        brandA(6, 1) = "LV"
        brandA(7, 0) = "Apple"
        brandA(7, 1) = "Samsung"
        brandA(8, 0) = "H&M"
        brandA(8, 1) = "Zara"
        brandA(9, 0) = "新光三越"
        brandA(9, 1) = "大遠百"
#End Region
#Region "Other題目"
        otherQ(0) = "選一種顏色?"
        otherQ(1) = "選一種遊戲?"
        otherQ(2) = "選一種寵物?"
        otherQ(3) = "選一種形狀?"
        otherQ(4) = "選一家餐廳?"
        otherQ(5) = "選一個季節?"
        otherQ(6) = "選一種類型的音樂?"
        otherQ(7) = "選一個節日?"
        otherQ(8) = "選一部電影?"
        otherQ(9) = "選一個程式語言"
#End Region
#Region "Other答案"
        otherA(0, 0) = "黃色"
        otherA(0, 1) = "藍色"
        otherA(1, 0) = "益智類"
        otherA(1, 1) = "動作類"
        otherA(2, 0) = "貓咪"
        otherA(2, 1) = "狗勾"
        otherA(3, 0) = "正方形"
        otherA(3, 1) = "圓形"
        otherA(4, 0) = "逐鹿"
        otherA(4, 1) = "大潤發"
        otherA(5, 0) = "冬天"
        otherA(5, 1) = "夏天"
        otherA(6, 0) = "華語"
        otherA(6, 1) = "英語"
        otherA(7, 0) = "端午節"
        otherA(7, 1) = "中秋節"
        otherA(8, 0) = "動物方程式"
        otherA(8, 1) = "玩具總動員"
        otherA(9, 0) = "VB"
        otherA(9, 1) = "JAVA"
#End Region
        Randomize()
        Label2.Text = time
        Label3.Text = score.ToString
    End Sub
#Region "選項點擊"
    Private Sub ButtonA1_Click(sender As Object, e As EventArgs) Handles ButtonA1.Click
        If Timer1.Enabled = True Then
            ButtonA1.BackgroundImage = My.Resources.answer_cilck
            ButtonA2.Enabled = False
            ButtonA1.Enabled = False
            choose = 1
            Dim CChoose As String = "Choose:" + choose
            SendToServer(CChoose)
        End If

    End Sub
    Private Sub ButtonA2_Click(sender As Object, e As EventArgs) Handles ButtonA2.Click
        If Timer1.Enabled = True Then
            ButtonA2.BackgroundImage = My.Resources.answer_cilck
            ButtonA1.Enabled = False
            ButtonA2.Enabled = False
            choose = 2
            Dim CChoose As String = "Choose:" + choose
            SendToServer(Cchoose)
        End If
    End Sub
#End Region
#Region "Connected"
    Public Function Connected()
        If RX.BaseStream.CanRead = True Then
            Try
                While RX.BaseStream.CanRead = True
                    Dim RawData As String = RX.ReadLine
                    Dim str As String() = Split(RawData, ":")
                    If str(0) = "Stage" Then
                        SsStage = str(1)
                    ElseIf str(0) = "Topic" Then
                        SsTopic = str(1)
                    ElseIf str(0) = "Qnum" Then
                        SsQnum = str(1)
                    ElseIf str(0) = "Choose" Then
                        SsChoose = str(1)
                    End If
                End While
            Catch ex As Exception
                Client.Close()
            End Try
        End If
        Return True
    End Function
#End Region
#Region "SendToServer"
    Function SendToServer(ByVal Data As String)
        Try
            TX.WriteLine(Data)
            TX.Flush()
            If closeCP = 1 Then
                closeCP = 0
            End If
        Catch ex As Exception

        End Try
        Return True
    End Function
#End Region
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Application.Exit()
    End Sub
#Region "Choose Stage"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        stage = "TRAVEL"
        Dim text As String = "Stage:" + stage
        SendToServer(text)
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        stage = "FOOD"
        Dim text As String = "Stage:" + stage
        SendToServer(text)
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
    End Sub
#End Region
#Region "選主題時間"
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        time2 -= 1
        TLabel.Text = time2
        If time2 = 0 Then
            Timer2.Enabled = False
            Timer3.Enabled = True
        End If
    End Sub
#End Region
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick  '倒數計時
        If time = 6 Then
            ButtonA1.Visible = True
            ButtonA2.Visible = True
            QLabel.Visible = True

            ButtonA1.BackgroundImage = My.Resources.answer
            ButtonA2.BackgroundImage = My.Resources.answer
            If topic = "TRAVEL" Then
                QLabel.Text = travelQ(a(j))
                ButtonA1.Text = travelA(a(j), 0)
                ButtonA2.Text = travelA(a(j), 1)
            ElseIf topic = "FOOD" Then
                QLabel.Text = foodQ(a(j))
                ButtonA1.Text = foodA(a(j), 0)
                ButtonA2.Text = foodA(a(j), 1)
            ElseIf topic = "IDEA" Then
                QLabel.Text = ideaQ(a(j))
                ButtonA1.Text = ideaA(a(j), 0)
                ButtonA2.Text = ideaA(a(j), 1)
            ElseIf topic = "BRAND" Then
                QLabel.Text = brandQ(a(j))
                ButtonA1.Text = brandA(a(j), 0)
                ButtonA2.Text = brandA(a(j), 1)
            ElseIf topic = "OTHER" Then
                QLabel.Text = otherQ(a(j))
                ButtonA1.Text = otherA(a(j), 0)
                ButtonA2.Text = otherA(a(j), 1)
            End If
            ButtonA1.Enabled = True
            ButtonA2.Enabled = True
        End If
        time -= 1
        If time >= 0 Then
            Label2.Text = time
        ElseIf time = -1 Then
            ButtonA1.BackgroundImage = My.Resources.answer
            ButtonA2.BackgroundImage = My.Resources.answer
            If choose = SsChoose And choose <> "" Then
                score = score + 20
                Label3.Text = score.ToString
            Else
                If SsChoose = "1" Then
                    ButtonA1.BackgroundImage = My.Resources.answer_wrong
                ElseIf SsChoose = "2" Then
                    ButtonA2.BackgroundImage = My.Resources.answer_wrong
                End If
            End If
        ElseIf time = -3 Then
            time = 6
            j += 1
            choose = ""
            SsChoose = ""
        End If
        If j = 5 Then
            Timer1.Enabled = False
            ButtonA1.Visible = False
            ButtonA2.Visible = False
            STopic.Visible = False
            STopicDis.Visible = False
            TLabel.Visible = False
            QLabel.Visible = False
            Label3.Text = "默契指數:" + score.ToString
            If score.ToString >= 60 Then
                If Form4.RndPlay = 1 Then
                    InsertFriendInvite()
                    friendinvite.FfState = "C"
                    friendinvite.Show()
                    Form4.RndPlay = 0
                    closeCP = 1
                    Dim xyz As String = "Close:Close"
                    SendToServer(xyz)
                    If closeCP = 0 Then
                        Client.Close()
                        Me.Hide()
                    End If
                Else
                    If MsgFst = 0 Then
                        MsgFst += 1
                        Dim RST = MsgBox("默契很好诶!", MsgBoxStyle.OkOnly, "GOOD")
                        If RST = MsgBoxResult.Ok Then
                            Form4.UserIp(Form4.MyIP, "On")
                            Form4.iamIn = 0
                            Form4.SendToServer()
                            Form4.Show()
                            closeCP = 1
                            Dim xyz As String = "Close:Close"
                            SendToServer(xyz)
                            If closeCP = 0 Then
                                Client.Close()
                                Me.Hide()
                            End If
                        End If
                    End If

                End If
            Else
                If Form4.RndPlay = 1 Then
                    If MsgFst = 0 Then
                        MsgFst += 1
                        Dim RST = MsgBox("很可惜你們默契未達標準QQ，日後有緣再見", MsgBoxStyle.OkOnly, "GoodBye")
                        If RST = MsgBoxResult.Ok Then
                            Form4.UserIp(Form4.MyIP, "On")
                            Form4.iamIn = 0
                            Form4.SendToServer()
                            Form4.Show()
                            Form4.RndPlay = 0
                            closeCP = 1
                            Dim xyz As String = "Close:Close"
                            SendToServer(xyz)
                            If closeCP = 0 Then
                                Client.Close()
                                Me.Hide()
                            End If
                        End If
                    End If
                Else
                    If MsgFst = 0 Then
                        MsgFst += 1
                        Dim RST = MsgBox("你們確定是朋友?", MsgBoxStyle.OkOnly, "GoodBye")
                        If RST = MsgBoxResult.Ok Then
                            Form4.UserIp(Form4.MyIP, "On")
                            Form4.iamIn = 0
                            Form4.SendToServer()
                            Form4.Show()
                            closeCP = 1
                            Dim xyz As String = "Close:Close"
                            SendToServer(xyz)
                            If closeCP = 0 Then
                                Client.Close()
                                Me.Hide()
                            End If
                        End If
                    End If
                End If

            End If
        End If
    End Sub
#Region "主題公布時間"
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        t3 = t3 + 1
        If t3 = 1 Then
            STopic.Visible = True
            STopicDis.Visible = True
            STopic.Text = SsStage
        End If

        If t3 = 2 Then
            Label4.Visible = True
            If stage = SsStage Then
                Label4.Text = "雙方選擇的為主題:" + stage + "(遊戲將5秒後開始)"
            Else
                Label4.Text = "雙方選擇的主題不同，將由系統隨機選取~" + "(遊戲將5秒後開始)"
            End If
        ElseIf t3 = 5 Then
            topic = SsTopic
        ElseIf t3 = 8 Then
            Panel1.Visible = False '選完關卡
            Label2.Text = "5"
            Label3.Text = "0"
            ButtonA1.Visible = False
            ButtonA2.Visible = False
            QLabel.Visible = False
            If SsQnum = "1" Then
                Rand1()
            ElseIf SsQnum = "2" Then
                Rand2()
            ElseIf SsQnum = "3" Then
                Rand3()
            ElseIf SsQnum = "4" Then
                Rand4()
            End If
            Timer3.Enabled = False
            Timer1.Enabled = True
        End If
    End Sub
#End Region
    Private Function InsertFriendInvite()
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim qs1 As String = "INSERT INTO confirm(SName,CName,Status) VALUES ('" + ssIP + "','" + ccIP + "','wait');"
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = qs1
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
#Region "rand1~4"
    Private Sub Rand1()
#Region "亂數"
        a(0) = 1
        a(1) = 3
        a(2) = 5
        a(3) = 7
        a(4) = 9
        a(5) = 2
        a(6) = 4
        a(7) = 6
        a(8) = 8
        a(9) = 0
#End Region

    End Sub
    Private Sub Rand2()
#Region "亂數"
        a(0) = 0
        a(1) = 2
        a(2) = 4
        a(3) = 6
        a(4) = 8
        a(5) = 1
        a(6) = 3
        a(7) = 5
        a(8) = 7
        a(9) = 9
#End Region

    End Sub
    Private Sub Rand3()
#Region "亂數"
        a(0) = 3
        a(1) = 6
        a(2) = 9
        a(3) = 2
        a(4) = 8
        a(5) = 4
        a(6) = 1
        a(7) = 7
        a(8) = 5
        a(9) = 0
#End Region

    End Sub
    Private Sub Rand4()
#Region "亂數"
        a(0) = 2
        a(1) = 3
        a(2) = 4
        a(3) = 5
        a(4) = 6
        a(5) = 7
        a(6) = 8
        a(7) = 9
        a(8) = 0
        a(9) = 1
#End Region
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
#End Region
End Class