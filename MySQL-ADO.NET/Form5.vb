Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient
Public Class Form5
    Dim SType As String
    Dim SIP As String
    Dim Num As Integer
    Public SorC As String = ""
    Public CtoS As String = ""
    Dim Fm5IP As String = Form4.MyIP
    Dim qs1 As String = "INSERT INTO room(SId) VALUES ('" + Form4.MyIP + "');"
    Dim first As String = "0"
    Dim Cancel1 As Integer = 0
    Dim frinotplay As Integer = 0
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer2.Enabled = False
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
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "SELECT * FROM room;"
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
                    SIP = dataReader(1).ToString
                    SType = dataReader(2).ToString
                    If SIP <> Fm5IP And SType <> "Play" Then
                        For i = 0 To Form4.msn - 1
                            If Form4.FindName(SIP) = Form4.Fb(i).Text.Trim() Then
                                frinotplay = 1
                                Exit For
                            End If
                        Next
                        If frinotplay = 0 Then
                            qs1 = "UPDATE room SET CType='Play' WHERE num ='" + Num.ToString + "';"
                            SorC = "C"
                            CtoS = SIP
                            CPlayer.ssIP = SIP
                            CPlayer.ccIP = Fm5IP
                            Timer1.Enabled = False
                            Timer2.Enabled = True
                            Exit Do
                        End If
                    ElseIf SIP = Fm5IP And SType = "Play" Then
                        SorC = "S"
                        Timer1.Enabled = False
                        Form4.RndPlay = 1

                        'SPlayer.Show()
                        'SPlayer.Close()
                        SPlayer.Refresh()
                        SPlayer.Show()
                        SPlayer.ssIP = Fm5IP
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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "SELECT * FROM room;"
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
                    SIP = dataReader(1).ToString
                    SType = dataReader(2).ToString
                    If CtoS = SIP And SType = "Play" Then
                        qs1 = "DELETE FROM room WHERE num ='" + Num.ToString + "';"
                        Exit Do
                    End If
                Loop
                dataReader.Close()
                If CtoS = SIP And SType = "Play" Then
                    MyCommand.CommandText = qs1
                    MyCommand.ExecuteNonQuery()
                    CPlayer.Close()
                    Form4.RndPlay = 1

                    'CPlayer.Show()
                    'CPlayer.Refresh()
                    CPlayer.Show()
                    CPlayer.ssIP = SIP
                    CPlayer.ccIP = Fm5IP
                    Me.Hide()
                    Timer2.Enabled = False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub

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
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "SELECT * FROM room;"
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
                    SIP = dataReader(1).ToString
                    SType = dataReader(2).ToString
                    If SIP = Fm5IP And SType <> "Play" Then
                        qs1 = "DELETE FROM room WHERE num ='" + Num.ToString + "';"
                        Exit Do
                    End If
                Loop
                dataReader.Close()
                MyCommand.CommandText = qs1
                MyCommand.ExecuteNonQuery()
                Form4.UserIp(Form4.MyIP, "On")
                Form4.iamIn = 0
                Form4.SendToServer()
                Form4.Show()
                Form4.FriendList()
                Me.Close()
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
            End Try
        End Using
    End Sub
End Class