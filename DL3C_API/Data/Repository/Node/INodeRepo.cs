namespace DL3C_API.Data.Repository.Node
{
    public interface INodeRepo
    {
        /// <summary>
        /// Get all nodes.
        /// </summary>
        /// <returns>A list of nodes.</returns>
        IQueryable<Source.Node> GetNodes();
    }
}
