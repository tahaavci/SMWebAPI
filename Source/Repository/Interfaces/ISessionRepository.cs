using SMWebApi.Models;

namespace SMWebApi.Repository.Interfaces
{
    public interface ISessionRepository
    {
        bool CreateSession(Session session);

        bool UpdateSession(Session session);

        Session GetSession(string token);

        bool SessionDeleteByToken(string token);



    }
}
