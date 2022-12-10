using AutoMapper;
using DL3C_API.Data.Repository.Face;
using DL3C_API.Infrastructure.Utility.ErrorHandling.Object;

namespace DL3C_API.Business.Face.Service
{
    public class FaceSvc: IFaceSvc
    {
        private readonly IFaceRepo _faceRepo;

        public FaceSvc(IFaceRepo faceRepo)
        {
            _faceRepo = faceRepo;
        }

        public IQueryable<Data.Source.Face> GetFaces()
        {
            IQueryable<Data.Source.Face> queryFace = this._faceRepo.GetFaces();

            if (queryFace == null)
            {
                throw new CException(StatusCodes.Status400BadRequest, "Empty face!");
            }

            return queryFace;
        }
    }
}
