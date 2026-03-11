namespace Domain.Entities.Auth;

public class Permiso
{
    public int Id { get; private set; }
    public string Codigo { get; private set; } = default!;
    public string Modulo { get; private set; } = default!;
    public string Accion { get; private set; } = default!;
    public string? Descripcion { get; private set; }

    protected Permiso() { }

    public Permiso(string codigo, string modulo, string accion, string? descripcion = null)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código del permiso es obligatorio");
        if (string.IsNullOrWhiteSpace(modulo))
            throw new ArgumentException("El módulo es obligatorio");
        if (string.IsNullOrWhiteSpace(accion))
            throw new ArgumentException("La acción es obligatoria");

        Codigo = codigo;
        Modulo = modulo;
        Accion = accion;
        Descripcion = descripcion;
    }

    public void Actualizar(string codigo, string modulo, string accion, string? descripcion)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código del permiso es obligatorio");
        if (string.IsNullOrWhiteSpace(modulo))
            throw new ArgumentException("El módulo es obligatorio");
        if (string.IsNullOrWhiteSpace(accion))
            throw new ArgumentException("La acción es obligatoria");

        Codigo = codigo;
        Modulo = modulo;
        Accion = accion;
        Descripcion = descripcion;
    }
}