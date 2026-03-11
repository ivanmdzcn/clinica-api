using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.ExamenesFisicos.GetExamenFisico;

public class GetExamenFisicoHandler
{
    private readonly IExamenFisicoRepository _examenFisicoRepository;

    public GetExamenFisicoHandler(IExamenFisicoRepository examenFisicoRepository)
    {
        _examenFisicoRepository = examenFisicoRepository;
    }

    public async Task<GetExamenFisicoResponse> HandleAsync(int id)
    {
        var examenFisico = await _examenFisicoRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El examen físico con ID {id} no existe");

        return new GetExamenFisicoResponse
        {
            Id = examenFisico.Id,
            ConsultaId = examenFisico.ConsultaId,
            EsNormal = examenFisico.EsNormal,
            Descripcion = examenFisico.Descripcion,
            FechaRegistro = examenFisico.FechaRegistro
        };
    }
}