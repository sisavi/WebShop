using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProductInWarehouseRepository : EFBaseRepository<ProductInWarehouse, AppDbContext>, IProductInWarehouseRepository
    {
        public ProductInWarehouseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}