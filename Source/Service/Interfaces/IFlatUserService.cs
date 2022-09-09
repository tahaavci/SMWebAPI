using SMWebApi.Dto;

namespace SMWebApi.Service.Interfaces
{
    public interface IFlatUserService
    {

        bool CreateRelation(FlatUserDto flatUserDto);

        bool DeleteRelation(FlatUserDto flatUserDto);


    }
}
