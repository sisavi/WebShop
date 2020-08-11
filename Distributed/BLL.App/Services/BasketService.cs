using System;
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
    public class BasketService : BaseEntityService<IAppUnitOfWork, IBasketRepository, IBasketServiceMapper,
        DAL.App.DTO.Basket, BLL.App.DTO.Basket>, IBasketService

    {
        public BasketService(IAppUnitOfWork uow) : base(uow, uow.Baskets, new BasketServiceMapper())
        {
        }
        public Basket GetByAppUserId(Guid userId)
        {
            return Mapper.Map(UOW.Baskets.GetByAppUserId(userId));
        }
 
        public async Task ClearBasket(Guid basketId)
        {
            foreach (var productInBasket in UOW.ProductInBasket.GetProductsForBasketAsync(basketId).Result)
            {
                await UOW.ProductInBasket.RemoveAsync(productInBasket.Id);
            }
 
            await UOW.SaveChangesAsync();
        }
        
    }
}