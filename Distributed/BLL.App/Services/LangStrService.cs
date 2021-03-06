using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class LangStrService : BaseEntityService<IAppUnitOfWork, ILangStrRepository, ILangStrServiceMapper,
        DAL.App.DTO.LangStr, BLL.App.DTO.LangStr>, ILangStrService

    {
        public LangStrService(IAppUnitOfWork uow) : base(uow, uow.LangStrs, new LangStrServiceMapper())
        {
        }
    }
}