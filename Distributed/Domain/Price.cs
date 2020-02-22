using System;

namespace Domain
{
    public class Price
    {
        public int PriceId { get; set; }
        
        public int ProductId { get; set; }
        
        public Product? Product { get; set; }
        
        public int CampaignId { get; set; }
        
        public Campaign? Campaign { get; set; }
        
        public decimal ProductPrice { get; set; } = default!;
        
        public DateTime StartTime { get; set; } = default!;
        
        public DateTime EndTime { get; set; } = default!;
    }
}