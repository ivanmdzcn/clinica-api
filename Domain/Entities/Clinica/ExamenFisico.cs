namespace Domain.Entities.Clinica;

public class ExamenFisico
{
    public int Id { get; private set; }
    public int ConsultaId { get; private set; }
    public bool EsNormal { get; private set; }
    public string? Descripcion { get; private set; }
    public DateTime FechaRegistro { get; private set; }

    // Constructor para crear nuevo examen físico
    public ExamenFisico(
        int consultaId,
        bool esNormal,
        string? descripcion = null)
    {
        ConsultaId = consultaId;
        EsNormal = esNormal;
        Descripcion = descripcion;
        FechaRegistro = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public ExamenFisico(
        int id,
        int consultaId,
        bool esNormal,
        string? descripcion,
        DateTime fechaRegistro)
    {
        Id = id;
        ConsultaId = consultaId;
        EsNormal = esNormal;
        Descripcion = descripcion;
        FechaRegistro = fechaRegistro;
    }

    public void Actualizar(bool esNormal, string? descripcion)
    {
        EsNormal = esNormal;
        Descripcion = descripcion;
    }
}