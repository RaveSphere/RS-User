namespace Api.RequestModels
{
    public record ValidateCredentialsRequest(
        string Username,
        string Password
     );
}
