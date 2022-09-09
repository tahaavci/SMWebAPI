using SMWebApi.Context;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;

namespace SMWebApi.Repository.Implementation
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext dataContext;

        public RequestRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool SubmitRequest(Request request)
        {

            dataContext.Requests.Add(request);

            if (dataContext.SaveChanges() > 0)
                return true;


            return false;
        }

    }
}
