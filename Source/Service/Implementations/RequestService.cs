using SMWebApi.Dto;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Service.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly IUserService userService;
        private readonly ISettlementService settlementService;
        private readonly IRequestRepository _requestRepository;

        public RequestService(IUserService userService, ISettlementService settlementService, IRequestRepository requestRepository)
        {
            this.userService = userService;
            this.settlementService = settlementService;
            _requestRepository = requestRepository;
        }

        public bool CreateRequest(RequestDto requestDto)
        {
            User user = userService.GetUserById(requestDto.user_id);

            if (user == null)
                throw new ApiException("User Not Found!");

            Settlement settlement = settlementService.GetSettlementById(requestDto.settle_id);
            if (settlement == null)
                throw new ApiException("Settlement Not Found!");

            Request debt = new Request()
            {
                req_title = requestDto.req_title,   
                req_desc = requestDto.req_desc,
                req_date = DateTime.Now,
                req_srcUser = user,
                req_dstSettle = settlement,
                req_isCompleted = false,
                
            };



            bool status = _requestRepository.SubmitRequest(debt);

            if (!status)
                throw new ApiException("An Error Occured!");



            return true;
        }
    }
}
