using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Antecedentes.UpdateAntecedente;

public class UpdateAntecedenteHandler
{
    private readonly IAntecedenteRepository _antecedenteRepository;

    public UpdateAntecedenteHandler(IAntecedenteRepository antecedenteRepository)
    {
        _antecedenteRepository = antecedenteRepository;
    }

    public async Task<UpdateAntecedenteResponse> HandleAsync(int id, UpdateAntecedenteRequest request)
    {
        var antecedente = await _antecedenteRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El antecedente con ID {id} no existe");

        antecedente.Actualizar(request.Tipo, request.Condicion, request.Descripcion);

        await _antecedenteRepository.UpdateAsync(antecedente);

        return new UpdateAntecedenteResponse
        {
            Id = antecedente.Id,
            PacienteId = antecedente.PacienteId,
            Tipo = antecedente.Tipo,
            Condicion = antecedente.Condicion,
            Descripcion = antecedente.Descripcion
        };
    }
}