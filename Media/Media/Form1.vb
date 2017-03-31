Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = True
        Button2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Image = My.Resources.canada_medium_animated
        My.Computer.Audio.Play(My.Resources.canada, AudioPlayMode.Background)
        Button1.Enabled = False
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Image = My.Resources.canada_still
        My.Computer.Audio.Stop()
        Button1.Enabled = True
        Button2.Enabled = False
    End Sub
End Class
