using System;
using System.Threading.Tasks;
using ee.itcollege.sisavi.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Product = BLL.App.DTO.Product;

namespace Contracts.DAL.App.Repositories
{
    public interface IBasketRepository : IBaseRepository<Basket>, IBasketRepositoryCustom
    {
        //Task<Basket> AddProduct(Guid basketId, Domain.App.Product product, bool noTracking = true);
    }
}