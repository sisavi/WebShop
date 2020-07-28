﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Category : DomainEntityId
    {
        [Display(Name = nameof(CategoryName), ResourceType = typeof(Resources.Domain.Category))]
        public string CategoryName { get; set; } = default!;
        
        public ICollection<Product>? Products { get; set; }
    }
}