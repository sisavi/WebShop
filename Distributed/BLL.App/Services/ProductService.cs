using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class ProductService : BaseEntityService<IAppUnitOfWork, IProductRepository, IProductServiceMapper,
        DAL.App.DTO.Product, BLL.App.DTO.Product>, IProductService

    {
        public ProductService(IAppUnitOfWork uow) : base(uow, uow.Products, new ProductServiceMapper())
        {
        }
        public async Task<Product> ApplyDiscount(Product product, double priceOfProduct)
        {
            DAL.App.DTO.Campaign? campaign = null;
            if (product.CampaignId != null)
            {
                campaign = await UOW.Campaigns.FirstOrDefaultAsync((Guid)product.CampaignId);
            }

            if (campaign == null)
            {
                return product;
            }
            
            product.ProductPrice = priceOfProduct * (1 - campaign.Discount);
            
            return product;
        }
    }
}