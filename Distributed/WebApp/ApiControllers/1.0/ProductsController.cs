using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v2.Mappers;
using Product = BLL.App.DTO.Product;
using V2DTO=PublicApi.DTO.v2;


namespace WebApp.ApiControllers._1._0
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly ProductMapper _mapper = new ProductMapper();

        public ProductsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Products
        [HttpGet]
        public async  Task<IEnumerable<V2DTO.Product>> GetProducts()
        {
            var test2 = new List<Product>();
            var test = (await _bll.Products.GetAllAsync());
            foreach (var item in test)
            {
                test2.Add(await _bll.Products.ApplyDiscount(item));
            }
            return test2.Select(e => _mapper.Map(e));
        }
        // GET: api/Categories/{id}
        /// <summary>
        /// Finds Specific Products from given Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns Products</returns>
        [HttpGet("CategoryProducts/{id}")]
        [AllowAnonymous]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<V2DTO.Product>>> GetProductsByCategory(Guid id)
        {
            return Ok((await _bll.Products.GetProductsByCategory(id)).Select(e => _mapper.Map(e)));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.Product>> GetProduct(Guid id)
        {
            var product = await _bll.Products.FirstOrDefaultAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(await _bll.Products.ApplyDiscount(product)));
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, V2DTO.Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _bll.Products.UpdateAsync(_mapper.Map(product));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.Product>> PostProduct(V2DTO.Product product)
        {
            var bllEntity = _mapper.Map(product);
            
            _bll.Products.Add(bllEntity);
            await _bll.SaveChangesAsync();
            product.Id = bllEntity.Id;

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Product>> DeleteProduct(Guid id)
        {
            var product = await _bll.Products.FirstOrDefaultAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _bll.Products.RemoveAsync(product);
            await _bll.SaveChangesAsync();

            return Ok(product);
        }
    }
}
