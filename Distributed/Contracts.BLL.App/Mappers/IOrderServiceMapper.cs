﻿using ee.itcollege.sisavi.Contracts.BLL.Base.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace Contracts.BLL.App.Mappers
{
    public interface IOrderServiceMapper  : IBaseMapper<DALAppDTO.Order, BLLAppDTO.Order>
    {
        
    }
}