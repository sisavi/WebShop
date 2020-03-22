using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PictureRepository : EFBaseRepository<Picture, AppDbContext>, IPictureRepository
    {
        public PictureRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}