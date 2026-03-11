namespace Application.UseCases.Clinica.ExamenesFisicos.CreateExamenFisico;

public class CreateExamenFisicoRequest
{
    public int ConsultaId { get; init; }
    public bool EsNormal { get; init; } = true;
    public string? Descripcion { get; init; }
}