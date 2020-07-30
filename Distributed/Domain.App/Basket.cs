using System;
using System.Collections.Generic;
using Domain.App.Identity;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Basket : DomainEntityIdMetadataUser<AppUser>
    {
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }

        public Order? Order { get; set; }
        public Guid? OrderId { get; set; }
        
    }
}