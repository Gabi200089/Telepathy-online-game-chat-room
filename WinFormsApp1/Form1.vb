Imports MySql.Data.MySqlClient
Imports MySqlConnector
'先去下載安裝 MySQL Connector 在執行此程式的電腦上
'https://dev.mysql.com/downloads/connector/net/
'然後把MySql.Data.dll 匯入專案參考 (C:\Program Files (x86)\MySQL\MySQL Connector Net 8.0.11\Assemblies\v4.5.2)
Imports System.IO
Imports System.Net
Imports System.Net.Sockets


Public Class Form1
    Dim ServerStatus As Boolean = False
    Dim ServerTrying As Boolean = False
    Dim Server As TcpListener
    Dim Clients As New List(Of TcpClient)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StartServer()
    End Sub

    Function StartServer()
        If ServerStatus = False Then
            ServerTrying = True
            Try
                Server = New TcpListener(IPAddress.Any, 4305)
                Server.Start()
                ServerStatus = True
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                RichTextBox1.Text += "伺服器建立成功" + vbLf
            Catch ex As Exception
                ServerStatus = False
            End Try
            ServerTrying = False
        End If

        Return True
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StopServer()
        RichTextBox1.Text += "伺服器中斷" + vbLf
    End Sub

    Function StopServer()
        If ServerStatus = True Then
            ServerTrying = True
            Try
                For Each Client As TcpClient In Clients
                    Client.Close()
                Next
                Server.Stop()
                ServerStatus = False
            Catch ex As Exception
                StopServer()
            End Try
            ServerTrying = False
        End If

        Return True
    End Function

    Function Handler_Client(ByVal State As Object)
        Dim TempClient As TcpClient
        Try
            Using Client As TcpClient = Server.AcceptTcpClient
                If ServerTrying = False Then
                    Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                End If

                Clients.Add(Client)

                RichTextBox1.Text += Client.Client.RemoteEndPoint.ToString + "已連線" + vbLf

                TempClient = Client
                Dim TX As New StreamWriter(Client.GetStream)
                Dim RX As New StreamReader(Client.GetStream)
                Try
                    If RX.BaseStream.CanRead = True Then
                        While RX.BaseStream.CanRead = True
                            Dim RawData As String = RX.ReadLine
                            Dim str As String() = Split(RawData, ";")
                            If Client.Client.Connected = True AndAlso Client.Connected = True AndAlso Client.GetStream.CanRead = True Then
                                If str(1) = "Close" Then
                                    If Clients.Contains(Client) Then
                                        Clients.Remove(Client)
                                        Client.Close()
                                    End If
                                    Exit While
                                Else
                                    Threading.ThreadPool.QueueUserWorkItem(AddressOf SendToClients, RawData)
                                End If
                            End If
                        End While
                    End If
                Catch ex As Exception
                    If Clients.Contains(Client) Then
                        Clients.Remove(Client)
                        Client.Close()
                    End If
                End Try
                'If RX.BaseStream.CanRead = False Then
                '
                'End If
            End Using
            If Clients.Contains(TempClient) Then
                Clients.Remove(TempClient)
                TempClient.Close()
            End If
        Catch ex As Exception
            If Clients.Contains(TempClient) Then
                Clients.Remove(TempClient)
                TempClient.Close()
            End If
        End Try
    End Function

    Function SendToClients(Data As String)
        Dim str As String() = Split(Data, ";")
        If ServerStatus = True Then
                If Clients.Count > 0 Then
                    Try
                        For Each Client As TcpClient In Clients
                        If Client.Client.RemoteEndPoint.ToString = str(1) Then
                            RichTextBox1.Text += str(0) + "傳送訊息給" + str(1)
                            Dim TX1 As New StreamWriter(Client.GetStream)
                            TX1.WriteLine(str(0))
                            TX1.Flush()
                        ElseIf str(1) = "NewIn" And Client.Client.RemoteEndPoint.ToString <> str(0) Then
                            Dim TX1 As New StreamWriter(Client.GetStream)
                            TX1.WriteLine(str(1))
                            TX1.Flush()
                        ElseIf str(1) = "Fight" And Client.Client.RemoteEndPoint.ToString = str(0) Then
                            Dim TX1 As New StreamWriter(Client.GetStream)
                            TX1.WriteLine(str(1))
                            TX1.Flush()
                        End If
                        Next
                    Catch ex As Exception
                        SendToClients(Data)
                    End Try
                End If
            End If
            Return True
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Clients.Count.ToString
    End Sub

End Class
