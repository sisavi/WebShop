using System.Collections.Generic;

namespace Domain
{
    public class Basket
    {
        public int BasketId { get; set; }
        public int AccountId { get; set; }
        
        public Account? Account { get; set; }
        
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }
    }
}