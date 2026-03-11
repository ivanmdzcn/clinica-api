using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Consultas.CerrarConsulta;

public class CerrarConsultaHandler
{
    private readonly IConsultaRepository _consultaRepository;

    public CerrarConsultaHandler(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task HandleAsync(int id)
    {
        var consulta = await _consultaRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La consulta con ID {id} no existe");

        if (consulta.Estado == "cerrada")
            throw new InvalidOperationException("La consulta ya está cerrada");

        if (consulta.Estado == "anulada")
            throw new InvalidOperationException("No se puede cerrar una consulta anulada");

        consulta.Cerrar();
        await _consultaRepository.UpdateAsync(consulta);
    }
}