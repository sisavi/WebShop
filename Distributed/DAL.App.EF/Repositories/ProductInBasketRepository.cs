using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain;
using Domain.App;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductInBasketRepository : EFBaseRepository<AppDbContext, AppUser, ProductInBasket, DTO.ProductInBasket>, IProductInBasketRepository
    {
        public ProductInBasketRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<ProductInBasket, DTO.ProductInBasket>())
        {
        }
        
        public async Task<IEnumerable<DTO.ProductInBasket>> GetProductsForBasketAsync(Guid basId, object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);

            query = query
                .Include(pib => pib.Product).ThenInclude(p => p!.ProductName)
                .Include(pib => pib.Product).ThenInclude(p => p!.Description)
                .Include(pib => pib.Product).ThenInclude(p => p!.ProductPrice)
                .Where(pib => pib.BasketId.Equals(basId));
            
            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;
        }
    }
}