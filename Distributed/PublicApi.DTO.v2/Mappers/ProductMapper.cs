using AutoMapper;

namespace PublicApi.DTO.v2.Mappers
{
    public class ProductMapper : BaseMapper<BLL.App.DTO.Product ,Product>
    {
        public ProductMapper()
        {
            MapperConfigurationExpression.CreateMap<BLL.App.DTO.Product, Domain.App.Product>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }

        public  Domain.App.Product MapToDomain(BLL.App.DTO.Product inObject)
        {
            return Mapper.Map<Domain.App.Product>(inObject);
        }
    }
}