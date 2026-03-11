using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.ExamenesFisicos.GetExamenFisicoByConsulta;

public class GetExamenFisicoByConsultaHandler
{
    private readonly IExamenFisicoRepository _examenFisicoRepository;

    public GetExamenFisicoByConsultaHandler(IExamenFisicoRepository examenFisicoRepository)
    {
        _examenFisicoRepository = examenFisicoRepository;
    }

    public async Task<GetExamenFisicoByConsultaResponse?> HandleAsync(int consultaId)
    {
        var examenFisico = await _examenFisicoRepository.GetByConsultaIdAsync(consultaId);

        if (examenFisico == null)
            return null;

        return new GetExamenFisicoByConsultaResponse
        {
            Id = examenFisico.Id,
            ConsultaId = examenFisico.ConsultaId,
            EsNormal = examenFisico.EsNormal,
            Descripcion = examenFisico.Descripcion,
            FechaRegistro = examenFisico.FechaRegistro
        };
    }
}