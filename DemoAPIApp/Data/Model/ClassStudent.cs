using System.ComponentModel.DataAnnotations;

namespace DemoAPIApp.Data.Model
{
    public class ClassStudent
    {
        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public Student Student { get; set; }
        public Class Class { get; set; }

    }
}
