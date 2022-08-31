using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TronApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatsController : ControllerBase
    {

        private readonly DataContext _context;

        public UserStatsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserStats>>> Get()
        {
            return Ok(await _context.UsersStats.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserStats>>> Get(int id)
        {
            var stats = await _context.UsersStats.FindAsync(id);
            if (stats == null)
                return BadRequest("404 hero not found");
            return Ok(stats);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserStats>>> AddStats(UserStats stats)
        {
            _context.UsersStats.Add(stats);
            await _context.SaveChangesAsync();

            return Ok(await _context.UsersStats.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<UserStats>>> UpdateStats(UserStats Request)
        {
            var dbStats = await _context.UsersStats.FindAsync(Request.StatId);
            if (dbStats == null)
                return NotFound("stats not found");

            dbStats.Strength = Request.Strength;
            dbStats.Defense = Request.Defense;
            dbStats.Speed = Request.Speed;
            dbStats.Dexterity = Request.Dexterity;
            dbStats.Experience = Request.Experience;
            dbStats.Life = Request.Life;
            dbStats.Money = Request.Money;

            await _context.SaveChangesAsync();

            return Ok(await _context.UsersStats.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserStats>>> Delete(int id)
        {
            var dbStats = await _context.UsersStats.FindAsync(id);
            if (dbStats == null)
                return BadRequest("404 hero not found");

            _context.UsersStats.Remove(dbStats);
            await _context.SaveChangesAsync();
            return Ok(await _context.UsersStats.ToListAsync());
        }
    }
}
