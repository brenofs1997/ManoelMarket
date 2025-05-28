using GM.Core.Domain;
using GM.Core.Shared.ModelViews.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Manager.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<IEnumerable<UserView>> GetAsync();

        Task<UserView> GetAsync(string email);

        Task<UserView> InsertAsync(NewUser user);

        Task<UserLogged> ValidateUserAndGenerateTokenAsync(User user);
    }
}
