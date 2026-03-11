using Application.Interfaces.Repositories;

namespace Application.UseCases.Pacientes.SearchPacientes;

public class SearchPacientesHandler
{
    private readonly IPacienteRepository _pacienteRepository;

    public SearchPacientesHandler(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<IEnumerable<SearchPacientesResponse>> HandleAsync(SearchPacientesRequest request)
    {
        var pacientes = await _pacienteRepository.SearchAsync(request.SearchTerm);

        return pacientes.Select(p => new SearchPacientesResponse
        {
            Id = p.Id,
            Dpi = p.Dpi,
            NombreCompleto = p.NombreCompleto,
            FechaNacimiento = p.FechaNacimiento,
            Edad = p.CalcularEdad(),
            Sexo = p.Sexo,
            Telefono = p.Telefono
        });
    }
}