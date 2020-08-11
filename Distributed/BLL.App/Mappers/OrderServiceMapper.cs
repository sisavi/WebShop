using AutoMapper;
using ee.itcollege.sisavi.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class OrderServiceMapper : BaseMapper<DALAppDTO.Order, BLLAppDTO.Order>, IOrderServiceMapper
    {
        
        public OrderServiceMapper() : base()
        {
            MapperConfigurationExpression.CreateMap<DALAppDTO.Identity.AppUser, BLLAppDTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Basket, BLLAppDTO.Basket>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.ProductInBasket, BLLAppDTO.ProductInBasket>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Order, BLLAppDTO.Order>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
        
    }
}