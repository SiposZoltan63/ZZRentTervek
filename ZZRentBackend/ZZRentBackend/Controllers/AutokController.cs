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

        [HttpPost]
        public async Task<IActionResult> Add(AddAutoDTO ujAuto)
        {
            var auto = new Auto
            {
                marka = ujAuto.marka,
                modell = ujAuto.modell,
                evjarat = ujAuto.evjarat,
                napi_ar = ujAuto.napi_ar,
                uzemanyag = ujAuto.uzemanyag,
                kategoria = ujAuto.kategoria,
                elerheto = ujAuto.elerheto
            };

            context.Autok.Add(auto);
            await context.SaveChangesAsync();

            return Ok(auto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAutoDTO modositottAuto)
        {
            var auto = await context.Autok.FindAsync(id);

            if (auto == null)
            {
                return NotFound("A módosítani kívánt autó nem található!");
            }

            auto.marka = modositottAuto.marka;
            auto.modell = modositottAuto.modell;
            auto.evjarat = modositottAuto.evjarat;
            auto.napi_ar = modositottAuto.napi_ar;
            auto.uzemanyag = modositottAuto.uzemanyag;
            auto.kategoria = modositottAuto.kategoria;
            auto.elerheto = modositottAuto.elerheto;

            await context.SaveChangesAsync();

            return Ok(auto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var auto = await context.Autok.FindAsync(id);

            if (auto == null)
            {
                return NotFound("A törölni kívánt autó nem található!");
            }

            context.Autok.Remove(auto);
            await context.SaveChangesAsync();

            return Ok("Az autó sikeresen törölve!");
        }
    }
}
