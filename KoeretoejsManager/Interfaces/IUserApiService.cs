using KoeretoejsManager.Shared.DTOs;

namespace KoeretoejsManager.Interfaces
{
    public interface IUserApiService
    {
        Task<List<UserIdDTO>> GetAllUserIds();    //Demo
    }
}
