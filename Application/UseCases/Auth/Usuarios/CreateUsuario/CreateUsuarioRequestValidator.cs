using FluentValidation;

namespace Application.UseCases.Auth.Usuarios.CreateUsuario;

public class CreateUsuarioRequestValidator : AbstractValidator<CreateUsuarioRequest>
{
    public CreateUsuarioRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("El username es obligatorio")
            .MinimumLength(3).WithMessage("Mínimo 3 caracteres")
            .MaximumLength(50).WithMessage("Máximo 50 caracteres")
            .Matches("^[a-zA-Z0-9._-]+$").WithMessage("Solo letras, números, puntos, guiones y guiones bajos");

        RuleFor(x => x.NombreCompleto)
            .NotEmpty().WithMessage("El nombre completo es obligatorio")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email inválido")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("La contraseña es obligatoria")
            .MinimumLength(8).WithMessage("Mínimo 8 caracteres")
            .Matches("[A-Z]").WithMessage("Debe contener al menos una mayúscula")
            .Matches("[a-z]").WithMessage("Debe contener al menos una minúscula")
            .Matches("[0-9]").WithMessage("Debe contener al menos un número");

        RuleFor(x => x.RolId)
            .GreaterThan(0).WithMessage("Debe seleccionar un rol válido");
    }
}