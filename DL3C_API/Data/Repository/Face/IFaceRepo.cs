namespace DL3C_API.Data.Repository.Face
{
    public interface IFaceRepo
    {
        /// <summary>
        /// Get all faces.
        /// </summary>
        /// <returns>A list of faces.</returns>
        IQueryable<Source.Face> GetFaces();
    }
}
