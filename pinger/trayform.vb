Imports System.Windows.Forms
Public Class trayform
    Private Sub trayform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ContextMenuStrip1.Show(Cursor.Position)
        Me.Left = ContextMenuStrip1.Left + 1
        Me.Top = ContextMenuStrip1.Top + 1
    End Sub
    Private Sub trayform_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub
    Private Sub cerrar_Click(sender As Object, e As EventArgs) Handles cerrar.Click
        Form1.onclosingg()
        Me.Close()
    End Sub
    Private Sub ping_Click(sender As Object, e As EventArgs) Handles ping.Click
        Form1.pingear()
        Me.Close()
    End Sub
    Private Sub time_Click(sender As Object, e As EventArgs) Handles time.Click
        Form2.ShowDialog(Form1)
        Me.Close()
    End Sub
    Private Sub config_Click(sender As Object, e As EventArgs) Handles config.Click
        Process.Start("notepad", Form1.archivo)
        Me.Close()
    End Sub
    Private Sub about_Click(sender As Object, e As EventArgs) Handles about.Click
        AboutBox1.ShowDialog(Form1)
        Me.Close()
    End Sub
End Class