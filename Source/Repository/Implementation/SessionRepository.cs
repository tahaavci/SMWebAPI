using SMWebApi.Context;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;

namespace SMWebApi.Repository.Implementation
{
    public class SessionRepository : ISessionRepository
    {
        private readonly DataContext dataContext;

        public SessionRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool CreateSession(Session session)
        {
            

            try
            {
                dataContext.Sessions.Add(session);
                var status = dataContext.SaveChanges();

                if (status > 0)
                    return true;
                else
                    throw new ApiException("Failed to create new session");
            }
            catch
            {
                throw new ApiException("Something went wrong");
            }

        }

        public Session GetSession(string token)
        {
            return dataContext.Sessions.Where(s => s.SessionToken == token).FirstOrDefault();
        }

        public bool SessionDeleteByToken(string token)
        {
            Session session = dataContext.Sessions.Where(s => s.SessionToken == token).FirstOrDefault();

            if (session == null)
                throw new ApiException("Session Not Found");
            else
            {
                dataContext.Sessions.Remove(session);


                if (dataContext.SaveChanges() > 0)
                    return true;

                else
                    throw new ApiException("Failed to Delete Session");


            }
        }



        public bool UpdateSession(Session session)
        {
            dataContext.Update(session);

            if(dataContext.SaveChanges()>0)
                return true;
            else
                return false;
        }








         



    }
}
