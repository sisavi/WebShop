using System;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class ProductInBasket : DomainEntityId
    {
        public Guid BasketId { get; set; }

        public Basket? Basket { get; set; }
        
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public int Quantity { get; set; }

        public double TotalCost { get; set; }
    }
    
    
}