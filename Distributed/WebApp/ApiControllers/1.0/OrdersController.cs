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
    public class OrdersController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly OrderMapper _mapper = new OrderMapper();
        public OrdersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.Order>>> GetOrders()
        {
            return Ok((await _bll.Orders.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.Order>> GetOrder(Guid id)
        {
            var order = await _bll.Orders.FirstOrDefaultAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(order));
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(Guid id, V2DTO.Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _bll.Orders.UpdateAsync(_mapper.Map(order));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.Order>> PostOrder(V2DTO.Order order)
        {
            var bllEntity = _mapper.Map(order);
            _bll.Orders.Add(bllEntity);
            
            await _bll.SaveChangesAsync();
            order.Id = bllEntity.Id;

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Order>> DeleteOrder(Guid id)
        {
            var order = await _bll.Orders.FirstOrDefaultAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _bll.Orders.RemoveAsync(order);
            await _bll.SaveChangesAsync();

            return Ok(order);
        }
    }
}
