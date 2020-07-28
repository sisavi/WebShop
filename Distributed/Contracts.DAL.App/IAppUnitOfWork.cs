using System;
using Contracts.DAL.App.Repositories;
using ee.itcollege.sisavi.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork, IBaseEntityTracker
    {
        ILangStrRepository LangStrs { get; }
        ILangStrTranslationRepository LangStrTranslations { get; }
        ICampaignRepository Campaigns { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IOrderRepository Orders { get; }
        IPaymentRepository Payments { get; }
        IPictureRepository Pictures { get; }
        IProductInBasketRepository ProductsInBaskets { get; }
        IProductInWarehouseRepository ProductsInWarehouse { get; }
        IProductRepository Products { get; }
        IWarehouseRepository Warehouses { get; }
        
    }
}