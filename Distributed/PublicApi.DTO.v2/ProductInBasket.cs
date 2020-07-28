using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class ProductInBasket : IDomainEntityId
    {
        public Guid AppUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = default!;
        public Guid Id { get; set; }
    }
}