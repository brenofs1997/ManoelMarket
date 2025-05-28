using AutoMapper;
using GM.Core.Domain;
using GM.Core.Shared.ModelViews.User;
using GM.Manager.Interfaces.Managers;
using GM.Manager.Interfaces.Repositories;
using GM.Manager.Interfaces.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        private readonly IJwtService jwt;

        public UserManager(IUserRepository repository, IMapper mapper, IJwtService jwt)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.jwt = jwt;
        }

        public async Task<IEnumerable<UserView>> GetAsync()
        {
            return mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(await repository.GetAsync());
        }
        public async Task<UserView> GetAsync(string login)
        {
            return mapper.Map<UserView>(await repository.GetAsync(login));
        }
        public async Task<UserView> InsertAsync(NewUser newUser)
        {
            var user = mapper.Map<User>(newUser);
            ConvertPasswordToHash(user);
            return mapper.Map<UserView>(await repository.InsertAsync(user));
        }

        private static void ConvertPasswordToHash(User user)
        {
            var passwordHasher = new PasswordHasher();
            user.Password = passwordHasher.HashPassword( user.Password);
        }

        public async Task<UserView> UpdateUserAsync(User user)
        {
            ConvertPasswordToHash(user);
            return mapper.Map<UserView>(await repository.UpdateAsync(user));
        }
        public async Task<UserLogged> ValidateUserAndGenerateTokenAsync(User user)
        {
            var userConsulted = await repository.GetAsync(user.Email);
            if (userConsulted == null)
            {
                return null;
            }
            if (await ValidateAndUpdateHashAsync(user, userConsulted.Password))
            {
                var userLogged = mapper.Map<UserLogged>(userConsulted);
                userLogged.Token = jwt.GenerateToken(userConsulted);
                return userLogged;
            }
            return null;
        }

        private async Task<bool> ValidateAndUpdateHashAsync(User user, string hash)
        {
            var passwordHasher = new PasswordHasher();
            var status = passwordHasher.VerifyHashedPassword( hash, user.Password);
            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateUserAsync(user);
                    return true;

                default:
                    throw new InvalidOperationException();
            }
        }

    }
}
