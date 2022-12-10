using DL3C_API.Infrastructure.Data.Interface;
using DL3C_API.Data.Source;

namespace DL3C_API.Data.Repository.BodyComp
{
    public class BodyCompRepo : IBodyCompRepo
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IBaseRepository<Source.BodyComp> _bodyCompRepository;

        public BodyCompRepo(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _bodyCompRepository = _dbContextFactory.GetContext<NhahatlonContext>().GetRepository<Source.BodyComp>();
        }

        public IQueryable<Source.BodyComp> GetBodyComps()
        {
            IQueryable<Source.BodyComp> queryBodyComp = _bodyCompRepository.GetAll();

            return queryBodyComp;
        }
    }
}
