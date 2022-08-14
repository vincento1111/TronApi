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


        [HttpPost]
        public async Task<ActionResult<List<UserAccount>>> AddUserAccount(UserAccount userAccount)
        {
            _context.userAccounts.Add(userAccount);
            await _context.SaveChangesAsync();

            return Ok(await _context.userAccounts.ToListAsync());
        }


    }
}
