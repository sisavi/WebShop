using System;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;


namespace DAL.App.DTO
{
    public class ProductInWarehouse : IDomainEntityId
    {

        public int ProductId { get; set; }

        public Product? Product { get; set; }
        
        public int WarehouseId { get; set; }
        
        public Warehouse? Warehouse { get; set; }
        
        public int Quantity { get; set; }

        public Guid Id { get; set; }
    }
}