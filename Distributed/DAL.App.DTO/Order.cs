using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.Domain;
using ee.itcollege.sisavi.Domain.Base;


namespace DAL.App.DTO
{
    public class Order : IDomainEntityId
    {
        public Guid Id { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }
        
        public DateTime? DateTime { get; set; }

        public DeliveryType? DeliveryType { get; set; }

        public Guid DeliveryTypeId { get; set; } = default!;
        
        [MaxLength(256)]
        public string Address { get; set; } = default!;
        
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }

        public Guid BasketId { get; set; }
        public Basket? Basket { get; set; }

        public double TotalCost { get; set; }
        public string PhoneNumber { get; set; } = default!;


    }
    
}