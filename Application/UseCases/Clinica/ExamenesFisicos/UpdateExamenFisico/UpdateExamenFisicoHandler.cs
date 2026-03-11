using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.ExamenesFisicos.UpdateExamenFisico;

public class UpdateExamenFisicoHandler
{
    private readonly IExamenFisicoRepository _examenFisicoRepository;

    public UpdateExamenFisicoHandler(IExamenFisicoRepository examenFisicoRepository)
    {
        _examenFisicoRepository = examenFisicoRepository;
    }

    public async Task<UpdateExamenFisicoResponse> HandleAsync(int id, UpdateExamenFisicoRequest request)
    {
        var examenFisico = await _examenFisicoRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El examen físico con ID {id} no existe");

        examenFisico.Actualizar(request.EsNormal, request.Descripcion);

        await _examenFisicoRepository.UpdateAsync(examenFisico);

        return new UpdateExamenFisicoResponse
        {
            Id = examenFisico.Id,
            ConsultaId = examenFisico.ConsultaId,
            EsNormal = examenFisico.EsNormal,
            Descripcion = examenFisico.Descripcion
        };
    }
}