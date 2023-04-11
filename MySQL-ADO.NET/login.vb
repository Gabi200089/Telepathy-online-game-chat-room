Imports MySql.Data.MySqlClient
Public Class login
    Dim password, name As String

    Private Sub passwordText_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles passwordText.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(Button1, New System.EventArgs())
        End If
    End Sub

    'Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
    '    'USname.Text = ""
    '    'passwordText.Text = ""
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        main.Show()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pass
        name = USname.Text
        pass = passwordText.Text

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match" '資料庫名稱為lifemanager
        ConString.Server = "127.0.0.1" '資料庫的IP位置
        ConString.UserID = "user" '資料庫使用者
        ConString.Password = "12345678" '資料庫使用者密碼
        ConString.SslMode = MySqlSslMode.None

        '建立查詢字串
        Dim QueryString As String = "SELECT * From info where Name='" & name & "';"
        '建立資料庫連線物件
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

                'DataSet可以存放多個表格資料，把資料放到 DataSet1 的第一個表格
                Adapter.Fill(DataSet1.Tables(0))

                '如果程式操作期間有對DataSet1中的任何資料做修改且需要更新資料庫，則可利用 update 方法把資料送回MySql Server
                'Adapter.Update(DataSet1)

                '設定繫結資料來源
                BindingSource1.DataSource = DataSet1
                '設定有繫結作用的資料來源中的哪個表格
                BindingSource1.DataMember = DataSet1.Tables(0).ToString

                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    'id = dataReader(0)
                    name = dataReader(0)
                    password = dataReader(3)
                    'ComboBox1.Items.Add(dataReader(0))
                Loop
                dataReader.Close()



                If pass = password Then
                    'MsgBox("恭喜你成功登入",, "成功登入")
                    'MsgBox(id)
                    'MsgBox(name)
                    'USname.Clear()
                    ' passwordText.Clear()

                    'memo.Show()
                    Form4.Text = USname.Text
                    Form4.Show()
                    Me.Hide()
                    'memo.Label3.Text = "歡迎回來!" & vbCrLf & vbCrLf & "我的主人   " & (name) & vbCrLf & vbCrLf & "請問你想看什麼呢?"

                    'MsgBox(name)
                Else
                    'MsgBox(password)
                    MsgBox("輸入錯誤，請重新輸入",, "輸入錯誤")
                    USname.Clear()
                    passwordText.Clear()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                Connection.Close()

            End Try
        End Using
    End Sub
End Class