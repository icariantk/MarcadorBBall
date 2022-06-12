Public Class FullScreen

    Private Sub FullScreen_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Principal.ToolStripMenuItem4.Checked = False

    End Sub

    Private Sub FullScreen_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = 27) Then
            Me.Hide()


        End If

    End Sub

   
    

    Private Sub FullScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Label1.Text = Screen.FromControl(Me).Bounds.Size.Width.ToString

        'Label2.Text = Screen.FromControl(Me).Bounds.Size.Height.ToString


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()

    End Sub



    Private Sub ScoreA_Click(sender As Object, e As EventArgs) Handles ScoreA.Click

    End Sub
End Class