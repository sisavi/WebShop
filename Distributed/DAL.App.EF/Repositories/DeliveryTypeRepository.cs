using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain.App;


namespace DAL.App.EF.Repositories
{
    public class DeliveryTypeRepository : EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.DeliveryType, DAL.App.DTO.DeliveryType>, IDeliveryTypeRepository
    {
        public DeliveryTypeRepository(AppDbContext repoDbContext) : base(repoDbContext, new DALMapper<DeliveryType, DTO.DeliveryType>())
        {
        }
    }
}