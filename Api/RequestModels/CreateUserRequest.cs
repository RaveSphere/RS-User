namespace Api.RequestModels
{
    public record CreateUserRequest(
        string Username,
        string HashedPassword,
        Guid Salt
     );
}
