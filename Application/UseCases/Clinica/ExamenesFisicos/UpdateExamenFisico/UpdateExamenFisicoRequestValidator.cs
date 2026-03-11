using FluentValidation;

namespace Application.UseCases.Clinica.ExamenesFisicos.UpdateExamenFisico;

public class UpdateExamenFisicoRequestValidator : AbstractValidator<UpdateExamenFisicoRequest>
{
    public UpdateExamenFisicoRequestValidator()
    {
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