<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CPlayer
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
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.QLabel = New System.Windows.Forms.Label()
        Me.scoreLabel = New System.Windows.Forms.Label()
        Me.ButtonA2 = New System.Windows.Forms.Button()
        Me.ButtonA1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.STopicDis = New System.Windows.Forms.Label()
        Me.STopic = New System.Windows.Forms.Label()
        Me.TLabel = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.BackColor = System.Drawing.Color.Transparent
        Me.TimeLabel.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLabel.ForeColor = System.Drawing.Color.Gold
        Me.TimeLabel.Location = New System.Drawing.Point(717, -48)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(49, 38)
        Me.TimeLabel.TabIndex = 56
        Me.TimeLabel.Text = "10"
        '
        'QLabel
        '
        Me.QLabel.AutoSize = True
        Me.QLabel.BackColor = System.Drawing.Color.Transparent
        Me.QLabel.Font = New System.Drawing.Font("微軟正黑體", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.QLabel.ForeColor = System.Drawing.Color.White
        Me.QLabel.Location = New System.Drawing.Point(244, 33)
        Me.QLabel.Name = "QLabel"
        Me.QLabel.Size = New System.Drawing.Size(158, 50)
        Me.QLabel.TabIndex = 55
        Me.QLabel.Text = "QLabel"
        Me.QLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'scoreLabel
        '
        Me.scoreLabel.AutoSize = True
        Me.scoreLabel.BackColor = System.Drawing.Color.Transparent
        Me.scoreLabel.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scoreLabel.ForeColor = System.Drawing.Color.White
        Me.scoreLabel.Location = New System.Drawing.Point(-12, -48)
        Me.scoreLabel.Name = "scoreLabel"
        Me.scoreLabel.Size = New System.Drawing.Size(87, 35)
        Me.scoreLabel.TabIndex = 54
        Me.scoreLabel.Text = "score:"
        '
        'ButtonA2
        '
        Me.ButtonA2.BackColor = System.Drawing.Color.Transparent
        Me.ButtonA2.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.answer
        Me.ButtonA2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonA2.FlatAppearance.BorderSize = 0
        Me.ButtonA2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.ButtonA2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonA2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButtonA2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonA2.Font = New System.Drawing.Font("微軟正黑體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonA2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonA2.Location = New System.Drawing.Point(217, 211)
        Me.ButtonA2.Name = "ButtonA2"
        Me.ButtonA2.Size = New System.Drawing.Size(332, 111)
        Me.ButtonA2.TabIndex = 53
        Me.ButtonA2.TabStop = False
        Me.ButtonA2.Text = "Button7"
        Me.ButtonA2.UseMnemonic = False
        Me.ButtonA2.UseVisualStyleBackColor = False
        '
        'ButtonA1
        '
        Me.ButtonA1.BackColor = System.Drawing.Color.Transparent
        Me.ButtonA1.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.answer
        Me.ButtonA1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonA1.FlatAppearance.BorderSize = 0
        Me.ButtonA1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.ButtonA1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonA1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButtonA1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonA1.Font = New System.Drawing.Font("微軟正黑體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ButtonA1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButtonA1.Location = New System.Drawing.Point(217, 95)
        Me.ButtonA1.Name = "ButtonA1"
        Me.ButtonA1.Size = New System.Drawing.Size(332, 110)
        Me.ButtonA1.TabIndex = 52
        Me.ButtonA1.TabStop = False
        Me.ButtonA1.Text = "Button6"
        Me.ButtonA1.UseMnemonic = False
        Me.ButtonA1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 39.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(258, 50)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 67)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "請選擇主題"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.其他1
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("微軟正黑體", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button5.Location = New System.Drawing.Point(489, 274)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(137, 123)
        Me.Button5.TabIndex = 18
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.品牌1
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("微軟正黑體", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button4.Location = New System.Drawing.Point(163, 276)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(137, 123)
        Me.Button4.TabIndex = 17
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.理想型1
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("微軟正黑體", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button3.Location = New System.Drawing.Point(639, 164)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(145, 118)
        Me.Button3.TabIndex = 16
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(17, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'STopicDis
        '
        Me.STopicDis.AutoSize = True
        Me.STopicDis.BackColor = System.Drawing.Color.Transparent
        Me.STopicDis.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.STopicDis.ForeColor = System.Drawing.Color.Transparent
        Me.STopicDis.Location = New System.Drawing.Point(16, 12)
        Me.STopicDis.Name = "STopicDis"
        Me.STopicDis.Size = New System.Drawing.Size(142, 21)
        Me.STopicDis.TabIndex = 14
        Me.STopicDis.Text = "對方選擇的關卡為:"
        Me.STopicDis.Visible = False
        '
        'STopic
        '
        Me.STopic.AutoSize = True
        Me.STopic.BackColor = System.Drawing.Color.Transparent
        Me.STopic.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.STopic.ForeColor = System.Drawing.Color.Transparent
        Me.STopic.Location = New System.Drawing.Point(159, 12)
        Me.STopic.Name = "STopic"
        Me.STopic.Size = New System.Drawing.Size(54, 21)
        Me.STopic.TabIndex = 12
        Me.STopic.Text = "(關卡)"
        Me.STopic.Visible = False
        '
        'TLabel
        '
        Me.TLabel.AutoSize = True
        Me.TLabel.BackColor = System.Drawing.Color.Transparent
        Me.TLabel.Font = New System.Drawing.Font("Comic Sans MS", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLabel.ForeColor = System.Drawing.Color.Gold
        Me.TLabel.Location = New System.Drawing.Point(755, 0)
        Me.TLabel.Name = "TLabel"
        Me.TLabel.Size = New System.Drawing.Size(53, 40)
        Me.TLabel.TabIndex = 3
        Me.TLabel.Text = "15"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.食物1
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("微軟正黑體", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button2.Location = New System.Drawing.Point(317, 164)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(145, 118)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.旅遊1
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("微軟正黑體", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.Location = New System.Drawing.Point(22, 164)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 118)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.太空背景
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.STopicDis)
        Me.Panel1.Controls.Add(Me.STopic)
        Me.Panel1.Controls.Add(Me.TLabel)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(10, 343)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(808, 412)
        Me.Panel1.TabIndex = 51
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(741, -4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 38)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, -4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 35)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "score:"
        '
        'CPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApp1.My.Resources.Resources.遊戲背景1
        Me.ClientSize = New System.Drawing.Size(802, 411)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TimeLabel)
        Me.Controls.Add(Me.QLabel)
        Me.Controls.Add(Me.scoreLabel)
        Me.Controls.Add(Me.ButtonA2)
        Me.Controls.Add(Me.ButtonA1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "CPlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CPlayer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TimeLabel As Label
    Friend WithEvents QLabel As Label
    Friend WithEvents scoreLabel As Label
    Friend WithEvents ButtonA2 As Button
    Friend WithEvents ButtonA1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents STopicDis As Label
    Friend WithEvents STopic As Label
    Friend WithEvents TLabel As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer4 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
