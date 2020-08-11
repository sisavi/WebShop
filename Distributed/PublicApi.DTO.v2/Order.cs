using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class Order : IDomainEntityId
    {
        public Guid AppUserId { get; set; }
        
        public DateTime? DateTime { get; set; }
        

        public Guid DeliveryTypeId { get; set; } = default!;
        
        [MaxLength(256)]
        public string Address { get; set; } = default!;
        
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }

        public Guid BasketId { get; set; }

        public double TotalCost { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public Guid Id { get; set; }
    }
    
}