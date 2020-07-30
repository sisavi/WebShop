using System;
using Contracts.BLL.App.Services;
using ee.itcollege.sisavi.Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        ICampaignService Campaigns { get; }
        ICategoryService Categories { get; }
        IOrderService Orders { get; }
        IPaymentService Payments { get; }
        IPictureService Pictures { get; }
        IBasketService Baskets { get; }
        IProductInWarehouseService ProductsInWarehouse { get; }
        IProductInBasketService ProductInBasket { get; }
        IProductService Products { get; }
        IDeliveryTypeService DeliveryTypes { get; }
        IWarehouseService Warehouses { get; }
        ILangStrService LangStrs { get; }
        ILangStrTranslationService LangStrTranslation { get; }
    }
}