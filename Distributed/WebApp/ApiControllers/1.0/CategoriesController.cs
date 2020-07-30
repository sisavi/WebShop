using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using V2DTO = PublicApi.DTO.v2;
using PublicApi.DTO.v2.Mappers;

namespace WebApp.ApiControllers._1._0
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly CategoryMapper _mapper = new CategoryMapper();

        public CategoriesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.Category>>> GetCategories()
        {
            return Ok((await _bll.Categories.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.Category>> GetCategory(Guid id)
        {
            var category = await _bll.Categories.FirstOrDefaultAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(category));
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, V2DTO.Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            await _bll.Categories.UpdateAsync(_mapper.Map(category));
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.Category>> PostCategory(V2DTO.Category category)
        {
            var bllEntity = _mapper.Map(category);
            _bll.Categories.Add(bllEntity);
            await _bll.SaveChangesAsync();
            category.Id = bllEntity.Id;
            

            return CreatedAtAction("GetCategory", new {id = category.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"}, category);
        }

        // DELETE: api/Categories/5
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Category>> DeleteCategory(Guid id)
        {
            var category = await _bll.Categories.FirstOrDefaultAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _bll.Categories.RemoveAsync(category);
            await _bll.SaveChangesAsync();

            return Ok(category);
        }
        
    }
}