namespace PublicApi.DTO.v2.Mappers
{
    public class AppUserMapper : BaseMapper<Domain.App.Identity.AppUser, PublicApi.DTO.v2.Identity.AppUser>
    {
        public Domain.App.Identity.AppUser MapAppUserToDomain(PublicApi.DTO.v2.Identity.AppUser inObject)
        {
            return Mapper.Map<Domain.App.Identity.AppUser>(inObject);
        }
    }
}