﻿using AutoMapper;
using ee.itcollege.sisavi.DAL.Base.Mappers;

namespace DAL.App.EF.Mappers
{
    public class DALMapper<TLeftObject, TRightObject> : BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public DALMapper() : base()
        { 
            // add more mappings
            
            MapperConfigurationExpression.CreateMap<Domain.App.Campaign, DAL.App.DTO.Campaign>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Category, DAL.App.DTO.Category>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Category, Domain.App.Category>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Basket, DAL.App.DTO.Basket>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Basket, Domain.App.Basket>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Product, DAL.App.DTO.Product>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Product, Domain.App.Product>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Order, DAL.App.DTO.Order>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Order, Domain.App.Order>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.ProductInBasket, DAL.App.DTO.ProductInBasket>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ProductInBasket, Domain.App.ProductInBasket>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Identity.AppUser, DAL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, Domain.App.Identity.AppUser>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}