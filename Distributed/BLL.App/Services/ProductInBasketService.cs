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
    public class ProductInBasketService : BaseEntityService<IAppUnitOfWork, IProductInBasketRepository, IProductInBasketServiceMapper,
        DAL.App.DTO.ProductInBasket, BLL.App.DTO.ProductInBasket>, IProductInBasketService

    {
        public ProductInBasketService(IAppUnitOfWork uow) : base(uow, uow.ProductInBasket, new ProductInBasketServiceMapper())
        {
        }
        
        public async Task<IEnumerable<ProductInBasket>> GetProductsForBasketAsync(Guid scId, object? userId = null, bool noTracking = true)
        {
            return (await Repository.GetProductsForBasketAsync(scId)).Select(e => Mapper.Map(e));
        }

        Task<IEnumerable<DAL.App.DTO.ProductInBasket>> IProductInBasketRepositoryCustom<ProductInBasket>.GetProductsForBasketAsync(Guid scId, object? userId, bool noTracking)
        {
            throw new NotImplementedException();
        }

        public DAL.App.DTO.ProductInBasket? ProductAlreadyInBasket(Guid shoppingCartId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<double> GetTotalCost(Guid scId)
        {
            return Repository.GetProductsForBasketAsync(scId).Result.Sum(a => a.TotalCost);
        }

        public async Task AddToShoppingCart(Guid id, Guid userId)
        {
            var basket = UOW.Baskets.GetByAppUserId(userId);
            var product = UOW.Products.FirstOrDefaultAsync(id).Result;
            
            // check if product already in cart
            var pil = UOW.ProductInBasket.ProductAlreadyInBasket(basket.Id, product.Id);

            if (pil == null)
            {
                var connection = new BLL.App.DTO.ProductInBasket()
                {
                    Id = Guid.NewGuid(),
                    ProductId = id,
                    Quantity = 1,
                    TotalCost = product.ProductPrice,
                    BasketId = basket.Id
                };
                
                UOW.ProductInBasket.Add(Mapper.Map(connection));
                await UOW.SaveChangesAsync();                
            }
            else
            {
                pil.Quantity++;
                pil.TotalCost = product.ProductPrice * pil.Quantity;
                await UOW.ProductInBasket.UpdateAsync(pil);
                await UOW.SaveChangesAsync();
            }

        }
        /*

        public async Task RemoveFromShoppingCart(Guid id, Guid userId)
        {
            var connection = UOW.ProductInBasket.GetPilByAppUserId(id);
            var basket = UOW.Baskets.GetByAppUserId(userId);

            if (basket.Id.Equals(connection.ShoppingCartId))
            {
                await UOW.ProductInBasket.RemoveAsync(id);
            }

        }
        */

        
    }
}