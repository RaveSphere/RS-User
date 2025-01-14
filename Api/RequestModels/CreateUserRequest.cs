namespace Api.RequestModels
{
    public record CreateUserRequest(
        string Username,
        string Password
     );
}
