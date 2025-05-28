using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime createAt { get; set; }
        public DateTime? updatedAt { get; set; }

        public ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
        }


    }
}
