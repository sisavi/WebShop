using System;
using Domain.App.Identity;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Payment : DomainEntityIdMetadataUser<AppUser>{
        
        public Guid OrderId { get; set; }
        
        public Order? Order { get; set; }
        
        public DateTime Time { get; set; } = default!;
    }
}