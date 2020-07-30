using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Contracts.Domain;


namespace BLL.App.DTO
{
    public class DeliveryType : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public string DeliveryTypeName { get; set; } = default!;

        public double? Price { get; set; }
    }
}