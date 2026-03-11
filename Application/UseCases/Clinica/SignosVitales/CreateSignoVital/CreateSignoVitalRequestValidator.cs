using FluentValidation;

namespace Application.UseCases.Clinica.SignosVitales.CreateSignoVital;

public class CreateSignoVitalRequestValidator : AbstractValidator<CreateSignoVitalRequest>
{
    public CreateSignoVitalRequestValidator()
    {
        RuleFor(x => x.ConsultaId)
            .GreaterThan(0)
            .WithMessage("El ID de la consulta debe ser mayor a 0");

        RuleFor(x => x.EnfermeraId)
            .GreaterThan(0)
            .WithMessage("El ID de la enfermera debe ser mayor a 0");

        RuleFor(x => x.PresionSistolica)
            .InclusiveBetween(50, 300)
            .WithMessage("La presión sistólica debe estar entre 50 y 300 mmHg")
            .When(x => x.PresionSistolica.HasValue);

        RuleFor(x => x.PresionDiastolica)
            .InclusiveBetween(30, 200)
            .WithMessage("La presión diastólica debe estar entre 30 y 200 mmHg")
            .When(x => x.PresionDiastolica.HasValue);

        RuleFor(x => x.Temperatura)
            .InclusiveBetween(35m, 43m)
            .WithMessage("La temperatura debe estar entre 35°C y 43°C")
            .When(x => x.Temperatura.HasValue);

        RuleFor(x => x.FrecuenciaCardiaca)
            .InclusiveBetween(30, 250)
            .WithMessage("La frecuencia cardíaca debe estar entre 30 y 250 lpm")
            .When(x => x.FrecuenciaCardiaca.HasValue);

        RuleFor(x => x.FrecuenciaRespiratoria)
            .InclusiveBetween(8, 60)
            .WithMessage("La frecuencia respiratoria debe estar entre 8 y 60 rpm")
            .When(x => x.FrecuenciaRespiratoria.HasValue);

        RuleFor(x => x.SaturacionOxigeno)
            .InclusiveBetween(50, 100)
            .WithMessage("La saturación de oxígeno debe estar entre 50% y 100%")
            .When(x => x.SaturacionOxigeno.HasValue);

        RuleFor(x => x.Peso)
            .InclusiveBetween(0.5m, 500m)
            .WithMessage("El peso debe estar entre 0.5 kg y 500 kg")
            .When(x => x.Peso.HasValue);

        RuleFor(x => x.Altura)
            .InclusiveBetween(0.3m, 2.5m)
            .WithMessage("La altura debe estar entre 0.3 m y 2.5 m")
            .When(x => x.Altura.HasValue);

        RuleFor(x => x.GlucosaCapilar)
            .InclusiveBetween(20m, 600m)
            .WithMessage("La glucosa capilar debe estar entre 20 y 600 mg/dL")
            .When(x => x.GlucosaCapilar.HasValue);

        RuleFor(x => x.NivelDolor)
            .InclusiveBetween(0, 10)
            .WithMessage("El nivel de dolor debe estar entre 0 y 10")
            .When(x => x.NivelDolor.HasValue);

        RuleFor(x => x.Observaciones)
            .MaximumLength(1000)
            .WithMessage("Las observaciones no pueden exceder 1000 caracteres")
            .When(x => !string.IsNullOrEmpty(x.Observaciones));
    }
}