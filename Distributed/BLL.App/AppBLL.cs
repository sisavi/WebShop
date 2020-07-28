using BLL.App.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.sisavi.BLL.Base;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        public AppBLL(IAppUnitOfWork uow) : base(uow)
        {
        }

        public ICampaignService Campaigns => GetService<ICampaignService>(() => new CampaignService(UOW));
        public ICategoryService Categories => GetService<ICategoryService>(() => new CategoryService(UOW));
        public ICommentService Comments  => GetService<ICommentService>(() => new CommentService(UOW));
        public IOrderService Orders => GetService<IOrderService>(() => new OrderService(UOW));
        public IPaymentService Payments => GetService<IPaymentService>(() => new PaymentService(UOW));
        public IPictureService Pictures => GetService<IPictureService>(() => new PictureService(UOW));
        public IProductInBasketService ProductsInBaskets  => GetService<IProductInBasketService>(() => new ProductInBasketService(UOW));
        public IProductInWarehouseService ProductsInWarehouse => GetService<IProductInWarehouseService>(() => new ProductInWarehouseService(UOW));
        public IProductService Products => GetService<IProductService>(() => new ProductService(UOW));
        public IWarehouseService Warehouses => GetService<IWarehouseService>(() => new WarehouseService(UOW));
        
        public ILangStrService LangStrs => GetService<ILangStrService>(() => new LangStrService(UOW));

        public ILangStrTranslationService LangStrTranslation => GetService<ILangStrTranslationService>(() => new LangStrTranslationService(UOW));
    }
}