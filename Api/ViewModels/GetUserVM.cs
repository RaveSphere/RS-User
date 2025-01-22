namespace Api.ViewModels
{
    public class GetUserVM
    {
        public string Username { get; set; }

        public GetUserVM(string username)
        {
            Username = username;
        }
    }
}
