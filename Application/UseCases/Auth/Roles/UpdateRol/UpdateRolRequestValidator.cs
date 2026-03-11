using FluentValidation;

namespace Application.UseCases.Auth.Roles.UpdateRol;

public class UpdateRolRequestValidator : AbstractValidator<UpdateRolRequest>
{
    public UpdateRolRequestValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre del rol es obligatorio")
            .MaximumLength(50).WithMessage("El nombre no puede exceder 50 caracteres")
            .Matches("^[a-zA-Z0-9_áéíóúÁÉÍÓÚñÑ ]+$").WithMessage("El nombre solo puede contener letras, números, espacios y guiones bajos");

        RuleFor(x => x.Descripcion)
            .MaximumLength(200).WithMessage("La descripción no puede exceder 200 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Descripcion));
    }
}