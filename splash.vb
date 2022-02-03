Public Class splash
    Private Sub splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim t As Double
        Static itr As Integer

        For t = 1 To 100
            lbprsn.Text = ProgressBar1.Value
        Next

        If itr <= 100 Then
            ProgressBar1.Value = itr
            itr = itr + 1
        Else
            Form1.Show()

        End If
    End Sub
End Class