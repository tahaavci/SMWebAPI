using SMWebApi.Dto;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Service.Implementations
{
    public class DebtService : IDebtService
    {
        private readonly IFlatService flatService;
        private readonly IBuildingService buildingService;
        private readonly ISettlementService settlementService;
        private readonly ISessionService sessionService;

        private readonly IDebtRepository _debtRepository;

        public DebtService(IFlatService flatService, IBuildingService buildingService, ISettlementService settlementService, ISessionService sessionService, IDebtRepository debtRepository)
        {
            this.flatService = flatService;
            this.buildingService = buildingService;
            this.settlementService = settlementService;
            this.sessionService = sessionService;
            _debtRepository = debtRepository;
        }

        public bool CreateDept(DeptDto deptDto)
        {

            Session session = sessionService.GetSessionByToken(deptDto.manager_token);
            if (session == null)
                throw new ApiException("Session Expired!");


            Flat flat = flatService.GetFlatById(deptDto.flat_id);
            if (flat == null)
                throw new ApiException("Flat Not Found!");


            Building building = buildingService.GetBuildingById(flat.build_id);
            if (building == null)
                throw new ApiException("Related Building Not Found!");


            Settlement settlement = settlementService.GetSettlementById(building.settle_id);
            if (settlement == null)
                throw new ApiException("Related Settlement Not Found!");



            // To create debt for flat, user need to be admin for related settlement
            if (settlement.user_id == session.user_id)
            {

                Debt d = new Debt()
                {
                    debt_amount = deptDto.dept_amount,
                    debt_duedate = deptDto.dept_duedate,
                    debt_iscompleted = false,
                    debt_type = deptDto.dept_type,

                    debtFlatId = null,

                };


                if (!_debtRepository.CreateDebt(d))
                    throw new ApiException("An Error Occured!");




                return true;
            }
            else
                throw new ApiException("You are not authorized!");
        }




        public bool PayDebt(long debt_id)
        {
            Debt debt = _debtRepository.GetDebt(debt_id);

            if (debt == null)
                throw new ApiException("Debt Not Found!");

            debt.debt_iscompleted=true;
            
            if(_debtRepository.PayDebt(debt))
                return true;



                throw new ApiException("An Error Occured!");    
        }
    }
}
