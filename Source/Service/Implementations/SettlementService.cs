using SMWebApi.Dto;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Service.Implementations
{
    public class SettlementService : ISettlementService
    {
        private readonly ISettlementRepository settlementRepository;
        private readonly IUserService userService;

        public SettlementService(ISettlementRepository settlementRepository, IUserService userService)
        {
            this.settlementRepository = settlementRepository;
            this.userService = userService;
        }

        public bool CreateSettlement(SettlementDto settle)
        {
            var manager = userService.GetUserByEmail(settle.settleManagerEmail);


            if (!userService.CheckEmailValidation(settle.settle_email))
                throw new ApiException("Email is not valid.");


            if (manager == null)
                throw new ApiException("Manager Not Found In User");


            if(settlementRepository.GetSettlementByEmail(settle.settle_email)!=null)
                throw new ApiException("Settlement Already Exist");
            

            Settlement model = new Settlement()
            {
                settle_name = settle.settle_name,
                settle_city = settle.settle_city,
                settle_phone = settle.settle_phone,
                settle_bankIban = settle.settle_bankIban,
                settle_bankName = settle.settle_bankName,
                settle_email = settle.settle_email,
                settle_province = settle.settle_province,
                settle_date = DateTime.Now,
                settleManager = manager,
            };

            settlementRepository.CreateSettle(model);



            return true;
        }

        public Settlement GetSettlementByEmail(string email)
        {
            return settlementRepository.GetSettlementByEmail(email);
        }

        public Settlement GetSettlementById(long id)
        {
            return settlementRepository.GetSettlementById(id);
        }
    }
}
