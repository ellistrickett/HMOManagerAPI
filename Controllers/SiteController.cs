using HMOManagerAPI.Data;
using HMOManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMOManagerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SiteController(ApplicationDbContext dbContext) : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpPost]
        public IActionResult CreateSite([FromBody] Site site)
        {
            _dbContext.Sites.Add(site);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetSiteById), new { id = site.SiteId }, site);
        }

        [HttpGet]
        public IActionResult GetSites()
        {
            var sites = _dbContext.Sites.ToList();
            return Ok(sites);
        }

        [HttpGet("{id}")]
        public IActionResult GetSiteById(int id)
        {
            var site = _dbContext.Sites.FirstOrDefault(s => s.SiteId == id);
            if (site == null)
            {
                return NotFound();
            }
            return Ok(site);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSite(int id, [FromBody] Site updatedSite)
        {
            var existingSite = _dbContext.Sites.FirstOrDefault(s => s.SiteId == id);
            if (existingSite == null)
            {
                return NotFound();
            }

            // Should Map
            existingSite = updatedSite;

            _dbContext.SaveChanges();
            return Ok(existingSite);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSite(int id)
        {
            var existingSite = _dbContext.Sites.FirstOrDefault(s => s.SiteId == id);
            if (existingSite == null)
            {
                return NotFound();
            }

            _dbContext.Remove(existingSite);

            _dbContext.SaveChanges();
            return Ok(existingSite);
        }
    }
}
