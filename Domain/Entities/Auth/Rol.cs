namespace Domain.Entities.Auth;

public class Rol
{
    public int Id { get; private set; }
    public string Nombre { get; private set; } = default!;
    public string? Descripcion { get; private set; }
    public DateTime FechaCreacion { get; private set; }

    protected Rol() { }

    public Rol(string nombre, string? descripcion = null)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del rol es obligatorio");

        Nombre = nombre;
        Descripcion = descripcion;
        FechaCreacion = DateTime.UtcNow;
    }

    public void Actualizar(string nombre, string? descripcion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre del rol es obligatorio");

        Nombre = nombre;
        Descripcion = descripcion;
    }
}