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
        private readonly PublicApi.DTO.v2.Mappers.ProductMapper _mapToDomain = new PublicApi.DTO.v2.Mappers.ProductMapper();

        public BasketsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Baskets
        [HttpGet("baskets")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<V2DTO.Basket>>> GetBaskets()
        {
            return Ok((await _bll.Baskets.GetAllAsync()).Select(e => _mapper.Map(e)).Where(e => e.AppUserId == User.UserId()));
        }

        // GET: api/Baskets/5
        [HttpGet("{id}")]
        [Authorize(Roles = "user,User")]
        public async Task<ActionResult<V2DTO.Basket>> GetBasket(Guid id)
        {
            var Basket = await _bll.Baskets.FirstOrDefaultAsync(id);

            if (Basket == null)
            {
                return NotFound();
            }

            return Ok(Basket);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">App UserId</param>
        /// <returns></returns>
        [HttpGet("userBasket/{id}")]
        [AllowAnonymous]
        [Produces("application/json")]

        public async Task<V2DTO.Basket> GetBasketByAppUser(Guid id)
        {
            var basket = _bll.Baskets.GetByAppUserId(id);

            return _mapper.Map(basket);
        }

        // PUT: api/Baskets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize(Roles = "user,User")]
        public async Task<IActionResult> PutBasket(Guid basketId, Guid productId, int quantity)
        {
            var basket = await _bll.Baskets.FirstOrDefaultAsync(basketId);
            var product = await _bll.Products.FirstOrDefaultAsync(productId);
            
            //await _bll.Baskets.AddProduct(basketId, _mapToDomain.MapToDomain(product));
            
            
            await _bll.Baskets.UpdateAsync(basket);
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
            _bll.Baskets.Add(bllEntity);
            await _bll.SaveChangesAsync();
            Basket.Id = bllEntity.Id;

            return CreatedAtAction("GetBasket", new { id = Basket.Id }, Basket);
        }

        // DELETE: api/Baskets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Basket>> DeleteBasket(Guid id)
        {
            var Basket = await _bll.Baskets.FirstOrDefaultAsync(id);
            if (Basket == null)
            {
                return NotFound();
            }

            await _bll.Baskets.RemoveAsync(Basket);
            await _bll.SaveChangesAsync();

            return Ok(Basket);
        }
    }
}
