Public Class checkout
    Private Sub checkout_Load() Handles MyBase.Load
        numlbl.Text = Nothing
        numtxt.Text = Nothing
        Dim r As New Random
        numlbl.Text = CStr(r.Next(0, 10)) & CStr(r.Next(0, 10)) & CStr(r.Next(0, 10)) & CStr(r.Next(0, 10))
        numtxt.Focus()
    End Sub
    Private Sub aceptar_Click() Handles aceptar.Click
        If numlbl.Text = numtxt.Text Then
            DialogResult = System.Windows.Forms.DialogResult.OK
            Form1.Activate()
            Me.Close()
        Else
            MsgBox("Número incorrecto.", vbExclamation)
            numlbl.Text = Nothing
            numtxt.Text = Nothing
            checkout_Load()
        End If
    End Sub
    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Form1.Activate()
        Me.Close()
    End Sub
    Private Sub numtxt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles numtxt.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            aceptar_Click()
        End If
    End Sub
End Class