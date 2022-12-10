namespace DL3C_API.Business.Building.Service
{
    public interface IBuildingSvc
    {
        /// <summary>
        /// Get list of all Buildings.
        /// </summary>
        /// <returns>List of Buildings.</returns>
        IQueryable<Data.Source.Building> GetBuildings();
    }
}
