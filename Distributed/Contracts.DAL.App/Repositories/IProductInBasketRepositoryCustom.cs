using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IProductInBasketRepositoryCustom: IProductInBasketRepositoryCustom<ProductInBasket>
    {
        
    }
    public interface IProductInBasketRepositoryCustom<TProductInBasket>
    {
        Task<IEnumerable<ProductInBasket>> GetProductsForBasketAsync(Guid scId, object? userId = null, bool noTracking = true);
        ProductInBasket? ProductAlreadyInBasket(Guid shoppingCartId, Guid productId);
        
    }
}