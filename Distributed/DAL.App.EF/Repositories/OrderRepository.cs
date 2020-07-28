using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain;
using Domain.App;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class OrderRepository : EFBaseRepository<AppDbContext, AppUser,Domain.App.Order, DAL.App.DTO.Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Order, DTO.Order>())
        {
        }
    }
}