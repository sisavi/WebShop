using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = default!;
        
        public ICollection<Product>? Products { get; set; }
    }
}