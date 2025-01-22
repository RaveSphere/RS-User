namespace Core.Models
{
    public class GetUserModel
    {
        public string Username { get; init; }

        public GetUserModel(string username)
        {
            Username = username;
        }
    }
}
