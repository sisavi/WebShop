using System;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public class DomainEntity : IDomainEntity
    {
        public Guid Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual string DeletedBy { get; set; }
        public virtual DateTime? DeletedAt { get; set; }
        
    }
}