namespace DL3C_API.Business.Face.Service
{
    public interface IFaceSvc
    {
        /// <summary>
        /// Get list of all Faces.
        /// </summary>
        /// <returns>List of Faces.</returns>
        IQueryable<Data.Source.Face> GetFaces();
    }
}
