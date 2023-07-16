using DemoAPIApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoAPIApp.Services.AuthService
{
    public class AuthService: IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
    }

        public async Task<User> Login(LoginRequest request)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password);

            // return error message if both student and teacher not found
            if (student == null && teacher == null)
            {
                return null;
            }

            else if (student != null)
            {
                var token = CreateToken(new User { Id = student.StdId, Username = student.Email, Role = "Student" });
                var userObj = new User
                {
                    Id = student.StdId,
                    Username = student.Email,
                    Role = "Student",
                    Token = token
                };

                return userObj;
            }
            else if (teacher != null) 
            {
                var token = CreateToken(new User { Id = teacher.TeacherId, Username = teacher.Email, Role = "Teacher" });
                var userObj = new User
                {
                    Id = teacher.TeacherId,
                    Username = teacher.Email,
                    Role = "Teacher",
                    Token = token
                };

                return userObj;
            }
            else
            {
                throw new Exception("Wrong email or password");
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
