using FluentValidation;

namespace Application.UseCases.Clinica.OrdenesLaboratorio.UpdateOrdenLaboratorio;

public class UpdateOrdenLaboratorioRequestValidator : AbstractValidator<UpdateOrdenLaboratorioRequest>
{
    public UpdateOrdenLaboratorioRequestValidator()
    {
        RuleFor(x => x.NumeroOrden)
            .NotEmpty()
            .WithMessage("El número de orden es requerido")
            .MaximumLength(50)
            .WithMessage("El número de orden no puede exceder 50 caracteres");

        RuleFor(x => x.FechaOrden)
            .NotEmpty()
            .WithMessage("La fecha de orden es requerida")
            .LessThanOrEqualTo(DateTime.Today.AddDays(1))
            .WithMessage("La fecha de orden no puede ser futura");

        RuleFor(x => x.DiagnosticoCie10)
            .MaximumLength(10)
            .WithMessage("El código CIE-10 no puede exceder 10 caracteres")
            .When(x => !string.IsNullOrEmpty(x.DiagnosticoCie10));

        RuleFor(x => x.Observaciones)
            .MaximumLength(1000)
            .WithMessage("Las observaciones no pueden exceder 1000 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Observaciones));
    }
}