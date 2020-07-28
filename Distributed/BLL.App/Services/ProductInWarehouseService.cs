using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class ProductInWarehouseService : BaseEntityService<IAppUnitOfWork, IProductInWarehouseRepository, IProductInWarehouseServiceMapper,
        DAL.App.DTO.ProductInWarehouse, BLL.App.DTO.ProductInWarehouse>, IProductInWarehouseService

    {
        public ProductInWarehouseService(IAppUnitOfWork uow) : base(uow, uow.ProductsInWarehouse, new ProductInWarehouseServiceMapper())
        {
        }
    }
}