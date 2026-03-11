using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Alergias.ListAlergiasByPaciente;

public class ListAlergiasByPacienteHandler
{
    private readonly IAlergiaRepository _alergiaRepository;

    public ListAlergiasByPacienteHandler(IAlergiaRepository alergiaRepository)
    {
        _alergiaRepository = alergiaRepository;
    }

    public async Task<IEnumerable<ListAlergiasByPacienteResponse>> HandleAsync(int pacienteId)
    {
        var alergias = await _alergiaRepository.GetByPacienteIdAsync(pacienteId);

        return alergias.Select(a => new ListAlergiasByPacienteResponse
        {
            Id = a.Id,
            PacienteId = a.PacienteId,
            MedicamentoOElemento = a.MedicamentoOElemento,
            Reaccion = a.Reaccion
        });
    }
}