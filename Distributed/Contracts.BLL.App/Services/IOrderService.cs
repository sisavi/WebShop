using System;
using System.Threading.Tasks;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IOrderService : IBaseEntityService<Order>, IOrderRepositoryCustom<Order>
    {
        Task CopyBasket(Guid basketId, Guid orderId);
        Task<Guid> PlaceOrderForApi(PublicApi.DTO.v2.Order orderCreate);

        Task<Guid?> PlaceOrder(Guid id, Guid userId, string address, string phone, Guid deliveryTypeId);
    }
}