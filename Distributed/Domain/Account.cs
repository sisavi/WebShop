using System;
using System.Collections.Generic;

namespace Domain
{
    public class Account
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        
        public ICollection<Order>? Orders { get; set; }
        
        public ICollection<Basket>? Baskets { get; set; }
        
        public ICollection<Payment>? Payments { get; set; }
        
    }
}