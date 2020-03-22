using System.Collections.Generic;
using DAL.Base;

namespace Domain
{
    public class Basket : DomainEntity
    {
        public int AccountId { get; set; }
        
        public Account? Account { get; set; }
        
        public ICollection<ProductInBasket>? ProductInBaskets { get; set; }
    }
}