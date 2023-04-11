<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.volumeoff = New System.Windows.Forms.Button()
        Me.volumeup = New System.Windows.Forms.Button()
        Me.volumedown = New System.Windows.Forms.Button()
        Me.volumeon = New System.Windows.Forms.Button()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.月亮1
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("微軟正黑體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(109, 199)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(142, 143)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "隨機" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "匹配"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.地圖1
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("微軟正黑體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(350, 199)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(152, 143)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "好友" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "對戰"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(55, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(476, 122)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.exit__1_1
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.Location = New System.Drawing.Point(26, 355)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(41, 45)
        Me.Button2.TabIndex = 15
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.聊天1
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(508, 334)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 55)
        Me.Button1.TabIndex = 16
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(581, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 359)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(140, 29)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(75, 23)
        Me.AxWindowsMediaPlayer1.TabIndex = 19
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(580, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(221, 57)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "在線好友列表"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'volumeoff
        '
        Me.volumeoff.BackColor = System.Drawing.Color.Transparent
        Me.volumeoff.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.no_sound
        Me.volumeoff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.volumeoff.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.volumeoff.FlatAppearance.BorderSize = 0
        Me.volumeoff.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.volumeoff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.volumeoff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.volumeoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.volumeoff.Location = New System.Drawing.Point(94, 12)
        Me.volumeoff.Name = "volumeoff"
        Me.volumeoff.Size = New System.Drawing.Size(35, 35)
        Me.volumeoff.TabIndex = 83
        Me.volumeoff.UseVisualStyleBackColor = False
        '
        'volumeup
        '
        Me.volumeup.BackColor = System.Drawing.Color.Transparent
        Me.volumeup.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.volume_up
        Me.volumeup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.volumeup.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.volumeup.FlatAppearance.BorderSize = 0
        Me.volumeup.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.volumeup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.volumeup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.volumeup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.volumeup.Location = New System.Drawing.Point(53, 12)
        Me.volumeup.Name = "volumeup"
        Me.volumeup.Size = New System.Drawing.Size(35, 35)
        Me.volumeup.TabIndex = 82
        Me.volumeup.UseVisualStyleBackColor = False
        '
        'volumedown
        '
        Me.volumedown.BackColor = System.Drawing.Color.Transparent
        Me.volumedown.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.volume_down
        Me.volumedown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.volumedown.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.volumedown.FlatAppearance.BorderSize = 0
        Me.volumedown.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.volumedown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.volumedown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.volumedown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.volumedown.Location = New System.Drawing.Point(12, 12)
        Me.volumedown.Name = "volumedown"
        Me.volumedown.Size = New System.Drawing.Size(35, 35)
        Me.volumedown.TabIndex = 81
        Me.volumedown.UseVisualStyleBackColor = False
        '
        'volumeon
        '
        Me.volumeon.BackColor = System.Drawing.Color.Transparent
        Me.volumeon.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.speaker
        Me.volumeon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.volumeon.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.volumeon.FlatAppearance.BorderSize = 0
        Me.volumeon.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.volumeon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.volumeon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.volumeon.Location = New System.Drawing.Point(94, 12)
        Me.volumeon.Name = "volumeon"
        Me.volumeon.Size = New System.Drawing.Size(35, 35)
        Me.volumeon.TabIndex = 84
        Me.volumeon.UseVisualStyleBackColor = False
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'Form4
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.星空背景1
        Me.ClientSize = New System.Drawing.Size(802, 411)
        Me.ControlBox = False
        Me.Controls.Add(Me.volumeoff)
        Me.Controls.Add(Me.volumeup)
        Me.Controls.Add(Me.volumedown)
        Me.Controls.Add(Me.volumeon)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form4"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents volumeoff As Button
    Friend WithEvents volumeup As Button
    Friend WithEvents volumedown As Button
    Friend WithEvents volumeon As Button
    Friend WithEvents Timer3 As Timer
End Class
