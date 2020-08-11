using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Category : DomainEntityId
    {
        [Display(Name = nameof(CategoryName), ResourceType = typeof(Resources.Domain.Category))]
        public LangStr? CategoryName { get; set; }
        
        public Guid CategoryNameId { get; set; }
        
        public ICollection<Product>? Products { get; set; }
    }
}