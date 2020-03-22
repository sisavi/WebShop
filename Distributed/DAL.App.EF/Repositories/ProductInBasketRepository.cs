using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductInBasketRepository : EFBaseRepository<ProductInBasket, AppDbContext>, IProductInBasketRepository
    {
        public ProductInBasketRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}