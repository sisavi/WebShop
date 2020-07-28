using System;
using Contracts.BLL.App.Services;
using ee.itcollege.sisavi.Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        ICampaignService Campaigns { get; }
        ICategoryService Categories { get; }
        ICommentService Comments { get; }
        IOrderService Orders { get; }
        IPaymentService Payments { get; }
        IPictureService Pictures { get; }
        IProductInBasketService ProductsInBaskets { get; }
        IProductInWarehouseService ProductsInWarehouse { get; }
        IProductService Products { get; }
        IWarehouseService Warehouses { get; }
        ILangStrService LangStrs { get; }
        ILangStrTranslationService LangStrTranslation { get; }
    }
}