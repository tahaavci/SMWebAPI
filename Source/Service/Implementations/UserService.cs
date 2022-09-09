using SMWebApi.Dto;
using SMWebApi.Models;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;
using SMWebApi.Exceptions;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Interfaces;
using System.Text.RegularExpressions;

namespace SMWebApi.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool CreateUser(UserDto newuser)
        {

            if (!CheckEmailValidation(newuser.user_email))
                throw new ApiException("Not Valid Email");

            if (userRepository.GetUserbyEmail(newuser.user_email)!= null)
                throw new ApiException("Email Already Exist");

            User user = new User()
            {
                user_name = newuser.user_name,
                user_surname = newuser.user_surname,
                user_email = newuser.user_email,
                user_password = EncryptPassword(newuser.user_password),
                user_created = DateTime.Now,
                user_phone = newuser.user_phone,
                user_isActive = true,
                user_confirmationCode = GenerateConfirmationCode(),
                user_confirmed = false,

            };


            if (userRepository.CreateUser(user))
            {
                SendConfirmationEmail(user);
                return true;
            }
            else
                return false;
        }


        public User LoginAuthorization(string email, string password)
        {

            password = EncryptPassword(password);

            User user = userRepository.GetUserbyEmail(email);

            if (user == null)
                throw new ApiException("User Not Found!");


            if (user.user_password != password)
                throw new ApiException("Password Incorrect");
            else
                return user;

        }

        public User GetUserById(long id)
        {
            return userRepository.GetUserbyId(id);
        }



        public User GetUserByEmail(string email)
        {
            return userRepository.GetUserbyEmail(email);
        }


        public bool CompleteConfirmation(User user)
        {
            throw new NotImplementedException();
        }




        public bool SendConfirmationEmail(User user)
        {
            return true;
        }

        public bool CheckEmailValidation(string email)
        {
            // check for email pattern is correct


            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);


            return isEmail;

            /*
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }*/
        }

        private string EncryptPassword(string password)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = new SHA256CryptoServiceProvider().ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        private string GenerateConfirmationCode()
        {
            Guid id = Guid.NewGuid();

            return Guid.NewGuid().ToString();
        }

    
    }

}
