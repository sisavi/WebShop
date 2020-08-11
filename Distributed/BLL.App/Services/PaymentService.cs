using System;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

namespace BLL.App.Services
{
    public class PaymentService : BaseEntityService<IAppUnitOfWork, IPaymentRepository, IPaymentServiceMapper,
        DAL.App.DTO.Payment, BLL.App.DTO.Payment>, IPaymentService

    {
        public PaymentService(IAppUnitOfWork uow) : base(uow, uow.Payments, new PaymentServiceMapper())
        {
        }
        
        public async Task MakePayment(Guid deliveryTypeId, string address, Guid orderId, Guid userId)
        {
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                Time = DateTime.Now,
                DeliveryTypeId = deliveryTypeId,
                Address = address,
                OrderId = orderId,
                AppUserId = userId
            };
 
            UOW.Payments.Add(Mapper.Map(payment));
            await UOW.SaveChangesAsync();
 
        }
    }
}