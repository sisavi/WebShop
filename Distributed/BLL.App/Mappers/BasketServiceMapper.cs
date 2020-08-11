using AutoMapper;
using ee.itcollege.sisavi.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class BasketServiceMapper : BaseMapper<DALAppDTO.Basket, BLLAppDTO.Basket>, IBasketServiceMapper
    {
        public BasketServiceMapper() : base()
        {
            MapperConfigurationExpression.CreateMap<DALAppDTO.Identity.AppUser, BLLAppDTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Basket, BLLAppDTO.Basket>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }

    }
}