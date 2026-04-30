using KoeretoejsManager.Api.Models;
using KoeretoejsManager.Shared.DTOs;

namespace KoeretoejsManager.Api.Mapper
{
    public static class UserMapper
    {
        public static UserIdDTO ToUserIdDto(User entity)
        {
            return new UserIdDTO
            {
                UserId = entity.UserId,
                UserName = entity.UserName
            };
        }
    }
}
