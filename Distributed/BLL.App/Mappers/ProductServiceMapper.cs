using AutoMapper;
using ee.itcollege.sisavi.BLL.Base.Mappers;
using Contracts.BLL.App.Mappers;
using BLLAppDTO=BLL.App.DTO;
using DALAppDTO=DAL.App.DTO;
namespace BLL.App.Mappers
{
    public class ProductServiceMapper : BaseMapper<DALAppDTO.Product, BLLAppDTO.Product>, IProductServiceMapper
    {

        public ProductServiceMapper() : base()
        {
            MapperConfigurationExpression.CreateMap<DALAppDTO.Identity.AppUser, BLLAppDTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Category, BLLAppDTO.Category>();
            MapperConfigurationExpression.CreateMap<DALAppDTO.Campaign, BLLAppDTO.Campaign>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}