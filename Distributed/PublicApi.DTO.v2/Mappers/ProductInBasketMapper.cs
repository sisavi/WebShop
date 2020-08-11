using AutoMapper;

namespace PublicApi.DTO.v2.Mappers
{
    public class ProductInBasketMapper : BaseMapper<BLL.App.DTO.ProductInBasket, PublicApi.DTO.v2.ProductInBasket>
    {
        public ProductInBasketMapper() : base()
        {
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Identity.AppUser, PublicApi.DTO.v2.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Product, Product>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Basket, Basket>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
    }
}