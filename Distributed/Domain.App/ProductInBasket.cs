using System.Collections.Generic;
using Domain.App.Identity;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class ProductInBasket : DomainEntityIdMetadataUser<AppUser>
    {

        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; } = default!;
        public ICollection<Order>? Orders { get; set; }
    }
}