using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO
{
    public class Warehouse : IDomainEntityId
    {
        public string WarehouseCode { get; set; } = default!;
        public Guid Id { get; set; }
    }
}