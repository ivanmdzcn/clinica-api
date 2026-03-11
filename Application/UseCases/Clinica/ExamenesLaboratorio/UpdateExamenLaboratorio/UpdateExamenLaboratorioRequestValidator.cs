using FluentValidation;

namespace Application.UseCases.Clinica.ExamenesLaboratorio.UpdateExamenLaboratorio;

public class UpdateExamenLaboratorioRequestValidator : AbstractValidator<UpdateExamenLaboratorioRequest>
{
    public UpdateExamenLaboratorioRequestValidator()
    {
        RuleFor(x => x.NombreExamen)
            .NotEmpty()
            .WithMessage("El nombre del examen es requerido")
            .MaximumLength(100)
            .WithMessage("El nombre del examen no puede exceder 100 caracteres");

        RuleFor(x => x.Resultado)
            .MaximumLength(50)
            .WithMessage("El resultado no puede exceder 50 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Resultado));

        RuleFor(x => x.Unidad)
            .MaximumLength(20)
            .WithMessage("La unidad no puede exceder 20 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Unidad));

        RuleFor(x => x.ValorReferencia)
            .MaximumLength(50)
            .WithMessage("El valor de referencia no puede exceder 50 caracteres")
            .When(x => !string.IsNullOrEmpty(x.ValorReferencia));

        RuleFor(x => x.FechaResultado)
            .LessThanOrEqualTo(DateTime.Today.AddDays(1))
            .WithMessage("La fecha del resultado no puede ser futura")
            .When(x => x.FechaResultado.HasValue);
    }
}