namespace Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        
        public int AccountId { get; set; }
        
        public Account? Account { get; set; }

        public int ProductInBasketId { get; set; }
        
        public ProductInBasket? ProductInBasket { get; set; }

        public string OrderNumber { get; set; } = default!;
        
    }
    
}