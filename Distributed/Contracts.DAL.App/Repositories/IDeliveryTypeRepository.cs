using DAL.App.DTO;
using ee.itcollege.sisavi.Contracts.DAL.Base.Repositories;


namespace Contracts.DAL.App.Repositories
{
    public interface IDeliveryTypeRepository : IBaseRepository<DeliveryType>, IDeliveryTypeRepositoryCustom
    {
    }


}