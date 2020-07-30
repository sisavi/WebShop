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
    public class PicturesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PictureMapper _mapper = new PictureMapper();

        public PicturesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Pictures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.Picture>>> GetPictures()
        {
            return Ok((await _bll.Pictures.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/Pictures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.Picture>> GetPicture(Guid id)
        {
            var picture = await _bll.Pictures.FirstOrDefaultAsync(id);

            if (picture == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(picture));
        }

        // PUT: api/Pictures/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPicture(Guid id, V2DTO.Picture picture)
        {
            if (id != picture.Id)
            {
                return BadRequest();
            }

            await _bll.Pictures.UpdateAsync(_mapper.Map(picture));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Pictures
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.Picture>> PostPicture(V2DTO.Picture picture)
        {
            var bllEntity = _mapper.Map(picture);
            _bll.Pictures.Add(bllEntity);
            await _bll.SaveChangesAsync();
            picture.Id = bllEntity.Id;

            return CreatedAtAction("GetPicture", new { id = picture.Id }, picture);
        }

        // DELETE: api/Pictures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Picture>> DeletePicture(Guid id)
        {
            var picture = await _bll.Pictures.FirstOrDefaultAsync(id);
            if (picture == null)
            {
                return NotFound();
            }

            await _bll.Pictures.RemoveAsync(picture);
            await _bll.SaveChangesAsync();

            return Ok(picture);
        }
    }
}
