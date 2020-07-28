using AutoMapper;
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
            MapperConfigurationExpression.CreateMap<Domain.App.Identity.AppUser, DAL.App.DTO.Identity.AppUser>();
            MapperConfigurationExpression.CreateMap<Domain.App.Campaign, DAL.App.DTO.Campaign>();
            
            MapperConfigurationExpression.CreateMap<Domain.App.Category, DAL.App.DTO.Category>();
            MapperConfigurationExpression.CreateMap<DAL.App.DTO.Category, Domain.App.Category>();
            
            Mapper = new Mapper(new MapperConfiguration(MapperConfigurationExpression));
        }
    }
}