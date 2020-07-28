﻿using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Product : DomainEntityIdMetadata
    {
        
        
        public Guid CategoryId { get; set; }
        
        public Category? Category { get; set; }
        
        public Guid? CampaignId { get; set; }
        
        public Campaign? Campaign { get; set; }

        public string ProductName { get; set; } = default!;
        public string Description { get; set; } = default!;

        public string ProductCode { get; set; } = default!;
        
        public double ProductPrice { get; set; } = default!;
        
        public ICollection<ProductInWarehouse>? ProductsInWarehouse { get; set; }
        
        public ICollection<Comment>? Comments { get; set; }
        
        public ICollection<Picture>? Pictures { get; set; }

        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }
        
    }
}