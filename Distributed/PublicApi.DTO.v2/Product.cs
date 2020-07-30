using System;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class Product : IDomainEntityId
    {
        
        
        public Guid CategoryId { get; set; }
        public Guid? CampaignId { get; set; }
        public string? ImagePath { get; set; }
        
        public string ProductName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double ProductPrice { get; set; } = default!;
        public Guid Id { get; set; }
    }
}