using System;
using ee.itcollege.sisavi.Domain.Base;


namespace Domain.App
{
    public class DeliveryType : DomainEntityId
    {
        public string DeliveryTypeName { get; set; } = default!;

        public double? Price { get; set; }
    }
}