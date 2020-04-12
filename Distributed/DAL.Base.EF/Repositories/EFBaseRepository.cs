using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class EFBaseRepository<TEntity, TDbContext> : BaseRepository<TEntity, Guid, TDbContext> 
        where TEntity : class, IDomainEntity<Guid>, new() 
        where TDbContext: DbContext
    {
        public EFBaseRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }
    public class BaseRepository<TEntity, TKey, TDbContext> : IBaseRepository<TEntity, TKey> 
        where TEntity : class, IDomainEntity<TKey>, new() 
        where TKey : struct, IComparable
        where TDbContext: DbContext
    {
        protected TDbContext RepoDbContext;
        protected DbSet<TEntity> RepoDbSet;
        
        public BaseRepository(TDbContext dbContext)
        {
            RepoDbContext = dbContext;
            RepoDbSet = RepoDbContext.Set<TEntity>();
            if (RepoDbSet == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " was not found as DBSet.");
            }
        }
        public IEnumerable<TEntity> All()
        {
            return RepoDbSet.ToList();
            
        }
        
        

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await RepoDbSet.ToListAsync();
        }
        
        public TEntity Find(params object[] id)
        {
            return RepoDbSet.Find(id);
        }

        public async Task<TEntity> FindAsync(params object[] id)
        {
            return await RepoDbSet.FindAsync(id);
        }

        public TEntity Add(TEntity entity)
        {
            return RepoDbSet.Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return RepoDbSet.Update(entity).Entity;
        }

        public TEntity Remove(TEntity entity)
        {
            return RepoDbSet.Remove(entity).Entity;
        }

        public TEntity Remove(params object[] id)
        {
            return Remove(Find(id));
        }
    }
}