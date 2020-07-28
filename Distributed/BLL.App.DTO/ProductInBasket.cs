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
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; } = default!;
        public Guid Id { get; set; }
    }
}