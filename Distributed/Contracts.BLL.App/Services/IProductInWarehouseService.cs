using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IProductInWarehouseService : IBaseEntityService<ProductInWarehouse>, IProductInWarehouseRepositoryCustom<ProductInWarehouse>
    {
        Task<IEnumerable<ProductInWarehouse>> GetProductsInWarehouse(Guid id);

    }
}