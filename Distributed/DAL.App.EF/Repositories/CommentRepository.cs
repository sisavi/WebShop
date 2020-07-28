using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.sisavi.DAL.Base.EF.Repositories;
using ee.itcollege.sisavi.DAL.Base.Mappers;
using Domain;
using Domain.App;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CommentRepository : EFBaseRepository<AppDbContext, AppUser, Domain.App.Comment, DAL.App.DTO.Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext, new DALMapper<Comment, DTO.Comment>())
        {
        }
    }
}