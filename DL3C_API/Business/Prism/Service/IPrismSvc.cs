namespace DL3C_API.Business.Prism.Service
{
    public interface IPrismSvc
    {
        /// <summary>
        /// Get list of all Prisms.
        /// </summary>
        /// <returns>List of Prisms.</returns>
        IQueryable<Data.Source.Prism> GetPrisms();
    }
}
