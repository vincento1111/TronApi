using Microsoft.AspNetCore.Mvc;

namespace TronApi.Controllers
{
    [Route("api/UserAccounts")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {

        private readonly DataContext _context;

        public UserAccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserAccount>>> Get()
        {
            return Ok(await _context.userAccounts.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserAccount>>> Get(int id)
        {
            var user = await _context.userAccounts.FindAsync(id);
            if (user == null)
                return BadRequest("404 user not found");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserAccount>>> AddUserAccount(UserAccount userAccount)
        {
            _context.userAccounts.Add(userAccount);
            await _context.SaveChangesAsync();

            return Ok(await _context.userAccounts.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<UserAccount>>> UpdateUserAccount(UserAccount Request)
        {
            var dbUser = await _context.userAccounts.FindAsync(Request.Id);
            if (dbUser == null)
                return NotFound("Hero not found");

            dbUser.Email = Request.Email;
            dbUser.Password = Request.Password;


            await _context.SaveChangesAsync();

            return Ok(await _context.userAccounts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserAccount>>> Delete(int id)
        {
            var dbUser = await _context.userAccounts.FindAsync(id);
            if (dbUser == null)
                return BadRequest("404 hero not found");

            _context.userAccounts.Remove(dbUser);
            await _context.SaveChangesAsync();
            return Ok(await _context.userAccounts.ToListAsync());
        }
    }
}
