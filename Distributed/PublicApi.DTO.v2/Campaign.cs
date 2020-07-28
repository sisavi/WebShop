using System;
using System.Collections.Generic;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class Campaign : IDomainEntityId
    {
        public double Discount { get; set; }
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid Id { get; set; }
    }
}