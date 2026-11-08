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

        [HttpPost]
        public async Task<IActionResult> Add(AddSoforDTO ujSofor)
        {
            var sofor = new Sofor
            {
                nev = ujSofor.nev,
                telefonszam = ujSofor.telefonszam
            };

            context.Soforok.Add(sofor);
            await context.SaveChangesAsync();

            return Ok(sofor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSoforDTO modositottSofor)
        {
            var sofor = await context.Soforok.FindAsync(id);

            if (sofor == null)
            {
                return NotFound("A módosítani kívánt sofőr nem található!");
            }

            sofor.nev = modositottSofor.nev;
            sofor.telefonszam = modositottSofor.telefonszam;

            await context.SaveChangesAsync();

            return Ok(sofor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sofor = await context.Soforok.FindAsync(id);

            if (sofor == null)
            {
                return NotFound("A törölni kívánt sofőr nem található!");
            }

            context.Soforok.Remove(sofor);
            await context.SaveChangesAsync();

            return Ok("A sofőr sikeresen törölve!");
        }
    }
}
