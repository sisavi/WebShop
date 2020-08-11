using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.sisavi.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using ProductInBasket = Domain.App.ProductInBasket;

namespace Contracts.DAL.App.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>, IOrderRepositoryCustom
    {
        Order GetOrderByAppUserId(Guid appUserId);
        
    }
}