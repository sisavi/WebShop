using System;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO
{
    public class ProductInWarehouse : IDomainEntityId
    {

        public Guid ProductId { get; set; }

        public Product? Product { get; set; }
        
        public Guid WarehouseId { get; set; }
        
        public Warehouse? Warehouse { get; set; }
        
        public int Quantity { get; set; }

        public Guid Id { get; set; }
    }
}