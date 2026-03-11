using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.Clinica;
using Domain.Entities.Clinica;

namespace Application.UseCases.Clinica.Antecedentes.CreateAntecedente;

public class CreateAntecedenteHandler
{
    private readonly IAntecedenteRepository _antecedenteRepository;
    private readonly IPacienteRepository _pacienteRepository;

    public CreateAntecedenteHandler(
        IAntecedenteRepository antecedenteRepository,
        IPacienteRepository pacienteRepository)
    {
        _antecedenteRepository = antecedenteRepository;
        _pacienteRepository = pacienteRepository;
    }

    public async Task<CreateAntecedenteResponse> HandleAsync(CreateAntecedenteRequest request)
    {
        // Validar que el paciente existe
        var paciente = await _pacienteRepository.GetByIdAsync(request.PacienteId);
        if (paciente == null)
            throw new InvalidOperationException($"El paciente con ID {request.PacienteId} no existe");

        var antecedente = new PacienteAntecedente(
            request.PacienteId,
            request.Tipo,
            request.Condicion,
            request.Descripcion
        );

        var id = await _antecedenteRepository.CreateAsync(antecedente);

        return new CreateAntecedenteResponse
        {
            Id = id,
            PacienteId = antecedente.PacienteId,
            Tipo = antecedente.Tipo,
            Condicion = antecedente.Condicion,
            Descripcion = antecedente.Descripcion
        };
    }
}