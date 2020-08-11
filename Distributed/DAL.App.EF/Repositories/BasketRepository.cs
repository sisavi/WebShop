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
using Product = BLL.App.DTO.Product;

namespace DAL.App.EF.Repositories
{
    public class BasketRepository : EFBaseRepository<AppDbContext, AppUser, Basket, DTO.Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Basket, DTO.Basket>())
        {
        }

        public override async Task<IEnumerable<DTO.Basket>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
 
            query = query
                .Include(sc => sc.AppUser);
 
            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
 
            return result;
        }
 
        public DTO.Basket GetByAppUserId(Guid userId)
        {
            var query = PrepareQuery().Where(sc => sc.AppUserId == userId);
            return Mapper.Map(query.FirstOrDefault(sc => sc.AppUserId == userId));
        }

    }
}