using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.Alergias.CreateAlergia;

public class CreateAlergiaHandler
{
    private readonly IAlergiaRepository _alergiaRepository;
    private readonly IPacienteRepository _pacienteRepository;

    public CreateAlergiaHandler(
        IAlergiaRepository alergiaRepository,
        IPacienteRepository pacienteRepository)
    {
        _alergiaRepository = alergiaRepository;
        _pacienteRepository = pacienteRepository;
    }

    public async Task<CreateAlergiaResponse> HandleAsync(CreateAlergiaRequest request)
    {
        // Validar que el paciente existe
        var paciente = await _pacienteRepository.GetByIdAsync(request.PacienteId);
        if (paciente == null)
            throw new InvalidOperationException($"El paciente con ID {request.PacienteId} no existe");

        var alergia = new PacienteAlergia(
            request.PacienteId,
            request.MedicamentoOElemento,
            request.Reaccion
        );

        var id = await _alergiaRepository.CreateAsync(alergia);

        return new CreateAlergiaResponse
        {
            Id = id,
            PacienteId = alergia.PacienteId,
            MedicamentoOElemento = alergia.MedicamentoOElemento,
            Reaccion = alergia.Reaccion
        };
    }
}