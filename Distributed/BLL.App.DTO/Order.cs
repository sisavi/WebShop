﻿using System;
using BLL.App.DTO.Identity;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO
{
    public class Order : IDomainEntityId
    {
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int ProductInBasketId { get; set; }
        
        public ProductInBasket? ProductInBasket { get; set; }

        public string OrderNumber { get; set; } = default!;

        public Guid Id { get; set; }
    }
    
}