using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Antecedentes.GetAntecedente;

public class GetAntecedenteHandler
{
    private readonly IAntecedenteRepository _antecedenteRepository;

    public GetAntecedenteHandler(IAntecedenteRepository antecedenteRepository)
    {
        _antecedenteRepository = antecedenteRepository;
    }

    public async Task<GetAntecedenteResponse> HandleAsync(int id)
    {
        var antecedente = await _antecedenteRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El antecedente con ID {id} no existe");

        return new GetAntecedenteResponse
        {
            Id = antecedente.Id,
            PacienteId = antecedente.PacienteId,
            Tipo = antecedente.Tipo,
            Condicion = antecedente.Condicion,
            Descripcion = antecedente.Descripcion
        };
    }
}