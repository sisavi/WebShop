using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Warehouse : DomainEntityIdMetadata
    {
        
        [Display(Name = nameof(WarehouseCode), ResourceType = typeof(Resources.Domain.Warehouse))]
        public string WarehouseCode { get; set; } = default!;
        
        public ICollection<ProductInWarehouse>? WareHouseProducts { get; set; }
    }
}