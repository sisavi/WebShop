using System;
using ee.itcollege.sisavi.Contracts.Domain;
using PublicApi.DTO.v2.Identity;

namespace PublicApi.DTO.v2
{
    public class Payment : IDomainEntityId
    {
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }

        public int OrderId { get; set; }
        public DateTime Time { get; set; } = default!;
        public Guid Id { get; set; }
    }
}