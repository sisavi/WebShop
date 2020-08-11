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
    public class ProductRepository : EFBaseRepository<AppDbContext, AppUser, Product, DTO.Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Product, DTO.Product>())
        {
        }
        
        public override async Task<IEnumerable<DTO.Product>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            query = query
                .Include(p => p.Description).ThenInclude(t=>t!.Translations)
                .Include(p => p.ProductName).ThenInclude(t=>t!.Translations);
            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;
        }
        

        public override async Task<DTO.Product> FirstOrDefaultAsync(Guid id, object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            var domainEntity = await query.Include(p => p.Description).ThenInclude(t => t!.Translations)
                .Include(p => p.ProductName).ThenInclude(t => t!.Translations)
                .FirstOrDefaultAsync(e => e.Id.Equals(id));

            var result = Mapper.Map(domainEntity);
            return result;
        }
    }
}