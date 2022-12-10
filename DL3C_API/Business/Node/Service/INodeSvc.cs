namespace DL3C_API.Business.Node.Service
{
    public interface INodeSvc
    {
        /// <summary>
        /// Get list of all Nodes.
        /// </summary>
        /// <returns>List of Nodes.</returns>
        IQueryable<Data.Source.Node> GetNodes();
    }
}
