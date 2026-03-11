namespace Application.UseCases.Clinica.ExamenesFisicos.GetExamenFisicoByConsulta;

public class GetExamenFisicoByConsultaResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public bool EsNormal { get; init; }
    public string? Descripcion { get; init; }
    public DateTime FechaRegistro { get; init; }
}