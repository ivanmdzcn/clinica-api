using FluentValidation;

namespace Application.UseCases.Clinica.Diagnosticos.CreateDiagnostico;

public class CreateDiagnosticoRequestValidator : AbstractValidator<CreateDiagnosticoRequest>
{
    public CreateDiagnosticoRequestValidator()
    {
        RuleFor(x => x.ConsultaId)
            .GreaterThan(0)
            .WithMessage("El ID de la consulta debe ser mayor a 0");

        RuleFor(x => x.Descripcion)
            .NotEmpty()
            .WithMessage("La descripción del diagnóstico es requerida")
            .MaximumLength(255)
            .WithMessage("La descripción no puede exceder 255 caracteres");

        RuleFor(x => x.Tipo)
            .NotEmpty()
            .WithMessage("El tipo de diagnóstico es requerido")
            .Must(tipo => tipo == "presuntivo" || tipo == "definitivo")
            .WithMessage("El tipo debe ser 'presuntivo' o 'definitivo'");

        RuleFor(x => x.CodigoCie10)
            .MaximumLength(10)
            .WithMessage("El código CIE-10 no puede exceder 10 caracteres")
            .When(x => !string.IsNullOrEmpty(x.CodigoCie10));
    }
}