using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO
{
    public class Category : IDomainEntityId
    {
        public string CategoryName { get; set; } = default!;
        
        public Guid CategoryNameId { get; set; }
        
        public Guid Id { get; set; }
        
        
    }
}