<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class checkout
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numlbl = New System.Windows.Forms.Label()
        Me.numtxt = New System.Windows.Forms.TextBox()
        Me.aceptar = New System.Windows.Forms.Button()
        Me.cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingrese estos dígitos para cerrar el servicio:"
        '
        'numlbl
        '
        Me.numlbl.AutoSize = True
        Me.numlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numlbl.Location = New System.Drawing.Point(77, 39)
        Me.numlbl.Name = "numlbl"
        Me.numlbl.Size = New System.Drawing.Size(120, 39)
        Me.numlbl.TabIndex = 1
        Me.numlbl.Text = "Label2"
        '
        'numtxt
        '
        Me.numtxt.Location = New System.Drawing.Point(84, 91)
        Me.numtxt.Name = "numtxt"
        Me.numtxt.Size = New System.Drawing.Size(100, 20)
        Me.numtxt.TabIndex = 2
        '
        'aceptar
        '
        Me.aceptar.Location = New System.Drawing.Point(134, 116)
        Me.aceptar.Name = "aceptar"
        Me.aceptar.Size = New System.Drawing.Size(75, 23)
        Me.aceptar.TabIndex = 3
        Me.aceptar.Text = "Aceptar"
        Me.aceptar.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.Location = New System.Drawing.Point(53, 116)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 23)
        Me.cancel.TabIndex = 4
        Me.cancel.Text = "Cancelar"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'checkout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 146)
        Me.ControlBox = False
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.aceptar)
        Me.Controls.Add(Me.numtxt)
        Me.Controls.Add(Me.numlbl)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "checkout"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Confirmar cierre del servicio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numlbl As System.Windows.Forms.Label
    Friend WithEvents numtxt As System.Windows.Forms.TextBox
    Friend WithEvents aceptar As System.Windows.Forms.Button
    Friend WithEvents cancel As System.Windows.Forms.Button
End Class
