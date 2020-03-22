using System.Collections.Generic;
using DAL.Base;

namespace Domain
{
    public class ProductInBasket : DomainEntity
    {
        
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; } = default!;
        public ICollection<Order>? Orders { get; set; }
    }
}