using System.Collections.Generic;
using DAL.Base;

namespace Domain
{
    public class Warehouse : DomainEntity
    {
        
        
        public string WarehouseCode { get; set; } = default!;
        
        public ICollection<ProductInWarehouse>? WareHouseProducts { get; set; }
    }
}