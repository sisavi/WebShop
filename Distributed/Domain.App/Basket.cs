using System;
using System.Collections.Generic;
using Domain.App.Identity;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class ProductInBasket : DomainEntityIdMetadataUser<AppUser>
    {
        public ICollection<Product>? Products { get; set; }
        
        public ICollection<Quantity>? Quantities { get; set; }
        
        public Order? Order { get; set; }
        public Guid? OrderId { get; set; }
        
        public bool? isActive { get; set; }
    }
}