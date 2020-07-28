using System;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class ProductInWarehouse : IDomainEntityId
    {

        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public Guid Id { get; set; }
    }
}