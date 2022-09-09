using Microsoft.EntityFrameworkCore;
using SMWebApi.Context;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;

namespace SMWebApi.Repository.Implementation
{
    public class BuildingRepository : IBuildingRepository
    {

        private readonly DataContext dataContext;

        public BuildingRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public bool AddBuilding(Building building)
        {
            dataContext.Buildings.Add(building);
            if (dataContext.SaveChanges() > 0)
                return true;
            else
                throw new ApiException("Failed to Create Building"); 
        }

       

        public ICollection<Building> GetBuildingsWithUserAndSettle()
        {

            return dataContext.Buildings.Include(s => s.buildSettle).Include(u => u.buildManager).ToList();
        }

       
        public ICollection<Building> GetBuildingsBySettleEmailEager(string email)
        {
            return dataContext.Buildings.Include(s => s.buildSettle)
                                        .Include(u => u.buildManager)
                                        .Where( b => b.buildSettle.settle_email == email)
                                        .ToList();
        }

        public Building GetBuildingById(long id)
        {

            return dataContext.Buildings.Where(b => b.build_id == id).FirstOrDefault();
        }
    }
}
