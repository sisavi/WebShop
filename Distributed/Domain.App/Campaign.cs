using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Campaign : DomainEntityIdMetadata
    {
        [Display(Name = nameof(Discount), ResourceType = typeof(Resources.Domain.Campaign))]
        public double Discount { get; set; }
        
        
        
    }
}