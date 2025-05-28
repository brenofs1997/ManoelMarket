using GM.Core.Domain;
using GM.Data.Context;
using GM.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GMContext context;

        public UserRepository(GMContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetAsync(string email)
        {
            return await context.Users
                .Include(p => p.Roles)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Email == email);
        }

        public async Task<User> InsertAsync(User user)
        {
            await InsertUserRoleAsync(user);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        private async Task InsertUserRoleAsync(User user)
        {
            var rolesConsulted = new List<Role>();
            foreach (var role in user.Roles)
            {
                var roleConsulted = await context.Roles.FindAsync(role.Id);
                rolesConsulted.Add(roleConsulted);
            }
            user.Roles = rolesConsulted;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var userConsulted = await context.Users.FindAsync(user.Email);
            if (userConsulted == null)
            {
                return null;
            }
            context.Entry(userConsulted).CurrentValues.SetValues(user);
            await context.SaveChangesAsync();
            return userConsulted;
        }
    }
}
