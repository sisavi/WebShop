using System;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using ee.itcollege.sisavi.DAL.Base.Mappers;
using Domain;
using Domain.App;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CategoryRepository : EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.Category, DAL.App.DTO.Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Category, DTO.Category>())
        {
        }

        
    }
}