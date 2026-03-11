namespace Domain.Entities;

public class Paciente
{
    public int Id { get; private set; }
    public string? Dpi { get; private set; }
    public string Nombres { get; private set; } = default!;
    public string Apellidos { get; private set; } = default!;
    public string NombreCompleto { get; private set; } = default!;
    public DateTime FechaNacimiento { get; private set; }
    public string Sexo { get; private set; } = default!;
    public string? Telefono { get; private set; }
    public string? Direccion { get; private set; }
    public string? Email { get; private set; }
    public DateTime FechaRegistro { get; private set; }
    public int CreadoPor { get; private set; }

    protected Paciente() { }

    public Paciente(
        string nombres,
        string apellidos,
        DateTime fechaNacimiento,
        string sexo,
        int creadoPor,
        string? dpi = null,
        string? telefono = null,
        string? direccion = null,
        string? email = null)
    {
        if (string.IsNullOrWhiteSpace(nombres))
            throw new ArgumentException("Los nombres son obligatorios");
        if (string.IsNullOrWhiteSpace(apellidos))
            throw new ArgumentException("Los apellidos son obligatorios");
        if (string.IsNullOrWhiteSpace(sexo))
            throw new ArgumentException("El sexo es obligatorio");
        if (!new[] { "masculino", "femenino", "otro" }.Contains(sexo.ToLower()))
            throw new ArgumentException("El sexo debe ser: masculino, femenino u otro");

        Nombres = nombres;
        Apellidos = apellidos;
        NombreCompleto = $"{nombres} {apellidos}";
        FechaNacimiento = fechaNacimiento;
        Sexo = sexo.ToLower();
        Dpi = dpi;
        Telefono = telefono;
        Direccion = direccion;
        Email = email;
        CreadoPor = creadoPor;
        FechaRegistro = DateTime.UtcNow;
    }

    public void Actualizar(
        string nombres,
        string apellidos,
        DateTime fechaNacimiento,
        string sexo,
        string? dpi = null,
        string? telefono = null,
        string? direccion = null,
        string? email = null)
    {
        if (string.IsNullOrWhiteSpace(nombres))
            throw new ArgumentException("Los nombres son obligatorios");
        if (string.IsNullOrWhiteSpace(apellidos))
            throw new ArgumentException("Los apellidos son obligatorios");
        if (string.IsNullOrWhiteSpace(sexo))
            throw new ArgumentException("El sexo es obligatorio");
        if (!new[] { "masculino", "femenino", "otro" }.Contains(sexo.ToLower()))
            throw new ArgumentException("El sexo debe ser: masculino, femenino u otro");

        Nombres = nombres;
        Apellidos = apellidos;
        NombreCompleto = $"{nombres} {apellidos}";
        FechaNacimiento = fechaNacimiento;
        Sexo = sexo.ToLower();
        Dpi = dpi;
        Telefono = telefono;
        Direccion = direccion;
        Email = email;
    }

    public int CalcularEdad()
    {
        var hoy = DateTime.Today;
        var edad = hoy.Year - FechaNacimiento.Year;
        if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
        return edad;
    }
}