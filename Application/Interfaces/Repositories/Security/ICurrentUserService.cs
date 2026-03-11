namespace Application.Interfaces.Security;

public interface ICurrentUserService
{
    int GetUserId();
    string GetUsername();
    bool IsAuthenticated();
}