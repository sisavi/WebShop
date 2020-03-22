using System;
using System.Collections.Generic;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class Account : DomainEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        
        public ICollection<Order>? Orders { get; set; }
        
        public ICollection<Basket>? Baskets { get; set; }
        
        public ICollection<Payment>? Payments { get; set; }

        public Guid AppUserId { get; set; } = default!;

        public AppUser? AppUser { get; set; }
    }
}