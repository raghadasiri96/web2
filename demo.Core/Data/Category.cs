using System;
using System.Collections.Generic;

namespace demo.Core.Data
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public decimal Categoryid { get; set; }
        public string Categoryname { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
