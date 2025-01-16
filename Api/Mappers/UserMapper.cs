using Api.ViewModels;
using Core.Models;

namespace Api.Mappers
{
    public class UserMapper
    {
        public UserVM Map(User user)
        {
            return new UserVM(user.Username);
        }
    }
}
