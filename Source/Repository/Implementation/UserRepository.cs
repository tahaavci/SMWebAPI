using SMWebApi.Context;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;

namespace SMWebApi.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext dataContext;
      
        public UserRepository(DataContext dataContext)
        {

            this.dataContext = dataContext;

        }
        public ICollection<User> GetUsers()
        {

            ICollection<User> result = dataContext.Users.OrderBy(u => u.user_id).ToList();

            return result;
        }


        public bool CreateUser(User user)
        {
            try
            {
                dataContext.Users.Add(user);
                var status = dataContext.SaveChanges();

                if (status > 0)
                    return true;
                else
                    throw new ApiException("Failed to Save User");


            }
            catch (Exception)
            {
                throw new ApiException("Failed to Create User");
            }

        }

        public User GetUserbyEmail(string email)
        {
            return dataContext.Users.FirstOrDefault(u => u.user_email == email);
        }

        public User GetUserbyId(long id)
        {
            return dataContext.Users.FirstOrDefault(u => u.user_id == id);
        }

    }
}
