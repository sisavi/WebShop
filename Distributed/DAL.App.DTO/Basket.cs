using System;
using System.Collections.Generic;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;
using DAL.App.DTO.Identity;
using Domain.App;

namespace DAL.App.DTO
{
    public class ProductInBasket : IDomainEntityId
    {
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        
        public ICollection<Product>? Products { get; set; }
        
        public ICollection<Quantity>? Quantities { get; set; }
        
        public Order? Order { get; set; }
        public Guid? OrderId { get; set; }
        public Guid Id { get; set; }
        
        public bool? isActive { get; set; }
    }
}