namespace Core.Models
{
    public class HashingModel
    {
        public string HashedPassword { get; init; }
        public byte[] Salt { get; init; }

        public HashingModel(string password, byte[] salt)
        {
            HashedPassword = password;
            Salt = salt;
        }
    }
}
