using System;
using DAL.Base;

namespace Domain
{
    public class Payment : DomainEntity
    {
        public int AccountId { get; set; }
        public Account? Account { get; set; }

        public int OrderId { get; set; }
        
        public Order? Order { get; set; }
        
        public DateTime Time { get; set; } = default!;
    }
}