using FluentValidation;

namespace Application.UseCases.Clinica.Alergias.UpdateAlergia;

public class UpdateAlergiaRequestValidator : AbstractValidator<UpdateAlergiaRequest>
{
    public UpdateAlergiaRequestValidator()
    {
        RuleFor(x => x.MedicamentoOElemento)
            .NotEmpty()
            .WithMessage("El medicamento o elemento es requerido")
            .MaximumLength(100)
            .WithMessage("El medicamento o elemento no puede exceder 100 caracteres");

        RuleFor(x => x.Reaccion)
            .MaximumLength(1000)
            .WithMessage("La reacción no puede exceder 1000 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Reaccion));
    }
}