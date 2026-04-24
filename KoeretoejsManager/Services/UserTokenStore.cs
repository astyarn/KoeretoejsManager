using KoeretoejsManager.Interfaces;

namespace KoeretoejsManager.Services
{
    public class UserTokenStore : IUserTokenStore
    {
        private string? _token;
        private DateTime? _expiresAt;

        public Task SetTokenAsync(string token, DateTime expiresAt)
        {
            _token = token;
            _expiresAt = expiresAt;
            return Task.CompletedTask;
        }

        public string? GetToken()
        {
            return _token;
        }

        public DateTime? GetExpiry()
        {
            return _expiresAt;
        }

        public bool IsAuthenticated()
        {
            if (string.IsNullOrEmpty(_token))
                return false;

            if (_expiresAt.HasValue && _expiresAt.Value <= DateTime.UtcNow)
                return false;

            return true;
        }

        public void Clear()
        {
            _token = null;
            _expiresAt = null;
        }
    }
}
