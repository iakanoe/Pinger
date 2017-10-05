Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim minutos As Integer
        Dim horas As Integer = 0
        minutos = CInt(My.Computer.FileSystem.ReadAllText(Form1.time)) / 60000
        If minutos >= 60 Then
            Do Until minutos < 60
                horas = horas + 1
                minutos = minutos - 60
            Loop
        End If
        hs.Value = horas
        min.Value = minutos
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim milis As Integer = 60000, horas As Integer = hs.Value, minu As Integer = min.Value
        horas = horas * 60
        minu = minu + horas
        milis = milis * minu
        IO.File.WriteAllText(Form1.time, milis)
        Form1.Activate()
        Me.Close()
    End Sub
End Class