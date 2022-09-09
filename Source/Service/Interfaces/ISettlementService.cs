using SMWebApi.Dto;
using SMWebApi.Models;

namespace SMWebApi.Service.Interfaces
{
    public interface ISettlementService
    {

        bool CreateSettlement(SettlementDto settleDto);

        Settlement GetSettlementByEmail(string email);

        Settlement GetSettlementById(long id);

    }
}
