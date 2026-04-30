using KoeretoejsManager.Shared.DTOs;

namespace KoeretoejsManager.Api.Interfaces
{
    public interface IUserService
    {
        List<UserIdDTO> GetAllUserIds();    //Demo method, used instead of login to show all available user
    }
}
