﻿using ee.itcollege.sisavi.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;

namespace BLL.App.Mappers
{
    public class CategoryServiceMapper : BaseMapper<DALAppDTO.Category, BLLAppDTO.Category>, ICategoryServiceMapper
    {
        
    }
}