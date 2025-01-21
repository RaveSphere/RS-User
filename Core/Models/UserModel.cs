namespace Core.Models
{
    public class UserModel
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public byte[] Salt { get; init; }

        public UserModel(string username, string password, byte[] salt)
        {
            Username = username;
            Password = password;
            Salt = salt;
        }
    }
}
