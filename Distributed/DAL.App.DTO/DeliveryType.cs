using System;
using ee.itcollege.sisavi.Contracts.Domain;

namespace DAL.App.DTO
{
    public class DeliveryType : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public string DeliveryTypeName { get; set; } = default!;

        public double? Price { get; set; }
    }
}