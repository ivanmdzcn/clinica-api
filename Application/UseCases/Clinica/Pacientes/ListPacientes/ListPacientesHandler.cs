using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.UseCases.Pacientes.ListPacientes;

public class ListPacientesHandler
{
    private readonly IPacienteRepository _pacienteRepository;

    public ListPacientesHandler(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<IEnumerable<ListPacientesResponse>> HandleAsync()
    {
        var pacientes = await _pacienteRepository.GetAllAsync();

        return pacientes.Select(p => new ListPacientesResponse
        {
            Id = p.Id,
            Dpi = p.Dpi,
            NombreCompleto = p.NombreCompleto,
            FechaNacimiento = p.FechaNacimiento,
            Edad = p.CalcularEdad(),
            Sexo = p.Sexo,
            Telefono = p.Telefono,
            Email = p.Email,
            FechaRegistro = p.FechaRegistro
        });
    }
}