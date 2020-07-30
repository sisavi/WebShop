using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using V2DTO=PublicApi.DTO.v2;
using PublicApi.DTO.v2.Mappers;

namespace WebApp.ApiControllers._1._0
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly CampaignMapper _mapper = new CampaignMapper();

        public CampaignsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Campaigns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<V2DTO.Campaign>>> GetCampaigns()
        {
            return Ok((await _bll.Campaigns.GetAllAsync()).Select(e => _mapper.Map(e)));
        }

        // GET: api/Campaigns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<V2DTO.Campaign>> GetCampaign(Guid id)
        {
            var campaign = await _bll.Campaigns.FirstOrDefaultAsync(id);

            if (campaign == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(campaign));
        }

        // PUT: api/Campaigns/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaign(Guid id, V2DTO.Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return BadRequest();
            }

            await _bll.Campaigns.UpdateAsync(_mapper.Map(campaign));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Campaigns
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<V2DTO.Campaign>> PostCampaign(V2DTO.Campaign campaign)
        {
            
            _bll.Campaigns.Add(_mapper.Map(campaign));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCampaign", new { id = campaign.Id }, campaign);
        }

        // DELETE: api/Campaigns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<V2DTO.Campaign>> DeleteCampaign(Guid id)
        {
            var campaign = await _bll.Campaigns.FirstOrDefaultAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }

            await _bll.Campaigns.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return Ok(campaign);
        }
        
    }
}
