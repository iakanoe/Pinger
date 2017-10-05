Imports System.IO
Imports System.Drawing
Imports System.Net.Mail
Imports System.Net
Imports System.Net.NetworkInformation
Public Class Form1
    Public archivo As String = "direcciones.txt"
    Public time As String = "time.txt"
    Dim direcciones() As String
    Dim doble As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            MsgBox("Este proceso ya esta en funcionamiento. No se permite correr dos instancias de este proceso.", vbOK)
            doble = True
            Me.Close()
        Else
            NotifyIcon1.Visible = True
            WindowState = System.Windows.Forms.FormWindowState.Minimized
            ShowInTaskbar = False
            NotifyIcon1.Visible = True
            pingear()
        End If
    End Sub
    Public Sub onclosingg() Handles MyBase.Closing
        If doble Then
            End
        Else
            If checkout.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                NotifyIcon1.Visible = False
                End
            End If
        End If
    End Sub
    Private Sub NotifyIcon1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        Dim forma As New trayform
        forma.Show()
        forma.Activate()
        forma.Width = 1
        forma.Height = 1
    End Sub
    Private Sub changeicon(isactivo As Boolean)
        If isactivo Then
            Try
                NotifyIcon1.Icon = New Icon("icon2.ico")
            Catch ex As Exception
            End Try
        Else
            Try
                NotifyIcon1.Icon = New Icon("icon.ico")
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub pingear() Handles Timer1.Tick
        Timer1.Stop()
        If File.Exists(time) = False Then
            File.WriteAllText(time, "3600000")
        End If
        Timer1.Interval = CInt(My.Computer.FileSystem.ReadAllText(time))
        If File.Exists(archivo) = False Then
            Try
                Dim file As StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter(archivo, False)
                file.WriteLine("En este archivo debe escribir todas las direcciones IP a las cuales quiere que el Pinger haga ping." & vbCrLf & "Para eso, escríbalas una por línea y borre este texto quedando la primer dirección en la primer linea." & vbCrLf & "Después de configurar las direcciones, inicie nuevamente el Pinger.")
                file.Close()
                Process.Start("notepad", archivo)
                NotifyIcon1.Visible = False
                End
            Catch exc As Exception
                MsgBox(exc.ToString)
            End Try
        ElseIf My.Computer.FileSystem.ReadAllText(archivo) = "" Or Mid(My.Computer.FileSystem.ReadAllText(archivo), 1, 8) = "En este "
            Try
                Dim file As StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter(archivo, False)
                file.WriteLine("En este archivo debe escribir todas las direcciones IP a las cuales quiere que el Pinger haga ping." & vbCrLf & "Para eso, escríbalas una por línea y borre este texto quedando la primer dirección en la primer linea." & vbCrLf & "Después de configurar las direcciones, inicie nuevamente el Pinger.")
                file.Close()
                Process.Start("notepad", archivo)
                NotifyIcon1.Visible = False
                End
            Catch exc As Exception
                MsgBox(exc.ToString)
            End Try
        Else
            direcciones = File.ReadAllLines(archivo)
            changeicon(True)
            For Each adress As String In direcciones
                Dim pinger As PingReply = New Ping().Send(adress)
                Try
                    If pinger.Status = IPStatus.Success Then
                        pinger.Address
                    Else
                        mail(adress)
                    End If
                Catch ex As Exception
                    mail(adress)
                End Try
            Next
            changeicon(False)
            Timer1.Start()
            End If
    End Sub
    Private Sub mail(adress As String)
        Try
            Dim smtpserver As New SmtpClient
            Dim email As New MailMessage()
            smtpserver.UseDefaultCredentials = False
            smtpserver.Credentials = New NetworkCredential("reportes@monitoreomayorista.com", "ram7906")
            smtpserver.Port = 587
            smtpserver.EnableSsl = False
            smtpserver.Host = "mail.monitoreomayorista.com"
            email = New MailMessage()
            email.From = New MailAddress("reportes@monitoreomayorista.com")
            email.To.Add("pinger@monitoreomayorista.com")
            email.Subject = "Pinger Error"
            email.IsBodyHtml = False
            email.Body = "[" & Now.ToString("dd/MM/yyyy HH:mm:ss") & "]: El ping a " & adress & " no se ha podido completar correctamente." & vbCrLf
            smtpserver.Send(email)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub mail2(adresses As String())
        Try
            Dim smtpserver As New SmtpClient
            Dim email As New MailMessage()
            smtpserver.UseDefaultCredentials = False
            smtpserver.Credentials = New NetworkCredential("reportes@monitoreomayorista.com", "ram7906")
            smtpserver.Port = 587
            smtpserver.EnableSsl = False
            smtpserver.Host = "mail.monitoreomayorista.com"
            email = New MailMessage()
            email.From = New MailAddress("reportes@monitoreomayorista.com")
            email.To.Add("pinger@monitoreomayorista.com")
            email.Subject = "Pinger Change"
            email.IsBodyHtml = False
            Dim direccioness As String
            If adresses.Length = 1 Then
                direccioness = adresses(0)
                email.Body = "[" & Now.ToString("dd/MM/yyyy HH:mm:ss") & "]: La dirección IP de " & direccioness & " ha cambiado." & vbCrLf
            Else
                For i As Integer = 0 To UBound(adresses)
                    direccioness = adresses(i)
                    If i = UBound(adresses) - 1 Then
                        direccioness = direccioness & adresses(i) & " y "
                    ElseIf i = UBound(adresses)
                        direccioness = direccioness & adresses(i)
                    Else
                        direccioness = direccioness & adresses(i) & ", "
                    End If
                Next
                email.Body = "[" & Now.ToString("dd/MM/yyyy HH:mm:ss") & "]: Las direcciónes IP de " & direccioness & " han cambiado." & vbCrLf
            End If
            smtpserver.Send(email)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub makematrix()
        Dim a As String() = File.ReadAllLines(archivo)
        Dim matrizprincipal(-1, 1) As String
        For Each ip As String In a
            ReDim Preserve matrizprincipal(UBound(matrizprincipal, 1) + 1, 1)
            matrizprincipal(UBound(matrizprincipal, 1), 0) = ipo
        Next
    End Sub
End Class