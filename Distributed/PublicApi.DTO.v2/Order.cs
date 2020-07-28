using System;
using BLL.App.DTO;
using BLL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class Order : IDomainEntityId
    {
        public Guid AppUserId { get; set; }

        public int ProductInBasketId { get; set; }

        public string OrderNumber { get; set; } = default!;

        public Guid Id { get; set; }
    }
    
}