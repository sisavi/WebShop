using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO
{
    public class Campaign : IDomainEntityId
    {
        public double Discount { get; set; }
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid Id { get; set; }
    }
}