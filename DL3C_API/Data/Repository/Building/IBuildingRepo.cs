namespace DL3C_API.Data.Repository.Building
{
    public interface IBuildingRepo
    {
        /// <summary>
        /// Get all buildings.
        /// </summary>
        /// <returns>A list of buildings.</returns>
        IQueryable<Source.Building> GetBuildings();
    }
}
