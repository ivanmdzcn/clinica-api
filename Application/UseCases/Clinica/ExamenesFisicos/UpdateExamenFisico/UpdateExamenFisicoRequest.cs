namespace Application.UseCases.Clinica.ExamenesFisicos.UpdateExamenFisico;

public class UpdateExamenFisicoRequest
{
    public bool EsNormal { get; init; } = true;
    public string? Descripcion { get; init; }
}