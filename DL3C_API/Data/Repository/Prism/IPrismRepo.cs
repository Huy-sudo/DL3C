namespace DL3C_API.Data.Repository.Prism
{
    public interface IPrismRepo
    {
        /// <summary>
        /// Get all prisms.
        /// </summary>
        /// <returns>A list of prisms.</returns>
        IQueryable<Source.Prism> GetPrisms();
    }
}
