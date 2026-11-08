using Microsoft.AspNetCore.Mvc;
using ZZRent.Models;
using ZZRent.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using ZZRent.Data;

namespace ZZRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoforController : ControllerBase
    {
        private readonly ZZRentDbContext context;
        public SoforController(ZZRentDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var soforok = await context.Soforok.ToListAsync();

            return Ok(soforok);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sofor = await context.Soforok.FindAsync(id);

            if (sofor == null)
            {
                return NotFound("A keresett sofőr nem található!");
            }

            return Ok(sofor);
        }
    }
}
