using DL3C_API.Infrastructure.Data.Interface;
using DL3C_API.Data.Source;

namespace DL3C_API.Data.Repository.Node
{
    public class NodeRepo : INodeRepo
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IBaseRepository<Source.Node> _nodeRepository;

        public NodeRepo(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _nodeRepository = _dbContextFactory.GetContext<NhahatlonContext>().GetRepository<Source.Node>();
        }

        public IQueryable<Source.Node> GetNodes()
        {
            IQueryable<Source.Node> queryNode = _nodeRepository.GetAll();

            return queryNode;
        }
    }
}
