namespace DL3C_API.Data.Repository.Body
{
    public interface IBodyRepo
    {
        /// <summary>
        /// Get all bodies.
        /// </summary>
        /// <returns>A list of bodies.</returns>
        IQueryable<Source.Body> GetBodies();
    }
}
