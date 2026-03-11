using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.OrdenesLaboratorio.UpdateOrdenLaboratorio;

public class UpdateOrdenLaboratorioHandler
{
    private readonly IOrdenLaboratorioRepository _ordenLaboratorioRepository;

    public UpdateOrdenLaboratorioHandler(IOrdenLaboratorioRepository ordenLaboratorioRepository)
    {
        _ordenLaboratorioRepository = ordenLaboratorioRepository;
    }

    public async Task<UpdateOrdenLaboratorioResponse> HandleAsync(int id, UpdateOrdenLaboratorioRequest request)
    {
        var orden = await _ordenLaboratorioRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La orden de laboratorio con ID {id} no existe");

        // Validar número de orden único si cambió
        if (orden.NumeroOrden != request.NumeroOrden)
        {
            if (await _ordenLaboratorioRepository.ExistsNumeroOrdenAsync(request.NumeroOrden, id))
                throw new InvalidOperationException($"El número de orden '{request.NumeroOrden}' ya existe");
        }

        orden.Actualizar(
            request.NumeroOrden,
            request.FechaOrden,
            request.DiagnosticoCie10,
            request.Observaciones
        );

        await _ordenLaboratorioRepository.UpdateAsync(orden);

        return new UpdateOrdenLaboratorioResponse
        {
            Id = orden.Id,
            ConsultaId = orden.ConsultaId,
            NumeroOrden = orden.NumeroOrden,
            FechaOrden = orden.FechaOrden,
            DiagnosticoCie10 = orden.DiagnosticoCie10,
            Observaciones = orden.Observaciones
        };
    }
}