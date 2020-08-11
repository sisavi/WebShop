using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v2.Identity;
using PublicApi.DTO.v2.Mappers;
using AppUser = BLL.App.DTO.Identity.AppUser;
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
        private readonly ProductInBasketMapper _pibMapper = new ProductInBasketMapper();
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">order id</param>
        /// <returns></returns>
        [HttpGet("orderProducts/{id}")]
        
        public async Task<ActionResult<V2DTO.ProductInBasket>> GetOrderProducts(Guid id)
        {
            return Ok((await _bll.ProductInBasket.GetProductsForOrderAsync(id)).Select(e =>_pibMapper.Map(e)));
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
            var orderId = _bll.Orders.PlaceOrderForApi(order).Result;
            await _bll.Orders.CopyBasket(order.BasketId, orderId);
            await _bll.Baskets.ClearBasket(order.BasketId);

            await _bll.SaveChangesAsync();
            
            
            
            return NoContent();
        }

        // DELETE: api/Orders/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
