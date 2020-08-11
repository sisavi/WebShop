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
            var productsInList = await Repository.GetProductsForBasketAsync(scId);
            var priceFix = new List<DAL.App.DTO.ProductInBasket>();
            foreach (var pil in productsInList)
            {
                if (pil != null)
                {
                    var fixing= await ApplyDiscount(pil.Product);
                    pil.Product = fixing;
                    priceFix.Add(pil);
                }

            }
            
            
            return priceFix.Select(e => Mapper.Map(e));
        }
        
        public async Task<DAL.App.DTO.Product> ApplyDiscount(DAL.App.DTO.Product product)
        {
            DAL.App.DTO.Campaign? campaign = null;
            if (product.CampaignId != null)
            {
                campaign = await UOW.Campaigns.FirstOrDefaultAsync((Guid)product.CampaignId);
            }

            if (campaign == null)
            {
                return (product);
            }
            
            Math.Round((product.ProductPrice *= ((100 - campaign.Discount) / 100)), 2);
            
            return product;
        }
        
        public async Task<IEnumerable<ProductInBasket>> GetProductsForOrderAsync(Guid orderId)
        {
            return (await Repository.GetProductsForOrderAsync(orderId)).Select(e => Mapper.Map(e));
        }
        
        public async Task AddToBasketApi(Guid productId, Guid basketId, int quantity = 1)
        {
            var product = UOW.Products.FirstOrDefaultAsync(productId).Result;
            
            // check if product already in cart
            var pil = UOW.ProductInBasket.ProductAlreadyInBasket(basketId, productId);

            if (pil == null)
            {
                var connection = new ProductInBasket()
                {
                    Id = Guid.NewGuid(),
                    ProductId = productId,
                    Quantity = quantity,
                    TotalCost = product.ProductPrice,
                    BasketId = basketId
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
        
        public async Task DecreaseQuantity(ProductInBasket pil)
        {
            var dalPil = await UOW.ProductInBasket.FirstOrDefaultAsync(pil.Id);
            var productPrice = dalPil.TotalCost / dalPil.Quantity;
            dalPil.TotalCost = Math.Round(dalPil.TotalCost - productPrice,  2, MidpointRounding.ToEven);
            dalPil.Quantity--;
            await UOW.ProductInBasket.UpdateAsync(dalPil);

        }
        
        

        public async Task<double> GetTotalCost(Guid scId)
        {
            var productsInList = await Repository.GetProductsForBasketAsync(scId);
            var priceFix = new List<DAL.App.DTO.ProductInBasket>();
            foreach (var pil in productsInList)
            {
                if (pil != null)
                {
                    var fixing= await ApplyDiscount(pil.Product);
                    pil.Product = fixing;
                    priceFix.Add(pil);
                }

            }
            
            
            return Math.Round(priceFix.Sum(a =>a.TotalCost), 2);
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
        
        public async Task RemoveFromShoppingCart(Guid id, Guid userId)
        {
            var connection = UOW.ProductInBasket.GetPibByAppUserId(id);
            var basket = UOW.Baskets.GetByAppUserId(userId);

            if (basket.Id.Equals(connection.Id))
            {
                await UOW.ProductInBasket.RemoveAsync(id);
            }

        }
        

        
    }
}