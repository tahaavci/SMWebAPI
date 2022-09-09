using SMWebApi.Dto;
using SMWebApi.Models;

namespace SMWebApi.Service.Interfaces
{
    public interface IBuildingService
    {

        bool CreateBuilding(BuildingDto buildingDto);

        ICollection<GetBuildingDto> GetBuildings();

        Building GetBuildingById(long id);

        ICollection<GetBuildingDto> GetBuildingsBySettle(string email);

    }
}
