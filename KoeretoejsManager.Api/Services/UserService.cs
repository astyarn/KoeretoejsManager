using KoeretoejsManager.Api.Data;
using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Mapper;
using KoeretoejsManager.Shared.DTOs;

namespace KoeretoejsManager.Api.Services
{
    public class UserService : IUserService
    {
        private readonly KoeretoejsManagerDbContext _db;

        public UserService(KoeretoejsManagerDbContext db)
        {
            _db = db;
        }

        public List<UserIdDTO> GetAllUserIds()
        {
            return _db.Users.Select(u => UserMapper.ToUserIdDto(u)).ToList();
        }
    }
}

