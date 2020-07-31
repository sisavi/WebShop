using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IProductInBasketService : IBaseEntityService<ProductInBasket>, IProductInBasketRepositoryCustom<ProductInBasket>
    {
        public Task<IEnumerable<ProductInBasket>> GetProductsForBasketAsync(Guid scId, object? userId = null, bool noTracking = true);
        Task<double> GetTotalCost(Guid scId);
        Task AddToShoppingCart(Guid id, Guid userId);
        

    }
}