using FluentValidation;

namespace Application.UseCases.Auth.RolPermisos.AsignarPermisos;

public class AsignarPermisosRequestValidator : AbstractValidator<AsignarPermisosRequest>
{
    public AsignarPermisosRequestValidator()
    {
        RuleFor(x => x.RolId)
            .GreaterThan(0).WithMessage("El ID del rol es inválido");

        RuleFor(x => x.PermisoIds)
            .NotNull().WithMessage("La lista de permisos es obligatoria")
            .Must(list => list.All(id => id > 0)).WithMessage("Todos los IDs de permisos deben ser válidos");
    }
}