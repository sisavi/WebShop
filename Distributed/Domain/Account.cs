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
        [Display(Name = nameof(FirstName), ResourceType = typeof(Resources.Domain.Account))]
        public string FirstName { get; set; } = default!;
        [MinLength(1)][MaxLength(128)]
        [Display(Name = nameof(LastName), ResourceType = typeof(Resources.Domain.Account))]
        public string LastName { get; set; } = default!;
        [Display(Name = nameof(Email), ResourceType = typeof(Resources.Domain.Account))]
        public string Email { get; set; } = default!;
        
        public ICollection<Order>? Orders { get; set; }
        
        public ICollection<Basket>? Baskets { get; set; }
        
        public ICollection<Payment>? Payments { get; set; }

        public Guid AppUserId { get; set; }

        public AppUser? AppUser { get; set; }
    }
}