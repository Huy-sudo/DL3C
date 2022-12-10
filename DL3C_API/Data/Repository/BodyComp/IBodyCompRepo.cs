namespace DL3C_API.Data.Repository.BodyComp
{
    public interface IBodyCompRepo
    {
        /// <summary>
        /// Get all body comp.
        /// </summary>
        /// <returns>A list of body comp.</returns>
        IQueryable<Source.BodyComp> GetBodyComps();
    }
}
