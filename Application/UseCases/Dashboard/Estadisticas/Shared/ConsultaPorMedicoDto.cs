namespace Application.UseCases.Dashboard.Estadisticas.Shared;

public class ConsultaPorMedicoDto
{
    public int MedicoId { get; set; }
    public string NombreMedico { get; set; } = string.Empty;
    public string Especialidad { get; set; } = string.Empty;
    public int CantidadConsultas { get; set; }
}