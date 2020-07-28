using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class WarehouseService : BaseEntityService<IAppUnitOfWork, IWarehouseRepository, IWarehouseServiceMapper,
        DAL.App.DTO.Warehouse, BLL.App.DTO.Warehouse>, IWarehouseService

    {
        public WarehouseService(IAppUnitOfWork uow) : base(uow, uow.Warehouses, new WarehouseServiceMapper())
        {
        }
    }
}