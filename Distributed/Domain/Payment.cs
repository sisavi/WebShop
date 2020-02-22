using System;

namespace Domain
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }

        public int OrderId { get; set; }
        
        public Order? Order { get; set; }
        
        public DateTime Time { get; set; } = default!;
    }
}