﻿using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Model
{
    public class Student
    {
        [Key]
        public int StdId { get; set; }

        [Required]
        public string? StdCode { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
        public string? ParentName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        [Required]
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public string? Class { get; set;}

        [Required]
        public string? Password { get; set; }
    }
}
