using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_back.Data;
using web_back.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_back.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserController(DataContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPost("pagination")]
        public async Task<ActionResult<IPaginationResponseDto<User>>> GetPaginatedUserAsync(IPaginationRequestDto<UserQueryDto> queryData)
        {
            var queryDto = queryData.Where?.Query;
            var users = await _context.Users
                        .Where(u => string.IsNullOrEmpty(queryDto) ||
                                u.Email.Contains(queryDto) ||
                                u.FirstName.Contains(queryDto) ||
                                u.LastName.Contains(queryDto))
                        .ToListAsync();
            if (users == null) return NotFound();

            var paginatedResult = await PaginateAsync(users, queryData.PageNumber, queryData.PageSize);

            return Ok(paginatedResult);

        }
        private async Task<IPaginationResponseDto<User>> PaginateAsync(List<User> users, int page, int pageSize)
        {
            var totalItems = users.Count;
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            //if (totalItems <= 4) page = 1;
            var items = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new IPaginationResponseDto<User>
            {
                Data = items,
                TotalItems = totalItems,
                PageSize = pageSize,
                PageNumber = page
            };
        }
        [HttpPost("count")]
        public async Task<ActionResult<int>> UserCount(UserQueryDto queryData)
        {
            var users = await _context.Users
                        .Where(u => string.IsNullOrEmpty(queryData.Query) ||
                                u.Email.Contains(queryData.Query) ||
                                u.FirstName.Contains(queryData.Query) ||
                                u.LastName.Contains(queryData.Query))
                        .ToListAsync();
            if (users == null) return NotFound();
            return Ok(users.Count);
            //return Ok(queryData.Status.ToString());

        }
    }
}
