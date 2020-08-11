using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v2.Mappers;
using V2DTO=PublicApi.DTO.v2;


namespace WebApp.ApiControllers._1._0
{
    /// <summary>
    /// products in basket controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductInBasketsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly ProductInBasketMapper _mapper = new ProductInBasketMapper();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="bll"></param>
        public ProductInBasketsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ProductInBaskets
        /// <summary>
        /// get all user products in basket
        /// </summary>
        /// <returns>all users products in basket</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<V2DTO.ProductInBasket>>> GetProductInBaskets()
        {
            return Ok((await _bll.ProductInBasket.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// get user product that has been added to product user basket
        /// </summary>
        /// <param name="id">basket id</param>
        /// <returns>user products</returns>
        [HttpGet("userProducts/{id}")]
        
        public async Task<ActionResult<IEnumerable<V2DTO.ProductInBasket>>> GetUserProductInBaskets(Guid id)
        {
            
            return Ok(await _bll.ProductInBasket.GetProductsForBasketAsync(id));
        }

        /// <summary>
        /// get certain user products from basket total Price
        /// </summary>
        /// <param name="id">user basket id</param>
        /// <returns>user products</returns>
        [HttpGet("userTotal/{id}")]
        
        public async Task<ActionResult<IEnumerable<V2DTO.ProductInBasket>>> GetUserProductInBasketsTotal(Guid id)
        {

            return Ok(await _bll.ProductInBasket.GetTotalCost(id));
        }


        // GET: api/ProductInBaskets/5
        /// <summary>
        /// get product in basket with correct id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.ProductInBasket>> GetProductInBasket(Guid id)
        {
            var productInBasket = await _bll.ProductInBasket.FirstOrDefaultAsync(id);

            if (productInBasket == null)
            {
                return NotFound();
            }

            return Ok(productInBasket);
        }

        // PUT: api/ProductInBaskets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// edit products in basket
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="productInBasket">product in basket</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInBasket(Guid id, V2DTO.ProductInBasket productInBasket)
        {
            if (id != productInBasket.Id)
            {
                return BadRequest();
            }

            await _bll.ProductInBasket.DecreaseQuantity(_mapper.Map(productInBasket));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ProductInBaskets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// put product to basket
        /// </summary>
        /// <param name="productInBasket">product to add to basket</param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<ActionResult<V2DTO.ProductInBasket>> PostProductInBasket(V2DTO.ProductInBasket productInBasket)
        {
            await _bll.ProductInBasket.AddToBasketApi(productInBasket.ProductId, productInBasket.BasketId);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProductInBasket", new { id = productInBasket.Id }, productInBasket);
        }

        // DELETE: api/ProductInBaskets/5
        /// <summary>
        /// delete product from basket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.ProductInBasket>> DeleteProductInBasket(Guid id)
        {
            var productInBasket = await _bll.ProductInBasket.FirstOrDefaultAsync(id);
            if (productInBasket == null)
            {
                return NotFound();
            }
            await _bll.ProductInBasket.RemoveAsync(productInBasket);
            await _bll.SaveChangesAsync();

            return Ok(productInBasket);
        }
    }
}
