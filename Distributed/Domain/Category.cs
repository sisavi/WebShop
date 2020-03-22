using System.Collections.Generic;
using DAL.Base;

namespace Domain
{
    public class Category : DomainEntity
    {

        public string CategoryName { get; set; } = default!;
        
        public ICollection<Product>? Products { get; set; }
    }
}