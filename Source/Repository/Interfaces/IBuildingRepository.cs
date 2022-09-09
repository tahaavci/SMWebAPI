using SMWebApi.Models;

namespace SMWebApi.Repository.Interfaces
{
    public interface IBuildingRepository
    {

        bool AddBuilding(Building building);

        ICollection<Building> GetBuildingsBySettleEmailEager(string email);

        ICollection<Building> GetBuildingsWithUserAndSettle();

        Building GetBuildingById(long id);

    }
}
