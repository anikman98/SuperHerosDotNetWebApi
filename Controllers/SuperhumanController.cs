using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeros.Data;

namespace SuperHeros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperhumanController : ControllerBase
    {
        private ApplicationDbContext _context;

        public SuperhumanController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> Get()
        { 
            return Ok(await _context.Supehero.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetHero(int id)
        {
            var hero = await _context.Supehero.FindAsync(id);
            if(hero == null)
            {
                return BadRequest("Hero not found!");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero superhero)
        {
            _context.Supehero.Add(superhero);
            await _context.SaveChangesAsync();
            return Ok(await _context.Supehero.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero superhero)
        {
            var hero = await _context.Supehero.FindAsync(superhero.Id);
            if (hero == null)
            {
                return BadRequest("Hero not found!");
            }
            hero.Name = superhero.Name;
            hero.FirstName = superhero.FirstName;
            hero.LastName = superhero.LastName;
            hero.Place = superhero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.Supehero.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Superhero>>> DeleteHero(int id)
        {
            var hero = await _context.Supehero.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero not found!");
            }
            _context.Supehero.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Supehero.ToListAsync());
        }
    }
}
