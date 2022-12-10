using DL3C_API.Infrastructure.Data.Interface;
using DL3C_API.Data.Source;

namespace DL3C_API.Data.Repository.Body
{
    public class BodyRepo : IBodyRepo
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IBaseRepository<Source.Body> _bodyRepository;

        public BodyRepo(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _bodyRepository = _dbContextFactory.GetContext<NhahatlonContext>().GetRepository<Source.Body>();
        }

        public IQueryable<Source.Body> GetBodies()
        {
            IQueryable<Source.Body> queryBody = _bodyRepository.GetAll();

            return queryBody;
        }
    }
}
