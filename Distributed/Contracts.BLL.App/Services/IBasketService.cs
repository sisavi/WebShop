using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using basket = DAL.App.DTO.Basket;
using Product = BLL.App.DTO.Product;

namespace Contracts.BLL.App.Services
{
    public interface IBasketService : IBaseEntityService<Basket>, IBasketRepositoryCustom<Basket>
    {
        //Task<basket> AddProduct(Guid basketId, Domain.App.Product product);
    }
}