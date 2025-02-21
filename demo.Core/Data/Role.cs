using System;
using System.Collections.Generic;

namespace demo.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            Logins = new HashSet<Login>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; } = null!;

        public virtual ICollection<Login> Logins { get; set; }
    }
}
