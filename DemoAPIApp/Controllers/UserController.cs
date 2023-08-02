using DemoAPIApp.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DemoAPIApp.Data.Dto;
using DemoAPIApp.Services.TeacherService;
using DemoAPIApp.Services.UserService;

namespace DemoAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService; 
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userService.GetUsers();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var userAdd = await _userService.AddUser(user);

            return Ok(userAdd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, User user)
        {
            var userUpdate = await _userService.UpdateUser(id, user);
            return Ok(userUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUser(id);

            return Ok(user);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var users = await _userService.Search(searchString);

            return Ok(users);
        }

    }
}
