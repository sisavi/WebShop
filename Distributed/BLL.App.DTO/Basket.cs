using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO
{
    public class ProductInBasket : IDomainEntityId
    {
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        
        public ICollection<Product>? Products { get; set; }
        
        public ICollection<Quantity>? Quantities { get; set; }
        public Guid Id { get; set; }
        
        public Order? Order { get; set; }
        public Guid? OrderId { get; set; }
        
        public bool? isActive { get; set; }
    }
}