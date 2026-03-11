using FluentValidation;

namespace Application.UseCases.Clinica.Recetas.UpdateReceta;

public class UpdateRecetaRequestValidator : AbstractValidator<UpdateRecetaRequest>
{
    public UpdateRecetaRequestValidator()
    {
        RuleFor(x => x.Medicamento)
            .NotEmpty()
            .WithMessage("El nombre del medicamento es requerido")
            .MaximumLength(150)
            .WithMessage("El nombre del medicamento no puede exceder 150 caracteres");

        RuleFor(x => x.Dosis)
            .MaximumLength(50)
            .WithMessage("La dosis no puede exceder 50 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Dosis));

        RuleFor(x => x.Frecuencia)
            .MaximumLength(50)
            .WithMessage("La frecuencia no puede exceder 50 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Frecuencia));

        RuleFor(x => x.Duracion)
            .MaximumLength(50)
            .WithMessage("La duración no puede exceder 50 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Duracion));

        RuleFor(x => x.ViaAdministracion)
            .MaximumLength(30)
            .WithMessage("La vía de administración no puede exceder 30 caracteres")
            .When(x => !string.IsNullOrEmpty(x.ViaAdministracion));

        RuleFor(x => x.Indicaciones)
            .MaximumLength(1000)
            .WithMessage("Las indicaciones no pueden exceder 1000 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Indicaciones));
    }
}