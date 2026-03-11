namespace Domain.Entities.Clinica;

public class Diagnostico
{
    public int Id { get; private set; }
    public int ConsultaId { get; private set; }
    public string? CodigoCie10 { get; private set; }
    public string Descripcion { get; private set; }
    public string Tipo { get; private set; } // 'presuntivo' o 'definitivo'
    public DateTime FechaRegistro { get; private set; }

    // Constructor para crear nuevo diagnóstico
    public Diagnostico(
        int consultaId,
        string descripcion,
        string tipo = "definitivo",
        string? codigoCie10 = null)
    {
        if (tipo != "presuntivo" && tipo != "definitivo")
            throw new ArgumentException("El tipo debe ser 'presuntivo' o 'definitivo'", nameof(tipo));

        ConsultaId = consultaId;
        Descripcion = descripcion;
        Tipo = tipo;
        CodigoCie10 = codigoCie10;
        FechaRegistro = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public Diagnostico(
        int id,
        int consultaId,
        string? codigoCie10,
        string descripcion,
        string tipo,
        DateTime fechaRegistro)
    {
        Id = id;
        ConsultaId = consultaId;
        CodigoCie10 = codigoCie10;
        Descripcion = descripcion;
        Tipo = tipo;
        FechaRegistro = fechaRegistro;
    }

    public void Actualizar(string descripcion, string tipo, string? codigoCie10)
    {
        if (tipo != "presuntivo" && tipo != "definitivo")
            throw new ArgumentException("El tipo debe ser 'presuntivo' o 'definitivo'", nameof(tipo));

        Descripcion = descripcion;
        Tipo = tipo;
        CodigoCie10 = codigoCie10;
    }
}