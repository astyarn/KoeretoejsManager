using KoeretoejsManager.Api.Models;

namespace KoeretoejsManager.Api.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
