using FluentValidation;

namespace Application.UseCases.Clinica.Consultas.CreateConsulta;

public class CreateConsultaRequestValidator : AbstractValidator<CreateConsultaRequest>
{
    public CreateConsultaRequestValidator()
    {
        RuleFor(x => x.PacienteId)
            .GreaterThan(0)
            .WithMessage("El ID del paciente debe ser mayor a 0");

        RuleFor(x => x.MedicoId)
            .GreaterThan(0)
            .WithMessage("El ID del médico debe ser mayor a 0");

        RuleFor(x => x.TipoConsulta)
            .Must(tipo => tipo == null || tipo == "primera_vez" || tipo == "seguimiento" || tipo == "emergencia")
            .WithMessage("El tipo de consulta debe ser 'primera_vez', 'seguimiento' o 'emergencia'")
            .When(x => !string.IsNullOrEmpty(x.TipoConsulta));

        RuleFor(x => x.MotivoConsulta)
            .NotEmpty()
            .WithMessage("El motivo de consulta es requerido")
            .MaximumLength(2000)
            .WithMessage("El motivo de consulta no puede exceder 2000 caracteres");

        RuleFor(x => x.Observaciones)
            .MaximumLength(2000)
            .WithMessage("Las observaciones no pueden exceder 2000 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Observaciones));

        RuleFor(x => x.ProximaCita)
            .GreaterThan(DateTime.Today)
            .WithMessage("La próxima cita debe ser una fecha futura")
            .When(x => x.ProximaCita.HasValue);
    }
}