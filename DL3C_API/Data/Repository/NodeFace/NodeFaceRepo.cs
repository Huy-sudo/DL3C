using DL3C_API.Infrastructure.Data.Interface;
using DL3C_API.Data.Source;

namespace DL3C_API.Data.Repository.NodeFace
{
    public class NodeFaceRepo : INodeFaceRepo
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IBaseRepository<Source.NodeFace> _nodeFaceRepository;

        public NodeFaceRepo(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _nodeFaceRepository = _dbContextFactory.GetContext<NhahatlonContext>().GetRepository<Source.NodeFace>();
        }

        public IQueryable<Source.NodeFace> GetNodeFaces()
        {
            IQueryable<Source.NodeFace> queryNodeFace = _nodeFaceRepository.GetAll();

            return queryNodeFace;
        }
    }
}
