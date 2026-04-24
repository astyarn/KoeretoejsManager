namespace KoeretoejsManager.Interfaces
{
    public interface IUserTokenStore
    {
        Task SetTokenAsync(string token, DateTime expiresAt);
        string? GetToken();
        DateTime? GetExpiry();
        bool IsAuthenticated();
        void Clear();
    }
}
