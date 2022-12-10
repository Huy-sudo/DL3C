using AutoMapper;
using DL3C_API.Data.Repository.Building;
using DL3C_API.Infrastructure.Utility.ErrorHandling.Object;

namespace DL3C_API.Business.Building.Service
{
    public class BuildingSvc: IBuildingSvc
    {
        private readonly IBuildingRepo _buildingRepo;

        public BuildingSvc(IBuildingRepo buildingRepo)
        {
            _buildingRepo = buildingRepo;
        }

        public IQueryable<Data.Source.Building> GetBuildings()
        {
            IQueryable<Data.Source.Building> queryBuilding = this._buildingRepo.GetBuildings();

            if (queryBuilding == null)
            {
                throw new CException(StatusCodes.Status400BadRequest, "Empty building!");
            }

            return queryBuilding;
        }
    }
}
