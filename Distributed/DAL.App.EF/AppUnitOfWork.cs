using System;
using System.Collections.Generic;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using ee.itcollege.sisavi.DAL.Base.EF;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<Guid, AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext uowDbContext) : base(uowDbContext)
        {
        }
        
        public ILangStrRepository LangStrs =>
            GetRepository<ILangStrRepository>(() => new LangStrRepository(UOWDbContext));

        public ILangStrTranslationRepository LangStrTranslations =>
            GetRepository<ILangStrTranslationRepository>(() => new LangStrTranslationRepository(UOWDbContext));
        public ICampaignRepository Campaigns =>
            GetRepository<ICampaignRepository>(() => new CampaignRepository(UOWDbContext));
        public ICategoryRepository Categories =>
            GetRepository<ICategoryRepository>((() => new CategoryRepository(UOWDbContext)));
        public ICommentRepository Comments =>
            GetRepository<ICommentRepository>((() => new CommentRepository(UOWDbContext)));
        public IOrderRepository Orders =>
            GetRepository<IOrderRepository>(() => new OrderRepository(UOWDbContext));
        public IPaymentRepository Payments =>
            GetRepository<IPaymentRepository>((() => new PaymentRepository(UOWDbContext)));
        public IPictureRepository Pictures =>
            GetRepository<IPictureRepository>((() => new PictureRepository(UOWDbContext)));
        public IProductInBasketRepository ProductsInBaskets =>
            GetRepository<IProductInBasketRepository>((() => new ProductInBasketRepository(UOWDbContext)));
        public IProductInWarehouseRepository ProductsInWarehouse =>
            GetRepository<IProductInWarehouseRepository>((() => new ProductInWarehouseRepository(UOWDbContext)));
        public IProductRepository Products =>
            GetRepository<IProductRepository>(() => new ProductRepository(UOWDbContext));
        public IWarehouseRepository Warehouses =>
            GetRepository<IWarehouseRepository>(() => new WarehouseRepository(UOWDbContext));
    }
}