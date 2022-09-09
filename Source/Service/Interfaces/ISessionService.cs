using SMWebApi.Models;

namespace SMWebApi.Service.Interfaces
{
    public interface ISessionService
    {

        string CreateSession(string email, string password, string ipAddress);

        Session GetSessionByToken(string token);

        bool UpdateSession(string token, string ipAddress);

        bool DeleteSession(string token);

    }
}