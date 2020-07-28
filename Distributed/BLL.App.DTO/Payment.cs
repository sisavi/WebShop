using System;
using BLL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO
{
    public class Payment : IDomainEntityId
    {
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }

        public int OrderId { get; set; }
        
        public Order? Order { get; set; }
        
        public DateTime Time { get; set; } = default!;
        public Guid Id { get; set; }
    }
}