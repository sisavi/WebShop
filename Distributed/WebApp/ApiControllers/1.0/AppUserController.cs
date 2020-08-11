using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain.App.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v2.Mappers;
using V2DTO=PublicApi.DTO.v2;

namespace WebApp.ApiControllers._1._0
{
    /// <summary>
    /// Appuser Controller
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class AppUsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUserMapper _mapper = new AppUserMapper();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManager"></param>
        public AppUsersController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        /// <summary>
        /// GetAppuser
        /// </summary>
        [HttpGet("appuser")]
        public async Task<ActionResult<PublicApi.DTO.v2.Identity.AppUser>> GetAppUser()
        {
            var appUser = await _userManager.FindByEmailAsync(User.Identity.Name);

            if (appUser == null)
            {
                return NotFound();
            }

            return _mapper.Map(appUser);
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// update AppUser
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(Guid id, PublicApi.DTO.v2.Identity.AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            var domainAppUser = await _context.Users.FindAsync(id);

            domainAppUser.Email = appUser.Email;
            domainAppUser.FirstName = appUser.FirstName;
            domainAppUser.LastName = appUser.LastName;

            _context.Entry(domainAppUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw;
            }

            return NoContent();
        }

    }
}
