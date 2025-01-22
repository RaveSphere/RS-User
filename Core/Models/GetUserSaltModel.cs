namespace Core.Models
{
    public class GetUserSaltModel
    {
        public Guid Salt { get; set; }

        public GetUserSaltModel(Guid salt)
        {
            Salt = salt;
        }
    }
}
