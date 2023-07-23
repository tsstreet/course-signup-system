﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAPIApp.Data.Model
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string? SubjectCode { get; set; }

        [Required]
        public string? Name { get; set; }

        //[Required]
        //[ForeignKey("Department")]
        //public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Falcuty? Falcuty { get; set; }
        [Required]
        public int FalcutyId { get; set; }

        //public ICollection<Teacher> Teachers { get; set; }

    }
}
