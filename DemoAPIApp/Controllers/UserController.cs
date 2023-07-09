using DemoAPIApp.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly IEmailService _emailService;

        private readonly IMapper _mapper;

        public UserController(DataContext context, IWebHostEnvironment hostEnvironment, IEmailService emailService)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return BadRequest("User not found");
            }
 
            var userDto = new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return Ok(userDto);

            //var userDto = _mapper.Map<UserDto>(user);
            //return user;
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Send a welcome email to the user
            _emailService.SendEmail(user.Email, "Welcome to our app!", "Thank you for signing up for our app.");
            return Ok();
        }
          

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest("User not found");
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
            }


            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return BadRequest("Product not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
     
    }
}
