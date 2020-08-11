using System;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class Product : IDomainEntityId
    {
        
        
        public Guid CategoryId { get; set; }
        
        public Category? Category { get; set; }
        
        public Guid? CampaignId { get; set; }
        
        public Campaign? Campaign { get; set; }

        public string ProductName { get; set; } = default!;
        
        public string Description { get; set; } = default!;

        public double ProductPrice { get; set; } = default!;
        
        public string? ImagePath { get; set; }
        public Guid Id { get; set; }
    }
}