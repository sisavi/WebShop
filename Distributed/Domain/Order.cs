using DAL.Base;

namespace Domain
{
    public class Order : DomainEntity
    {

        public int AccountId { get; set; }
        
        public Account? Account { get; set; }

        public int ProductInBasketId { get; set; }
        
        public ProductInBasket? ProductInBasket { get; set; }

        public string OrderNumber { get; set; } = default!;
        
    }
    
}