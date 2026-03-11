using FluentValidation;

namespace Application.UseCases.Clinica.Medicos.CreateMedico;

public class CreateMedicoRequestValidator : AbstractValidator<CreateMedicoRequest>
{
    public CreateMedicoRequestValidator()
    {
        RuleFor(x => x.UsuarioId)
            .GreaterThan(0)
            .WithMessage("El ID del usuario debe ser mayor a 0");

        RuleFor(x => x.CedulaProfesional)
            .NotEmpty()
            .WithMessage("La cédula profesional es requerida")
            .MaximumLength(50)
            .WithMessage("La cédula profesional no puede exceder 50 caracteres");

        RuleFor(x => x.Especialidad)
            .NotEmpty()
            .WithMessage("La especialidad es requerida")
            .MaximumLength(100)
            .WithMessage("La especialidad no puede exceder 100 caracteres");

        RuleFor(x => x.Subespecialidad)
            .MaximumLength(100)
            .WithMessage("La subespecialidad no puede exceder 100 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Subespecialidad));

        RuleFor(x => x.Consultorio)
            .MaximumLength(50)
            .WithMessage("El consultorio no puede exceder 50 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Consultorio));

        RuleFor(x => x.TelefonoConsultorio)
            .MaximumLength(20)
            .WithMessage("El teléfono no puede exceder 20 caracteres")
            .When(x => !string.IsNullOrEmpty(x.TelefonoConsultorio));
    }
}