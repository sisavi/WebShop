using System;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IBasketRepository Baskets { get; }
        ICampaignRepository Campaigns { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IOrderRepository Orders { get; }
        IPaymentRepository Payments { get; }
        IPictureRepository Pictures { get; }
        IPriceRepository Prices { get; }
        IProductInBasketRepository ProductsInBaskets { get; }
        IProductInWarehouseRepository ProductsInWarehouse { get; }
        IProductRepository Products { get; }
        IWarehouseRepository Warehouses { get; }


    }
}