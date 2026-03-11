using FluentValidation;

namespace Application.UseCases.Pacientes.UpdatePaciente;

public class UpdatePacienteRequestValidator : AbstractValidator<UpdatePacienteRequest>
{
    public UpdatePacienteRequestValidator()
    {
        RuleFor(x => x.Nombres)
            .NotEmpty().WithMessage("Los nombres son obligatorios")
            .MaximumLength(100).WithMessage("Los nombres no pueden exceder 100 caracteres");

        RuleFor(x => x.Apellidos)
            .NotEmpty().WithMessage("Los apellidos son obligatorios")
            .MaximumLength(100).WithMessage("Los apellidos no pueden exceder 100 caracteres");

        RuleFor(x => x.FechaNacimiento)
            .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria")
            .LessThan(DateTime.Now).WithMessage("La fecha de nacimiento debe ser anterior a hoy");

        RuleFor(x => x.Sexo)
            .NotEmpty().WithMessage("El sexo es obligatorio")
            .Must(x => new[] { "masculino", "femenino", "otro" }.Contains(x?.ToLower()))
            .WithMessage("El sexo debe ser: masculino, femenino u otro");

        RuleFor(x => x.Dpi)
            .MaximumLength(20).WithMessage("El DPI no puede exceder 20 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Dpi));

        RuleFor(x => x.Telefono)
            .MaximumLength(20).WithMessage("El teléfono no puede exceder 20 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Telefono));

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("El email no tiene un formato válido")
            .MaximumLength(100).WithMessage("El email no puede exceder 100 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Email));
    }
}