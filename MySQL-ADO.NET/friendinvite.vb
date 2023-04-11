Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient
Public Class friendinvite
    Public FfState As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None
        Dim QueryString As String = ""
        Dim qs1 As String = ""
        Dim qss1 As String = ""
        Dim qss2 As String = ""
        Dim SIP As String = ""
        Dim CIP As String = ""
        Dim SCType As String = ""
        If FfState = "S" Then
            QueryString = "SELECT * FROM confirm WHERE SName='" + SPlayer.ssIP + "';"
        ElseIf FfState = "C" Then
            QueryString = "SELECT * FROM confirm WHERE SName='" + CPlayer.ssIP + "' AND CName='" + CPlayer.ccIP + "';"
        End If
        If QueryString <> "" Then
            Using Connection As New MySqlConnection(ConString.ToString)
                '建立送入查詢字串物件
                Dim MyCommand As MySqlCommand = Connection.CreateCommand()
                MyCommand.CommandText = QueryString
                Try
                    '開啟資料庫連線
                    Connection.Open()
                    Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                    Do While dataReader.Read()
                        SIP = dataReader(0).ToString
                        CIP = dataReader(1).ToString
                        SCType = dataReader(2).ToString
                        If SIP <> "" Then
                            Exit Do
                        End If
                    Loop
                    If FfState = "S" And SCType = "wait" Then
                        qs1 = "UPDATE confirm SET Status='Sok' WHERE SName='" + SPlayer.ssIP + "';"
                    ElseIf FfState = "S" And SCType = "Cok" Then
                        qs1 = "DELETE FROM confirm WHERE SName ='" + SPlayer.ssIP + "';"
                        qss1 = "INSERT INTO list(SFname,CFname,New) VALUES ('" + Form4.FindName(SPlayer.ssIP) + "','" + Form4.FindName(CIP) + "','0');"
                        qss2 = "INSERT INTO list(SFname,CFname,New) VALUES ('" + Form4.FindName(CIP) + "','" + Form4.FindName(SPlayer.ssIP) + "','0');"
                    ElseIf FfState = "C" And SCType = "wait" Then
                        qs1 = "UPDATE confirm SET Status='Cok' WHERE CName='" + CPlayer.ccIP + "';"
                    ElseIf FfState = "C" And SCType = "Sok" Then
                        qs1 = "DELETE FROM confirm WHERE CName ='" + CPlayer.ccIP + "';"
                        qss1 = "INSERT INTO list(SFname,CFname,New) VALUES ('" + Form4.FindName(CPlayer.ccIP) + "','" + Form4.FindName(CPlayer.ssIP) + "','0');"
                        qss2 = "INSERT INTO list(SFname,CFname,New) VALUES ('" + Form4.FindName(CPlayer.ssIP) + "','" + Form4.FindName(CPlayer.ccIP) + "','0');"
                    End If
                    dataReader.Close()
                    If qs1 <> "" Then
                        MyCommand.CommandText = qs1
                        MyCommand.ExecuteNonQuery()
                    End If

                    If qss1 <> "" Then
                        MyCommand.CommandText = qss1
                        MyCommand.ExecuteNonQuery()
                    End If

                    If qss2 <> "" Then
                        MyCommand.CommandText = qss2
                        MyCommand.ExecuteNonQuery()
                    End If

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
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None
        Dim QueryString As String = ""
        Dim qs1 As String = ""
        Dim qss1 As String = ""
        Dim qss2 As String = ""
        Dim SIP As String = ""
        Dim CIP As String = ""
        Dim SCType As String = ""
        If FfState = "S" Then
            QueryString = "SELECT * FROM confirm WHERE SName='" + SPlayer.ssIP + "';"
        ElseIf FfState = "C" Then
            QueryString = "SELECT * FROM confirm WHERE SName='" + CPlayer.ssIP + "' AND CName='" + CPlayer.ccIP + "';"
        End If
        If QueryString <> "" Then
            Using Connection As New MySqlConnection(ConString.ToString)
                '建立送入查詢字串物件
                Dim MyCommand As MySqlCommand = Connection.CreateCommand()
                MyCommand.CommandText = QueryString
                Try
                    '開啟資料庫連線
                    Connection.Open()
                    Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                    Do While dataReader.Read()
                        SIP = dataReader(0).ToString
                        CIP = dataReader(1).ToString
                        SCType = dataReader(2).ToString
                        If SIP <> "" Then
                            Exit Do
                        End If
                    Loop
                    If FfState = "S" Then
                        qs1 = "DELETE FROM confirm WHERE SName ='" + SPlayer.ssIP + "';"
                    ElseIf FfState = "C" Then
                        qs1 = "DELETE FROM confirm WHERE SName='" + CPlayer.ssIP + "'AND CName ='" + CPlayer.ccIP + "';"
                    End If
                    dataReader.Close()
                    If qs1 <> "" Then
                        MyCommand.CommandText = qs1
                        MyCommand.ExecuteNonQuery()
                    End If
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
        End If
    End Sub

    Private Sub friendinvite_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class