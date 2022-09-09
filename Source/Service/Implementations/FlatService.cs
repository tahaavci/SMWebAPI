using SMWebApi.Dto;
using SMWebApi.Exceptions;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;
using SMWebApi.Service.Interfaces;

namespace SMWebApi.Service.Implementations
{
    public class FlatService : IFlatService
    {
        private readonly IBuildingService _buildingService;
        private readonly IFlatRepository flatRepository;

        public FlatService(IBuildingService buildingService, IFlatRepository flatRepository)
        {
            _buildingService = buildingService;
            this.flatRepository = flatRepository;
        }

        public bool CreateFlat(FlatDto flatDto)
        {

            var building = _buildingService.GetBuildingById(flatDto.build_id);

            if (building == null)
                throw new ApiException("Building Not Found!");


            Flat flat = new Flat()
            {
                flat_number = flatDto.flat_number,
                flat_desc = flatDto.flat_desc,
                flatBuildId = building

            };

            return flatRepository.CreateFLat(flat);
        }


        public Flat GetFlatById(long id)
        {

            return flatRepository.GetFlatById(id);


        }


    }




}
