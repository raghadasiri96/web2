using System;
using System.Collections.Generic;

namespace demo.Core.Data
{
    public partial class Course
    {
        public Course()
        {
            Stdcourses = new HashSet<Stdcourse>();
        }

        public decimal Courseid { get; set; }
        public string Coursename { get; set; } = null!;
        public string? Imagename { get; set; }
        public decimal? Categoryid { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Stdcourse> Stdcourses { get; set; }
    }
}
