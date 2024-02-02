using HMOManagerAPI.Data;
using HMOManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMOManagerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TenantController(ApplicationDbContext dbContext) : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        [HttpPost]
        public IActionResult CreateTenant([FromBody] Tenant tenant)
        {
            _dbContext.Tenants.Add(tenant);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetTenantById), new { id = tenant.TenantId }, tenant);
        }

        [HttpGet]
        public IActionResult GetTenants()
        {
            var tenants = _dbContext.Tenants.ToList();
            return Ok(tenants);
        }

        [HttpGet("{id}")]
        public IActionResult GetTenantById(int id)
        {
            var tenant = _dbContext.Tenants.FirstOrDefault(t => t.TenantId == id);
            if (tenant == null)
            {
                return NotFound();
            }
            return Ok(tenant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTenant(int id, [FromBody] Tenant updatedTenant)
        {
            var existingTenant = _dbContext.Tenants.FirstOrDefault(t => t.TenantId == id);
            if (existingTenant == null)
            {
                return NotFound();
            }

            //Should Map
            existingTenant = updatedTenant;

            _dbContext.SaveChanges();
            return Ok(existingTenant);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTenant(int id)
        {
            var existingTenants = _dbContext.Tenants.FirstOrDefault(s => s.TenantId == id);
            if (existingTenants == null)
            {
                return NotFound();
            }

            _dbContext.Remove(existingTenants);

            _dbContext.SaveChanges();
            return Ok(existingTenants);
        }
    }
}
