using AutoMapper;
using DL3C_API.Data.Repository.Node;
using DL3C_API.Infrastructure.Utility.ErrorHandling.Object;

namespace DL3C_API.Business.Node.Service
{
    public class NodeSvc: INodeSvc
    {
        private readonly INodeRepo _nodeRepo;

        public NodeSvc(INodeRepo nodeRepo)
        {
            _nodeRepo = nodeRepo;
        }

        public IQueryable<Data.Source.Node> GetNodes()
        {
            IQueryable<Data.Source.Node> queryNode = this._nodeRepo.GetNodes();

            if (queryNode == null)
            {
                throw new CException(StatusCodes.Status400BadRequest, "Empty node!");
            }

            return queryNode;
        }
    }
}
