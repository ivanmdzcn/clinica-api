namespace Domain.Entities.Clinica;

public class ExamenLaboratorio
{
    public int Id { get; private set; }
    public int OrdenLaboratorioId { get; private set; }
    public string NombreExamen { get; private set; }
    public string? Resultado { get; private set; }
    public string? Unidad { get; private set; }
    public string? ValorReferencia { get; private set; }
    public DateTime? FechaResultado { get; private set; }
    public DateTime FechaRegistro { get; private set; }

    // Constructor para crear nuevo examen
    public ExamenLaboratorio(
        int ordenLaboratorioId,
        string nombreExamen,
        string? resultado = null,
        string? unidad = null,
        string? valorReferencia = null,
        DateTime? fechaResultado = null)
    {
        OrdenLaboratorioId = ordenLaboratorioId;
        NombreExamen = nombreExamen;
        Resultado = resultado;
        Unidad = unidad;
        ValorReferencia = valorReferencia;
        FechaResultado = fechaResultado;
        FechaRegistro = DateTime.Now;
    }

    // Constructor para recuperar desde BD
    public ExamenLaboratorio(
        int id,
        int ordenLaboratorioId,
        string nombreExamen,
        string? resultado,
        string? unidad,
        string? valorReferencia,
        DateTime? fechaResultado,
        DateTime fechaRegistro)
    {
        Id = id;
        OrdenLaboratorioId = ordenLaboratorioId;
        NombreExamen = nombreExamen;
        Resultado = resultado;
        Unidad = unidad;
        ValorReferencia = valorReferencia;
        FechaResultado = fechaResultado;
        FechaRegistro = fechaRegistro;
    }

    public void Actualizar(
        string nombreExamen,
        string? resultado,
        string? unidad,
        string? valorReferencia,
        DateTime? fechaResultado)
    {
        NombreExamen = nombreExamen;
        Resultado = resultado;
        Unidad = unidad;
        ValorReferencia = valorReferencia;
        FechaResultado = fechaResultado;
    }

    public bool TieneResultado() => !string.IsNullOrEmpty(Resultado);
}