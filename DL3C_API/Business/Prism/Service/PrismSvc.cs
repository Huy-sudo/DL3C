using AutoMapper;
using DL3C_API.Data.Repository.Prism;
using DL3C_API.Infrastructure.Utility.ErrorHandling.Object;

namespace DL3C_API.Business.Prism.Service
{
    public class PrismSvc: IPrismSvc
    {
        private readonly IPrismRepo _prismRepo;

        public PrismSvc(IPrismRepo prismRepo)
        {
            _prismRepo = prismRepo;
        }

        public IQueryable<Data.Source.Prism> GetPrisms()
        {
            IQueryable<Data.Source.Prism> queryPrism = this._prismRepo.GetPrisms();

            if (queryPrism == null)
            {
                throw new CException(StatusCodes.Status400BadRequest, "Empty prism!");
            }

            return queryPrism;
        }
    }
}
