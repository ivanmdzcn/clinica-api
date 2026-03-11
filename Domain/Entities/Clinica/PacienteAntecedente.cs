namespace Domain.Entities.Clinica;

public class PacienteAntecedente
{
    public int Id { get; private set; }
    public int PacienteId { get; private set; }
    public string Tipo { get; private set; } // 'familiar' o 'personal'
    public string Condicion { get; private set; }
    public string? Descripcion { get; private set; }

    // Constructor para crear nuevo antecedente
    public PacienteAntecedente(
        int pacienteId,
        string tipo,
        string condicion,
        string? descripcion = null)
    {
        if (tipo != "familiar" && tipo != "personal")
            throw new ArgumentException("El tipo debe ser 'familiar' o 'personal'", nameof(tipo));

        PacienteId = pacienteId;
        Tipo = tipo;
        Condicion = condicion;
        Descripcion = descripcion;
    }

    // Constructor para recuperar desde BD
    public PacienteAntecedente(
        int id,
        int pacienteId,
        string tipo,
        string condicion,
        string? descripcion)
    {
        Id = id;
        PacienteId = pacienteId;
        Tipo = tipo;
        Condicion = condicion;
        Descripcion = descripcion;
    }

    public void Actualizar(string tipo, string condicion, string? descripcion)
    {
        if (tipo != "familiar" && tipo != "personal")
            throw new ArgumentException("El tipo debe ser 'familiar' o 'personal'", nameof(tipo));

        Tipo = tipo;
        Condicion = condicion;
        Descripcion = descripcion;
    }
}