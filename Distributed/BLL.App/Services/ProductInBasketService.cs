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
        public ProductInBasketService(IAppUnitOfWork uow) : base(uow, uow.ProductsInBaskets, new ProductInBasketServiceMapper())
        {
        }
        
        
    }
}