using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class Account : DomainEntity
    {
        [MinLength(1)][MaxLength(128)]
        public string FirstName { get; set; } = default!;
        [MinLength(1)][MaxLength(128)]
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        
        public ICollection<Order>? Orders { get; set; }
        
        public ICollection<Basket>? Baskets { get; set; }
        
        public ICollection<Payment>? Payments { get; set; }

        public Guid AppUserId { get; set; }

        public AppUser? AppUser { get; set; }
    }
}