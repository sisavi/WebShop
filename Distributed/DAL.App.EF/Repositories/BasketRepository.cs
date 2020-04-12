using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v1;

namespace DAL.App.EF.Repositories
{
    public class BasketRepository :  EFBaseRepository<Basket, AppDbContext>, IBasketRepository
    {
        public BasketRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Basket>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return await base.AllAsync(); // base is not actually needed, using it for clarity
            }

            return await RepoDbSet.Where(a => a.Account.AppUserId == userId).ToListAsync();
        }

        public async Task<Basket> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.Account.AppUserId == userId);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            if (userId == null)
            {
                return await RepoDbSet.AnyAsync(a => a.Id == id);
            }

            return await RepoDbSet.AnyAsync(a => a.Id == id && a.Account.AppUserId == userId);
        }

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var abstractList = await FirstOrDefaultAsync(id, userId);
            base.Remove(abstractList);
        }
        
        // we need to do it on database level, to avoid unnecessary queries to db 

        public async Task<IEnumerable<BasketDTO>> DTOAllAsync(Guid? userId = null)
        {
            var query = RepoDbSet.AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.Account.AppUserId == userId);
            }
            return await query
                .Select(a => new BasketDTO()
                {
                    Id = a.Id,
                    AccountId = a.AccountId
                })
                .ToListAsync();
        }

        public async Task<BasketDTO> DTOFirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.Account.AppUserId == userId);
            }

            var ownerDTO = await query.Select(a => new BasketDTO()
            {
                Id = a.Id,
                AccountId = a.AccountId,
            }).FirstOrDefaultAsync();

            return ownerDTO;
        }
    }
}