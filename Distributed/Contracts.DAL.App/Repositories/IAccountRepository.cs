using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;
using PublicApi.DTO.v1;

namespace Contracts.DAL.App.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<IEnumerable<Account>> AllAsync(Guid? userId = null);
        Task<Account> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
        
        
        // DTO methods
        Task<IEnumerable<AccountDTO>> DTOAllAsync(Guid? userId = null);
        Task<AccountDTO> DTOFirstOrDefaultAsync(Guid id, Guid? userId = null);
    }
}