using FluentValidation;

namespace Application.UseCases.Auth.RolPermisos.AsignarPermiso;

public class AsignarPermisoRequestValidator : AbstractValidator<AsignarPermisoRequest>
{
    public AsignarPermisoRequestValidator()
    {
        RuleFor(x => x.RolId)
            .GreaterThan(0).WithMessage("El ID del rol es inválido");

        RuleFor(x => x.PermisoId)
            .GreaterThan(0).WithMessage("El ID del permiso es inválido");
    }
}