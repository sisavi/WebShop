using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class WarehouseRepository : EFBaseRepository<Warehouse, AppDbContext>, IWarehouseRepository
    {
        public WarehouseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}