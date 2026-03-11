using FluentValidation;

namespace Application.UseCases.Clinica.ExamenesFisicos.CreateExamenFisico;

public class CreateExamenFisicoRequestValidator : AbstractValidator<CreateExamenFisicoRequest>
{
    public CreateExamenFisicoRequestValidator()
    {
        RuleFor(x => x.ConsultaId)
            .GreaterThan(0)
            .WithMessage("El ID de la consulta debe ser mayor a 0");

        RuleFor(x => x.Descripcion)
            .NotEmpty()
            .WithMessage("La descripción es requerida cuando el examen no es normal")
            .When(x => !x.EsNormal);

        RuleFor(x => x.Descripcion)
            .MaximumLength(5000)
            .WithMessage("La descripción no puede exceder 5000 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Descripcion));
    }
}