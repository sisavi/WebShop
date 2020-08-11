using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.sisavi.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IProductInBasketRepository : IBaseRepository<ProductInBasket>, IProductInBasketRepositoryCustom
    {
        Task<IEnumerable<ProductInBasket>> GetProductsForBasketAsync(Guid basId, object? userId = null, bool noTracking = true);
        Task<IEnumerable<ProductInBasket>> GetProductsForOrderAsync(Guid orderId, object? userId = null, bool noTracking = true);
        ProductInBasket? ProductAlreadyInBasket(Guid basketId, Guid productId);
        ProductInBasket GetPibByAppUserId(Guid id);
    }
}