using System;
using DAL.Base;

namespace Domain
{
    public class Price : DomainEntity
    {

        public int ProductId { get; set; }
        
        public Product? Product { get; set; }
        
        public int CampaignId { get; set; }
        
        public Campaign? Campaign { get; set; }
        
        public double ProductPrice { get; set; } = default!;
        
        public DateTime StartTime { get; set; } = default!;
        
        public DateTime EndTime { get; set; } = default!;
    }
}