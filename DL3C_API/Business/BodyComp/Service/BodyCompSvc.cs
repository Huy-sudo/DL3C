using AutoMapper;
using DL3C_API.Data.Repository.BodyComp;
using DL3C_API.Infrastructure.Utility.ErrorHandling.Object;

namespace DL3C_API.Business.BodyComp.Service
{
    public class BodyCompSvc: IBodyCompSvc
    {
        private readonly IBodyCompRepo _bodyCompRepo;

        public BodyCompSvc(IBodyCompRepo bodyCompRepo)
        {
            _bodyCompRepo = bodyCompRepo;
        }

        public IQueryable<Data.Source.BodyComp> GetBodyComps()
        {
            IQueryable<Data.Source.BodyComp> queryBodyComp = this._bodyCompRepo.GetBodyComps();

            if (queryBodyComp == null)
            {
                throw new CException(StatusCodes.Status400BadRequest, "Empty body comp!");
            }

            return queryBodyComp;
        }
    }
}
