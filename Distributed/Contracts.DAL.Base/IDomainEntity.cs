using System;
using System.Diagnostics.Tracing;

namespace Contracts.DAL.Base
{
    public interface IDomainEntity : IDomainEntity<Guid>
    {
        
    }

    public interface IDomainEntity<TKey> : IDomainBaseEntity<TKey>, IDomainEntityMetadata
        where TKey: struct, IComparable
    {
        
    }
    
    
}