using Core.Models;

namespace Application.Interfaces
{
    public interface IHashingService
    {
        public Task<HashingModel> Hash(string password, byte[] salt);
    }
}
