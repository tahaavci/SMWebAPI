using SMWebApi.Models;

namespace SMWebApi.Repository.Interfaces
{
    public interface ISettlementRepository
    {

        bool CreateSettle(Settlement settlement);

        Settlement GetSettlementByEmail(string email);
        Settlement GetSettlementById(long id);

    }
}
