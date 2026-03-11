namespace Application.UseCases.Dashboard.Estadisticas.Shared;

public class PacientesPorMesDto
{
    public int Anio { get; set; }
    public int Mes { get; set; }
    public string NombreMes { get; set; } = string.Empty;
    public int CantidadPacientes { get; set; }
}