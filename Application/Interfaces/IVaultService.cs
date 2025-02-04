namespace Application.Interfaces
{
    public interface IVaultService
    {
        Task<string?> GetSecretAsync(string path, string key);
    }
}
