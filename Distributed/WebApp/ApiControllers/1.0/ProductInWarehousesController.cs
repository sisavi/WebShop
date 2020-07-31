using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v2.Mappers;
using V2DTO=PublicApi.DTO.v2;


namespace WebApp.ApiControllers._1._0
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class 
        ProductInWarehousesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly ProductInWarehouseMapper _mapper = new ProductInWarehouseMapper();
        public ProductInWarehousesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ProductInWarehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.ProductInWarehouse>>> GetProductInWarehouses()
        {
            return Ok((await _bll.ProductsInWarehouse.GetAllAsync()).Select(e => _mapper.Map(e)));
        }
        
        // GET: api/Categories/{id}
        /// <summary>
        /// Finds Specific Products from given Category
        /// </summary>
        /// <returns>returns Products</returns>
        [HttpGet("WarehouseProducts/{id}")]
        [AllowAnonymous]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<V2DTO.ProductInWarehouse>>> GetProductsInWarehouse(Guid id)
        {
            return Ok((await _bll.ProductsInWarehouse.GetProductsInWarehouse(id)).Select(e => _mapper.Map(e)));
        }

        // GET: api/ProductInWarehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.ProductInWarehouse>> GetProductInWarehouse(Guid id)
        {
            var productInWarehouse = await _bll.ProductsInWarehouse.FirstOrDefaultAsync(id);

            if (productInWarehouse == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(productInWarehouse));
        }

        // PUT: api/ProductInWarehouses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("UpdatedWarehouseProduct/{id}")]
        public async Task<IActionResult> PutProductInWarehouse(Guid id, V2DTO.ProductInWarehouse productInWarehouse)
        {
            if (id != productInWarehouse.Id)
            {
                return BadRequest();
            }

            await _bll.ProductsInWarehouse.UpdateAsync(_mapper.Map(productInWarehouse));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ProductInWarehouses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.ProductInWarehouse>> PostProductInWarehouse(V2DTO.ProductInWarehouse productInWarehouse)
        {
            var bllEntity = _mapper.Map(productInWarehouse);
            
            _bll.ProductsInWarehouse.Add(bllEntity);
            await _bll.SaveChangesAsync();
            productInWarehouse.Id = bllEntity.Id;

            return CreatedAtAction("GetProductInWarehouse", new { id = productInWarehouse.Id }, productInWarehouse);
        }

        // DELETE: api/ProductInWarehouses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.ProductInWarehouse>> DeleteProductInWarehouse(Guid id)
        {
            var productInWarehouse = await _bll.ProductsInWarehouse.FirstOrDefaultAsync(id);
            if (productInWarehouse == null)
            {
                return NotFound();
            }

            await _bll.ProductsInWarehouse.RemoveAsync(productInWarehouse);
            await _bll.SaveChangesAsync();

            return Ok(productInWarehouse);
        }
        
    }
}
