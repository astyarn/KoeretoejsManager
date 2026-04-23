namespace KoeretoejsManager.Interfaces
{
    public interface IUserAuthApiService
    {
        Task<string?> LoginAsync(string username, string password);
    }
}
