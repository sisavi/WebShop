using System;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;
using DAL.App.DTO.Identity;


namespace DAL.App.DTO
{
    public class Order : IDomainEntityId
    {
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int BasketId { get; set; }
        
        public Basket? Basket { get; set; }

        public string OrderNumber { get; set; } = default!;

        public Guid Id { get; set; }
    }
    
}