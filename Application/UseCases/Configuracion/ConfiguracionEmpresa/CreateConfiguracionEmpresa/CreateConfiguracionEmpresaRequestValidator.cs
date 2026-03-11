using FluentValidation;

namespace Application.UseCases.Configuracion.ConfiguracionEmpresa.CreateConfiguracionEmpresa;

public class CreateConfiguracionEmpresaRequestValidator : AbstractValidator<CreateConfiguracionEmpresaRequest>
{
    public CreateConfiguracionEmpresaRequestValidator()
    {
        RuleFor(x => x.RazonSocial)
            .NotEmpty().WithMessage("La razón social es requerida")
            .MaximumLength(200).WithMessage("La razón social no puede exceder 200 caracteres");

        RuleFor(x => x.NombreComercial)
            .MaximumLength(200).WithMessage("El nombre comercial no puede exceder 200 caracteres")
            .When(x => !string.IsNullOrEmpty(x.NombreComercial));

        RuleFor(x => x.NumeroIdentificacionFiscal)
            .MaximumLength(50).WithMessage("El número de identificación fiscal no puede exceder 50 caracteres")
            .When(x => !string.IsNullOrEmpty(x.NumeroIdentificacionFiscal));

        RuleFor(x => x.Direccion)
            .NotEmpty().WithMessage("La dirección es requerida");

        RuleFor(x => x.Pais)
            .NotEmpty().WithMessage("El país es requerido")
            .MaximumLength(100).WithMessage("El país no puede exceder 100 caracteres");

        RuleFor(x => x.EmailPrincipal)
            .NotEmpty().WithMessage("El email principal es requerido")
            .EmailAddress().WithMessage("El email principal debe ser válido")
            .MaximumLength(100).WithMessage("El email principal no puede exceder 100 caracteres");

        RuleFor(x => x.EmailSecundario)
            .EmailAddress().WithMessage("El email secundario debe ser válido")
            .When(x => !string.IsNullOrEmpty(x.EmailSecundario));

        RuleFor(x => x.CodigoMoneda)
            .NotEmpty().WithMessage("El código de moneda es requerido")
            .Length(3).WithMessage("El código de moneda debe tener 3 caracteres");

        RuleFor(x => x.PosicionSimbolo)
            .Must(x => x == "antes" || x == "despues")
            .WithMessage("La posición del símbolo debe ser 'antes' o 'despues'");

        RuleFor(x => x.Decimales)
            .InclusiveBetween(0, 4).WithMessage("Los decimales deben estar entre 0 y 4");
    }
}