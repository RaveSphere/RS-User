using Application.Interfaces;
using Core.Models;
using Konscious.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class HashingService : IHashingService
    {
        public async Task<HashingModel> Hash(string password, byte[] salt)
        {
            byte[] byteInput = Encoding.ASCII.GetBytes(password);

            Argon2id argon2 = new(byteInput)
            {
                DegreeOfParallelism = 1,
                MemorySize = 19456,
                Iterations = 2,
                Salt = salt
            };

            byte[] hash = await argon2.GetBytesAsync(44);

            return new HashingModel(Convert.ToBase64String(hash), salt);
        }
    }
}
