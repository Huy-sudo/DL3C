using AutoMapper;
using DL3C_API.Data.Repository.Body;
using DL3C_API.Infrastructure.Utility.ErrorHandling.Object;

namespace DL3C_API.Business.Body.Service
{
    public class BodySvc: IBodySvc
    {
        private readonly IBodyRepo _bodyRepo;

        public BodySvc(IBodyRepo bodyRepo)
        {
            _bodyRepo = bodyRepo;
        }

        public IQueryable<Data.Source.Body> GetBodies()
        {
            IQueryable<Data.Source.Body> queryBody = this._bodyRepo.GetBodies();

            if (queryBody == null)
            {
                throw new CException(StatusCodes.Status400BadRequest, "Empty body!");
            }

            return queryBody;
        }
    }
}
