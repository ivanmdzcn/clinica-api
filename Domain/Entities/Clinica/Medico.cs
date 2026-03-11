namespace Domain.Entities.Clinica;

public class Medico
{
    public int Id { get; private set; }
    public int UsuarioId { get; private set; }
    public string CedulaProfesional { get; private set; }
    public string Especialidad { get; private set; }
    public string? Subespecialidad { get; private set; }
    public string? Consultorio { get; private set; }
    public string? TelefonoConsultorio { get; private set; }
    public string? HorarioAtencion { get; private set; }
    public string? Observaciones { get; private set; }
    public bool Activo { get; private set; }
    public DateTime FechaCreacion { get; private set; }

    // Constructor para crear nuevo médico
    public Medico(
        int usuarioId,
        string cedulaProfesional,
        string especialidad,
        string? subespecialidad = null,
        string? consultorio = null,
        string? telefonoConsultorio = null,
        string? horarioAtencion = null,
        string? observaciones = null,
        bool activo = true)
    {
        UsuarioId = usuarioId;
        CedulaProfesional = cedulaProfesional;
        Especialidad = especialidad;
        Subespecialidad = subespecialidad;
        Consultorio = consultorio;
        TelefonoConsultorio = telefonoConsultorio;
        HorarioAtencion = horarioAtencion;
        Observaciones = observaciones;
        Activo = activo;
        FechaCreacion = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public Medico(
        int id,
        int usuarioId,
        string cedulaProfesional,
        string especialidad,
        string? subespecialidad,
        string? consultorio,
        string? telefonoConsultorio,
        string? horarioAtencion,
        string? observaciones,
        bool activo,
        DateTime fechaCreacion)
    {
        Id = id;
        UsuarioId = usuarioId;
        CedulaProfesional = cedulaProfesional;
        Especialidad = especialidad;
        Subespecialidad = subespecialidad;
        Consultorio = consultorio;
        TelefonoConsultorio = telefonoConsultorio;
        HorarioAtencion = horarioAtencion;
        Observaciones = observaciones;
        Activo = activo;
        FechaCreacion = fechaCreacion;
    }

    public void Actualizar(
        string cedulaProfesional,
        string especialidad,
        string? subespecialidad,
        string? consultorio,
        string? telefonoConsultorio,
        string? horarioAtencion,
        string? observaciones,
        bool activo)
    {
        CedulaProfesional = cedulaProfesional;
        Especialidad = especialidad;
        Subespecialidad = subespecialidad;
        Consultorio = consultorio;
        TelefonoConsultorio = telefonoConsultorio;
        HorarioAtencion = horarioAtencion;
        Observaciones = observaciones;
        Activo = activo;
    }

    public void Activar() => Activo = true;
    public void Desactivar() => Activo = false;
}