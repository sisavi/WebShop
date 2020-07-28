using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using Domain;
using Domain.App;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PictureRepository : EFBaseRepository<AppDbContext, AppUser, Picture, DTO.Picture>, IPictureRepository
    {
        public PictureRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Picture, DTO.Picture>())
        {
        }
    }
}