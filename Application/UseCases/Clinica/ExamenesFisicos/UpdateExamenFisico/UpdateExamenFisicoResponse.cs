namespace Application.UseCases.Clinica.ExamenesFisicos.UpdateExamenFisico;

public class UpdateExamenFisicoResponse
{
    public int Id { get; init; }
    public int ConsultaId { get; init; }
    public bool EsNormal { get; init; }
    public string? Descripcion { get; init; }
}