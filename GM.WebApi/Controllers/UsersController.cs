using GM.Core.Domain;
using GM.Core.Shared.ModelViews.User;
using GM.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager manager;

        public UsersController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserView userView)
        {
            User user = new User();
            user.Email = userView.Email;
            user.Password = userView.Password;

            var usuarioLogado = await manager.ValidateUserAndGenerateTokenAsync(user);
            if (usuarioLogado != null)
            {
                return Ok(usuarioLogado);
            }
            return Unauthorized();
        }

        [Authorize(Roles = "Admin, Lider")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string email = User.Identity.Name;
            var user = await manager.GetAsync(email);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewUser user)
        {
            var userInsert = await manager.InsertAsync(user);
            return CreatedAtAction(nameof(Get), new { email = user.Email }, userInsert);
        }
    }
}
