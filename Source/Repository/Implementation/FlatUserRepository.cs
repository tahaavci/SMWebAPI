using SMWebApi.Context;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;

namespace SMWebApi.Repository.Implementation
{
    public class FlatUserRepository : IFlatUserRepository
    {
        private readonly DataContext dataContext;

        public FlatUserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool SubmitRelation(FlatUser model)
        {

            dataContext.FlatUsers.Add(model);
            if(dataContext.SaveChanges()>0)
                return true;
            

            return false;
        }
    }
}
