using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Order : DomainEntityIdMetadataUser<AppUser>
    {
        
        public DateTime? DateTime { get; set; }

        public DeliveryType? DeliveryType { get; set; }

        public Guid DeliveryTypeId { get; set; } = default!;
        
        [MaxLength(256)]
        [Display(Name = nameof(Address), ResourceType = typeof(Resources.Domain.Order))]
        public string Address { get; set; } = default!;
        
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }

        public Guid BasketId { get; set; }
        public Basket? Basket { get; set; }
        [Display(Name = nameof(TotalCost), ResourceType = typeof(Resources.Domain.Order))]
        public double TotalCost { get; set; }

        [Display(Name = nameof(PhoneNumber), ResourceType = typeof(Resources.Domain.Order))]
        public string PhoneNumber { get; set; } = default!;


    }
    
}