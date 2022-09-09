using SMWebApi.Dto;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Service.Implementations
{
    public class FlatUserService : IFlatUserService
    {
        private IUserService userService;
        private IFlatService flatService;
        private IFlatUserRepository _flatuserRepository;


        public bool CreateRelation(FlatUserDto flatUserDto)
        {
            
            var user = userService.GetUserById(flatUserDto.user_id);

            var flat = flatService.GetFlatById(flatUserDto.flat_id);

            if (user == null)
                throw new ApiException("User Not Found!");


            if (flat == null)
                throw new ApiException("Flat Not Found!");

            FlatUser obj = new FlatUser()
            {
                flat_id = flatUserDto.flat_id,
                user_id = flatUserDto.user_id,
                isOwner = flatUserDto.isOwner
            };

            if (_flatuserRepository.SubmitRelation(obj))
                return true;
            else
                throw new ApiException("An Error Occured");

        }

        public bool DeleteRelation(FlatUserDto flatUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
