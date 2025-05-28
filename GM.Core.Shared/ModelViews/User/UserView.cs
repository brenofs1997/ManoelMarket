using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Core.Shared.ModelViews.User
{
    public class UserView
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<RoleView>? Roles { get; set; }
    }
}
