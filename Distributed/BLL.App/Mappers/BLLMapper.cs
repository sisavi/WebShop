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
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Campaign, BLL.App.DTO.Campaign>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Campaign, DAL.App.DTO.Campaign>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Campaign, BLL.App.DTO.Campaign>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Campaign, DAL.App.DTO.Campaign>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Campaign, BLL.App.DTO.Campaign>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Campaign, DAL.App.DTO.Campaign>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Campaign, BLL.App.DTO.Campaign>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Campaign, DAL.App.DTO.Campaign>();
            
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Campaign, BLL.App.DTO.Campaign>();
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Campaign, DAL.App.DTO.Campaign>();
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}