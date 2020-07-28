using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class CommentService : BaseEntityService<IAppUnitOfWork, ICommentRepository, ICommentServiceMapper,
        DAL.App.DTO.Comment, BLL.App.DTO.Comment>, ICommentService

    {
        public CommentService(IAppUnitOfWork uow) : base(uow, uow.Comments, new CommentServiceMapper())
        {
        }
    }
}