using Domain.Entities.Auth;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Security;

public interface ITokenGenerator
{
    Task<string> GenerateAsync(Usuario usuario, string rolNombre, IEnumerable<string> permisos);
}
