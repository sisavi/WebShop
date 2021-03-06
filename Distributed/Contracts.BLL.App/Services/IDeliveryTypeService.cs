﻿using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IDeliveryTypeService : IBaseEntityService<DeliveryType>, IDeliveryTypeRepositoryCustom<DeliveryType>
    {
        
    }
}