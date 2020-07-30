using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v2.Mappers;
using V2DTO=PublicApi.DTO.v2;


namespace WebApp.ApiControllers._1._0
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductInBasketsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly ProductInBasketMapper _mapper = new ProductInBasketMapper();

        public ProductInBasketsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ProductInBaskets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.ProductInBasket>>> GetProductInBaskets()
        {
            return Ok((await _bll.ProductInBasket.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/ProductInBaskets/5
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInBasket(Guid id, V2DTO.ProductInBasket productInBasket)
        {
            if (id != productInBasket.Id)
            {
                return BadRequest();
            }

            await _bll.ProductInBasket.UpdateAsync(_mapper.Map(productInBasket));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ProductInBaskets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.ProductInBasket>> PostProductInBasket(V2DTO.ProductInBasket productInBasket)
        {
            var bllEntity = _mapper.Map(productInBasket);
            _bll.ProductInBasket.Add(bllEntity);
            await _bll.SaveChangesAsync();
            productInBasket.Id = bllEntity.Id;

            return CreatedAtAction("GetProductInBasket", new { id = productInBasket.Id }, productInBasket);
        }

        // DELETE: api/ProductInBaskets/5
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
