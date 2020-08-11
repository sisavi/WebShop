using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CategoryRepository : EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.Category, DAL.App.DTO.Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Category, DTO.Category>())
        {
        }
        
        public override async Task<IEnumerable<DTO.Category>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            query = query
                .Include(l => l.CategoryName)
                .ThenInclude(t => t!.Translations);
            
            var domainEntities = await query.ToListAsync();
            var result = domainEntities.Select(e => Mapper.Map(e));
            return result;
        }

        
    }
}