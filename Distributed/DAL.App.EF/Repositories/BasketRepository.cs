using System;
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

        /*
        public async Task<DTO.Basket> AddProduct(Guid basketId, Domain.App.Product product, bool noTracking = true)
        {
            var basket = await RepoDbSet.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == basketId);
            
            basket.Products?.Add(product);
            
            return Mapper.Map(basket);
        }
        **/
        public DAL.App.DTO.Basket GetByAppUserId(Guid userId)
        {
            var basket = RepoDbSet.AsNoTracking()
                .FirstOrDefaultAsync(a => a.AppUserId == userId).Result;
            
            
            
            return Mapper.Map(basket);
        }
    }
}