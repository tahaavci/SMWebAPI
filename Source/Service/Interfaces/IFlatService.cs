using SMWebApi.Dto;
using SMWebApi.Models;

namespace SMWebApi.Service.Interfaces
{
    public interface IFlatService
    {
        bool CreateFlat(FlatDto flatDto);

        Flat GetFlatById(long id); 

    }
}
