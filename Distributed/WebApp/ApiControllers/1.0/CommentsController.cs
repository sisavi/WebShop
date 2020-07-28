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
    public class CommentsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly CommentMapper _mapper = new CommentMapper();

        public CommentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.Comment>>> GetComments()
        {
            return Ok((await _bll.Comments.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.Comment>> GetComment(Guid id)
        {
            var comment = await _bll.Comments.FirstOrDefaultAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(comment));
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(Guid id, V2DTO.Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            await _bll.Comments.UpdateAsync(_mapper.Map(comment));
            await _bll.SaveChangesAsync();

           
            return NoContent();
        }

        // POST: api/Comments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.Comment>> PostComment(V2DTO.Comment comment)
        {
            var bllEntity = _mapper.Map(comment);
            _bll.Comments.Add(bllEntity);
            await _bll.SaveChangesAsync();
            comment.Id = bllEntity.Id;

            return CreatedAtAction("GetComment", new { id = comment.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0" }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Comment>> DeleteComment(Guid id)
        {
            var comment = await _bll.Comments.FirstOrDefaultAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _bll.Comments.RemoveAsync(comment);
            await _bll.SaveChangesAsync();

            return Ok(comment);
        }
        
    }
}
