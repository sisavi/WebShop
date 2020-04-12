using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Base;

namespace Domain
{
    public class Category : DomainEntity
    {
        [Display(Name = nameof(CategoryName), ResourceType = typeof(Resources.Domain.Category))]
        public string CategoryName { get; set; } = default!;
        
        public ICollection<Product>? Products { get; set; }
    }
}