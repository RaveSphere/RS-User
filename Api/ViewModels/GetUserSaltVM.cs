namespace Api.ViewModels
{
    public class GetUserSaltVM
    {
        public Guid Salt { get; set; }

        public GetUserSaltVM(Guid salt)
        {
            Salt = salt;
        }
    }
}
