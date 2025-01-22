namespace Core.Models
{
    internal class ValidateCredentialsModel
    {
        public string Username { get; init; }
        public string Password { get; init; }

        public ValidateCredentialsModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
