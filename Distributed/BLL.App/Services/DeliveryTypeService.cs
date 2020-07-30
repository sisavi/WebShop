using BLL.App.Mappers;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.sisavi.BLL.Base.Services;

namespace BLL.App.Services
{
    public class DeliveryTypeService : BaseEntityService<IAppUnitOfWork, IDeliveryTypeRepository,IDeliveryTypeServiceMapper, DAL.App.DTO.DeliveryType, BLL.App.DTO.DeliveryType>, IDeliveryTypeService
    {
        public DeliveryTypeService(IAppUnitOfWork uow) : base(uow, uow.DeliveryTypes, new DeliveryTypeServiceMapper())
        {
        }
        
    }
}