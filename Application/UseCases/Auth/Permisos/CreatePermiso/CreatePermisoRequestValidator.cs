using FluentValidation;

namespace Application.UseCases.Auth.Permisos.CreatePermiso;

public class CreatePermisoRequestValidator : AbstractValidator<CreatePermisoRequest>
{
    public CreatePermisoRequestValidator()
    {
        RuleFor(x => x.Codigo)
            .NotEmpty().WithMessage("El código es obligatorio")
            .MaximumLength(100).WithMessage("El código no puede exceder 100 caracteres")
            .Matches("^[A-Za-z0-9_.]+$").WithMessage("El código solo puede contener letras, números, puntos y guiones bajos (ej: Prueba.Ver)");

        RuleFor(x => x.Modulo)
            .NotEmpty().WithMessage("El módulo es obligatorio")
            .MaximumLength(50).WithMessage("El módulo no puede exceder 50 caracteres")
            .Matches("^[A-Za-z0-9áéíóúÁÉÍÓÚñÑ ]+$").WithMessage("El módulo solo puede contener letras, números y espacios");

        RuleFor(x => x.Accion)
            .NotEmpty().WithMessage("La acción es obligatoria")
            .MaximumLength(50).WithMessage("La acción no puede exceder 50 caracteres")
            .Matches("^[A-Za-z0-9áéíóúÁÉÍÓÚñÑ ]+$").WithMessage("La acción solo puede contener letras, números y espacios");

        RuleFor(x => x.Descripcion)
            .MaximumLength(200).WithMessage("La descripción no puede exceder 200 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Descripcion));
    }
}