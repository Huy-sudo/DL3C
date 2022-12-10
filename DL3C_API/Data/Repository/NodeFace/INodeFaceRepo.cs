namespace DL3C_API.Data.Repository.Node
{
    public interface INodeFaceRepo
    {
        /// <summary>
        /// Get all nodeFaces.
        /// </summary>
        /// <returns>A list of nodeFaces.</returns>
        IQueryable<Source.NodeFace> GetNodeFaces();
    }
}
