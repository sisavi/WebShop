using System;
using ee.itcollege.sisavi.Contracts.DAL.Base.Repositories;
using ee.itcollege.sisavi.Contracts.Domain;

namespace ee.itcollege.sisavi.Contracts.BLL.Base.Services
{
    public interface IBaseEntityService<TEntity> : IBaseEntityService<Guid, TEntity>
        where TEntity : class, IDomainEntityId<Guid>, new()
    {
    }

    public interface IBaseEntityService<in TKey, TEntity> : IBaseService, IBaseRepository<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : class, IDomainEntityId<TKey>, new()
    {
        
    }

}
