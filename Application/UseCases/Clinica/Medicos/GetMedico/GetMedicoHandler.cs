using Application.Interfaces.Repositories.Clinica;

namespace Application.UseCases.Clinica.Medicos.GetMedico;

public class GetMedicoHandler
{
    private readonly IMedicoRepository _medicoRepository;

    public GetMedicoHandler(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public async Task<GetMedicoResponse> HandleAsync(int id)
    {
        var medico = await _medicoRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"El médico con ID {id} no existe");

        return new GetMedicoResponse
        {
            Id = medico.Id,
            UsuarioId = medico.UsuarioId,
            CedulaProfesional = medico.CedulaProfesional,
            Especialidad = medico.Especialidad,
            Subespecialidad = medico.Subespecialidad,
            Consultorio = medico.Consultorio,
            TelefonoConsultorio = medico.TelefonoConsultorio,
            HorarioAtencion = medico.HorarioAtencion,
            Observaciones = medico.Observaciones,
            Activo = medico.Activo,
            FechaCreacion = medico.FechaCreacion
        };
    }
}