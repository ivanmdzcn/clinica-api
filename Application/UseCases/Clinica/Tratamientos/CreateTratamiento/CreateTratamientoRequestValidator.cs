using FluentValidation;

namespace Application.UseCases.Clinica.Tratamientos.CreateTratamiento;

public class CreateTratamientoRequestValidator : AbstractValidator<CreateTratamientoRequest>
{
    public CreateTratamientoRequestValidator()
    {
        RuleFor(x => x.ConsultaId)
            .GreaterThan(0)
            .WithMessage("El ID de la consulta debe ser mayor a 0");

        RuleFor(x => x.Descripcion)
            .NotEmpty()
            .WithMessage("La descripción del tratamiento es requerida")
            .MaximumLength(5000)
            .WithMessage("La descripción no puede exceder 5000 caracteres");

        RuleFor(x => x.Indicaciones)
            .MaximumLength(5000)
            .WithMessage("Las indicaciones no pueden exceder 5000 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Indicaciones));

        RuleFor(x => x.FechaFin)
            .GreaterThanOrEqualTo(x => x.FechaInicio)
            .WithMessage("La fecha de fin debe ser posterior o igual a la fecha de inicio")
            .When(x => x.FechaInicio.HasValue && x.FechaFin.HasValue);
    }
}   