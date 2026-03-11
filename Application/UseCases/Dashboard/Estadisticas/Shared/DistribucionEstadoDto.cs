namespace Application.UseCases.Dashboard.Estadisticas.Shared;

public class DistribucionEstadoDto
{
    public string Estado { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal Porcentaje { get; set; }
}