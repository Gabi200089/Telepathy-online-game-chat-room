Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient
Public Class data
    Dim head As String
    Public name As String
    Private Sub interest_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub USname_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sql()
        If head = "head1" Then
            PictureBox2.Image = My.Resources.choosehead111
        ElseIf head = "head2" Then
            PictureBox2.Image = My.Resources.choosehead2
        ElseIf head = "head3" Then
            PictureBox2.Image = My.Resources.choosehead3
        ElseIf head = "head4" Then
            PictureBox2.Image = My.Resources.choosehead4
        End If
    End Sub
    Function Sql()
        Dim ConString As New MySqlConnectionStringBuilder
        ConString.Database = "match"
        ConString.Server = "127.0.0.1"
        ConString.UserID = "user"
        ConString.Password = "12345678"
        ConString.SslMode = MySqlSslMode.None

        Dim QueryString As String = "SELECT * FROM info where Name='" & name & "';"
        Using Connection As New MySqlConnection(ConString.ToString)
            '建立送入查詢字串物件
            Dim MyCommand As MySqlCommand = Connection.CreateCommand()
            MyCommand.CommandText = QueryString
            Try
                '開啟資料庫連線
                Connection.Open()
                Dim dataReader As MySqlDataReader = MyCommand.ExecuteReader()
                Do While dataReader.Read()
                    USname.Text = dataReader(0).ToString
                    gender.Text = dataReader(5).ToString
                    interest.Text = dataReader(9).ToString
                    age.Text = dataReader(6).ToString
                    Zodiac.Text = dataReader(7).ToString
                    birthday.Text = dataReader(8).ToString
                    email.Text = dataReader(10).ToString
                    head = dataReader(2).ToString
                Loop
                dataReader.Close()


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection.Close()
            End Try
        End Using
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub
End Class