using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v2.Mappers;
using V2DTO=PublicApi.DTO.v2;


namespace WebApp.ApiControllers._1._0
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly BasketMapper _mapper = new BasketMapper();

        public BasketsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Baskets
        [HttpGet("baskets")]
        [Authorize()]
        public async Task<ActionResult<IEnumerable<V2DTO.Basket>>> GetBaskets()
        {
            return Ok((await _bll.ProductsInBaskets.GetAllAsync()).Select(e => _mapper.Map(e)).Where(e => e.AppUserId == User.UserId()));
        }

        // GET: api/Baskets/5
        [HttpGet("{id}")]
        [Authorize(Roles = "user,User")]
        public async Task<ActionResult<V2DTO.Basket>> GetBasket(Guid id)
        {
            var Basket = await _bll.ProductsInBaskets.FirstOrDefaultAsync(id);

            if (Basket == null)
            {
                return NotFound();
            }

            return Ok(Basket);
        }

        // PUT: api/Baskets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize(Roles = "user,User")]
        public async Task<IActionResult> PutBasket(Guid basketId, Guid ProductId, int quantity)
        {
            var basket = await _bll.ProductsInBaskets.FirstOrDefaultAsync(basketId);
            
            await _bll.ProductsInBaskets.AddProduct(ProductId, quantity);
            
            await _bll.ProductsInBaskets.UpdateAsync(basket);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Baskets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.Basket>> PostBasket(V2DTO.Basket Basket)
        {
            var bllEntity = _mapper.Map(Basket);
            _bll.ProductsInBaskets.Add(bllEntity);
            await _bll.SaveChangesAsync();
            Basket.Id = bllEntity.Id;

            return CreatedAtAction("GetBasket", new { id = Basket.Id }, Basket);
        }

        // DELETE: api/Baskets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Basket>> DeleteBasket(Guid id)
        {
            var Basket = await _bll.ProductsInBaskets.FirstOrDefaultAsync(id);
            if (Basket == null)
            {
                return NotFound();
            }

            await _bll.ProductsInBaskets.RemoveAsync(Basket);
            await _bll.SaveChangesAsync();

            return Ok(Basket);
        }
    }
}
