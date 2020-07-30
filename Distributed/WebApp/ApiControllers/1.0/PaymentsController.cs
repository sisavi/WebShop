using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v2.Mappers;
using V2DTO=PublicApi.DTO.v2;


namespace WebApp.ApiControllers._1._0
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PaymentMapper _mapper = new PaymentMapper();

        public PaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.Payment>>> GetPayments()
        {
            return Ok((await _bll.Payments.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.Payment>> GetPayment(Guid id)
        {
            var payment = await _bll.Payments.FirstOrDefaultAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(payment));
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(Guid id, V2DTO.Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            await _bll.Payments.UpdateAsync(_mapper.Map(payment));
            await _bll.SaveChangesAsync();
            

            return NoContent();
        }

        // POST: api/Payments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.Payment>> PostPayment(V2DTO.Payment payment)
        {
            var bllEntity = _mapper.Map(payment);
            _bll.Payments.Add(bllEntity);
            await _bll.SaveChangesAsync();
            payment.Id = bllEntity.Id;

            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Payment>> DeletePayment(Guid id)
        {
            var payment = await _bll.Payments.FirstOrDefaultAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            await _bll.Payments.RemoveAsync(payment);
            await _bll.SaveChangesAsync();

            return Ok(payment);
        }
        
    }
}
