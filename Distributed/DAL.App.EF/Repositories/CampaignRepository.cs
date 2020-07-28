using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain.App;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CampaignRepository : EFBaseRepository<AppDbContext, AppUser, Domain.App.Campaign, DAL.App.DTO.Campaign>, ICampaignRepository
    {
        public CampaignRepository(AppDbContext repoDbContext) : base(repoDbContext, new DALMapper<Campaign, DTO.Campaign>())
        {
        }
    }
}