using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.OrdenesLaboratorio.GetOrdenLaboratorio;

public class GetOrdenLaboratorioHandler
{
    private readonly IOrdenLaboratorioRepository _ordenLaboratorioRepository;

    public GetOrdenLaboratorioHandler(IOrdenLaboratorioRepository ordenLaboratorioRepository)
    {
        _ordenLaboratorioRepository = ordenLaboratorioRepository;
    }

    public async Task<GetOrdenLaboratorioResponse> HandleAsync(int id)
    {
        var orden = await _ordenLaboratorioRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La orden de laboratorio con ID {id} no existe");

        return new GetOrdenLaboratorioResponse
        {
            Id = orden.Id,
            ConsultaId = orden.ConsultaId,
            NumeroOrden = orden.NumeroOrden,
            FechaOrden = orden.FechaOrden,
            PacienteId = orden.PacienteId,
            MedicoId = orden.MedicoId,
            DiagnosticoCie10 = orden.DiagnosticoCie10,
            Observaciones = orden.Observaciones,
            FechaRegistro = orden.FechaRegistro
        };
    }
}