using System;
using System.Collections.Generic;
using DAL.Base;

namespace Domain
{
    public class Campaign : DomainEntity
    {
        public double Discount { get; set; }
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public ICollection<Price>? Prices { get; set; }
    }
}