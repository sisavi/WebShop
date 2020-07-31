using System;
using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain.App;
using Basket = DAL.App.DTO.Basket;

namespace BLL.App.Services
{
    public class BasketService : BaseEntityService<IAppUnitOfWork, IBasketRepository, IBasketServiceMapper,
        DAL.App.DTO.Basket, BLL.App.DTO.Basket>, IBasketService

    {
        public BasketService(IAppUnitOfWork uow) : base(uow, uow.Baskets, new BasketServiceMapper())
        {
        }
        /*
        public async Task<Basket> AddProduct(Guid basketId, Product product)
        {
            var basket = await UOW.ProductsInBaskets.AddProduct(basketId, product);

            return basket;
        }
        */
        
    }
}