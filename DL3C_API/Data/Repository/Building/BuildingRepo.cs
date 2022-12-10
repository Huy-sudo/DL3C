using DL3C_API.Infrastructure.Data.Interface;
using DL3C_API.Data.Source;

namespace DL3C_API.Data.Repository.Building
{
    public class BuildingRepo : IBuildingRepo
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IBaseRepository<Source.Building> _buildingRepository;

        public BuildingRepo(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _buildingRepository = _dbContextFactory.GetContext<NhahatlonContext>().GetRepository<Source.Building>();
        }

        public IQueryable<Source.Building> GetBuildings()
        {
            IQueryable<Source.Building> queryBuilding = _buildingRepository.GetAll();

            return queryBuilding;
        }
    }
}
