using SMWebApi.Dto;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Service.Implementations
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository buildingRepository; 
        private readonly ISettlementService settlementService;
        private readonly IUserService userService;

        public BuildingService(IBuildingRepository buildingRepository, ISettlementService settlementService, IUserService userService)
        {
            this.buildingRepository = buildingRepository;
            this.settlementService = settlementService;
            this.userService = userService;
        }

        public bool CreateBuilding(BuildingDto buildingDto)
        {
            User manager = null;

            var settle = settlementService.GetSettlementByEmail(buildingDto.build_settleEmail);
            if (settle == null)
                throw new ApiException("Settlement Not Found!");


            // manager is nullable
            if(buildingDto.build_managerEmail != null)
            {
                manager = userService.GetUserByEmail(buildingDto.build_managerEmail);

                if (manager == null)
                    throw new ApiException("Manager User not found!");

            }




            Building building = new Building()
            {
                build_name=buildingDto.build_name,
                build_date=DateTime.Now,
                buildSettle= settle,
                buildManager = manager,
                
            };



            return buildingRepository.AddBuilding(building);
        }

        public Building GetBuildingById(long id)
        {
            Building b = buildingRepository.GetBuildingById(id);

            return b;
        }

        public ICollection<GetBuildingDto> GetBuildings()
        {
            ICollection<GetBuildingDto> getBuildingDtos = new List<GetBuildingDto>();

            var buildings = buildingRepository.GetBuildingsWithUserAndSettle();


            foreach (var item in buildings)
            {
                GetBuildingDto dto = new GetBuildingDto()
                {
                    build_id = item.build_id,
                    build_name = item.build_name,


                    buildSettle = item.buildSettle.settle_name,
                    buildManager = item.buildManager?.user_name
                };

                getBuildingDtos.Add(dto);
            }

            return getBuildingDtos;
        }


        public ICollection<GetBuildingDto> GetBuildingsBySettle(string email)
        {

            ICollection<Building> buildings =  buildingRepository.GetBuildingsBySettleEmailEager(email);

            ICollection<GetBuildingDto> getBuildingDtos = new List<GetBuildingDto>();

            foreach (var item in buildings)
            {
                GetBuildingDto dto = new GetBuildingDto()
                {
                    build_id = item.build_id,
                    build_name = item.build_name,


                    buildSettle = item.buildSettle.settle_name,
                    buildManager = item.buildManager?.user_name

                };
                getBuildingDtos.Add(dto);

            }


            return getBuildingDtos;
        }

    }
}
