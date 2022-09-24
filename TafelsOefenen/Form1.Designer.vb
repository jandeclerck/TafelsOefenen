<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.OpdrachtLbl = New System.Windows.Forms.Label()
        Me.AntwoordTxt = New System.Windows.Forms.TextBox()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Tijdprg = New System.Windows.Forms.ProgressBar()
        Me.ScoreLbl = New System.Windows.Forms.Label()
        Me.WillekeurigOptBtn = New System.Windows.Forms.RadioButton()
        Me.LaagsteScoreOptbtn = New System.Windows.Forms.RadioButton()
        Me.MinstGeoefendOptBtn = New System.Windows.Forms.RadioButton()
        Me.AantalPerSessieTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.InstellingenPanel = New System.Windows.Forms.Panel()
        Me.StopBtn = New System.Windows.Forms.Button()
        Me.StatusOefeningLbl = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.RecordLbl = New System.Windows.Forms.Label()
        Me.NogNietGeoefendLbl = New System.Windows.Forms.Label()
        Me.AllesWissenBtn = New System.Windows.Forms.Button()
        Me.InstellingenPanel.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StartBtn
        '
        Me.StartBtn.Location = New System.Drawing.Point(21, 38)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(207, 58)
        Me.StartBtn.TabIndex = 0
        Me.StartBtn.Text = "Starten"
        Me.StartBtn.UseVisualStyleBackColor = True
        '
        'OpdrachtLbl
        '
        Me.OpdrachtLbl.AutoSize = True
        Me.OpdrachtLbl.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.OpdrachtLbl.Location = New System.Drawing.Point(20, 250)
        Me.OpdrachtLbl.Name = "OpdrachtLbl"
        Me.OpdrachtLbl.Size = New System.Drawing.Size(0, 54)
        Me.OpdrachtLbl.TabIndex = 1
        '
        'AntwoordTxt
        '
        Me.AntwoordTxt.Enabled = False
        Me.AntwoordTxt.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.AntwoordTxt.Location = New System.Drawing.Point(199, 250)
        Me.AntwoordTxt.Name = "AntwoordTxt"
        Me.AntwoordTxt.Size = New System.Drawing.Size(107, 61)
        Me.AntwoordTxt.TabIndex = 2
        '
        'Timer
        '
        Me.Timer.Interval = 1000
        '
        'Tijdprg
        '
        Me.Tijdprg.Location = New System.Drawing.Point(349, 267)
        Me.Tijdprg.Maximum = 60
        Me.Tijdprg.Name = "Tijdprg"
        Me.Tijdprg.Size = New System.Drawing.Size(342, 35)
        Me.Tijdprg.TabIndex = 4
        '
        'ScoreLbl
        '
        Me.ScoreLbl.AutoSize = True
        Me.ScoreLbl.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ScoreLbl.ForeColor = System.Drawing.Color.Blue
        Me.ScoreLbl.Location = New System.Drawing.Point(21, 338)
        Me.ScoreLbl.Name = "ScoreLbl"
        Me.ScoreLbl.Size = New System.Drawing.Size(171, 54)
        Me.ScoreLbl.TabIndex = 5
        Me.ScoreLbl.Text = "Score: 0"
        '
        'WillekeurigOptBtn
        '
        Me.WillekeurigOptBtn.AutoSize = True
        Me.WillekeurigOptBtn.Location = New System.Drawing.Point(23, 22)
        Me.WillekeurigOptBtn.Name = "WillekeurigOptBtn"
        Me.WillekeurigOptBtn.Size = New System.Drawing.Size(205, 29)
        Me.WillekeurigOptBtn.TabIndex = 6
        Me.WillekeurigOptBtn.Text = "Willekeurig opvragen"
        Me.WillekeurigOptBtn.UseVisualStyleBackColor = True
        '
        'LaagsteScoreOptbtn
        '
        Me.LaagsteScoreOptbtn.AutoSize = True
        Me.LaagsteScoreOptbtn.Checked = True
        Me.LaagsteScoreOptbtn.Location = New System.Drawing.Point(23, 57)
        Me.LaagsteScoreOptbtn.Name = "LaagsteScoreOptbtn"
        Me.LaagsteScoreOptbtn.Size = New System.Drawing.Size(346, 29)
        Me.LaagsteScoreOptbtn.TabIndex = 7
        Me.LaagsteScoreOptbtn.TabStop = True
        Me.LaagsteScoreOptbtn.Text = "Opvragen waar ik het moeilijk mee heb"
        Me.LaagsteScoreOptbtn.UseVisualStyleBackColor = True
        '
        'MinstGeoefendOptBtn
        '
        Me.MinstGeoefendOptBtn.AutoSize = True
        Me.MinstGeoefendOptBtn.Location = New System.Drawing.Point(23, 92)
        Me.MinstGeoefendOptBtn.Name = "MinstGeoefendOptBtn"
        Me.MinstGeoefendOptBtn.Size = New System.Drawing.Size(299, 29)
        Me.MinstGeoefendOptBtn.TabIndex = 8
        Me.MinstGeoefendOptBtn.Text = "Minst geoefende tafels opvragen"
        Me.MinstGeoefendOptBtn.UseVisualStyleBackColor = True
        '
        'AantalPerSessieTxt
        '
        Me.AantalPerSessieTxt.Location = New System.Drawing.Point(235, 137)
        Me.AantalPerSessieTxt.Name = "AantalPerSessieTxt"
        Me.AantalPerSessieTxt.Size = New System.Drawing.Size(67, 31)
        Me.AantalPerSessieTxt.TabIndex = 10
        Me.AantalPerSessieTxt.Text = "10"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 25)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Aantal Per Oefensessie:"
        '
        'InstellingenPanel
        '
        Me.InstellingenPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.InstellingenPanel.Controls.Add(Me.WillekeurigOptBtn)
        Me.InstellingenPanel.Controls.Add(Me.Label1)
        Me.InstellingenPanel.Controls.Add(Me.LaagsteScoreOptbtn)
        Me.InstellingenPanel.Controls.Add(Me.AantalPerSessieTxt)
        Me.InstellingenPanel.Controls.Add(Me.MinstGeoefendOptBtn)
        Me.InstellingenPanel.Location = New System.Drawing.Point(271, 38)
        Me.InstellingenPanel.Name = "InstellingenPanel"
        Me.InstellingenPanel.Size = New System.Drawing.Size(386, 187)
        Me.InstellingenPanel.TabIndex = 12
        '
        'StopBtn
        '
        Me.StopBtn.Enabled = False
        Me.StopBtn.Location = New System.Drawing.Point(21, 161)
        Me.StopBtn.Name = "StopBtn"
        Me.StopBtn.Size = New System.Drawing.Size(207, 58)
        Me.StopBtn.TabIndex = 13
        Me.StopBtn.Text = "Stoppen"
        Me.StopBtn.UseVisualStyleBackColor = True
        '
        'StatusOefeningLbl
        '
        Me.StatusOefeningLbl.AutoSize = True
        Me.StatusOefeningLbl.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.StatusOefeningLbl.Location = New System.Drawing.Point(21, 114)
        Me.StatusOefeningLbl.Name = "StatusOefeningLbl"
        Me.StatusOefeningLbl.Size = New System.Drawing.Size(179, 32)
        Me.StatusOefeningLbl.TabIndex = 14
        Me.StatusOefeningLbl.Text = "Oefening 0/10"
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(21, 548)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 62
        Me.dgv.RowTemplate.Height = 33
        Me.dgv.Size = New System.Drawing.Size(727, 553)
        Me.dgv.TabIndex = 15
        '
        'RecordLbl
        '
        Me.RecordLbl.AutoSize = True
        Me.RecordLbl.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.RecordLbl.Location = New System.Drawing.Point(590, 355)
        Me.RecordLbl.Name = "RecordLbl"
        Me.RecordLbl.Size = New System.Drawing.Size(101, 32)
        Me.RecordLbl.TabIndex = 16
        Me.RecordLbl.Text = "Record:"
        Me.RecordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NogNietGeoefendLbl
        '
        Me.NogNietGeoefendLbl.AutoSize = True
        Me.NogNietGeoefendLbl.Location = New System.Drawing.Point(315, 388)
        Me.NogNietGeoefendLbl.Name = "NogNietGeoefendLbl"
        Me.NogNietGeoefendLbl.Size = New System.Drawing.Size(0, 25)
        Me.NogNietGeoefendLbl.TabIndex = 17
        '
        'AllesWissenBtn
        '
        Me.AllesWissenBtn.Location = New System.Drawing.Point(21, 437)
        Me.AllesWissenBtn.Name = "AllesWissenBtn"
        Me.AllesWissenBtn.Size = New System.Drawing.Size(131, 43)
        Me.AllesWissenBtn.TabIndex = 18
        Me.AllesWissenBtn.Text = "Alles Wissen"
        Me.AllesWissenBtn.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 434)
        Me.Controls.Add(Me.AllesWissenBtn)
        Me.Controls.Add(Me.NogNietGeoefendLbl)
        Me.Controls.Add(Me.RecordLbl)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.StatusOefeningLbl)
        Me.Controls.Add(Me.StopBtn)
        Me.Controls.Add(Me.InstellingenPanel)
        Me.Controls.Add(Me.ScoreLbl)
        Me.Controls.Add(Me.Tijdprg)
        Me.Controls.Add(Me.AntwoordTxt)
        Me.Controls.Add(Me.OpdrachtLbl)
        Me.Controls.Add(Me.StartBtn)
        Me.Name = "Form1"
        Me.Text = "Tafels Oefenen "
        Me.InstellingenPanel.ResumeLayout(False)
        Me.InstellingenPanel.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StartBtn As Button
    Friend WithEvents OpdrachtLbl As Label
    Friend WithEvents AntwoordTxt As TextBox
    Friend WithEvents Timer As Timer
    Friend WithEvents Tijdprg As ProgressBar
    Friend WithEvents ScoreLbl As Label
    Friend WithEvents WillekeurigOptBtn As RadioButton
    Friend WithEvents LaagsteScoreOptbtn As RadioButton
    Friend WithEvents MinstGeoefendOptBtn As RadioButton
    Friend WithEvents AantalPerSessieTxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents InstellingenPanel As Panel
    Friend WithEvents StopBtn As Button
    Friend WithEvents StatusOefeningLbl As Label
    Friend WithEvents dgv As DataGridView
    Friend WithEvents RecordLbl As Label
    Friend WithEvents NogNietGeoefendLbl As Label
    Friend WithEvents AllesWissenBtn As Button
End Class
