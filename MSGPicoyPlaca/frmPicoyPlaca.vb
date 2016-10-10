
Public Class frmPicoYPlaca
    Dim clsValida As New clsPicoyPlaca

    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        If clsValida.VerificaPicoyPlaca(Me.txtPlaca.Text, Me.txtFecha.Text, Me.txtHora.Text) Then
            lblEstado.Text = "RESTRINGIDO"
        Else
            lblEstado.Text = "PERMITIDO"
        End If
    End Sub

    Private Sub frmPicoYPlaca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsValida.fDiccionarioPicoyPlaca()
    End Sub
End Class
