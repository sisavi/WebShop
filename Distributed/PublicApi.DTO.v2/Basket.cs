using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class ProductInBasket : IDomainEntityId
    {
        public Guid AppUserId { get; set; }
        public Guid Id { get; set; }
        
        public bool? isActive { get; set; }
        
        public Order? Order { get; set; }
        public Guid? OrderId { get; set; }
    }
}