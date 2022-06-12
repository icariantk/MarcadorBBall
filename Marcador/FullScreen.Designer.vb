<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FullScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FullScreen))
        Me.ScoreA = New System.Windows.Forms.Label()
        Me.ScoreB = New System.Windows.Forms.Label()
        Me.Cuarto = New System.Windows.Forms.PictureBox()
        Me.TimeFS = New System.Windows.Forms.Label()
        Me.FoulsA = New System.Windows.Forms.Label()
        Me.FoulsB = New System.Windows.Forms.Label()
        Me.Sec24A = New System.Windows.Forms.Label()
        Me.Sec24B = New System.Windows.Forms.Label()
        CType(Me.Cuarto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ScoreA
        '
        Me.ScoreA.AutoSize = True
        Me.ScoreA.BackColor = System.Drawing.Color.Transparent
        Me.ScoreA.Font = New System.Drawing.Font("Microsoft Sans Serif", 300.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ScoreA.ForeColor = System.Drawing.Color.Lime
        Me.ScoreA.Location = New System.Drawing.Point(12, 9)
        Me.ScoreA.Name = "ScoreA"
        Me.ScoreA.Size = New System.Drawing.Size(644, 340)
        Me.ScoreA.TabIndex = 1
        Me.ScoreA.Text = "000"
        '
        'ScoreB
        '
        Me.ScoreB.AutoSize = True
        Me.ScoreB.BackColor = System.Drawing.Color.Transparent
        Me.ScoreB.Font = New System.Drawing.Font("Microsoft Sans Serif", 300.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ScoreB.ForeColor = System.Drawing.Color.Lime
        Me.ScoreB.Location = New System.Drawing.Point(1245, 9)
        Me.ScoreB.Name = "ScoreB"
        Me.ScoreB.Size = New System.Drawing.Size(644, 340)
        Me.ScoreB.TabIndex = 2
        Me.ScoreB.Text = "000"
        '
        'Cuarto
        '
        Me.Cuarto.Image = CType(resources.GetObject("Cuarto.Image"), System.Drawing.Image)
        Me.Cuarto.Location = New System.Drawing.Point(833, 30)
        Me.Cuarto.Name = "Cuarto"
        Me.Cuarto.Size = New System.Drawing.Size(75, 400)
        Me.Cuarto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Cuarto.TabIndex = 3
        Me.Cuarto.TabStop = False
        '
        'TimeFS
        '
        Me.TimeFS.AutoSize = True
        Me.TimeFS.BackColor = System.Drawing.Color.Transparent
        Me.TimeFS.Font = New System.Drawing.Font("Microsoft Sans Serif", 300.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.TimeFS.ForeColor = System.Drawing.Color.Lime
        Me.TimeFS.Location = New System.Drawing.Point(292, 547)
        Me.TimeFS.Name = "TimeFS"
        Me.TimeFS.Size = New System.Drawing.Size(1311, 340)
        Me.TimeFS.TabIndex = 5
        Me.TimeFS.Text = "00:00:00"
        Me.TimeFS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FoulsA
        '
        Me.FoulsA.AutoSize = True
        Me.FoulsA.BackColor = System.Drawing.Color.Transparent
        Me.FoulsA.Font = New System.Drawing.Font("Microsoft Sans Serif", 150.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.FoulsA.ForeColor = System.Drawing.Color.Red
        Me.FoulsA.Location = New System.Drawing.Point(631, 365)
        Me.FoulsA.Name = "FoulsA"
        Me.FoulsA.Size = New System.Drawing.Size(155, 170)
        Me.FoulsA.TabIndex = 6
        Me.FoulsA.Text = "0"
        '
        'FoulsB
        '
        Me.FoulsB.AutoSize = True
        Me.FoulsB.BackColor = System.Drawing.Color.Transparent
        Me.FoulsB.Font = New System.Drawing.Font("Microsoft Sans Serif", 150.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.FoulsB.ForeColor = System.Drawing.Color.Red
        Me.FoulsB.Location = New System.Drawing.Point(1726, 365)
        Me.FoulsB.Name = "FoulsB"
        Me.FoulsB.Size = New System.Drawing.Size(155, 170)
        Me.FoulsB.TabIndex = 7
        Me.FoulsB.Text = "0"
        '
        'Sec24A
        '
        Me.Sec24A.AutoSize = True
        Me.Sec24A.BackColor = System.Drawing.Color.Transparent
        Me.Sec24A.Font = New System.Drawing.Font("Microsoft Sans Serif", 300.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Sec24A.ForeColor = System.Drawing.Color.Yellow
        Me.Sec24A.Location = New System.Drawing.Point(73, 283)
        Me.Sec24A.Name = "Sec24A"
        Me.Sec24A.Size = New System.Drawing.Size(477, 340)
        Me.Sec24A.TabIndex = 8
        Me.Sec24A.Text = "24"
        '
        'Sec24B
        '
        Me.Sec24B.AutoSize = True
        Me.Sec24B.BackColor = System.Drawing.Color.Transparent
        Me.Sec24B.Font = New System.Drawing.Font("Microsoft Sans Serif", 300.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Sec24B.ForeColor = System.Drawing.Color.Yellow
        Me.Sec24B.Location = New System.Drawing.Point(1302, 283)
        Me.Sec24B.Name = "Sec24B"
        Me.Sec24B.Size = New System.Drawing.Size(477, 340)
        Me.Sec24B.TabIndex = 9
        Me.Sec24B.Text = "24"
        '
        'FullScreen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1822, 900)
        Me.ControlBox = False
        Me.Controls.Add(Me.FoulsB)
        Me.Controls.Add(Me.FoulsA)
        Me.Controls.Add(Me.Sec24B)
        Me.Controls.Add(Me.Sec24A)
        Me.Controls.Add(Me.Cuarto)
        Me.Controls.Add(Me.ScoreB)
        Me.Controls.Add(Me.ScoreA)
        Me.Controls.Add(Me.TimeFS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FullScreen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FullScreen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Cuarto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ScoreA As System.Windows.Forms.Label
    Friend WithEvents ScoreB As System.Windows.Forms.Label
    Friend WithEvents Cuarto As System.Windows.Forms.PictureBox
    Friend WithEvents TimeFS As System.Windows.Forms.Label
    Friend WithEvents FoulsA As System.Windows.Forms.Label
    Friend WithEvents FoulsB As System.Windows.Forms.Label
    Friend WithEvents Sec24A As System.Windows.Forms.Label
    Friend WithEvents Sec24B As System.Windows.Forms.Label
End Class
