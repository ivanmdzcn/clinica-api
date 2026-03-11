using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Medicos.ListMedicos;

public class ListMedicosHandler
{
    private readonly IMedicoRepository _medicoRepository;

    public ListMedicosHandler(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public async Task<IEnumerable<ListMedicosResponse>> HandleAsync(bool? soloActivos = null)
    {
        var medicos = await _medicoRepository.GetAllAsync(soloActivos);

        return medicos.Select(m => new ListMedicosResponse
        {
            Id = m.Id,
            UsuarioId = m.UsuarioId,
            CedulaProfesional = m.CedulaProfesional,
            Especialidad = m.Especialidad,
            Subespecialidad = m.Subespecialidad,
            Consultorio = m.Consultorio,
            Activo = m.Activo
        });
    }
}