using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
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
        
        public async Task<IEnumerable<ProductInWarehouse>> GetProductsInWarehouse(Guid id)
        {
            var products = await UOW.ProductsInWarehouse.GetAllAsync();
            
            var warehouseProducts = new List<DAL.App.DTO.ProductInWarehouse>();

            foreach (var product in products)
            {
                if (product.WarehouseId.Equals(id))
                {
                    warehouseProducts.Add(product);
                }
            }
            var productsInWarehouse = warehouseProducts.Select(e => Mapper.Map(e)); 

            return productsInWarehouse;
        }
    }
}