using KoeretoejsManager.Api.Models;

namespace KoeretoejsManager.Api.Interfaces
{
    public interface IUserAuthService
    {
        User ValidateUser(string username, string password);
    }
}
