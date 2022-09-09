using SMWebApi.Models;

namespace SMWebApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUserbyEmail(string email);
        User GetUserbyId(long id);
        bool CreateUser(User user);






    }
}
