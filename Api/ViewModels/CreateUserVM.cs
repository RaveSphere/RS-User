namespace Api.ViewModels
{
    public class CreateUserVM
    {
        public string Username { get; set; }

        public CreateUserVM(string username)
        {
            Username = username;
        }
    }
}
