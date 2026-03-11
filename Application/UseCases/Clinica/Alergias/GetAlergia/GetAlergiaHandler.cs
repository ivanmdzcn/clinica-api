using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Alergias.GetAlergia;

public class GetAlergiaHandler
{
    private readonly IAlergiaRepository _alergiaRepository;

    public GetAlergiaHandler(IAlergiaRepository alergiaRepository)
    {
        _alergiaRepository = alergiaRepository;
    }

    public async Task<GetAlergiaResponse> HandleAsync(int id)
    {
        var alergia = await _alergiaRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La alergia con ID {id} no existe");

        return new GetAlergiaResponse
        {
            Id = alergia.Id,
            PacienteId = alergia.PacienteId,
            MedicamentoOElemento = alergia.MedicamentoOElemento,
            Reaccion = alergia.Reaccion
        };
    }
}