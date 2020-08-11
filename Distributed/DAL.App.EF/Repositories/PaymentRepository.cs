using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;

using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PaymentRepository : EFBaseRepository<AppDbContext,Domain.App.Identity.AppUser, Domain.App.Payment, DTO.Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Domain.App.Payment, DTO.Payment>())
        {
        }
        
        public override async Task<IEnumerable<Payment>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
 
            query = query
                .Include(o => o.Order)
                .Include(pt => pt.DeliveryTypeId)//.ThenInclude(ls => ls!.Name!.Translations)
                .Include(d => d.Address)
                .Include(au => au.AppUser)
                .OrderByDescending(a => a.Time);
 
            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
 
            return result;
        }
 
 
        public override async Task<Payment> FirstOrDefaultAsync(Guid id, object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            var domainEntity = await query
                .Include(p => p.Address)
                .Include(p => p.Order)
                .Include(p => p.DeliveryTypeId)//.ThenInclude(ls => ls!.Name!.Translations)
                .Include(p => p.AppUser)
                .FirstOrDefaultAsync(p => p.Id.Equals(id));
 
            var result = Mapper.Map(domainEntity);
 
            return result;
        }
    }
}