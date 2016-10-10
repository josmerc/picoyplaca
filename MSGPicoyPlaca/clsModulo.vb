
Public Class clsPicoyPlaca
    Dim form As frmPicoYPlaca
    Private vDigitoPlaca As String
    Private DigitoPlacaDia As New Dictionary(Of String, String)
    Private HoraIngreso As DateTime
    Private HoraInicioDia As DateTime
    Private HoraFinDia As String
    Private HoraFinNoche As String
    Private HoraInicioNoche As String

    Public Function VerificaPicoyPlaca(ByVal parPlaca As String, ByVal parFecha As String, ByVal parHora As String) As Boolean
        Dim vDigitoPlaca As String

        VerificaPicoyPlaca = False
        vDigitoPlaca = fExtraeNumeroPlaca(parPlaca)
        VerificaPicoyPlaca = fValidaRestriccion(parFecha, vDigitoPlaca, parHora)
    End Function

    Private Function fExtraeNumeroPlaca(ByVal parPlaca) As String
        Dim sPlaca() As String

        If parPlaca = "" Or Len(Trim(parPlaca)) = 0 Then
            fExtraeNumeroPlaca = ""
        Else
            sPlaca = Split(parPlaca, "-")
            fExtraeNumeroPlaca = Right(sPlaca(1), 1)
        End If
    End Function

    Private Function fValidaRestriccion(ByVal parFecha As String, ByVal parNumeroPlaca As String, ByVal parHora As String) As Boolean
        Dim DiaSemana As String

        fValidaRestriccion = False

        DiaSemana = WeekdayName((Weekday(parFecha, vbMonday)), False, vbMonday)
        If DigitoPlacaDia.ContainsKey(DiaSemana) Then
            Dim DigitosRestringidos As String = DigitoPlacaDia.Item(DiaSemana)

            If InStr(DigitosRestringidos, parNumeroPlaca, CompareMethod.Text) > 0 Then
                fValidaRestriccion = FValidaHoras(parHora)
            End If
        End If
    End Function

    Private Function FValidaHoras(ByVal parhora As String) As Boolean
        FValidaHoras = False
        HoraIngreso = CType(parhora, DateTime)

        If (HoraIngreso >= HoraInicioDia And HoraIngreso <= HoraFinDia) Or (HoraIngreso >= HoraInicioNoche And HoraIngreso <= HoraFinNoche) Then
            FValidaHoras = True
        End If
    End Function

    Public Function fDiccionarioPicoyPlaca()
        DigitoPlacaDia.Add("lunes", "1-2")
        DigitoPlacaDia.Add("martes", "3-4")
        DigitoPlacaDia.Add("miercoles", "5-6")
        DigitoPlacaDia.Add("jueves", "7-8")
        DigitoPlacaDia.Add("viernes", "9-0")

        HoraInicioDia = CType("07:00:00 AM", DateTime)
        HoraFinDia = CType("9:30:00 AM", DateTime)
        HoraInicioNoche = CType("16:00:00 PM", DateTime)
        HoraFinNoche = CType("19:30:00 PM", DateTime)
        Return DigitoPlacaDia
    End Function
End Class
