using KoeretoejsManager.Api.Data;
using KoeretoejsManager.Api.Interfaces;
using KoeretoejsManager.Api.Models;

namespace KoeretoejsManager.Api.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly KoeretoejsManagerDbContext _db;

        public UserAuthService(KoeretoejsManagerDbContext db)
        {
            _db = db;
        }

        public User ValidateUser(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
                return null;

            //TODO: Implement password hashing and verification
            //if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            //    return null;
            if ((password != user.PasswordHash))
                return null;

            return user;
        }
    }
}
