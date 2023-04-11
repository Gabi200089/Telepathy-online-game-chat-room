Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient
Public Class Form6
    Dim State As String = ""
    Dim FrSIP As String = ""
    Dim FrCIP As String = ""
    Dim Num As Integer = 0
    Dim SorC As String = ""
    Dim qs1 As String = "INSERT INTO froom(FrSIP,FrCIP,State) VALUES ('" + Form4.MyIP + "','" + Form4.RerIp(Form4.ChoosePlayer) + "','Wait');"
    Dim qs2 As String = ""
    Dim first As String = "0"
    Dim Cancel1 As Integer = 0
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer3.Enabled = True
        Button1.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Sql()
    End Sub

    Function Sql()
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "root"
        ConString.Password = ""
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
                    If FrSIP = Form4.MyIP And State = "Play" Then
                        SorC = "S"
                        Timer1.Enabled = False
                        SqlClose()
                        Exit Do
                    ElseIf FrSIP = Form4.MyIP And State = "QQ" Then
                        Timer1.Enabled = False
                        reject.Show()
                        Me.Close()
                        Me.Dispose()
                        Exit Do
                    End If
                Loop
                dataReader.Close()
                If first = "0" Then
                    MyCommand.CommandText = qs1
                    MyCommand.ExecuteNonQuery()
                    first = "1"
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
            End Try
        End Using
        Return True
    End Function

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Cancel1 += 1
        If Cancel1 = 5 Then
            Button1.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = False

        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "root"
        ConString.Password = ""
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
                    FrSIP = dataReader(1).ToString
                    State = dataReader(3).ToString
                    If FrSIP = Form4.MyIP And State = "Wait" Then
                        qs2 = "DELETE FROM froom WHERE FrNo ='" + Num.ToString + "';"
                        Exit Do
                    End If
                Loop
                dataReader.Close()
                If qs2 <> "" Then
                    MyCommand.CommandText = qs2
                    MyCommand.ExecuteNonQuery()
                    Form4.Show()
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
    Function SqlClose()
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "root"
        ConString.Password = ""
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
                    FrSIP = dataReader(1).ToString
                    State = dataReader(3).ToString
                    If Form4.MyIP = FrSIP And State = "Play" Then
                        qs2 = "DELETE FROM froom WHERE FrNo ='" + Num.ToString + "';"
                        Exit Do
                    End If
                Loop
                dataReader.Close()
                If Form4.MyIP = FrSIP And State = "Play" Then
                    MyCommand.CommandText = qs2
                    MyCommand.ExecuteNonQuery()
                    SPlayer.Close()
                    SPlayer.Show()
                    Me.Close()
                    Me.Dispose()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
            End Try
        End Using
    End Function

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class