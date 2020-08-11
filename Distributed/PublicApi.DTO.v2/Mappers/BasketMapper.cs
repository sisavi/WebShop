using AutoMapper;

namespace PublicApi.DTO.v2.Mappers
{
    public class BasketMapper : BaseMapper<BLL.App.DTO.Basket, Basket>
    {
     
        public BasketMapper() : base()
        {
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Identity.AppUser, PublicApi.DTO.v2.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Basket, Basket>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}