using AutoMapper;
using ee.itcollege.sisavi.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class ProductInBasketServiceMapper : BaseMapper<DALAppDTO.ProductInBasket, BLLAppDTO.ProductInBasket>, IProductInBasketServiceMapper
    {
        
        public ProductInBasketServiceMapper() : base()
        {
            MapperConfigurationExpression.CreateMap<DALAppDTO.Identity.AppUser, BLLAppDTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Product, BLLAppDTO.Product>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Basket, BLLAppDTO.Basket>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Order, BLLAppDTO.Order>();
            
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}