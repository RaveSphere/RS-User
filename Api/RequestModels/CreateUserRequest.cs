namespace Api.RequestModels
{
    public record CreateUserRequest(
        string Username,
        string HasedPassword,
        Guid Salt
     );
}
