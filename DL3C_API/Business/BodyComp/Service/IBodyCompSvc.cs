namespace DL3C_API.Business.BodyComp.Service
{
    public interface IBodyCompSvc
    {
        /// <summary>
        /// Get list of all BodyComps.
        /// </summary>
        /// <returns>List of BodyComps.</returns>
        IQueryable<Data.Source.BodyComp> GetBodyComps();
    }
}
