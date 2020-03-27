using System;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;

namespace DAL.Base
{
    public class DomainEntity : IDomainEntity
    {
        [Key]
        public Guid Id { get; set; }
        public virtual string CreatedBy { get; set; } = default!;
        public virtual DateTime CreatedAt { get; set; }
        public virtual string? DeletedBy { get; set; } = default!;
        public virtual DateTime? DeletedAt { get; set; }
        
    }
}