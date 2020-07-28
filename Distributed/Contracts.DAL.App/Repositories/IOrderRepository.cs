﻿using ee.itcollege.sisavi.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>, IOrderRepositoryCustom
    {
        
    }
}