using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;
using DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext uowDbContext) : base(uowDbContext)
        {
        }
        public IAccountRepository Accounts => GetRepository<IAccountRepository>((() => new AccountRepository(UOWDbContext)));
        public IBasketRepository Baskets => GetRepository<IBasketRepository>((() => new BasketRepository(UOWDbContext)));
        public ICampaignRepository Campaigns => GetRepository<ICampaignRepository>(() => new CampaignRepository(UOWDbContext));
        public ICategoryRepository Categories => GetRepository<ICategoryRepository>((() => new CategoryRepository(UOWDbContext)));
        public ICommentRepository Comments => GetRepository<ICommentRepository>((() => new CommentRepository(UOWDbContext)));
        public IOrderRepository Orders => GetRepository<IOrderRepository>(() => new OrderRepository(UOWDbContext));
        public IPaymentRepository Payments => GetRepository<IPaymentRepository>((() => new PaymentRepository(UOWDbContext)));
        public IPictureRepository Pictures => GetRepository<IPictureRepository>((() => new PictureRepository(UOWDbContext)));
        public IPriceRepository Prices => GetRepository<IPriceRepository>(() => new PriceRepository(UOWDbContext));
        public IProductInBasketRepository ProductsInBaskets => GetRepository<IProductInBasketRepository>((() => new ProductInBasketRepository(UOWDbContext)));
        public IProductInWarehouseRepository ProductsInWarehouse => GetRepository<IProductInWarehouseRepository>((() => new ProductInWarehouseRepository(UOWDbContext)));
        public IProductRepository Products => GetRepository<IProductRepository>(() => new ProductRepository(UOWDbContext));
        public IWarehouseRepository Warehouses => GetRepository<IWarehouseRepository>(() => new WarehouseRepository(UOWDbContext));
    }
}