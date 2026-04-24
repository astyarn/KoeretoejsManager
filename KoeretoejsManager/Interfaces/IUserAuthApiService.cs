namespace KoeretoejsManager.Interfaces
{
    public interface IUserAuthApiService
    {
        Task<bool?> LoginAsync(string username, string password);
    }
}
