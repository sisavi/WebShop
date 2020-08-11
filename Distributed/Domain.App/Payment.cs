using System;
using Domain.App.Identity;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Payment : DomainEntityIdMetadataUser<AppUser>{
        
        public Guid OrderId { get; set; }
        
        public Order? Order { get; set; }
        public Guid DeliveryTypeId { get; set; } = default!;

        public DeliveryType? DeliveryType { get; set; }
        public string Address { get; set; } = default!;
        
        public DateTime Time { get; set; } = default!;
    }
}