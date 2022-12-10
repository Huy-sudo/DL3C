namespace DL3C_API.Business.Body.Service
{
    public interface IBodySvc
    {
        /// <summary>
        /// Get list of all Bodies.
        /// </summary>
        /// <returns>List of Bodies.</returns>
        IQueryable<Data.Source.Body> GetBodies();
    }
}
