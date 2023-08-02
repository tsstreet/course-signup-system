using DemoAPIApp.Data.Model;
using DemoAPIApp.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIApp.Services.UserService
{
    public class UserService: IUserService
    {

        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<User> AddUser(User user)
        {
            var existUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (existUser != null)
            {
                throw new Exception("Email already exist");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
           
            var userUpdate = await _context.Users.FindAsync(id);
            userUpdate.Name = user.Name;
            userUpdate.Email = user.Email;
            userUpdate.Role = user.Role;
            userUpdate.ImageUrl = user.ImageUrl;

            await _context.SaveChangesAsync();

            return userUpdate;
        }

        public async Task<User> DeleteUser(int id)
        {

            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return user;
        }  
        public async Task<List<User>> Search(string searchString)
        {
            var user = from s in _context.Users
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.Name.ToLower().Contains(searchString.ToLower())); 
            }

            return await user.ToListAsync();
        }
    }
}
