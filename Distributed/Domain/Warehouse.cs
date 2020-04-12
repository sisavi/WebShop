using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Base;

namespace Domain
{
    public class Warehouse : DomainEntity
    {
        
        [Display(Name = nameof(WarehouseCode), ResourceType = typeof(Resources.Domain.Warehouse))]
        public string WarehouseCode { get; set; } = default!;
        
        public ICollection<ProductInWarehouse>? WareHouseProducts { get; set; }
    }
}