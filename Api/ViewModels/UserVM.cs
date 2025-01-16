namespace Api.ViewModels
{
    public class UserVM
    {
        public string Username { get; set; }

        public UserVM(string username)
        {
            Username = username;
        }
    }
}
