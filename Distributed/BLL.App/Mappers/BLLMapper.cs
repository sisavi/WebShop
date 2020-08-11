using AutoMapper;
using ee.itcollege.sisavi.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class BLLMapper<TLeftObject, TRightObject> : BaseMapper<TLeftObject, TRightObject>
        where TRightObject : class?, new()
        where TLeftObject : class?, new()
    {
        public BLLMapper() : base()
        { 
            // add more mappings
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Campaign, BLL.App.DTO.Campaign>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Campaign, DAL.App.DTO.Campaign>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Product, BLL.App.DTO.Product>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Product, DAL.App.DTO.Product>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.ProductInBasket, BLL.App.DTO.ProductInBasket>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.ProductInBasket, DAL.App.DTO.ProductInBasket>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Basket, BLL.App.DTO.Basket>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Basket, DAL.App.DTO.Basket>();
            
            
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Identity.AppUser, DAL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Identity.AppUser, BLL.App.DTO.Identity.AppUser>();
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}