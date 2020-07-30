using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class Basket : IDomainEntityId
    {
        public Guid AppUserId { get; set; }
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }

        public Order? Order { get; set; }
        public Guid? OrderId { get; set; }
        public Guid Id { get; set; }
    }
}