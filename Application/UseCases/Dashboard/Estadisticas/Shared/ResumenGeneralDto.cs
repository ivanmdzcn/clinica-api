namespace Application.UseCases.Dashboard.Estadisticas.Shared;

public class ResumenGeneralDto
{
    public int TotalUsuarios { get; set; }
    public int TotalPacientes { get; set; }
    public int TotalMedicosActivos { get; set; }
    public int ConsultasDelMes { get; set; }
    public int ConsultasHoy { get; set; }
}