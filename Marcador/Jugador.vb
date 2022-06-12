Public Class Jugador

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If CInt(fouls.Text) < 5 Then
            fouls.Text = CStr(CInt(fouls.Text) + 1)
            ListBox1.Items.Add(team.Text + "|F+1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + index.Text)

        End If

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If CInt(fouls.Text) > 0 Then
            fouls.Text = CStr(CInt(fouls.Text) - 1)
            ListBox1.Items.Add(team.Text + "|F-1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + index.Text)
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        canastas.Text = CStr(CInt(canastas.Text) + 1)
        ListBox1.Items.Add(team.Text + "|C+1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + index.Text)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        canastas.Text = CStr(CInt(canastas.Text) + 2)
        ListBox1.Items.Add(team.Text + "|C+2|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + index.Text)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        canastas.Text = CStr(CInt(canastas.Text) + 3)
        ListBox1.Items.Add(team.Text + "|C+3|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + index.Text)
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        If CInt(canastas.Text) > 0 Then
            canastas.Text = CStr(CInt(canastas.Text) - 1)
            ListBox1.Items.Add(team.Text + "|C-1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + index.Text)
        End If

    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        If CInt(canastas.Text) > 1 Then
            canastas.Text = CStr(CInt(canastas.Text) - 2)
            ListBox1.Items.Add(team.Text + "|C+2|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + index.Text)
        Else
            canastas.Text = "0"
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If CInt(canastas.Text) > 2 Then
            canastas.Text = CStr(CInt(canastas.Text) - 3)
            ListBox1.Items.Add(team.Text + "|C-3|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + index.Text)
        Else
            canastas.Text = "0"
        End If
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        If team.Text = "A" Then
            Principal.TALV.Items(CInt(index.Text)).SubItems(3).Text = canastas.Text
            Principal.TALV.Items(CInt(index.Text)).SubItems(2).Text = fouls.Text
            Principal.TALV.Items(CInt(index.Text)).SubItems(5).Text = asistencias.Text
            Principal.TALV.Items(CInt(index.Text)).SubItems(6).Text = rebotes.Text
            Principal.TALV.Items(CInt(index.Text)).SubItems(4).Text = robos.Text
        Else
            Principal.TBLV.Items(CInt(index.Text)).SubItems(3).Text = canastas.Text
            Principal.TBLV.Items(CInt(index.Text)).SubItems(2).Text = fouls.Text
            Principal.TBLV.Items(CInt(index.Text)).SubItems(5).Text = asistencias.Text
            Principal.TBLV.Items(CInt(index.Text)).SubItems(6).Text = rebotes.Text
            Principal.TBLV.Items(CInt(index.Text)).SubItems(4).Text = robos.Text
        End If
        For c = 0 To ListBox1.Items.Count - 1
            Principal.log.Items.Add(ListBox1.Items.Item(c))
        Next
        Me.Hide()


    End Sub

 
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        rebotes.Text = CStr(CInt(rebotes.Text) + 1)
        If (team.Text = "A") Then
            ListBox1.Items.Add("A|R+1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TALV.Items(CInt(index.Text)).SubItems(7).Text)
        Else
            ListBox1.Items.Add("B|R+1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TBLV.Items(CInt(index.Text)).SubItems(7).Text)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (rebotes.Text <> "0") Then
            rebotes.Text = CStr(CInt(rebotes.Text) - 1)
            If (team.Text = "A") Then
                ListBox1.Items.Add("A|R-1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TALV.Items(CInt(index.Text)).SubItems(7).Text)
            Else
                ListBox1.Items.Add("B|R-1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TBLV.Items(CInt(index.Text)).SubItems(7).Text)
            End If
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        asistencias.Text = CStr(CInt(asistencias.Text) + 1)
        If (team.Text = "A") Then
            ListBox1.Items.Add("A|A+1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TALV.Items(CInt(index.Text)).SubItems(7).Text)
        Else
            ListBox1.Items.Add("B|A+1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TBLV.Items(CInt(index.Text)).SubItems(7).Text)
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If (asistencias.Text <> "0") Then
            asistencias.Text = CStr(CInt(asistencias.Text) - 1)
            If (team.Text = "A") Then
                ListBox1.Items.Add("A|A-1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TALV.Items(CInt(index.Text)).SubItems(7).Text)
            Else
                ListBox1.Items.Add("B|A-1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TBLV.Items(CInt(index.Text)).SubItems(7).Text)
            End If
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        robos.Text = CStr(CInt(robos.Text) + 1)
        If (team.Text = "A") Then
            ListBox1.Items.Add("A|S+1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TALV.Items(CInt(index.Text)).SubItems(7).Text)
        Else
            ListBox1.Items.Add("B|S+1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TBLV.Items(CInt(index.Text)).SubItems(7).Text)
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If (robos.Text <> "0") Then
            robos.Text = CStr(CInt(robos.Text) - 1)
            If (team.Text = "A") Then
                ListBox1.Items.Add("A|S-1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TALV.Items(CInt(index.Text)).SubItems(7).Text)
            Else
                ListBox1.Items.Add("B|S-1|" + Principal.Minutos.Text + ":" + Principal.Segundos.Text + "|" + cuarto.Text + "|" + Principal.TBLV.Items(CInt(index.Text)).SubItems(7).Text)
            End If
        End If
    End Sub
End Class