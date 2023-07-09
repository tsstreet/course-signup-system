namespace DemoAPIApp.Data.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

    }

    //public class UserDto
    //{
    //    public string Username { get; set; }

    //    public string Password { get; set; }

    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }

    //    public string Email { get; set; }
    //}

}
