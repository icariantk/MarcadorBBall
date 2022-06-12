Imports System.Xml
Imports Microsoft.Office.Interop
Imports System.IO.Ports
Imports System.IO

Public Class Principal
    Dim players As New List(Of Jugador)
    Dim cTiro As Integer

    Dim timelapse As Date
    Dim totminutos As Double
    Dim time24 As Date
    Dim actual24 As Double
    Dim actual As Double
    Private valores(10) As Char
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Int32) As Int16

    Private foulsA_1, foulsA_2, foulsA_3, foulsA_4 As Integer
    Private foulsB_1, foulsB_2, foulsB_3, foulsB_4 As Integer

    Private Function convierte(numero As Integer)
        Dim a As Integer
        a = 0

        If numero = 0 Then a = 63
        If numero = 1 Then a = 6
        If numero = 2 Then a = 91
        If numero = 3 Then a = 79
        If numero = 4 Then a = 102
        If numero = 5 Then a = 109
        If numero = 6 Then a = 125
        If numero = 7 Then a = 7
        If numero = 8 Then a = 127
        If numero = 9 Then a = 103
        Return a


    End Function

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub
    Public Sub tiempo()
        Dim encontrado, activado As Integer
        Dim newc As String
        Dim k As Boolean

        newc = ""
        Dim a As String = ""
        activado = 1
        REM Poner a 0 para activar licenciado del software, el cual encripta la mac address con una clave que se debe ingresar
        REM para hacerla válida.
        Dim checkac As String
        If Not My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\configuracion.xml") Then
            My.Computer.FileSystem.WriteAllText(Application.UserAppDataPath + "\configuracion.xml", "<?xml version=""1.0"" encoding=""utf-8"" ?><Configuracion>  <Tiempo>12</Tiempo>  <cTiro>24</cTiro>  <Activacion>mFJ8Zook09aeYDT4CWpWkw==</Activacion></Configuracion>", False)
        End If
        Using reader As XmlReader = XmlReader.Create(Application.UserAppDataPath + "\configuracion.xml")
            While reader.Read()
                If reader.Name = "Tiempo" Then

                    Minutos.Text = reader.ReadString()

                    If Minutos.Text.Length < 2 Then
                        Minutos.Text = "0" + Minutos.Text

                    End If

                    actual = CDbl(Minutos.Text) * 60 * 1000
                    totminutos = actual
                    actual24 = 24000
                    Segundos.Text = "00"
                    Decimas.Text = "00"
                End If
                If reader.Name = "cTiro" Then
                    cTiro = CInt(reader.ReadString()) * 1000
                End If
                If reader.Name = "Activacion" Then

                    encontrado = 1
                    Dim clave(20) As Byte
                    clave(0) = 10
                    clave(1) = 7
                    clave(2) = 10
                    clave(3) = 154
                    clave(4) = 36
                    clave(5) = 78
                    clave(6) = 96
                    clave(7) = 139
                    clave(8) = 220
                    clave(9) = 222
                    clave(10) = 214
                    clave(11) = 36
                    clave(12) = 105
                    clave(13) = 7
                    clave(14) = 99
                    clave(15) = 27
                    clave(16) = 4
                    clave(17) = 19
                    clave(18) = 86
                    clave(19) = 6
                    Dim clv As String
                    clv = System.Text.Encoding.Unicode.GetString(clave)

                    checkac = reader.ReadString()

                    k = False
                    For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                        If k = False Then
                            If nic.NetworkInterfaceType <> Net.NetworkInformation.NetworkInterfaceType.Wireless80211 Then
                                a = String.Format("{0}", nic.GetPhysicalAddress())
                                Dim b As String = AES_Encrypt(a, clv)


                                Dim c As String = AES_Decrypt(checkac, clv)
                                If b = checkac Then
                                    activado = 1
                                Else
                                    activado = 1
                                    REM Aquí se forza la activación, debería ser 0.
                                End If
                                k = True
                            End If
                        End If
                    Next
                End If
            End While
            reader.Close()

        End Using
        If activado = 0 Or encontrado = 0 Then
            newc = InputBox("Su software no ha sido activado, enviar un mensaje de texto con el código: -" + a + "- al número 3311380117", "Error de licencia")
            If newc <> "" Then


                Dim settings As New XmlWriterSettings()
                settings.Indent = True

                ' Initialize the XmlWriter.
                Dim XmlWrt As XmlWriter = XmlWriter.Create(Application.UserAppDataPath + "\configuracion.xml", settings)
                With XmlWrt
                    .WriteStartDocument()
                    .WriteStartElement("Configuracion")
                    For cc = 0 To config.ListBox1.Items.Count - 1
                        .WriteStartElement(config.ListBox1.Items.Item(cc))
                        If config.ListBox1.Items.Item(cc) = "Activacion" Then
                            .WriteString(newc)
                        Else
                            .WriteString(config.ListBox2.Items.Item(cc))
                        End If
                        .WriteEndElement()

                    Next
                    .WriteEndDocument()
                    .Close()
                End With
                MsgBox("Por favor reinicie la aplicación para verificar la licencia nuevamente")
                Application.Exit()
            Else
                Application.Exit()
            End If

        End If

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        startup()
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopiarToolStripMenuItem.Click
        config.Show()

    End Sub






    Private Sub actualiza()
        Dim score, fouls As Integer
        score = 0
        fouls = 0
        For c = 0 To TBLV.Items.Count - 1
            score = score + CInt(TBLV.Items.Item(c).SubItems(3).Text)
        Next
        foulsB_1 = 0
        foulsB_2 = 0
        foulsB_3 = 0
        foulsB_4 = 0
        For c = 0 To log.Items.Count - 1
            Dim a() As String
            a = Split(log.Items.Item(c), "|")

            If a(0) = "B" And a(1) = "F+1" And a(3) = "1" Then
                foulsB_1 = foulsB_1 + 1
            End If
            If a(0) = "B" And a(1) = "F-1" And a(3) = "1" Then
                foulsB_1 = foulsB_1 - 1
            End If
            If a(0) = "B" And a(1) = "F+1" And a(3) = "2" Then
                foulsB_2 = foulsB_2 + 1
            End If
            If a(0) = "B" And a(1) = "F-1" And a(3) = "2" Then
                foulsB_2 = foulsB_2 - 1
            End If
            If a(0) = "B" And a(1) = "F+1" And a(3) = "3" Then
                foulsB_3 = foulsB_3 + 1
            End If
            If a(0) = "B" And a(1) = "F-1" And a(3) = "3" Then
                foulsB_3 = foulsB_3 - 1
            End If
            If a(0) = "B" And a(1) = "F+1" And (a(3) = "4" Or a(3) = "E1") Then
                foulsB_4 = foulsB_4 + 1
            End If
            If a(0) = "B" And a(1) = "F-1" And (a(3) = "4" Or a(3) = "E2") Then
                foulsB_4 = foulsB_4 - 1
            End If
            If a(0) = "B" And a(1) = "F+1" And (a(3) = "4" Or a(3) = "E2") Then
                foulsB_4 = foulsB_4 + 1
            End If
            If a(0) = "B" And a(1) = "F-1" And (a(3) = "4" Or a(3) = "E1") Then
                foulsB_4 = foulsB_4 - 1
            End If
        Next
        B11.Checked = False
        B12.Checked = False
        B13.Checked = False
        B14.Checked = False
        B15.Checked = False
        B21.Checked = False
        B22.Checked = False
        B23.Checked = False
        B24.Checked = False
        B25.Checked = False
        B31.Checked = False
        B32.Checked = False
        B33.Checked = False
        B34.Checked = False
        B35.Checked = False
        B41.Checked = False
        B42.Checked = False
        B43.Checked = False
        B44.Checked = False
        B45.Checked = False


        If foulsB_1 > 0 Then
            B11.Checked = True
        End If
        If foulsB_1 > 1 Then
            B12.Checked = True
        End If
        If foulsB_1 > 2 Then
            B13.Checked = True
        End If
        If foulsB_1 > 3 Then
            B14.Checked = True
        End If
        If foulsB_1 > 4 Then
            B15.Checked = True
        End If
        If foulsB_2 > 0 Then
            B21.Checked = True
        End If
        If foulsB_2 > 1 Then
            B22.Checked = True
        End If
        If foulsB_2 > 2 Then
            B23.Checked = True
        End If
        If foulsB_2 > 3 Then
            B24.Checked = True
        End If
        If foulsB_2 > 4 Then
            B25.Checked = True
        End If
        If foulsB_3 > 0 Then
            B31.Checked = True
        End If
        If foulsB_3 > 1 Then
            B32.Checked = True
        End If
        If foulsB_3 > 2 Then
            B33.Checked = True
        End If
        If foulsB_3 > 3 Then
            B34.Checked = True
        End If
        If foulsB_3 > 4 Then
            B35.Checked = True
        End If
        If foulsB_4 > 0 Then
            B41.Checked = True
        End If
        If foulsB_4 > 1 Then
            B42.Checked = True
        End If
        If foulsB_4 > 2 Then
            B43.Checked = True
        End If
        If foulsB_4 > 3 Then
            B44.Checked = True
        End If
        If foulsB_4 > 4 Then
            B45.Checked = True
        End If
        If score < 10 Then
            ScoreB.Text = "0" + CStr(score)
        Else
            ScoreB.Text = CStr(score)
        End If
        score = 0
        fouls = 0
        For c = 0 To TALV.Items.Count - 1
            score = score + CInt(TALV.Items.Item(c).SubItems(3).Text)
        Next

        If A11.Enabled = False Then
            foulsA_1 = 0
            foulsA_2 = 0
            foulsA_3 = 0
            foulsA_4 = 0
            For c = 0 To log.Items.Count - 1
                Dim a() As String
                a = Split(log.Items.Item(c), "|")

                If a(0) = "A" And a(1) = "F+1" And a(3) = "1" Then
                    foulsA_1 = foulsA_1 + 1
                End If
                If a(0) = "A" And a(1) = "F-1" And a(3) = "1" Then
                    foulsA_1 = foulsA_1 - 1
                End If
                If a(0) = "A" And a(1) = "F+1" And a(3) = "2" Then
                    foulsA_2 = foulsA_2 + 1
                End If
                If a(0) = "A" And a(1) = "F-1" And a(3) = "2" Then
                    foulsA_2 = foulsA_2 - 1
                End If
                If a(0) = "A" And a(1) = "F+1" And a(3) = "3" Then
                    foulsA_3 = foulsA_3 + 1
                End If
                If a(0) = "A" And a(1) = "F-1" And a(3) = "3" Then
                    foulsA_3 = foulsA_3 - 1
                End If
                If a(0) = "A" And a(1) = "F+1" And (a(3) = "4" Or a(3) = "E") Then
                    foulsA_4 = foulsA_4 + 1
                End If
                If a(0) = "A" And a(1) = "F-1" And (a(3) = "4" Or a(3) = "E") Then
                    foulsA_4 = foulsA_4 - 1
                End If
            Next

            A11.Checked = False
            A12.Checked = False
            A13.Checked = False
            A14.Checked = False
            A15.Checked = False
            A21.Checked = False
            A22.Checked = False
            A23.Checked = False
            A24.Checked = False
            A25.Checked = False
            A31.Checked = False
            A32.Checked = False
            A33.Checked = False
            A34.Checked = False
            A35.Checked = False
            A41.Checked = False
            A42.Checked = False
            A43.Checked = False
            A44.Checked = False
            A45.Checked = False


            If foulsA_1 > 0 Then
                A11.Checked = True
            End If
            If foulsA_1 > 1 Then
                A12.Checked = True
            End If
            If foulsA_1 > 2 Then
                A13.Checked = True
            End If
            If foulsA_1 > 3 Then
                A14.Checked = True
            End If
            If foulsA_1 > 4 Then
                A15.Checked = True
            End If
            If foulsA_2 > 0 Then
                A21.Checked = True
            End If
            If foulsA_2 > 1 Then
                A22.Checked = True
            End If
            If foulsA_2 > 2 Then
                A23.Checked = True
            End If
            If foulsA_2 > 3 Then
                A24.Checked = True
            End If
            If foulsA_2 > 4 Then
                A25.Checked = True
            End If
            If foulsA_3 > 0 Then
                A31.Checked = True
            End If
            If foulsA_3 > 1 Then
                A32.Checked = True
            End If
            If foulsA_3 > 2 Then
                A33.Checked = True
            End If
            If foulsA_3 > 3 Then
                A34.Checked = True
            End If
            If foulsA_3 > 4 Then
                A35.Checked = True
            End If
            If foulsA_4 > 0 Then
                A41.Checked = True
            End If
            If foulsA_4 > 1 Then
                A42.Checked = True
            End If
            If foulsA_4 > 2 Then
                A43.Checked = True
            End If
            If foulsA_4 > 3 Then
                A44.Checked = True
            End If
            If foulsA_4 > 4 Then
                A45.Checked = True
            End If
        End If
        If score < 10 Then
            ScoreA.Text = "0" + CStr(score)
        Else
            ScoreA.Text = CStr(score)
        End If


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click

        B11.Enabled = True
        B12.Enabled = True
        B13.Enabled = True
        B14.Enabled = True
        B15.Enabled = True
        B21.Enabled = True
        B22.Enabled = True
        B23.Enabled = True
        B24.Enabled = True
        B25.Enabled = True
        B31.Enabled = True
        B32.Enabled = True
        B33.Enabled = True
        B34.Enabled = True
        B35.Enabled = True
        B41.Enabled = True
        B42.Enabled = True
        B43.Enabled = True
        B44.Enabled = True
        B45.Enabled = True

        A11.Enabled = True
        A12.Enabled = True
        A13.Enabled = True
        A14.Enabled = True
        A15.Enabled = True
        A21.Enabled = True
        A22.Enabled = True
        A23.Enabled = True
        A24.Enabled = True
        A25.Enabled = True
        A31.Enabled = True
        A32.Enabled = True
        A33.Enabled = True
        A34.Enabled = True
        A35.Enabled = True
        A41.Enabled = True
        A42.Enabled = True
        A43.Enabled = True
        A44.Enabled = True
        A45.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick




        actual = totminutos - Now.Subtract(timelapse).TotalMilliseconds

        Dim descomponer As Double



        Dim dec, seg, min As Integer
        If actual > 0 Then


            descomponer = actual / 60000
            min = Math.Floor(descomponer)
            descomponer = actual - (min * 60000)
            descomponer = descomponer / 1000
            seg = Math.Floor(descomponer)
            descomponer = (descomponer - seg) * 1000
            dec = Math.Floor(descomponer)
            Minutos.Text = CStr(min)
            Segundos.Text = CStr(seg)
            Decimas.Text = CStr(dec)
        Else
            Timer1.Enabled = False
            Minutos.Text = "00"
            Segundos.Text = "00"
            Decimas.Text = "00"
        End If
        If Minutos.Text.Length < 2 Then
            Minutos.Text = "0" + Minutos.Text
        End If
        If Segundos.Text.Length < 2 Then
            Segundos.Text = "0" + Segundos.Text
        End If
        If Decimas.Text.Length < 2 Then
            Decimas.Text = "0" + Decimas.Text
        End If
        If Decimas.Text.Length > 2 Then
            Decimas.Text = Decimas.Text.Substring(0, 2)
        End If
        FullScreen.TimeFS.Text = Minutos.Text + ":" + Segundos.Text + ":" + Decimas.Text
        FullScreen.ScoreA.Text = ScoreA.Text
        FullScreen.ScoreB.Text = ScoreB.Text



    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If (vbYes = MsgBox("¿Está seguro de querer reiniciar el contador de tiempo principal?", MsgBoxStyle.YesNo, "Confirmación de reseteo")) Then
            actual24 = 24000
            Button5.Text = "Inicio"
            Timer1.Enabled = False
            TiroA.Text = 24
            TiroB.Text = 24
            Timer3.Enabled = False
            tiempo()
        End If
    End Sub
    Private Sub inicio()
        If Button5.Text = "Inicio" Then
            timelapse = Now
            totminutos = (CDbl(Minutos.Text) * 60000) + (CDbl(Segundos.Text) * 1000) + (CDbl(Decimas.Text) * 10)
            time24 = Now
            Timer1.Enabled = True
            Timer3.Enabled = True
            Textra2.Enabled = False
            Textra.Enabled = False
            cuarto1.Enabled = False
            cuarto2.Enabled = False
            cuarto3.Enabled = False
            cuarto4.Enabled = False
            Textra2.Enabled = False
            Textra.Enabled = False


            Button5.Text = "Pausa"

        Else
            actual24 = actual24 - Now.Subtract(time24).TotalMilliseconds
            totminutos = totminutos - Now.Subtract(timelapse).TotalMilliseconds
            Timer1.Enabled = False
            Timer3.Enabled = False
            Button5.Text = "Inicio"
            cuarto1.Enabled = True
            cuarto2.Enabled = True
            cuarto3.Enabled = True
            cuarto4.Enabled = True
            Textra2.Enabled = True
            Textra.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        inicio()




    End Sub




    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If ToolStripMenuItem2.Checked Then
            Me.Width = 849
            log.Visible = False
            ToolStripMenuItem2.Checked = False
        Else
            Me.Width = 1361
            log.Visible = True
            ToolStripMenuItem2.Checked = True
        End If




    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles TimerSerialData.Tick
        If config.ListBox3.SelectedIndex <> -1 Then
            Dim sum As Integer
            Dim continuar As Boolean

            sum = 0

            Dim sPort As New IO.Ports.SerialPort(config.ListBox3.Items.Item(config.ListBox3.SelectedIndex), 250000, Parity.None, 8, StopBits.One)
            continuar = True

            Try
                sPort.Open()

            Catch ex As Exception

                TimerSerialData.Enabled = False
                MsgBox("Este puerto no está disponible para el marcador", MsgBoxStyle.Information, "Advertencia")
                config.ListBox3.SelectedIndex = -1
                TimerSerialData.Enabled = True
                continuar = False

            End Try

            Try
                If CInt(Minutos.Text) < 0 Or CInt(Segundos.Text) < 0 Or CInt(Decimas.Text) < 0 Then
                    continuar = False
                End If
            Catch ex As Exception

                MsgBox("FIN DEL CUARTO", MsgBoxStyle.Exclamation, "Advertencia")
                continuar = False
                MsgBox(e.ToString)



            End Try
            If continuar Then


                If valores(0) <> ChrW(convierte(CInt(ScoreA.Text.Substring(0, 1)))) Then
                    sPort.Write(ChrW(0))
                    sPort.Write(ChrW(convierte(CInt(ScoreA.Text.Substring(0, 1)))))
                    valores(0) = ChrW(convierte(CInt(ScoreA.Text.Substring(0, 1))))
                End If
                If valores(1) <> ChrW(convierte(CInt(ScoreA.Text.Substring(1, 1)))) Then
                    sPort.Write(ChrW(1))
                    sPort.Write(ChrW(convierte(CInt(ScoreA.Text.Substring(1, 1)))))
                    valores(1) = ChrW(convierte(CInt(ScoreA.Text.Substring(1, 1))))
                End If
                If valores(2) <> ChrW(convierte(CInt(ScoreB.Text.Substring(0, 1)))) Then
                    sPort.Write(ChrW(2))
                    sPort.Write(ChrW(convierte(CInt(ScoreB.Text.Substring(0, 1)))))
                    valores(2) = ChrW(convierte(CInt(ScoreB.Text.Substring(0, 1))))
                End If

                If valores(3) <> ChrW(convierte(CInt(ScoreB.Text.Substring(1, 1)))) Then
                    sPort.Write(ChrW(3))
                    sPort.Write(ChrW(convierte(CInt(ScoreB.Text.Substring(1, 1)))))
                    valores(3) = ChrW(convierte(CInt(ScoreB.Text.Substring(1, 1))))
                End If
                If (CInt(Minutos.Text) > 0) Then
                    If valores(4) <> ChrW(convierte(CInt(Minutos.Text.Substring(0, 1)))) Then
                        sPort.Write(ChrW(4))
                        sPort.Write(ChrW(convierte(CInt(Minutos.Text.Substring(0, 1)))))
                        valores(4) = ChrW(convierte(CInt(Minutos.Text.Substring(0, 1))))
                    End If

                    If valores(5) <> ChrW(convierte(CInt(Minutos.Text.Substring(1, 1)))) Then
                        sPort.Write(ChrW(5))
                        sPort.Write(ChrW(convierte(CInt(Minutos.Text.Substring(1, 1)))))
                        valores(5) = ChrW(convierte(CInt(Minutos.Text.Substring(1, 1))))
                    End If

                    If valores(6) <> ChrW(convierte(CInt(Segundos.Text.Substring(0, 1)))) Then
                        sPort.Write(ChrW(6))
                        sPort.Write(ChrW(convierte(CInt(Segundos.Text.Substring(0, 1)))))
                        valores(6) = ChrW(convierte(CInt(Segundos.Text.Substring(0, 1))))
                    End If

                    If valores(7) <> ChrW(convierte(CInt(Segundos.Text.Substring(1, 1)))) Then
                        sPort.Write(ChrW(7))
                        sPort.Write(ChrW(convierte(CInt(Segundos.Text.Substring(1, 1)))))
                        valores(7) = ChrW(convierte(CInt(Segundos.Text.Substring(1, 1))))
                    End If
                Else
                    If valores(4) <> ChrW(convierte(CInt(Segundos.Text.Substring(0, 1)))) Then
                        sPort.Write(ChrW(4))
                        sPort.Write(ChrW(convierte(CInt(Segundos.Text.Substring(0, 1)))))
                        valores(4) = ChrW(convierte(CInt(Segundos.Text.Substring(0, 1))))
                    End If

                    If valores(5) <> ChrW(convierte(CInt(Segundos.Text.Substring(1, 1)))) Then
                        sPort.Write(ChrW(5))
                        sPort.Write(ChrW(convierte(CInt(Segundos.Text.Substring(1, 1)))))
                        valores(5) = ChrW(convierte(CInt(Segundos.Text.Substring(1, 1))))
                    End If

                    If valores(6) <> ChrW(convierte(CInt(Decimas.Text.Substring(0, 1)))) Then
                        sPort.Write(ChrW(6))
                        sPort.Write(ChrW(convierte(CInt(Decimas.Text.Substring(0, 1)))))
                        valores(6) = ChrW(convierte(CInt(Decimas.Text.Substring(0, 1))))
                    End If

                    If valores(7) <> ChrW(convierte(CInt(Decimas.Text.Substring(1, 1)))) Then
                        sPort.Write(ChrW(7))
                        sPort.Write(ChrW(convierte(CInt(Decimas.Text.Substring(1, 1)))))
                        valores(7) = ChrW(convierte(CInt(Decimas.Text.Substring(1, 1))))
                    End If
                End If
                If cuarto1.Checked Then
                    If A11.Checked Then
                        sum = sum + 1
                    End If
                    If A12.Checked Then
                        sum = sum + 2
                    End If
                    If A13.Checked Then
                        sum = sum + 4
                    End If
                    If A14.Checked Then
                        sum = sum + 8
                    End If
                    If A15.Checked Then
                        sum = sum + 16
                    End If
                ElseIf cuarto2.Checked Then
                    If A21.Checked Then
                        sum = sum + 1
                    End If
                    If A22.Checked Then
                        sum = sum + 2
                    End If
                    If A23.Checked Then
                        sum = sum + 4
                    End If
                    If A24.Checked Then
                        sum = sum + 8
                    End If
                    If A25.Checked Then
                        sum = sum + 16
                    End If
                ElseIf cuarto3.Checked Then
                    If A31.Checked Then
                        sum = sum + 1
                    End If
                    If A32.Checked Then
                        sum = sum + 2
                    End If
                    If A33.Checked Then
                        sum = sum + 4
                    End If
                    If A34.Checked Then
                        sum = sum + 8
                    End If
                    If A35.Checked Then
                        sum = sum + 16
                    End If
                Else
                    If A41.Checked Then
                        sum = sum + 1
                    End If
                    If A42.Checked Then
                        sum = sum + 2
                    End If
                    If A43.Checked Then
                        sum = sum + 4
                    End If
                    If A44.Checked Then
                        sum = sum + 8
                    End If
                    If A45.Checked Then
                        sum = sum + 16
                    End If
                End If


                If CChar(ChrW(sum)) <> valores(8) Then
                    sPort.Write(ChrW(8))
                    sPort.Write(ChrW(sum))
                    valores(8) = CChar(ChrW(sum))
                End If
                sum = 0
                If cuarto1.Checked Then
                    If B11.Checked Then
                        sum = sum + 1
                    End If
                    If B12.Checked Then
                        sum = sum + 2
                    End If
                    If B13.Checked Then
                        sum = sum + 4
                    End If
                    If B14.Checked Then
                        sum = sum + 8
                    End If
                    If B15.Checked Then
                        sum = sum + 16
                    End If
                ElseIf cuarto2.Checked Then
                    If B21.Checked Then
                        sum = sum + 1
                    End If
                    If B22.Checked Then
                        sum = sum + 2
                    End If
                    If B23.Checked Then
                        sum = sum + 4
                    End If
                    If B24.Checked Then
                        sum = sum + 8
                    End If
                    If B25.Checked Then
                        sum = sum + 16
                    End If
                ElseIf cuarto3.Checked Then
                    If B31.Checked Then
                        sum = sum + 1
                    End If
                    If B32.Checked Then
                        sum = sum + 2
                    End If
                    If B33.Checked Then
                        sum = sum + 4
                    End If
                    If B34.Checked Then
                        sum = sum + 8
                    End If
                    If B35.Checked Then
                        sum = sum + 16
                    End If
                Else
                    If B41.Checked Then
                        sum = sum + 1
                    End If
                    If B42.Checked Then
                        sum = sum + 2
                    End If
                    If B43.Checked Then
                        sum = sum + 4
                    End If
                    If B44.Checked Then
                        sum = sum + 8
                    End If
                    If B45.Checked Then
                        sum = sum + 16
                    End If
                End If

                If ChrW(sum) <> valores(9) Then
                    sPort.Write(ChrW(9))
                    sPort.Write(ChrW(sum))
                    valores(9) = ChrW(sum)
                End If


                sPort.Close()

            End If
        End If
    End Sub


    Private Sub TeamA_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub
    Private Sub startup()
        valores(8) = ChrW(1)
        valores(9) = ChrW(1)
        fecha.Text = Now().Day.ToString + "/" + Now().Month.ToString + "/" + Now().Year.ToString
        config.ListBox3.Items.Clear()
        config.ListBox1.Items.Clear()
        config.ListBox2.Items.Clear()
        Timer1.Enabled = False
        TimerSerialData.Enabled = False
        Timer3.Enabled = False
        keysTimmer.Enabled = True

        TALV.Clear()
        TBLV.Clear()

        TALV.View = View.Details
        TBLV.View = View.Details

        TALV.Columns.Add("Número", 50, HorizontalAlignment.Center)
        TALV.Columns.Add("Nombre", 150, HorizontalAlignment.Center)
        TALV.Columns.Add("Faltas", 50, HorizontalAlignment.Center)
        TALV.Columns.Add("Canastas", 70, HorizontalAlignment.Center)
        TALV.Columns.Add("Robos", 70, HorizontalAlignment.Center)
        TALV.Columns.Add("Asistencias", 90, HorizontalAlignment.Center)
        TALV.Columns.Add("Rebotes", 70, HorizontalAlignment.Center)
        TALV.Columns.Add("ID", 30, HorizontalAlignment.Center)



        TBLV.Columns.Add("Número", 50, HorizontalAlignment.Center)
        TBLV.Columns.Add("Nombre", 150, HorizontalAlignment.Center)
        TBLV.Columns.Add("Faltas", 50, HorizontalAlignment.Center)
        TBLV.Columns.Add("Canastas", 70, HorizontalAlignment.Center)
        TBLV.Columns.Add("Robos", 70, HorizontalAlignment.Center)
        TBLV.Columns.Add("Asistencias", 90, HorizontalAlignment.Center)
        TBLV.Columns.Add("Rebotes", 70, HorizontalAlignment.Center)
        TBLV.Columns.Add("ID", 30, HorizontalAlignment.Center)

        For Each sp As String In My.Computer.Ports.SerialPortNames
            config.ListBox3.Items.Add(sp)
        Next
        If Not My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\configuracion.xml") Then
            My.Computer.FileSystem.WriteAllText(Application.UserAppDataPath + "\configuracion.xml", "<?xml version=""1.0"" encoding=""utf-8"" ?><Configuracion>  <Tiempo>12</Tiempo>  <cTiro>24</cTiro>  <Activacion>mFJ8Zook09aeYDT4CWpWkw==</Activacion></Configuracion>", False)
        End If
        Using reader As XmlReader = XmlReader.Create(Application.UserAppDataPath + "\configuracion.xml")
            While reader.Read()
                If reader.IsStartElement() Then
                    If Not reader.IsEmptyElement Then
                        If reader.Name <> "Configuracion" Then
                            If Not reader.IsEmptyElement Then
                                config.ListBox1.Items.Add(reader.Name)
                                config.ListBox2.Items.Add(reader.ReadString())
                            End If
                        End If
                    End If
                End If
            End While
            reader.Close()

        End Using
        categoria.Text = ""
        Cancha.Text = ""
        TeamA_name.Text = ""
        TeamB_name.Text = ""
        TiroA.Text = "24"
        TiroB.Text = "24"
        ScoreA.Text = "00"
        ScoreB.Text = "00"
        log.Items.Clear()

        Rama.Text = ""
        A11.Checked = False
        A12.Checked = False
        A13.Checked = False
        A14.Checked = False
        A15.Checked = False
        A21.Checked = False
        A22.Checked = False
        A23.Checked = False
        A24.Checked = False
        A25.Checked = False
        A31.Checked = False
        A32.Checked = False
        A33.Checked = False
        A34.Checked = False
        A35.Checked = False
        A41.Checked = False
        A42.Checked = False
        A43.Checked = False
        A44.Checked = False
        A45.Checked = False
        B11.Checked = False
        B12.Checked = False
        B13.Checked = False
        B14.Checked = False
        B15.Checked = False
        B21.Checked = False
        B22.Checked = False
        B23.Checked = False
        B24.Checked = False
        B25.Checked = False
        B31.Checked = False
        B32.Checked = False
        B33.Checked = False
        B34.Checked = False
        B35.Checked = False
        B41.Checked = False
        B42.Checked = False
        B43.Checked = False
        B44.Checked = False
        B45.Checked = False

        actual24 = 24000
        Button5.Text = "Inicio"
        Timer1.Enabled = False
        Timer3.Enabled = False

        tiempo()


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        Dim dir1 = Directory.GetCurrentDirectory()


        Dim dir = System.Reflection.Assembly.GetExecutingAssembly().Location
        dir = Path.GetDirectoryName(dir)
        xlWorkBook = xlApp.Workbooks.Open(dir + "/Resultados.xlsm")

        xlWorkSheet = xlWorkBook.Worksheets("Jugadores")
        Dim xlCells As Excel.Range = Nothing
        Dim c = 5
        Dim d = 5
        idJugador.Items.Clear()
        jugadores.Items.Clear()
        numJugador.Items.Clear()
        Dim jug = ""
        xlCells = (xlWorkSheet.Cells(c, 2))
        Dim active = xlCells.Value2
        xlCells = (xlWorkSheet.Cells(c, 3))


        idJugador.Items.Clear()

        While (CStr(xlCells.Value2) <> "")
            If (active = 1) Then
                xlCells = xlWorkSheet.Cells(c, 3)
                idJugador.Items.Add(xlCells.Value2)
                xlCells = xlWorkSheet.Cells(c, 4)
                jugadores.Items.Add(xlCells.Value2)
                xlCells = xlWorkSheet.Cells(c, 5)
                numJugador.Items.Add(xlCells.Value2)
            End If
            c = c + 1
            xlCells = (xlWorkSheet.Cells(c, 2))
            active = xlCells.Value2
            xlCells = (xlWorkSheet.Cells(c, 3))
        End While
        c = 5
        TeamA_name.Items.Clear()
        TeamB_name.Items.Clear()

        idEquipo.Items.Clear()

        xlWorkSheet = xlWorkBook.Sheets("Equipos")
        xlCells = (xlWorkSheet.Cells(c, 2))
        active = xlCells.Value2
        xlCells = (xlWorkSheet.Cells(c, 3))
        While (CStr(xlCells.Value2) <> "")
            If (active = 1) Then
                d = 5
                xlCells = (xlWorkSheet.Cells(c, 3))
                idEquipo.Items.Add(CStr(xlCells.Value2))
                xlCells = (xlWorkSheet.Cells(c, 4))
                Equipos.Items.Add(CStr(xlCells.Value2))
                TeamA_name.Items.Add(CStr(xlCells.Value2))
                TeamB_name.Items.Add(CStr(xlCells.Value2))
                xlCells = (xlWorkSheet.Cells(c, d))
            End If
            c = c + 1
            xlCells = (xlWorkSheet.Cells(c, 2))
            active = xlCells.Value2
            xlCells = (xlWorkSheet.Cells(c, 3))
        End While

        c = 5
        jugXequipo.Items.Clear()

        xlWorkSheet = xlWorkBook.Sheets("Armado de equipos")
        xlCells = (xlWorkSheet.Cells(c, 2))
        While (CStr(xlCells.Value2) <> "")
            Dim k As String
            k = xlCells.Value
            xlCells = (xlWorkSheet.Cells(c, 3))
            jugXequipo.Items.Add(k + "|" + CStr(xlCells.Value))
            c = c + 1
            xlCells = (xlWorkSheet.Cells(c, 2))
        End While

        xlWorkBook.Saved = True
        xlWorkBook.Close()


        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        xlApp = Nothing
        For Each p As Process In Process.GetProcesses
            If p.ProcessName = "EXCEL" Then p.Kill()
        Next

    End Sub

    Private Sub GuardarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem1.Click
        If MsgBox("¿Desea Guardar los datos y agregarlos a la base de datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Try
                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value

                xlApp = New Excel.Application
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                Dim dir = System.Reflection.Assembly.GetExecutingAssembly().Location
                dir = Path.GetDirectoryName(dir)
                xlWorkBook = xlApp.Workbooks.Open(dir + "/Resultados.xlsm")


                xlWorkBook.Sheets("Machote").Copy(xlWorkBook.Sheets("Machote"))
                xlWorkSheet = xlWorkBook.Sheets("Machote")
                xlWorkSheet = xlWorkBook.Sheets("Machote (2)")
                Dim k As String
                k = TeamA_name.Text.Substring(0, If(TeamA_name.Text.Length > 13, 13, TeamA_name.Text.Length)) + " vs " + (TeamB_name.Text.Substring(0, If(TeamB_name.Text.Length > 13, 13, TeamB_name.Text.Length)))
                xlWorkSheet.Name = k

                xlWorkSheet.Cells(3, 9) = fecha.Text
                xlWorkSheet.Cells(2, 9) = Cancha.Text
                xlWorkSheet.Cells(2, 5) = categoria.Text
                xlWorkSheet.Cells(3, 5) = Rama.Text

                xlWorkSheet.Cells(6, 7) = TeamA_name.Text
                foulsA_1 = 0
                foulsA_2 = 0
                foulsA_3 = 0
                foulsA_4 = 0
                For c = 0 To log.Items.Count - 1
                    Dim a() As String
                    a = Split(log.Items.Item(c), "|")

                    If a(0) = "A" And a(1) = "F+1" And a(3) = "1" Then
                        foulsA_1 = foulsA_1 + 1
                    End If
                    If a(0) = "A" And a(1) = "F-1" And a(3) = "1" Then
                        foulsA_1 = foulsA_1 - 1
                    End If
                    If a(0) = "A" And a(1) = "F+1" And a(3) = "2" Then
                        foulsA_2 = foulsA_2 + 1
                    End If
                    If a(0) = "A" And a(1) = "F-1" And a(3) = "2" Then
                        foulsA_2 = foulsA_2 - 1
                    End If
                    If a(0) = "A" And a(1) = "F+1" And a(3) = "3" Then
                        foulsA_3 = foulsA_3 + 1
                    End If
                    If a(0) = "A" And a(1) = "F-1" And a(3) = "3" Then
                        foulsA_3 = foulsA_3 - 1
                    End If
                    If a(0) = "A" And a(1) = "F+1" And (a(3) = "4" Or a(3) = "E") Then
                        foulsA_4 = foulsA_4 + 1
                    End If
                    If a(0) = "A" And a(1) = "F-1" And (a(3) = "4" Or a(3) = "E") Then
                        foulsA_4 = foulsA_4 - 1
                    End If
                Next
                xlWorkSheet.Cells(8, 3) = CStr(foulsA_1)
                xlWorkSheet.Cells(9, 3) = CStr(foulsA_2)
                xlWorkSheet.Cells(10, 3) = CStr(foulsA_3)
                xlWorkSheet.Cells(11, 3) = CStr(foulsA_4)

                If TALV.Items.Count <> 0 Then
                    Dim C1, C2, C3, C4, Ex As Integer
                    For c = 0 To TALV.Items.Count - 1
                        C1 = 0
                        C2 = 0
                        C3 = 0
                        C4 = 0
                        Ex = 0
                        xlWorkSheet.Cells(14 + c, 7) = CStr(TALV.Items(c).SubItems(0).Text)
                        xlWorkSheet.Cells(14 + c, 8) = CStr(TALV.Items(c).SubItems(1).Text)
                        xlWorkSheet.Cells(14 + c, 10) = CStr(TALV.Items(c).SubItems(2).Text)
                        xlWorkSheet.Cells(14 + c, 11) = TALV.Items(c).SubItems(3).Text
                        If log.Items.Count <> 0 Then
                            For cc = 0 To log.Items.Count - 1
                                Dim a() As String
                                a = Split(log.Items.Item(cc), "|")
                                If a(0) = "A" And a(1) = "C+1" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 + 1
                                End If
                                If a(0) = "A" And a(1) = "C-1" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 - 1
                                End If
                                If a(0) = "A" And a(1) = "C+1" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 + 1
                                End If
                                If a(0) = "A" And a(1) = "C-1" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 - 1
                                End If
                                If a(0) = "A" And a(1) = "C+1" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 + 1
                                End If
                                If a(0) = "A" And a(1) = "C-1" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 - 1
                                End If
                                If a(0) = "A" And a(1) = "C+1" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 + 1
                                End If
                                If a(0) = "A" And a(1) = "C-1" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 - 1
                                End If
                                If a(0) = "A" And a(1) = "C+1" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex + 1
                                End If
                                If a(0) = "A" And a(1) = "C-1" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex - 1
                                End If
                                If a(0) = "A" And a(1) = "C+2" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 + 2
                                End If
                                If a(0) = "A" And a(1) = "C-2" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 - 2
                                End If
                                If a(0) = "A" And a(1) = "C+2" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 + 2
                                End If
                                If a(0) = "A" And a(1) = "C-2" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 - 2
                                End If
                                If a(0) = "A" And a(1) = "C+2" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 + 2
                                End If
                                If a(0) = "A" And a(1) = "C-2" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 - 2
                                End If
                                If a(0) = "A" And a(1) = "C+2" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 + 2
                                End If
                                If a(0) = "A" And a(1) = "C-2" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 - 2
                                End If
                                If a(0) = "A" And a(1) = "C+2" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex + 2
                                End If
                                If a(0) = "A" And a(1) = "C-2" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex - 2
                                End If
                                If a(0) = "A" And a(1) = "C+3" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 + 3
                                End If
                                If a(0) = "A" And a(1) = "C-3" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 - 3
                                End If
                                If a(0) = "A" And a(1) = "C+3" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 + 3
                                End If
                                If a(0) = "A" And a(1) = "C-3" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 - 3
                                End If
                                If a(0) = "A" And a(1) = "C+3" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 + 3
                                End If
                                If a(0) = "A" And a(1) = "C-3" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 - 3
                                End If
                                If a(0) = "A" And a(1) = "C+3" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 + 3
                                End If
                                If a(0) = "A" And a(1) = "C-3" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 - 3
                                End If
                                If a(0) = "A" And a(1) = "C+3" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex + 3
                                End If
                                If a(0) = "A" And a(1) = "C-3" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex - 3
                                End If
                            Next
                            xlWorkSheet.Cells(14 + c, 2) = C1
                            xlWorkSheet.Cells(14 + c, 3) = C2
                            xlWorkSheet.Cells(14 + c, 4) = C3
                            xlWorkSheet.Cells(14 + c, 5) = C4
                            xlWorkSheet.Cells(14 + c, 6) = Ex
                        End If

                    Next
                End If

                xlWorkSheet.Cells(36, 7) = TeamB_name.Text
                foulsB_1 = 0
                foulsB_2 = 0
                foulsB_3 = 0
                foulsB_4 = 0
                For c = 0 To log.Items.Count - 1
                    Dim a() As String
                    a = Split(log.Items.Item(c), "|")

                    If a(0) = "B" And a(1) = "F+1" And a(3) = "1" Then
                        foulsB_1 = foulsB_1 + 1
                    End If
                    If a(0) = "B" And a(1) = "F-1" And a(3) = "1" Then
                        foulsB_1 = foulsB_1 - 1
                    End If
                    If a(0) = "B" And a(1) = "F+1" And a(3) = "2" Then
                        foulsB_2 = foulsB_2 + 1
                    End If
                    If a(0) = "B" And a(1) = "F-1" And a(3) = "2" Then
                        foulsB_2 = foulsB_2 - 1
                    End If
                    If a(0) = "B" And a(1) = "F+1" And a(3) = "3" Then
                        foulsB_3 = foulsB_3 + 1
                    End If
                    If a(0) = "B" And a(1) = "F-1" And a(3) = "3" Then
                        foulsB_3 = foulsB_3 - 1
                    End If
                    If a(0) = "B" And a(1) = "F+1" And (a(3) = "4" Or a(3) = "E") Then
                        foulsB_4 = foulsB_4 + 1
                    End If
                    If a(0) = "B" And a(1) = "F-1" And (a(3) = "4" Or a(3) = "E") Then
                        foulsB_4 = foulsB_4 - 1
                    End If
                Next
                xlWorkSheet.Cells(38, 3) = CStr(foulsB_1)
                xlWorkSheet.Cells(39, 3) = CStr(foulsB_2)
                xlWorkSheet.Cells(40, 3) = CStr(foulsB_3)
                xlWorkSheet.Cells(41, 3) = CStr(foulsB_4)

                If TBLV.Items.Count <> 0 Then
                    Dim C1, C2, C3, C4, Ex As Integer
                    For c = 0 To TBLV.Items.Count - 1
                        C1 = 0
                        C2 = 0
                        C3 = 0
                        C4 = 0
                        Ex = 0
                        xlWorkSheet.Cells(44 + c, 7) = TBLV.Items(c).SubItems(0).Text
                        xlWorkSheet.Cells(44 + c, 8) = TBLV.Items(c).SubItems(1).Text
                        xlWorkSheet.Cells(44 + c, 10) = TBLV.Items(c).SubItems(2).Text
                        xlWorkSheet.Cells(44 + c, 11) = TBLV.Items(c).SubItems(3).Text

                        If log.Items.Count <> 0 Then
                            For cc = 0 To log.Items.Count - 1
                                Dim a() As String
                                a = Split(log.Items.Item(cc), "|")
                                If a(0) = "B" And a(1) = "C+1" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 + 1
                                End If
                                If a(0) = "B" And a(1) = "C-1" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 - 1
                                End If
                                If a(0) = "B" And a(1) = "C+1" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 + 1
                                End If
                                If a(0) = "B" And a(1) = "C-1" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 - 1
                                End If
                                If a(0) = "B" And a(1) = "C+1" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 + 1
                                End If
                                If a(0) = "B" And a(1) = "C-1" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 - 1
                                End If
                                If a(0) = "B" And a(1) = "C+1" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 + 1
                                End If
                                If a(0) = "B" And a(1) = "C-1" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 - 1
                                End If
                                If a(0) = "B" And a(1) = "C+1" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex + 1
                                End If
                                If a(0) = "B" And a(1) = "C-1" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex - 1
                                End If
                                If a(0) = "B" And a(1) = "C+2" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 + 2
                                End If
                                If a(0) = "B" And a(1) = "C-2" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 - 2
                                End If
                                If a(0) = "B" And a(1) = "C+2" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 + 2
                                End If
                                If a(0) = "B" And a(1) = "C-2" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 - 2
                                End If
                                If a(0) = "B" And a(1) = "C+2" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 + 2
                                End If
                                If a(0) = "B" And a(1) = "C-2" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 - 2
                                End If
                                If a(0) = "B" And a(1) = "C+2" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 + 2
                                End If
                                If a(0) = "B" And a(1) = "C-2" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 - 2
                                End If
                                If a(0) = "B" And a(1) = "C+2" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex + 2
                                End If
                                If a(0) = "B" And a(1) = "C-2" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex - 2
                                End If
                                If a(0) = "B" And a(1) = "C+3" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 + 3
                                End If
                                If a(0) = "B" And a(1) = "C-3" And a(3) = "1" And a(4) = CStr(c) Then
                                    C1 = C1 - 3
                                End If
                                If a(0) = "B" And a(1) = "C+3" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 + 3
                                End If
                                If a(0) = "B" And a(1) = "C-3" And a(3) = "2" And a(4) = CStr(c) Then
                                    C2 = C2 - 3
                                End If
                                If a(0) = "B" And a(1) = "C+3" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 + 3
                                End If
                                If a(0) = "B" And a(1) = "C-3" And a(3) = "3" And a(4) = CStr(c) Then
                                    C3 = C3 - 3
                                End If
                                If a(0) = "B" And a(1) = "C+3" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 + 3
                                End If
                                If a(0) = "B" And a(1) = "C-3" And a(3) = "4" And a(4) = CStr(c) Then
                                    C4 = C4 - 3
                                End If
                                If a(0) = "B" And a(1) = "C+3" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex + 3
                                End If
                                If a(0) = "B" And a(1) = "C-3" And a(3) = "E" And a(4) = CStr(c) Then
                                    Ex = Ex - 3
                                End If
                            Next
                            xlWorkSheet.Cells(44 + c, 2) = C1
                            xlWorkSheet.Cells(44 + c, 3) = C2
                            xlWorkSheet.Cells(44 + c, 4) = C3
                            xlWorkSheet.Cells(44 + c, 5) = C4
                            xlWorkSheet.Cells(44 + c, 6) = Ex
                        End If

                    Next
                End If
                xlWorkSheet = xlWorkBook.Sheets("Jugadores")
                Dim xRng As Excel.Range


                For c = 0 To TALV.Items.Count - 1
                    Dim d As Integer
                    d = 5
                    xRng = CType(xlWorkSheet.Cells(d, 3), Excel.Range)

                    While (CStr(xRng.Value2) <> "")
                        xRng = CType(xlWorkSheet.Cells(d, 3), Excel.Range)
                        If (xRng.Value2 = TALV.Items(c).SubItems(7).Text) Then
                            xRng = CType(xlWorkSheet.Cells(d, 6), Excel.Range)
                            xlWorkSheet.Cells(d, 6) = CInt(xRng.Value2) + CInt(TALV.Items(c).SubItems(3).Text)
                            xRng = CType(xlWorkSheet.Cells(d, 7), Excel.Range)
                            xlWorkSheet.Cells(d, 7) = CInt(xRng.Value2) + CInt(TALV.Items(c).SubItems(2).Text)
                            xRng = CType(xlWorkSheet.Cells(d, 8), Excel.Range)
                            xlWorkSheet.Cells(d, 8) = CInt(xRng.Value2) + 1
                            xRng = CType(xlWorkSheet.Cells(d, 9), Excel.Range)
                            xlWorkSheet.Cells(d, 9) = CInt(xRng.Value2) + CInt(TALV.Items(c).SubItems(4).Text)
                            xRng = CType(xlWorkSheet.Cells(d, 10), Excel.Range)
                            xlWorkSheet.Cells(d, 10) = CInt(xRng.Value2) + CInt(TALV.Items(c).SubItems(5).Text)
                            xRng = CType(xlWorkSheet.Cells(d, 11), Excel.Range)
                            xlWorkSheet.Cells(d, 11) = CInt(xRng.Value2) + CInt(TALV.Items(c).SubItems(6).Text)
                        End If
                        d = d + 1
                    End While
                Next
                For c = 0 To TBLV.Items.Count - 1
                    Dim d As Integer
                    d = 5
                    xRng = CType(xlWorkSheet.Cells(d, 3), Excel.Range)

                    While (CStr(xRng.Value2) <> "")
                        xRng = CType(xlWorkSheet.Cells(d, 3), Excel.Range)
                        If (CStr(xRng.Value2) = TBLV.Items(c).SubItems(7).Text) Then
                            xRng = CType(xlWorkSheet.Cells(d, 6), Excel.Range)
                            xlWorkSheet.Cells(d, 6) = CInt(xRng.Value2) + CInt(TBLV.Items(c).SubItems(3).Text)
                            xRng = CType(xlWorkSheet.Cells(d, 7), Excel.Range)
                            xlWorkSheet.Cells(d, 7) = CInt(xRng.Value2) + CInt(TBLV.Items(c).SubItems(2).Text)
                            xRng = CType(xlWorkSheet.Cells(d, 8), Excel.Range)
                            xlWorkSheet.Cells(d, 8) = CInt(xRng.Value2) + 1
                            xRng = CType(xlWorkSheet.Cells(d, 9), Excel.Range)
                            xlWorkSheet.Cells(d, 9) = CInt(xRng.Value2) + CInt(TBLV.Items(c).SubItems(4).Text)
                            xRng = CType(xlWorkSheet.Cells(d, 10), Excel.Range)
                            xlWorkSheet.Cells(d, 10) = CInt(xRng.Value2) + CInt(TBLV.Items(c).SubItems(5).Text)
                            xRng = CType(xlWorkSheet.Cells(d, 11), Excel.Range)
                            xlWorkSheet.Cells(d, 11) = CInt(xRng.Value2) + CInt(TBLV.Items(c).SubItems(6).Text)
                        End If
                        d = d + 1
                    End While
                Next

                xlWorkBook.Save()
                xlWorkBook.Saved = True
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                xlApp = Nothing
                For Each p As Process In Process.GetProcesses
                    If p.ProcessName = "EXCEL" Then p.Kill()
                Next
                MsgBox("Base de datos actualizada", MsgBoxStyle.Information, "Información")
            Catch ex As Exception
                MsgBox("Verifique que no se esté utilizando la base de datos" + vbCrLf + "Error:" + ex.ToString, MsgBoxStyle.Critical, "Error")

            End Try
        End If
    End Sub

    Private Sub AcercaDeToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem2.Click
        About.Show()

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim p As New System.Diagnostics.ProcessStartInfo()
        p.WindowStyle = ProcessWindowStyle.Hidden
        Dim dir = System.Reflection.Assembly.GetExecutingAssembly().Location
        dir = Path.GetDirectoryName(dir)

        p.FileName = dir + "/Resultados.xlsm"
        p.UseShellExecute = True
        System.Diagnostics.Process.Start(p)
    End Sub

    Private Sub AcercaDeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem1.Click
        Guia.Show()

    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click

        Process.Start("explorer.exe", "/select," + Application.StartupPath + "\Reglas\reglas.pdf")


    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        ToolStripMenuItem4.Checked = Not ToolStripMenuItem4.Checked
        If ToolStripMenuItem4.Checked Then
            Dim myScreens() As Screen = Screen.AllScreens

            If (myScreens.Length > 1) Then
                'Position form 1 in the middle of screen 1
                'Position the top left corner of form 2 in the middle of screen 2
                Dim H, W, R As Double

                H = myScreens(1).Bounds.Size.Height
                W = myScreens(1).Bounds.Size.Width
                R = W / H

                If R = 1.6 Then
                    FullScreen.Cuarto.Height = H / 2
                    FullScreen.Cuarto.Width = FullScreen.Cuarto.Height * 0.1875
                    FullScreen.ScoreA.Font = New Font("DS-Digital", W / 4, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.ScoreB.Font = New Font("DS-Digital", W / 4, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.TimeFS.Font = New Font("DS-Digital", W / 4, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.FoulsA.Font = New Font("DS-Digital", W / 7, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.FoulsB.Font = New Font("DS-Digital", W / 7, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.Sec24A.Font = New Font("DS-Digital", W / 6, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.Sec24B.Font = New Font("DS-Digital", W / 6, FontStyle.Regular, GraphicsUnit.Pixel)

                    FullScreen.ScoreA.Top = H / 64
                    FullScreen.ScoreB.Top = H / 64
                    FullScreen.Sec24A.Top = (H / 2) - (FullScreen.Sec24A.Height / 2)
                    FullScreen.Sec24B.Top = (H / 2) - (FullScreen.Sec24B.Height / 2)
                    FullScreen.TimeFS.Top = (H * 0.75) - (FullScreen.TimeFS.Height / 2)
                    FullScreen.FoulsA.Top = H * 3 / 8
                    FullScreen.FoulsB.Top = H * 3 / 8

                    FullScreen.Sec24A.Left = CInt(W * 0.1)
                    FullScreen.Sec24B.Left = W * 0.5 + W * 0.3 - (FullScreen.Sec24B.Size.Width / 2)
                    FullScreen.ScoreA.Left = W * 0.015625
                    FullScreen.ScoreB.Left = (W * 0.99) - FullScreen.ScoreB.Size.Width
                    FullScreen.TimeFS.Left = (W / 2) - (FullScreen.TimeFS.Width / 2)
                    FullScreen.FoulsA.Left = (W / 2) - FullScreen.FoulsA.Width - (FullScreen.FoulsA.Width / 2)
                    FullScreen.FoulsB.Left = (W / 2) + (FullScreen.FoulsB.Width / 2)
                    FullScreen.Cuarto.Left = (W / 2) - (FullScreen.Cuarto.Width / 2)




                    FullScreen.Left = myScreens(0).Bounds.Width + myScreens(1).WorkingArea.Width / 2
                    FullScreen.Top = myScreens(1).WorkingArea.Height / 2
                ElseIf R = 1920 / 1080 Then
                    FullScreen.Cuarto.Height = H / 2
                    FullScreen.Cuarto.Width = FullScreen.Cuarto.Height * 0.1875
                    FullScreen.ScoreA.Font = New Font("DS-Digital", W / 6.5, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.ScoreB.Font = New Font("DS-Digital", W / 6.5, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.TimeFS.Font = New Font("DS-Digital", W / 5, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.FoulsA.Font = New Font("DS-Digital", W / 8, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.FoulsB.Font = New Font("DS-Digital", W / 8, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.Sec24A.Font = New Font("DS-Digital", W / 7, FontStyle.Regular, GraphicsUnit.Pixel)
                    FullScreen.Sec24B.Font = New Font("DS-Digital", W / 7, FontStyle.Regular, GraphicsUnit.Pixel)

                    FullScreen.ScoreA.Top = H / 64
                    FullScreen.ScoreB.Top = H / 64
                    FullScreen.Sec24A.Top = (H / 2) - (FullScreen.Sec24A.Height / 1.65)
                    FullScreen.Sec24B.Top = (H / 2) - (FullScreen.Sec24B.Height / 1.65)
                    FullScreen.TimeFS.Top = (H * 0.75) - (FullScreen.TimeFS.Height / 2)
                    FullScreen.FoulsA.Top = H * 5 / 16
                    FullScreen.FoulsB.Top = H * 5 / 16

                    FullScreen.Sec24A.Left = W * 0.5 - W * 0.3 - (FullScreen.Sec24A.Size.Width / 2)
                    FullScreen.Sec24B.Left = W * 0.5 + W * 0.3 - (FullScreen.Sec24B.Size.Width / 2)
                    FullScreen.ScoreA.Left = W * 0.1
                    FullScreen.ScoreB.Left = (W * 0.9) - FullScreen.ScoreB.Size.Width
                    FullScreen.TimeFS.Left = (W / 2) - (FullScreen.TimeFS.Width / 2)

                    FullScreen.FoulsA.Left = (W / 2) - FullScreen.FoulsA.Width - (FullScreen.FoulsA.Width / 2)
                    FullScreen.FoulsB.Left = (W / 2) + (FullScreen.FoulsB.Width / 2)
                    FullScreen.Cuarto.Left = (W / 2) - (FullScreen.Cuarto.Width / 2)




                    FullScreen.Left = myScreens(0).Bounds.Width + myScreens(1).WorkingArea.Width / 2
                    FullScreen.Top = myScreens(1).WorkingArea.Height / 2
                End If
            Else

                FullScreen.Cuarto.Height = myScreens(0).Bounds.Size.Height / 3
                FullScreen.Cuarto.Width = FullScreen.Cuarto.Height * 0.1875
                FullScreen.Cuarto.Left = (myScreens(0).Bounds.Size.Width / 2) - (FullScreen.Cuarto.Width / 2)


                FullScreen.ScoreA.Font = New Font("DS-Digital", myScreens(0).Bounds.Size.Width / 6)
                FullScreen.ScoreB.Font = New Font("DS-Digital", myScreens(0).Bounds.Size.Width / 6)
                FullScreen.TimeFS.Font = New Font("DS-Digital", myScreens(0).Bounds.Size.Width / 5)
                FullScreen.FoulsA.Font = New Font("DS-Digital", myScreens(0).Bounds.Size.Width / 14)
                FullScreen.FoulsB.Font = New Font("DS-Digital", myScreens(0).Bounds.Size.Width / 14)
                FullScreen.Sec24A.Font = New Font("DS-Digital", myScreens(0).Bounds.Size.Width / 8)
                FullScreen.Sec24B.Font = New Font("DS-Digital", myScreens(0).Bounds.Size.Width / 8)


                FullScreen.Sec24A.Top = (myScreens(0).Bounds.Size.Height / 2) - (FullScreen.Sec24A.Height / 2)
                FullScreen.Sec24B.Top = (myScreens(0).Bounds.Size.Height / 2) - (FullScreen.Sec24B.Height / 2)
                FullScreen.TimeFS.Top = myScreens(0).Bounds.Size.Height * 9 / 16
                FullScreen.FoulsA.Top = myScreens(0).Bounds.Size.Height * 3 / 8
                FullScreen.FoulsB.Top = myScreens(0).Bounds.Size.Height * 3 / 8

                FullScreen.Sec24A.Left = myScreens(0).Bounds.Size.Width / 12
                FullScreen.Sec24B.Left = myScreens(0).Bounds.Size.Width * 2 / 3
                FullScreen.ScoreB.Left = myScreens(0).Bounds.Size.Width * 7 / 12
                FullScreen.TimeFS.Left = (myScreens(0).Bounds.Size.Width / 2) - (FullScreen.TimeFS.Width / 2)
                FullScreen.FoulsA.Left = (myScreens(0).Bounds.Size.Width / 2) - ((FullScreen.Cuarto.Width * 2) / 5) - FullScreen.FoulsA.Size.Width
                FullScreen.FoulsB.Left = (myScreens(0).Bounds.Size.Width / 2) + ((FullScreen.Cuarto.Width * 2) / 5)

            End If

            FullScreen.Show()
        Else
            FullScreen.Hide()


        End If



    End Sub
    Private Sub resetTeamA(x As Integer)
        time24 = Now
        actual24 = x
        FullScreen.Sec24A.Text = CStr(x / 1000)
        TiroA.Text = CStr(x / 1000)
        TiroB.Text = "0"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        resetTeamA(cTiro)
    End Sub
    Private Sub resetTeamB(x As Integer)
        time24 = Now
        actual24 = x
        TiroA.Text = "0"
        FullScreen.Sec24B.Text = CStr(x / 1000)
        TiroB.Text = CStr(x / 1000)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        resetTeamB(cTiro)

    End Sub
    Private time As Integer = 0
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim ahora As Double
        ahora = actual24 - Now.Subtract(time24).TotalMilliseconds
        If ahora < 0 Then ahora = 0
        If TiroA.Text <> "0" Then
            TiroA.Text = CStr(Math.Floor(ahora / 1000))
        End If
        If TiroB.Text <> "0" Then
            TiroB.Text = CStr(Math.Floor(ahora / 1000))
        End If
        If PosA.Checked Then
            FullScreen.ScoreA.ForeColor = Color.Magenta
            FullScreen.ScoreB.ForeColor = Color.LimeGreen
        Else
            FullScreen.ScoreB.ForeColor = Color.Magenta
            FullScreen.ScoreA.ForeColor = Color.LimeGreen

        End If
        FullScreen.Sec24B.Text = TiroB.Text
        FullScreen.Sec24A.Text = TiroA.Text
        time = 0

        Dim sum As Integer

        If cuarto1.Checked Then
            If A11.Checked Then
                sum = sum + 1
            End If
            If A12.Checked Then
                sum = sum + 1
            End If
            If A13.Checked Then
                sum = sum + 1
            End If
            If A14.Checked Then
                sum = sum + 1
            End If
            If A15.Checked Then
                sum = sum + 1
            End If
        ElseIf cuarto2.Checked Then
            If A21.Checked Then
                sum = sum + 1
            End If
            If A22.Checked Then
                sum = sum + 1
            End If
            If A23.Checked Then
                sum = sum + 1
            End If
            If A24.Checked Then
                sum = sum + 8
            End If
            If A25.Checked Then
                sum = sum + 1
            End If
        ElseIf cuarto3.Checked Then
            If A31.Checked Then
                sum = sum + 1
            End If
            If A32.Checked Then
                sum = sum + 1
            End If
            If A33.Checked Then
                sum = sum + 1
            End If
            If A34.Checked Then
                sum = sum + 1
            End If
            If A35.Checked Then
                sum = sum + 1
            End If
        Else
            If A41.Checked Then
                sum = sum + 1
            End If
            If A42.Checked Then
                sum = sum + 1
            End If
            If A43.Checked Then
                sum = sum + 1
            End If
            If A44.Checked Then
                sum = sum + 1
            End If
            If A45.Checked Then
                sum = sum + 1
            End If
        End If
        FullScreen.FoulsA.Text = CStr(sum)
        sum = 0
        If cuarto1.Checked Then
            If B11.Checked Then
                sum = sum + 1
            End If
            If B12.Checked Then
                sum = sum + 1
            End If
            If B13.Checked Then
                sum = sum + 1
            End If
            If B14.Checked Then
                sum = sum + 1
            End If
            If B15.Checked Then
                sum = sum + 1
            End If
        ElseIf cuarto2.Checked Then
            If B21.Checked Then
                sum = sum + 1
            End If
            If B22.Checked Then
                sum = sum + 1
            End If
            If B23.Checked Then
                sum = sum + 1
            End If
            If B24.Checked Then
                sum = sum + 1
            End If
            If B25.Checked Then
                sum = sum + 1
            End If
        ElseIf cuarto3.Checked Then
            If B31.Checked Then
                sum = sum + 1
            End If
            If B32.Checked Then
                sum = sum + 1
            End If
            If B33.Checked Then
                sum = sum + 1
            End If
            If B34.Checked Then
                sum = sum + 1
            End If
            If B35.Checked Then
                sum = sum + 1
            End If
        Else
            If B41.Checked Then
                sum = sum + 1
            End If
            If B42.Checked Then
                sum = sum + 1
            End If
            If B43.Checked Then
                sum = sum + 1
            End If
            If B44.Checked Then
                sum = sum + 1
            End If
            If B45.Checked Then
                sum = sum + 1
            End If

        End If
        FullScreen.FoulsB.Text = CStr(sum)
    End Sub

    Private Sub cuarto2_CheckedChanged(sender As Object, e As EventArgs) Handles cuarto2.CheckedChanged
        If cuarto2.Checked = True Then
            FullScreen.Cuarto.Image = New System.Drawing.Bitmap("cuarto2.png")

        End If
    End Sub

    Private Sub cuarto3_CheckedChanged(sender As Object, e As EventArgs) Handles cuarto3.CheckedChanged
        If cuarto3.Checked = True Then

            FullScreen.Cuarto.Image = New System.Drawing.Bitmap("cuarto3.png")
        End If
    End Sub

    Private Sub cuarto4_CheckedChanged(sender As Object, e As EventArgs) Handles cuarto4.CheckedChanged
        If cuarto4.Checked = True Then

            FullScreen.Cuarto.Image = New System.Drawing.Bitmap("cuarto4.png")
        End If
    End Sub

    Private Sub Textra_CheckedChanged(sender As Object, e As EventArgs) Handles Textra.CheckedChanged
        If Textra.Checked = True Then

            FullScreen.Cuarto.Image = New System.Drawing.Bitmap("cuarto5.png")
        End If
    End Sub

    Private Sub Textra2_CheckedChanged(sender As Object, e As EventArgs) Handles Textra2.CheckedChanged
        If Textra2.Checked = True Then

            FullScreen.Cuarto.Image = New System.Drawing.Bitmap("cuarto6.png")
        End If
    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub


    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            Return 0
        End Try
    End Function


    Private Sub keys_Tick(sender As Object, e As EventArgs) Handles keysTimmer.Tick

        keysTimmer.Enabled = False

        If (GetAsyncKeyState(Keys.Left)) Then
            resetTeamA(cTiro)

        End If
        Dim a As String

        If GetAsyncKeyState(Keys.ControlKey) And (GetAsyncKeyState(Keys.Left)) Then
            a = InputBox("Tiempo de tiro del equipo A", "Resetear tiempo de tiro", "14")
            If a <> "" Then resetTeamA(1000 * CInt(a))
        End If
        If GetAsyncKeyState(Keys.ControlKey) And (GetAsyncKeyState(Keys.Right)) Then
            a = InputBox("Tiempo de tiro del equipo B", "Resetear tiempo de tiro", "14")
            If a <> "" Then resetTeamB(1000 * CInt(a))


        End If
        If (GetAsyncKeyState(Keys.Right)) Then
            resetTeamB(cTiro)

        End If
        If (GetAsyncKeyState(Keys.F12)) Then
            PosA.Checked = Not PosA.Checked
            PosB.Checked = Not PosA.Checked

        End If
        keysTimmer.Enabled = True
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        If (MsgBox("¿Desea descartar el juego actual?", MsgBoxStyle.YesNo, "Confirmación de nuevo juego") = vbYes) Then
            startup()
        End If

    End Sub

    Private Sub TeamA_name_KeyDown(sender As Object, e As KeyEventArgs) Handles TeamA_name.KeyDown
        e.SuppressKeyPress = True
    End Sub
    Private Sub TeamA_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TeamA_name.SelectedIndexChanged
        If (MsgBox("¿Desea borrar al equipo ""A"" actual y su score?", MsgBoxStyle.YesNoCancel, "Seleccionar nuevo equipo") = vbYes) Then
            Dim c = 0
            Dim b() As String

            If (TeamA_name.SelectedIndex <> -1) Then
                Dim idOfTeam As String
                idOfTeam = idEquipo.Items.Item(TeamA_name.SelectedIndex)
                TALV.Items.Clear()
                Dim items(8) As String
                For c = 0 To jugXequipo.Items.Count - 1
                    b = Split(jugXequipo.Items.Item(c), "|")
                    If b(0) = idOfTeam Then
                        For d = 0 To idJugador.Items.Count - 1
                            If b(1) = idJugador.Items.Item(d) Then
                                items(0) = numJugador.Items.Item(d)
                                items(1) = jugadores.Items.Item(d)
                                items(2) = "0"
                                items(3) = "0"
                                items(4) = "0"
                                items(5) = "0"
                                items(6) = "0"
                                items(7) = b(1)
                                Dim li As New ListViewItem(items)
                                TALV.Items.Add(li)
                            End If
                        Next
                    End If


                Next

            End If


        End If
    End Sub

    Private Sub TeamB_name_KeyDown(sender As Object, e As KeyEventArgs) Handles TeamB_name.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub TeamB_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TeamB_name.SelectedIndexChanged
        If (MsgBox("¿Desea borrar al equipo ""B"" actual y su score?", MsgBoxStyle.YesNoCancel, "Seleccionar nuevo equipo") = vbYes) Then
            Dim c = 0
            Dim b() As String

            If (TeamB_name.SelectedIndex <> -1) Then
                Dim idOfTeam As String
                idOfTeam = idEquipo.Items.Item(TeamB_name.SelectedIndex)
                TBLV.Items.Clear()
                Dim items(8) As String
                For c = 0 To jugXequipo.Items.Count - 1
                    b = Split(jugXequipo.Items.Item(c), "|")
                    If b(0) = idOfTeam Then
                        For d = 0 To idJugador.Items.Count - 1
                            If b(1) = idJugador.Items.Item(d) Then
                                items(0) = numJugador.Items.Item(d)
                                items(1) = jugadores.Items.Item(d)
                                items(2) = "0"
                                items(3) = "0"
                                items(4) = "0"
                                items(5) = "0"
                                items(6) = "0"
                                items(7) = b(1)
                                Dim li As New ListViewItem(items)
                                TBLV.Items.Add(li)
                            End If
                        Next
                    End If


                Next

            End If


        End If

    End Sub



    Private Sub TBLV_KeyDown(sender As Object, e As KeyEventArgs) Handles TBLV.KeyDown
        If (e.KeyCode <> Keys.Up And e.KeyCode <> Keys.Down) Then
            e.SuppressKeyPress = True
        End If
    End Sub



    Private Sub TBLV_KeyUp(sender As Object, e As KeyEventArgs) Handles TBLV.KeyUp
        If (e.KeyCode <> Keys.Up And e.KeyCode <> Keys.Down) Then
            If (TBLV.SelectedIndices.Count > 0) Then
                Dim cua As String
                cua = "1"
                If cuarto2.Checked Then
                    cua = "2"
                End If
                If cuarto3.Checked Then
                    cua = "3"
                End If
                If cuarto4.Checked Then
                    cua = "4"
                End If
                If Textra.Checked Then
                    cua = "E1"
                End If
                If Textra2.Checked Then
                    cua = "E2"
                End If
                If e.KeyData = Keys.F Then
                    If TBLV.SelectedItems(0).SubItems(2).Text <> "5" Then
                        TBLV.SelectedItems(0).SubItems(2).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(2).Text) + 1)
                        log.Items.Add("B|F+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                        If TBLV.SelectedItems(0).SubItems(2).Text = "5" Then
                            TBLV.SelectedItems(0).BackColor = Color.Red
                            MsgBox("Jugador expulsado")
                        End If

                    End If
                End If
                If e.KeyData = Keys.R Then
                    If TBLV.SelectedItems(0).SubItems(2).Text <> "0" Then
                        TBLV.SelectedItems(0).SubItems(2).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(2).Text) - 1)
                        log.Items.Add("B|F-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                        TBLV.SelectedItems(0).BackColor = Color.White

                    End If
                End If

                If e.KeyData = Keys.D Then
                    TBLV.SelectedItems(0).SubItems(6).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(6).Text) + 1)
                    log.Items.Add("B|R+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                End If
                If e.KeyData = Keys.E Then
                    If (TBLV.SelectedItems(0).SubItems(6).Text <> "0") Then
                        TBLV.SelectedItems(0).SubItems(6).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(6).Text) - 1)
                        log.Items.Add("B|R-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If

                If e.KeyData = Keys.A Then
                    TBLV.SelectedItems(0).SubItems(5).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(5).Text) + 1)
                    log.Items.Add("B|A+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                End If
                If e.KeyData = Keys.Q Then
                    If (TBLV.SelectedItems(0).SubItems(5).Text <> "0") Then
                        TBLV.SelectedItems(0).SubItems(5).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(5).Text) - 1)
                        log.Items.Add("B|A-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If

                If e.KeyData = Keys.S Then
                    TBLV.SelectedItems(0).SubItems(4).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(4).Text) + 1)
                    log.Items.Add("B|S+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                End If
                If e.KeyData = Keys.W Then
                    If (TBLV.SelectedItems(0).SubItems(4).Text <> "0") Then
                        TBLV.SelectedItems(0).SubItems(4).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(4).Text) - 1)
                        log.Items.Add("B|S-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If

                If e.KeyData = Keys.D1 Then
                    TBLV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(3).Text) + 1)
                    log.Items.Add("B|C+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)

                End If
                If e.KeyData = Keys.D2 Then
                    TBLV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(3).Text) + 2)
                    log.Items.Add("B|C+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                End If
                If e.KeyData = Keys.D3 Then
                    TBLV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(3).Text) + 3)
                    log.Items.Add("B|C+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                End If

                If e.KeyData = Keys.F1 Then
                    If (CInt(TBLV.SelectedItems(0).SubItems(3).Text) > 0) Then
                        TBLV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(3).Text) - 1)
                        log.Items.Add("B|C-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If

                If e.KeyData = Keys.F2 Then
                    If (CInt(TBLV.SelectedItems(0).SubItems(3).Text) > 1) Then
                        TBLV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(3).Text) - 2)
                        log.Items.Add("B|C-2|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If

                If e.KeyData = Keys.F3 Then
                    If (CInt(TBLV.SelectedItems(0).SubItems(3).Text) > 2) Then
                        TBLV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TBLV.SelectedItems(0).SubItems(3).Text) - 3)
                        log.Items.Add("B|C-3|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TBLV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If
                actualiza()
            End If
        End If
    End Sub

    Private Sub cuarto1_CheckedChanged(sender As Object, e As EventArgs) Handles cuarto1.CheckedChanged
        If cuarto1.Checked = True Then
            FullScreen.Cuarto.Image = New System.Drawing.Bitmap("cuarto1.png")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As String
        a = InputBox("Tiempo de tiro del equipo A", "Resetear tiempo de tiro", "14")
        If (a <> "") Then resetTeamA(1000 * CInt(a))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a As String
        a = InputBox("Tiempo de tiro del equipo B", "Resetear tiempo de tiro", "14")
        If (a <> "") Then resetTeamB(1000 * CInt(a))
    End Sub

    Private Sub ForceStart_Tick(sender As Object, e As EventArgs) Handles ForceStart.Tick
        If (GetAsyncKeyState(Keys.F5)) Then
            inicio()
            While (GetAsyncKeyState(Keys.F5))
                ForceStart.Enabled = False
            End While
            ForceStart.Enabled = True
        End If

        If (GetAsyncKeyState(Keys.F7)) Then
            While (Not TALV.Focused)
                TALV.Focus()
            End While
            If (TALV.Items.Count > 0) Then
                TALV.Items(0).Selected = True
                TALV.Items(0).Focused = True
            End If
        End If
        If (GetAsyncKeyState(Keys.F8)) Then
            While (Not TBLV.Focused)
                TBLV.Focus()
            End While
            If (TBLV.Items.Count > 0) Then
                TBLV.Items(0).Selected = True
                TBLV.Items(0).Focused = True
            End If
        End If




    End Sub


    Private Sub TALV_KeyDown(sender As Object, e As KeyEventArgs) Handles TALV.KeyDown
        If (e.KeyCode <> Keys.Up And e.KeyCode <> Keys.Down) Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub TALV_KeyUp(sender As Object, e As KeyEventArgs) Handles TALV.KeyUp
        If (e.KeyCode <> Keys.Up And e.KeyCode <> Keys.Down) Then
            If (TALV.SelectedIndices.Count > 0) Then
                Dim cua As String
                cua = "1"
                If cuarto2.Checked Then
                    cua = "2"
                End If
                If cuarto3.Checked Then
                    cua = "3"
                End If
                If cuarto4.Checked Then
                    cua = "4"
                End If
                If Textra.Checked Then
                    cua = "E1"
                End If
                If Textra2.Checked Then
                    cua = "E2"
                End If
                If e.KeyData = Keys.F Then
                    If TALV.SelectedItems(0).SubItems(2).Text <> "5" Then
                        TALV.SelectedItems(0).SubItems(2).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(2).Text) + 1)
                        log.Items.Add("A|F+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                        If TALV.SelectedItems(0).SubItems(2).Text = "5" Then
                            TALV.SelectedItems(0).BackColor = Color.Red
                            MsgBox("Jugador expulsado")
                        End If

                    End If
                End If
                If e.KeyData = Keys.R Then
                    If TALV.SelectedItems(0).SubItems(2).Text <> "0" Then
                        TALV.SelectedItems(0).SubItems(2).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(2).Text) - 1)
                        log.Items.Add("A|F-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                        TALV.SelectedItems(0).BackColor = Color.White
                    End If
                End If

                If e.KeyData = Keys.D Then
                    TALV.SelectedItems(0).SubItems(6).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(6).Text) + 1)
                    log.Items.Add("A|R+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                End If
                If e.KeyData = Keys.E Then
                    If (TALV.SelectedItems(0).SubItems(6).Text <> "0") Then
                        TALV.SelectedItems(0).SubItems(6).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(6).Text) - 1)
                        log.Items.Add("A|R-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If

                If e.KeyData = Keys.A Then
                    TALV.SelectedItems(0).SubItems(5).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(5).Text) + 1)
                    log.Items.Add("A|A+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                End If
                If e.KeyData = Keys.Q Then
                    If (TALV.SelectedItems(0).SubItems(5).Text <> "0") Then
                        TALV.SelectedItems(0).SubItems(5).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(5).Text) - 1)
                        log.Items.Add("A|A-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If

                If e.KeyData = Keys.S Then
                    TALV.SelectedItems(0).SubItems(4).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(4).Text) + 1)
                    log.Items.Add("A|S+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                End If
                If e.KeyData = Keys.W Then
                    If (TALV.SelectedItems(0).SubItems(4).Text <> "0") Then
                        TALV.SelectedItems(0).SubItems(4).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(4).Text) - 1)
                        log.Items.Add("A|S-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                    End If
                End If

                If e.KeyData = Keys.D1 Then
                    TALV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(3).Text) + 1)
                    log.Items.Add("A|C+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)

                End If
                If e.KeyData = Keys.D2 Then
                    TALV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(3).Text) + 2)
                    log.Items.Add("A|C+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                End If
                If e.KeyData = Keys.D3 Then
                    TALV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(3).Text) + 3)
                    log.Items.Add("A|C+1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                End If

                If e.KeyData = Keys.F1 Then
                    If (CInt(TALV.SelectedItems(0).SubItems(3).Text) > 0) Then
                        TALV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(3).Text) - 1)
                        log.Items.Add("A|C-1|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                    End If


                End If

                If e.KeyData = Keys.F2 Then

                    If (CInt(TALV.SelectedItems(0).SubItems(3).Text) > 1) Then
                        TALV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(3).Text) - 2)
                        log.Items.Add("A|C-2|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                    End If

                End If

                If e.KeyData = Keys.F3 Then

                    If (CInt(TALV.SelectedItems(0).SubItems(3).Text) > 2) Then
                        TALV.SelectedItems(0).SubItems(3).Text = CStr(CInt(TALV.SelectedItems(0).SubItems(3).Text) - 3)
                        log.Items.Add("A|C-3|" + Minutos.Text + ":" + Segundos.Text + "|" + cua + "|" + TALV.SelectedItems(0).SubItems(7).Text)
                    End If

                End If
                actualiza()
            End If
        End If

    End Sub


    Private Sub TALV_DoubleClick(sender As Object, e As EventArgs) Handles TALV.DoubleClick
        Dim SecondForm As New Jugador
        players.Add(SecondForm)

        If cuarto1.Checked Then
            players(players.Count - 1).cuarto.Text = "1"
        End If
        If cuarto2.Checked Then
            players(players.Count - 1).cuarto.Text = "2"
        End If
        If cuarto3.Checked Then
            players(players.Count - 1).cuarto.Text = "3"
        End If
        If cuarto4.Checked Then
            players(players.Count - 1).cuarto.Text = "4"
        End If

        players(players.Count - 1).ListBox1.Items.Clear()
        players(players.Count - 1).index.Text = TALV.SelectedItems(0).Index

        players(players.Count - 1).team.Text = "A"

        players(players.Count - 1).nombre.Text = TALV.SelectedItems(0).SubItems(1).Text
        players(players.Count - 1).numero.Text = TALV.SelectedItems(0).SubItems(0).Text
        players(players.Count - 1).fouls.Text = TALV.SelectedItems(0).SubItems(2).Text
        players(players.Count - 1).canastas.Text = TALV.SelectedItems(0).SubItems(3).Text
        players(players.Count - 1).robos.Text = TALV.SelectedItems(0).SubItems(4).Text
        players(players.Count - 1).asistencias.Text = TALV.SelectedItems(0).SubItems(5).Text
        players(players.Count - 1).rebotes.Text = TALV.SelectedItems(0).SubItems(6).Text
        players(players.Count - 1).nomequ.Text = TeamA_name.Text
        players(players.Count - 1).Show()

    End Sub
    Private Sub TBLV_DoubleClick(sender As Object, e As EventArgs) Handles TBLV.DoubleClick

        Dim SecondForm As New Jugador
        players.Add(SecondForm)



        If cuarto1.Checked Then
            players(players.Count - 1).cuarto.Text = "1"
        End If
        If cuarto2.Checked Then
            players(players.Count - 1).cuarto.Text = "2"
        End If
        If cuarto3.Checked Then
            players(players.Count - 1).cuarto.Text = "3"
        End If
        If cuarto4.Checked Then
            players(players.Count - 1).cuarto.Text = "4"
        End If

        players(players.Count - 1).ListBox1.Items.Clear()
        players(players.Count - 1).index.Text = TBLV.SelectedItems(0).Index

        players(players.Count - 1).team.Text = "B"

        players(players.Count - 1).nombre.Text = TBLV.SelectedItems(0).SubItems(1).Text
        players(players.Count - 1).numero.Text = TBLV.SelectedItems(0).SubItems(0).Text
        players(players.Count - 1).fouls.Text = TBLV.SelectedItems(0).SubItems(2).Text
        players(players.Count - 1).canastas.Text = TBLV.SelectedItems(0).SubItems(3).Text
        players(players.Count - 1).robos.Text = TBLV.SelectedItems(0).SubItems(4).Text
        players(players.Count - 1).asistencias.Text = TBLV.SelectedItems(0).SubItems(5).Text
        players(players.Count - 1).rebotes.Text = TBLV.SelectedItems(0).SubItems(6).Text
        players(players.Count - 1).nomequ.Text = TeamA_name.Text
        players(players.Count - 1).Show()
    End Sub

    Private Sub TALV_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TALV.SelectedIndexChanged

    End Sub

    Private Sub TBLV_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TBLV.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles asignarTiempo.Click
        Dim mins As String
        mins = InputBox("¿A qué minuto deseas asignar?", "Asignar tiempo al marcador", Minutos.Text)
        Dim a As Double
        Dim b As Double
        a = Math.Floor(CDbl(mins))
        b = ((mins - a) * 60)
        If (a >= 10) Then
            Minutos.Text = CStr(a)
        Else
            Minutos.Text = "0" + CStr(a)
        End If
        If (b >= 10) Then
            Segundos.Text = CStr(Math.Floor(b))
        Else
            Segundos.Text = "0" + CStr(Math.Floor(b))
        End If
        Decimas.Text = "00"
    End Sub
End Class
