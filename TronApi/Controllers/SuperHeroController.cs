using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TronApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        //private static List<SuperHero> heroes = new List<SuperHero>
        //    {
        //        new SuperHero { Id = 1,
        //            Name = "Spider Man",
        //            FirstName = "Peter",
        //            LastName = "Parker",
        //            Place = "New York City"
        //        },

        //         new SuperHero { Id = 2,
        //            Name = "Iron Man",
        //            FirstName = "Tony",
        //            LastName = "Stark",
        //            Place = "ur mum"
        //        }
        //    };

        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("404 hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero Request)
        {
            var dbHero = await _context.SuperHeroes.FindAsync( Request.Id);
            if (dbHero == null)
                 return NotFound("Hero not found");

            dbHero.Name = Request.Name;
            dbHero.FirstName = Request.FirstName;
            dbHero.LastName = Request.LastName;
            dbHero.Place = Request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("404 hero not found");

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
