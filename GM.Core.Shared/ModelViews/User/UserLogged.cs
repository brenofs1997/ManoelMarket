using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Core.Shared.ModelViews.User
{
    public class UserLogged
    {
        public string Email { get; set; }
        public ICollection<RoleView> Roles { get; set; }
        public string Token { get; set; }
    }
}
