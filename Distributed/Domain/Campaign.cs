using System;
using System.Collections.Generic;

namespace Domain
{
    public class Campaign
    {
        public int CampaignId { get; set; }

        public decimal Discount { get; set; }
        

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public ICollection<Price>? Prices { get; set; }
    }
}