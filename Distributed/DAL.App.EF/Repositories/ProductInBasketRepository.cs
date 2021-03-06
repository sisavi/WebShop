﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain.App;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    
    public class ProductInBasketRepository : EFBaseRepository<AppDbContext, AppUser, ProductInBasket, DTO.ProductInBasket>, IProductInBasketRepository
    {
        public ProductInBasketRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<ProductInBasket, DTO.ProductInBasket>())
        {
        }
        
        public async Task<IEnumerable<DTO.ProductInBasket>> GetProductsForBasketAsync(Guid basId, object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);

            query = query
                .Include(pib => pib.Product).ThenInclude(p=>p!.Description).ThenInclude(t=>t!.Translations)
                .Include(pib => pib.Product).ThenInclude(p=>p!.ProductName).ThenInclude(t=>t!.Translations)
                .Where(pib => pib.BasketId.Equals(basId));
            
            var domainItems = await query.AsNoTracking().ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;
        }
        


        public override async Task<IEnumerable<DTO.ProductInBasket>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            query = query
                .Include(pib => pib.Product);

            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            
            return result;
        }
        
        public DTO.ProductInBasket GetPibByAppUserId(Guid id)
        {
            return Mapper.Map((PrepareQuery().FirstOrDefaultAsync(pil => pil.Id.Equals(id)).Result));
        }

        public async Task<IEnumerable<DTO.ProductInBasket>> GetProductsForOrderAsync(Guid orderId, object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
 
            query = query
                .Include(pil => pil.Product).ThenInclude(p => p!.ProductName).ThenInclude(ls => ls!.Translations)
                .Include(pil => pil.Product).ThenInclude(p => p!.Description).ThenInclude(ls => ls!.Translations)
                .Where(pil => pil.OrderId.Equals(orderId));
 
            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;
        }
        

        public DTO.ProductInBasket? ProductAlreadyInBasket(Guid shoppingCartId, Guid productId)
        {
            // There should always be 1 or 0
            return Mapper.Map(PrepareQuery().Where(pil => pil.BasketId.Equals(shoppingCartId) && pil.ProductId.Equals(productId)).FirstOrDefaultAsync().Result)?? null;
        }
    }
}