using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Alergias.UpdateAlergia;

public class UpdateAlergiaHandler
{
    private readonly IAlergiaRepository _alergiaRepository;

    public UpdateAlergiaHandler(IAlergiaRepository alergiaRepository)
    {
        _alergiaRepository = alergiaRepository;
    }

    public async Task<UpdateAlergiaResponse> HandleAsync(int id, UpdateAlergiaRequest request)
    {
        var alergia = await _alergiaRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La alergia con ID {id} no existe");

        alergia.Actualizar(request.MedicamentoOElemento, request.Reaccion);

        await _alergiaRepository.UpdateAsync(alergia);

        return new UpdateAlergiaResponse
        {
            Id = alergia.Id,
            PacienteId = alergia.PacienteId,
            MedicamentoOElemento = alergia.MedicamentoOElemento,
            Reaccion = alergia.Reaccion
        };
    }
}