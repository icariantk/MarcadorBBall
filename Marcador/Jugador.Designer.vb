<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Jugador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Jugador))
        Me.index = New System.Windows.Forms.Label()
        Me.team = New System.Windows.Forms.Label()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fouls = New System.Windows.Forms.Label()
        Me.canastas = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nomequ = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.cuarto = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rebotes = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.asistencias = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.robos = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'index
        '
        Me.index.AutoSize = True
        Me.index.Location = New System.Drawing.Point(315, 21)
        Me.index.Name = "index"
        Me.index.Size = New System.Drawing.Size(33, 13)
        Me.index.TabIndex = 0
        Me.index.Text = "Index"
        Me.index.Visible = False
        '
        'team
        '
        Me.team.AutoSize = True
        Me.team.Location = New System.Drawing.Point(275, 21)
        Me.team.Name = "team"
        Me.team.Size = New System.Drawing.Size(34, 13)
        Me.team.TabIndex = 1
        Me.team.Text = "Team"
        Me.team.Visible = False
        '
        'nombre
        '
        Me.nombre.Enabled = False
        Me.nombre.Location = New System.Drawing.Point(23, 64)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(237, 20)
        Me.nombre.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Número"
        '
        'numero
        '
        Me.numero.Enabled = False
        Me.numero.Location = New System.Drawing.Point(23, 103)
        Me.numero.Name = "numero"
        Me.numero.Size = New System.Drawing.Size(237, 20)
        Me.numero.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fouls"
        '
        'fouls
        '
        Me.fouls.AutoSize = True
        Me.fouls.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fouls.Location = New System.Drawing.Point(33, 164)
        Me.fouls.Name = "fouls"
        Me.fouls.Size = New System.Drawing.Size(29, 31)
        Me.fouls.TabIndex = 8
        Me.fouls.Text = "0"
        '
        'canastas
        '
        Me.canastas.AutoSize = True
        Me.canastas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.canastas.Location = New System.Drawing.Point(33, 282)
        Me.canastas.Name = "canastas"
        Me.canastas.Size = New System.Drawing.Size(29, 31)
        Me.canastas.TabIndex = 10
        Me.canastas.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Canastas"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(133, 257)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "+1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(171, 257)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "+2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(209, 257)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "+3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(133, 150)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(32, 32)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "+1"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(133, 188)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(32, 32)
        Me.Button5.TabIndex = 18
        Me.Button5.Text = "-1"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(209, 295)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(32, 32)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "-3"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(171, 295)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(32, 32)
        Me.Button7.TabIndex = 16
        Me.Button7.Text = "-2"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(133, 295)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(32, 32)
        Me.Button8.TabIndex = 15
        Me.Button8.Text = "-1"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Equipo:"
        '
        'nomequ
        '
        Me.nomequ.AutoSize = True
        Me.nomequ.Location = New System.Drawing.Point(70, 21)
        Me.nomequ.Name = "nomequ"
        Me.nomequ.Size = New System.Drawing.Size(48, 13)
        Me.nomequ.TabIndex = 20
        Me.nomequ.Text = "NomEqu"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(308, 61)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 21
        Me.Button9.Text = "Aceptar"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(308, 90)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 22
        Me.Button10.Text = "Cancelar"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(273, 163)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(109, 121)
        Me.ListBox1.TabIndex = 23
        Me.ListBox1.Visible = False
        '
        'cuarto
        '
        Me.cuarto.AutoSize = True
        Me.cuarto.Location = New System.Drawing.Point(354, 21)
        Me.cuarto.Name = "cuarto"
        Me.cuarto.Size = New System.Drawing.Size(38, 13)
        Me.cuarto.TabIndex = 24
        Me.cuarto.Text = "Cuarto"
        Me.cuarto.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 348)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Rebotes"
        '
        'rebotes
        '
        Me.rebotes.AutoSize = True
        Me.rebotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rebotes.Location = New System.Drawing.Point(33, 373)
        Me.rebotes.Name = "rebotes"
        Me.rebotes.Size = New System.Drawing.Size(29, 31)
        Me.rebotes.TabIndex = 26
        Me.rebotes.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(130, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Asistencias"
        '
        'asistencias
        '
        Me.asistencias.AutoSize = True
        Me.asistencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.asistencias.Location = New System.Drawing.Point(140, 373)
        Me.asistencias.Name = "asistencias"
        Me.asistencias.Size = New System.Drawing.Size(29, 31)
        Me.asistencias.TabIndex = 28
        Me.asistencias.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(262, 348)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Robos"
        '
        'robos
        '
        Me.robos.AutoSize = True
        Me.robos.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.robos.Location = New System.Drawing.Point(272, 373)
        Me.robos.Name = "robos"
        Me.robos.Size = New System.Drawing.Size(29, 31)
        Me.robos.TabIndex = 30
        Me.robos.Text = "0"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(89, 387)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(32, 32)
        Me.Button11.TabIndex = 32
        Me.Button11.Text = "-1"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(89, 349)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(32, 32)
        Me.Button12.TabIndex = 31
        Me.Button12.Text = "+1"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(209, 387)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(32, 32)
        Me.Button13.TabIndex = 34
        Me.Button13.Text = "-1"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(209, 349)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(32, 32)
        Me.Button14.TabIndex = 33
        Me.Button14.Text = "+1"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(316, 387)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(32, 32)
        Me.Button15.TabIndex = 36
        Me.Button15.Text = "-1"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(316, 349)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(32, 32)
        Me.Button16.TabIndex = 35
        Me.Button16.Text = "+1"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Jugador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 441)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.robos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.asistencias)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.rebotes)
        Me.Controls.Add(Me.cuarto)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.nomequ)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.canastas)
        Me.Controls.Add(Me.fouls)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.team)
        Me.Controls.Add(Me.index)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Jugador"
        Me.Text = " "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents index As System.Windows.Forms.Label
    Friend WithEvents team As System.Windows.Forms.Label
    Friend WithEvents nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fouls As System.Windows.Forms.Label
    Friend WithEvents canastas As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nomequ As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents cuarto As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rebotes As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents asistencias As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents robos As System.Windows.Forms.Label
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
End Class
