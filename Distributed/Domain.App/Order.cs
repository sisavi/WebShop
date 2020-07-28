using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App.Identity;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Order : DomainEntityIdMetadataUser<AppUser>
    {

        public Guid ProductInBasketId { get; set; }
        
        public ProductInBasket? ProductInBasket { get; set; }

        public int OrderStatus { get; set; }

        public string DeliveryType { get; set; } = default!;
        
        [MaxLength(256)]
        public string Adress { get; set; } = default!;

        public string OrderNumber { get; set; } = default!;
        
        public ICollection<Payment>? Payments { get; set; }

    }
    
}