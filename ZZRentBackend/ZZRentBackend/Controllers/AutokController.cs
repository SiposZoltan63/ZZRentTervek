using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZZRent.Data;
using ZZRent.Models;
using ZZRent.Models.DTOs;

namespace ZZRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutokController : ControllerBase
    {
        private readonly ZZRentDbContext context;

        public AutokController(ZZRentDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var autok = await context.Autok.ToListAsync();

            return Ok(autok);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var auto = await context.Autok.FindAsync(id);

            if (auto == null)
            {
                return NotFound("A keresett autó nem található!");
            }

            return Ok(auto);
        }
    }
}
