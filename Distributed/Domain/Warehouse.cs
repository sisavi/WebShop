using System.Collections.Generic;

namespace Domain
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        
        public string WarehouseCode { get; set; } = default!;
        
        public ICollection<ProductInWarehouse>? WareHouseProducts { get; set; }
    }
}