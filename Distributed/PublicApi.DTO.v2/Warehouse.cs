using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class Warehouse : IDomainEntityId
    {
        
        
        public string WarehouseCode { get; set; } = default!;
        public Guid Id { get; set; }
    }
}