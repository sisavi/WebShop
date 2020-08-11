using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Product : DomainEntityIdMetadata
    {
        public Guid CategoryId { get; set; }
        
        public Category? Category { get; set; }
        
        public Guid? CampaignId { get; set; }
        
        public Campaign? Campaign { get; set; }
        [Display(Name = nameof(ProductName), ResourceType = typeof(Resources.Domain.Product))]
        public LangStr? ProductName { get; set; }
        public Guid ProductNameId { get; set; }
        
        
        [Display(Name = nameof(Description), ResourceType = typeof(Resources.Domain.Product))]
        public LangStr? Description { get; set; }
        public Guid DescriptionId { get; set; }

        [Display(Name = nameof(ProductPrice), ResourceType = typeof(Resources.Domain.Product))]
        public double ProductPrice { get; set; } = default!;
        
        public string? ImagePath { get; set; }
        
        public ICollection<ProductInWarehouse>? ProductsInWarehouse { get; set; }

        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }
        
        
    }
}