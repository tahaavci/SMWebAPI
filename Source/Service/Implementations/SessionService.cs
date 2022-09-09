using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Interfaces;
using System.Net;

namespace SMWebApi.Service.Implementations
{
    public class SessionService : ISessionService
    {
        private readonly IUserService userService;
        private readonly ISessionRepository sessionRepository;

        private const double session_expireinhour = 1;

        public SessionService(IUserService userService, ISessionRepository sessionRepository)
        {
            this.userService = userService;
            this.sessionRepository = sessionRepository;
        }

        public string CreateSession(string email, string password, string ipAddress)
        {

            var user = userService.LoginAuthorization(email, password);

            if (user != null)
            {

                string token = GenerateSessionToken();

                Session session = new Session()
                {
                    SessionToken = token,
                    ipAddress = ipAddress,
                    session_expiretime = DateTime.Now.AddHours(session_expireinhour),
                    sessionUser = user,

                };

                if (sessionRepository.CreateSession(session))
                    return token;
                else
                    return "";

            }
            else
                throw new ApiException("Session service failed to get user");

        }

        public Session GetSessionByToken(string token)
        {
            return sessionRepository.GetSession(token);
        }





        public bool UpdateSession(string token,string ipAddress)
        {

            Session session = sessionRepository.GetSession(token);

            if (session == null)
                throw new ApiException("Session Not Found.");

            if (session.session_expiretime.Subtract(DateTime.Now).Ticks > 0)
            {
                session.ipAddress = ipAddress;
                session.session_expiretime = DateTime.Now.AddHours(session_expireinhour);

                return true;
            }
            else
                throw new ApiException("Session Expired.");


        }


        public bool DeleteSession(string token)
        {


            sessionRepository.SessionDeleteByToken(token);



            return true;
        }



        private string GenerateSessionToken()
        {
            Guid id = Guid.NewGuid();

            return Guid.NewGuid().ToString();
        }

    }
}
