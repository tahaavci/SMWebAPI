using SMWebApi.Context;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;

namespace SMWebApi.Repository.Implementation
{
    public class SettlementRepository : ISettlementRepository
    {
        private readonly DataContext dataContext;

        public SettlementRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public bool CreateSettle(Settlement settlement)
        {
            dataContext.Settlements.Add(settlement);
            if (dataContext.SaveChanges() > 0)
                return true;
            else
                throw new ApiException("Failed to Create Settlement");
            
        }



        public Settlement GetSettlementByEmail(string email)
        {
           return dataContext.Settlements.FirstOrDefault(s => s.settle_email == email);
        }

        public Settlement GetSettlementById(long id)
        {
            return dataContext.Settlements.FirstOrDefault(s => s.settle_id == id);
        }
    }
}
