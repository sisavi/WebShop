using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Contracts.Domain;
using Domain.App;

namespace DAL.App.DTO
{
    public class Basket : IDomainEntityId
    {
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }

        public Order? Order { get; set; }
        public Guid? OrderId { get; set; }
        public Guid Id { get; set; }
    }
}