using FluentValidation;

namespace Application.UseCases.Clinica.Antecedentes.CreateAntecedente;

public class CreateAntecedenteRequestValidator : AbstractValidator<CreateAntecedenteRequest>
{
    public CreateAntecedenteRequestValidator()
    {
        RuleFor(x => x.PacienteId)
            .GreaterThan(0)
            .WithMessage("El ID del paciente debe ser mayor a 0");

        RuleFor(x => x.Tipo)
            .NotEmpty()
            .WithMessage("El tipo es requerido")
            .Must(tipo => tipo == "familiar" || tipo == "personal")
            .WithMessage("El tipo debe ser 'familiar' o 'personal'");

        RuleFor(x => x.Condicion)
            .NotEmpty()
            .WithMessage("La condición es requerida")
            .MaximumLength(150)
            .WithMessage("La condición no puede exceder 150 caracteres");

        RuleFor(x => x.Descripcion)
            .MaximumLength(1000)
            .WithMessage("La descripción no puede exceder 1000 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Descripcion));
    }
}