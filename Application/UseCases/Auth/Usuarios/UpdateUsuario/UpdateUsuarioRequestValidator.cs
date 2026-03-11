using FluentValidation;

namespace Application.UseCases.Auth.Usuarios.UpdateUsuario;

public class UpdateUsuarioRequestValidator : AbstractValidator<UpdateUsuarioRequest>
{
    public UpdateUsuarioRequestValidator()
    {
        RuleFor(x => x.NombreCompleto)
            .NotEmpty().WithMessage("El nombre completo es obligatorio")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email inválido")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.RolId)
            .GreaterThan(0).WithMessage("Debe seleccionar un rol válido");
    }
}