using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Consultas.AnularConsulta;

public class AnularConsultaHandler
{
    private readonly IConsultaRepository _consultaRepository;

    public AnularConsultaHandler(IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task HandleAsync(int id)
    {
        var consulta = await _consultaRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"La consulta con ID {id} no existe");

        if (consulta.Estado == "anulada")
            throw new InvalidOperationException("La consulta ya está anulada");

        consulta.Anular();
        await _consultaRepository.UpdateAsync(consulta);
    }
}