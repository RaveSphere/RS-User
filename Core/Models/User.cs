namespace Core.Models
{
    public class User
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public byte[] Salt { get; init; }

        public User(string username, string password, byte[] salt)
        {
            Username = username;
            Password = password;
            Salt = salt;
        }
    }
}
