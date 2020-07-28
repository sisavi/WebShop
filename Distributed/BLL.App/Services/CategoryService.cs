using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;


namespace BLL.App.Services
{
    public class CategoryService : BaseEntityService<IAppUnitOfWork, ICategoryRepository, ICategoryServiceMapper,
        DAL.App.DTO.Category, BLL.App.DTO.Category>, ICategoryService

    {
        public CategoryService(IAppUnitOfWork uow) : base(uow, uow.Categories, new CategoryServiceMapper())
        {
        }
    }
}