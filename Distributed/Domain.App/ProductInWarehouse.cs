using System;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class ProductInWarehouse : DomainEntityIdMetadata
    {

        public Guid ProductId { get; set; }

        public Product? Product { get; set; }
        
        public Guid WarehouseId { get; set; }
        
        public Warehouse? Warehouse { get; set; }
        
        public int Quantity { get; set; }
        
    }
}