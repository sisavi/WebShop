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
        public async Task<Product> ApplyDiscount(Product product)
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
            
            product.ProductPrice *= ((100 - campaign.Discount) / 100);
            
            return product;
        }

        
        public async Task<IEnumerable<Product>> GetProductsByCategory(Guid id)
        {
            var products = await UOW.Products.GetAllAsync();
            
            var categoryProducts = new List<DAL.App.DTO.Product>();

            foreach (var product in products)
            {
                if (product.CategoryId.Equals(id))
                {
                    categoryProducts.Add(product);
                }
                
            }

            var productsByCategory = categoryProducts.Select(e => Mapper.Map(e)); 

            return productsByCategory;
        }
    }
}