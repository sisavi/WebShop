using System.Collections.Generic;
using DAL.Base;

namespace Domain
{
    public class Product : DomainEntity
    {
        
        
        public int CategoryId { get; set; }
        
        public Category? Category { get; set; }

        public string ProductName { get; set; } = default!;

        public string ProductCode { get; set; } = default!;
        
        public ICollection<ProductInWarehouse>? ProductsInWarehouse { get; set; }
        
        public ICollection<Comment>? Comments { get; set; }
        
        public ICollection<Picture>? Pictures { get; set; }
        public ICollection<Price>? Prices { get; set; }
        
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }
        
    }
}