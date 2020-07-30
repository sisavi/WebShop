using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class ProductInBasketService : BaseEntityService<IAppUnitOfWork, IProductInBasketRepository, IProductInBasketServiceMapper,
        DAL.App.DTO.Basket, BLL.App.DTO.Basket>, IProductInBasketService

    {
        public ProductInBasketService(IAppUnitOfWork uow) : base(uow, uow.ProductsInBaskets, new ProductInBasketServiceMapper())
        {
        }
        
        
    }
}