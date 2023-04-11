Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient
Public Class Form7
    Dim State As String = ""
    Dim FrSIP As String = ""
    Dim FrCIP As String = ""
    Dim Num As Integer = 0
    Dim SorC As String = ""
    Dim qs2 As String = ""
    Public FPlay As Integer = 0
    Public ssplay As String = ""
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "SELECT * FROM froom;"
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            Try
                '開啟資料庫連線
                Connection.Open()
                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()

                While dataReader.Read()
                    Num = dataReader(0).ToString
                    FrCIP = dataReader(2).ToString
                    FrSIP = dataReader(1).ToString
                    State = dataReader(3).ToString
                    Label1.Text += Form4.FindName(FrSIP) + ">>" + FrCIP + "::"
                    Label1.Text = "1"
                    If FrCIP = ssplay Then
                        Label1.Text = Form4.FindName(FrSIP) + "對你發出挑戰，是否接受?"
                        Form5.CtoS = FrSIP
                        Exit While
                    Else

                    End If
                End While
                dataReader.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "SELECT * FROM froom;"
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            Try
                '開啟資料庫連線
                Connection.Open()
                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    Num = dataReader(0).ToString
                    FrCIP = dataReader(2).ToString
                    FrSIP = dataReader(1).ToString
                    State = dataReader(3).ToString
                    If FrCIP = Form4.MyIP Then
                        qs2 = "UPDATE froom SET State='Play' WHERE FrNo ='" + Num.ToString + "';"
                        Form5.CtoS = FrSIP
                        Exit Do
                    End If
                Loop
                dataReader.Close()
                If qs2 <> "" Then
                    MyCommand.CommandText = qs2
                    MyCommand.ExecuteNonQuery()
                    CPlayer.Close()
                    '
                    CPlayer.Show()
                    FPlay = 1
                    Me.Close()
                    Me.Dispose()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "SELECT * FROM froom;"
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            Try
                '開啟資料庫連線
                Connection.Open()
                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    Num = dataReader(0).ToString
                    FrCIP = dataReader(2).ToString
                    FrSIP = dataReader(1).ToString
                    State = dataReader(3).ToString
                    If FrCIP = Form4.MyIP Then
                        qs2 = "UPDATE froom SET State='QQ' WHERE FrNo ='" + Num.ToString + "';"
                        Exit Do
                    End If
                Loop
                dataReader.Close()
                If qs2 <> "" Then
                    MyCommand.CommandText = qs2
                    MyCommand.ExecuteNonQuery()
                    Form4.UserIp(Form4.MyIP, "On")
                    Form4.iamIn = 0
                    Form4.SendToServer()
                    Form4.Show()
                    Form4.Timer2.Enabled = True
                    FPlay = 0
                    Me.Close()
                    Me.Dispose()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub
    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.Width = Button1.Width * 1.2
        Button1.Height = Button1.Height * 1.2
        Button1.FlatStyle = FlatStyle.Flat
        'Button1.FlatAppearance.BorderSize = 0
        Button1.BackColor = Color.Transparent
    End Sub
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.Width = Button1.Width / 1.2
        Button1.Height = Button1.Height / 1.2
    End Sub
    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Button2.Width = Button1.Width * 1.2
        Button2.Height = Button1.Height * 1.2
        Button2.FlatStyle = FlatStyle.Flat
        Button2.BackColor = Color.Transparent
    End Sub
    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.Width = Button1.Width / 1.2
        Button2.Height = Button1.Height / 1.2
        Button1.FlatStyle = FlatStyle.Flat
        Button1.BackColor = Color.Transparent
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) 

    End Sub
End Class