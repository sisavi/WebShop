using System.Collections.Generic;

namespace Domain
{
    public class ProductInBasket
    {
        public int ProductInBasketId { get; set; }
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; } = default!;
        public ICollection<Order>? Orders { get; set; }
    }
}