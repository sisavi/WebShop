using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class CategoryRepository : EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.Category, DAL.App.DTO.Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Category, DTO.Category>())
        {
        }

        
    }
}