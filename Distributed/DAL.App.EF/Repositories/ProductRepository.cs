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
        /**
        public override async Task<IEnumerable<DTO.Product>> GetAllAsync(object userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            query = query
                .Include(p => p.Category);
                //.Include(p => p.Price);
            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;
        }
        **/
        
    }
}