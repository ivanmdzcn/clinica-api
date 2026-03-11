namespace Application.UseCases.Dashboard.Estadisticas.ObtenerConsultasPorDia;

public class ObtenerConsultasPorDiaRequest
{
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}