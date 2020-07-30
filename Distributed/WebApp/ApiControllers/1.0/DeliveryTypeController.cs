using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using V2DTO=PublicApi.DTO.v2;


using PublicApi.DTO.v2.Mappers;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryTypeController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly DeliveryTypeMapper _mapper = new DeliveryTypeMapper();

        public DeliveryTypeController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/DeliveryType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.DeliveryType>>> GetDeliveryTypes()
        {
            return Ok((await _bll.DeliveryTypes.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/DeliveryType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.DeliveryType>> GetDeliveryType(Guid id)
        {
            var deliveryType = await _bll.DeliveryTypes.FirstOrDefaultAsync(id);

            if (deliveryType == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(deliveryType));
        }

        // PUT: api/DeliveryType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryType(Guid id, V2DTO.DeliveryType deliveryType)
        {
            if (id != deliveryType.Id)
            {
                return BadRequest();
            }

            await _bll.DeliveryTypes.UpdateAsync(_mapper.Map(deliveryType));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/DeliveryType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<V2DTO.DeliveryType>> PostDeliveryType(V2DTO.DeliveryType deliveryType)
        {
            var bllEntity = _mapper.Map(deliveryType);
            _bll.DeliveryTypes.Add(bllEntity);
            await _bll.SaveChangesAsync();
            deliveryType.Id = bllEntity.Id;

            return CreatedAtAction("GetDeliveryType", new { id = deliveryType.Id }, deliveryType);
        }

        // DELETE: api/DeliveryType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.DeliveryType>> DeleteDeliveryType(Guid id)
        {
            var deliveryType = await _bll.DeliveryTypes.FirstOrDefaultAsync(id);
            if (deliveryType == null)
            {
                return NotFound();
            }

            await _bll.DeliveryTypes.RemoveAsync(deliveryType);
            await _bll.SaveChangesAsync();

            return Ok(deliveryType);
        }
    }
}
