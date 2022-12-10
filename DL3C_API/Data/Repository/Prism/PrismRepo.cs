using DL3C_API.Infrastructure.Data.Interface;
using DL3C_API.Data.Source;

namespace DL3C_API.Data.Repository.Prism
{
    public class PrismRepo : IPrismRepo
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IBaseRepository<Source.Prism> _prismRepository;

        public PrismRepo(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _prismRepository = _dbContextFactory.GetContext<NhahatlonContext>().GetRepository<Source.Prism>();
        }

        public IQueryable<Source.Prism> GetPrisms()
        {
            IQueryable<Source.Prism> queryPrism = _prismRepository.GetAll();

            return queryPrism;
        }
    }
}
