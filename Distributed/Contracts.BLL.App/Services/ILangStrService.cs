using Contracts.DAL.App.Repositories;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.BLL.Base.Services;


namespace Contracts.BLL.App.Services
{
    public interface ILangStrService : IBaseEntityService<LangStr>, ILangStrRepositoryCustom<LangStr>
    {
        
    }
}