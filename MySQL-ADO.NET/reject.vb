Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient
Public Class reject
    Dim FrSIP As String = ""
    Dim FrCIP As String = ""
    Dim Num As Integer = 0
    Dim qs1 As String = ""
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
                    FrSIP = dataReader(1).ToString
                    If Form4.MyIP = FrSIP Then
                        qs1 = "DELETE FROM froom WHERE FrNo ='" + Num.ToString + "';"
                        Exit Do
                    End If
                Loop
                dataReader.Close()
                MyCommand.CommandText = qs1
                MyCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
                Form4.UserIp(Form4.MyIP, "On")
                Form4.iamIn = 0
                Form4.SendToServer()
                Form4.Show()
                Me.Close()
                Me.Dispose()
            End Try
        End Using
    End Sub

    Private Sub QQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class