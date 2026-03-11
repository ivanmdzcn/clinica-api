using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Antecedentes.ListAntecedentesByPaciente;

public class ListAntecedentesByPacienteHandler
{
    private readonly IAntecedenteRepository _antecedenteRepository;

    public ListAntecedentesByPacienteHandler(IAntecedenteRepository antecedenteRepository)
    {
        _antecedenteRepository = antecedenteRepository;
    }

    public async Task<IEnumerable<ListAntecedentesByPacienteResponse>> HandleAsync(int pacienteId)
    {
        var antecedentes = await _antecedenteRepository.GetByPacienteIdAsync(pacienteId);

        return antecedentes.Select(a => new ListAntecedentesByPacienteResponse
        {
            Id = a.Id,
            PacienteId = a.PacienteId,
            Tipo = a.Tipo,
            Condicion = a.Condicion,
            Descripcion = a.Descripcion
        });
    }
}