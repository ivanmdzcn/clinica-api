using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Medicos.UpdateMedico;

public class UpdateMedicoHandler
{
    private readonly IMedicoRepository _medicoRepository;

    public UpdateMedicoHandler(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public async Task<UpdateMedicoResponse> HandleAsync(int id, UpdateMedicoRequest request)
    {
        var medico = await _medicoRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El médico con ID {id} no existe");

        // Validar cédula única si cambió
        if (medico.CedulaProfesional != request.CedulaProfesional)
        {
            if (await _medicoRepository.ExistsByCedulaAsync(request.CedulaProfesional, id))
                throw new InvalidOperationException($"La cédula profesional '{request.CedulaProfesional}' ya está registrada");
        }

        medico.Actualizar(
            request.CedulaProfesional,
            request.Especialidad,
            request.Subespecialidad,
            request.Consultorio,
            request.TelefonoConsultorio,
            request.HorarioAtencion,
            request.Observaciones,
            request.Activo
        );

        await _medicoRepository.UpdateAsync(medico);

        return new UpdateMedicoResponse
        {
            Id = medico.Id,
            UsuarioId = medico.UsuarioId,
            CedulaProfesional = medico.CedulaProfesional,
            Especialidad = medico.Especialidad,
            Subespecialidad = medico.Subespecialidad,
            Activo = medico.Activo
        };
    }
}