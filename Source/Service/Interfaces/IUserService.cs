using SMWebApi.Dto;
using SMWebApi.Models;

namespace SMWebApi.Service.Interfaces
{
    public interface IUserService
    {

        bool CreateUser(UserDto user);

        User LoginAuthorization(string email, string password);

        User GetUserByEmail(string email);

        User GetUserById(long id);

        bool SendConfirmationEmail(User user);

        bool CompleteConfirmation(User user);

        public bool CheckEmailValidation(string email);


    }
}
