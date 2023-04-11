Imports MySql.Data.MySqlClient

Public Class register
    Dim username As String
    Public choose As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim b As Boolean
        Dim emailrevise As String
        Dim repeat = 1



        b = email.Text.Contains("@") And email.Text.Contains(".com")
        If b = True Then
            username = USname.Text
        Else
            MsgBox("email格式錯誤喔> <|||",, "提示訊息")
            email.Clear()
            Exit Sub
        End If


        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "SELECT * From info where Name='" & username & "';"
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            Try
                '開啟資料庫連線
                Connection.Open()

                '建立資料表橋接器
                Dim Adapter As New MySqlDataAdapter()
                '送出給MySql Server 執行的 SQL 指令
                Adapter.SelectCommand = MyCommand

                'Dim qs1 As String = "insert into clientip(username,IP)values('" &  & "','" &  & "');"
                'INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`) VALUES ('', NULL, '', '', '', '', '', '', '', '', '');
                'Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                'cmd.ExecuteNonQuery()

                Adapter.Fill(DataSet1.Tables(0))

                '設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString
                '    'DataGridView 跟 ComboBox 透過 BindingSource做繫結，之後兩者的資料會連動，也就是在ComboBox選擇某資料項 DataGridView 會將該筆資料反藍，反之亦然
                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    If username = dataReader(0) Then
                        MsgBox("此暱稱已註冊過，請重新輸入暱稱")
                        repeat = 0
                        Exit Do
                    End If

                Loop
                dataReader.Close()

                If repeat = 0 Then
                    USname.Clear()
                    gender.Clear()
                    birthday.Clear()
                    age.Clear()
                    Zodiac.Clear()
                    interest.Clear()
                    email.Clear()
                    password.Clear()
                    password2.Clear()
                    PictureBox2.Image = My.Resources.chooseheadnone
                ElseIf repeat = 1 Then

                    Dim qs1 As String = "insert into info(HeadPic,Name,Gender,Birth,YearOld,Zodiac,Interest,Mail,Password)values('" & choose & "','" & USname.Text & "','" & gender.Text & "','" & birthday.Text & "','" & age.Text & "','" & Zodiac.Text & "','" & interest.Text & "','" & email.Text & "','" & password.Text & "');"
                    Dim cmd As MySqlCommand = New MySqlCommand(qs1, Connection)
                    MsgBox("恭喜你註冊成功，請重新登入",, "註冊資訊")
                    USname.Clear()
                    gender.Clear()
                    birthday.Clear()
                    age.Clear()
                    Zodiac.Clear()
                    interest.Clear()
                    email.Clear()
                    password.Clear()
                    password2.Clear()
                    cmd.ExecuteNonQuery()
                    Me.Close()
                    'start.Show()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()

            End Try
        End Using
        Me.Hide()
        main.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        choosehead.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        main.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        USname.Text = "張小義"
        gender.Text = "男"
        interest.Text = "扣丁"
        age.Text = "20"
        Zodiac.Text = "獅子座"
        birthday.Text = "2000/8/8"
        email.Text = "123@.com"
        password.Text = "123"
        password2.Text = "123"
    End Sub
End Class
