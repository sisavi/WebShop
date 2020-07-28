using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class PictureService : BaseEntityService<IAppUnitOfWork, IPictureRepository, IPictureServiceMapper,
        DAL.App.DTO.Picture, BLL.App.DTO.Picture>, IPictureService

    {
        public PictureService(IAppUnitOfWork uow) : base(uow, uow.Pictures, new PictureServiceMapper())
        {
        }
    }
}