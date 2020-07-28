using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace DAL.App.DTO
{
    public class Warehouse : IDomainEntityId
    {
        
        
        public string WarehouseCode { get; set; } = default!;
        
        public ICollection<ProductInWarehouse>? WareHouseProducts { get; set; }
        public Guid Id { get; set; }
    }
}