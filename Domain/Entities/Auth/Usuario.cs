namespace Domain.Entities.Auth;

public class Usuario
{
    public int Id { get; private set; }
    public string Username { get; private set; } = default!;
    public string NombreCompleto { get; private set; } = default!;
    public string? Email { get; private set; }
    public string PasswordHash { get; private set; } = default!;
    public int RolId { get; private set; }
    public bool Activo { get; private set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? UltimoAcceso { get; private set; }

    protected Usuario() { }

    public Usuario(
        string username,
        string nombreCompleto,
        string passwordHash,
        int rolId,
        string? email = null)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("El username es obligatorio");
        if (string.IsNullOrWhiteSpace(nombreCompleto))
            throw new ArgumentException("El nombre completo es obligatorio");
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("El password hash es obligatorio");

        Username = username;
        NombreCompleto = nombreCompleto;
        PasswordHash = passwordHash;
        RolId = rolId;
        Email = email;
        Activo = true;
        FechaCreacion = DateTime.UtcNow;
    }

    public void Actualizar(string nombreCompleto, string? email, int rolId)
    {
        if (string.IsNullOrWhiteSpace(nombreCompleto))
            throw new ArgumentException("El nombre completo es obligatorio");

        NombreCompleto = nombreCompleto;
        Email = email;
        RolId = rolId;
    }

    public void CambiarPassword(string nuevoPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(nuevoPasswordHash))
            throw new ArgumentException("El password hash es obligatorio");

        PasswordHash = nuevoPasswordHash;
    }

    public void Activar() => Activo = true;

    public void Desactivar() => Activo = false;

    public void RegistrarAcceso()
    {
        UltimoAcceso = DateTime.UtcNow;
    }
}
