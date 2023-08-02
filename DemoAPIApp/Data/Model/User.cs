﻿namespace DemoAPIApp.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public string Token { get; set; }

        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
