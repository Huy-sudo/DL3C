using DL3C_API.Infrastructure.Data.Interface;
using DL3C_API.Data.Source;

namespace DL3C_API.Data.Repository.Face
{
    public class FaceRepo : IFaceRepo
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IBaseRepository<Source.Face> _faceRepository;

        public FaceRepo(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _faceRepository = _dbContextFactory.GetContext<NhahatlonContext>().GetRepository<Source.Face>();
        }

        public IQueryable<Source.Face> GetFaces()
        {
            IQueryable<Source.Face> queryFace = _faceRepository.GetAll();

            return queryFace;
        }
    }
}
