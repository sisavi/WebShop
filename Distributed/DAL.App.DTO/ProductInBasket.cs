using System;
using ee.itcollege.sisavi.Contracts.Domain;

namespace DAL.App.DTO
{
    public class ProductInBasket : IDomainEntityId
    {
        public Guid BasketId { get; set; }

        public Basket? Basket { get; set; }
        
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public int Quantity { get; set; }

        public double TotalCost { get; set; }
        
        public Guid? OrderId { get; set; }

        public Order? Order { get; set; }
        public Guid Id { get; set; }
    }
    
    
}