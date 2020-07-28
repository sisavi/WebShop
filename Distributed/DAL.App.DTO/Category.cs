using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;


namespace DAL.App.DTO
{
    public class Category : IDomainEntityId
    {
        public string CategoryName { get; set; } = default!;
        
        public ICollection<Product>? Products { get; set; }
        public Guid Id { get; set; }
    }
}