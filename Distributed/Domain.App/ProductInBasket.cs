using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class ProductInBasket : DomainEntityId
    {
        public Guid BasketId { get; set; }

        public Basket? Basket { get; set; }
        
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        [Display(Name = nameof(Quantity), ResourceType = typeof(Resources.Domain.ProductInBasket))]
        public int Quantity { get; set; }

        [Display(Name = nameof(TotalCost), ResourceType = typeof(Resources.Domain.ProductInBasket))]
        public double TotalCost { get; set; }
        
        public Guid? OrderId { get; set; }

        public Order? Order { get; set; }
    }
    
    
}