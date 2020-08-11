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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly WarehouseMapper _mapper = new WarehouseMapper();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="bll"></param>
        public WarehousesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Warehouses
        /// <summary>
        /// get All warehouses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.Warehouse>>> GetWarehouses()
        {
            return Ok((await _bll.Warehouses.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/Warehouses/5
        /// <summary>
        /// get warehouse with id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.Warehouse>> GetWarehouse(Guid id)
        {
            var warehouse = await _bll.Warehouses.FirstOrDefaultAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(warehouse));
        }

        // PUT: api/Warehouses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// eidt warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouse(Guid id, V2DTO.Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return BadRequest();
            }

            await _bll.Warehouses.UpdateAsync(_mapper.Map(warehouse));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Warehouses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// create new warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<V2DTO.Warehouse>> PostWarehouse(V2DTO.Warehouse warehouse)
        {
            var bllEntity = _mapper.Map(warehouse);
            _bll.Warehouses.Add(bllEntity);
            await _bll.SaveChangesAsync();
            warehouse.Id = bllEntity.Id;

            return CreatedAtAction("GetWarehouse", new { id = warehouse.Id }, warehouse);
        }

        // DELETE: api/Warehouses/5
        /// <summary>
        /// delete warehouse
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Warehouse>> DeleteWarehouse(Guid id)
        {
            var warehouse = await _bll.Warehouses.FirstOrDefaultAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            await _bll.Warehouses.RemoveAsync(warehouse);
            await _bll.SaveChangesAsync();

            return Ok(warehouse);
        }
        
    }
}
