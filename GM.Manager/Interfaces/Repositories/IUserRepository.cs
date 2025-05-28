using GM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Manager.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();

        Task<User> GetAsync(string email);

        Task<User> InsertAsync(User user);

        Task<User> UpdateAsync(User user);
    }
}
