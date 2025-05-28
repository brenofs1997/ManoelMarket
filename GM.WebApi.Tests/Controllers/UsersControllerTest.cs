using FluentAssertions;
using GM.Core.Shared.ModelViews.User;
using GM.Manager.Interfaces.Managers;
using GM.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Security.Claims;
namespace GM.WebApi.Tests.Controllers
{
    public class UsersControllerTest
    {
        
        private readonly IUserManager manager;
       
        private readonly UsersController controller;
        public UsersControllerTest()
        {
            manager    = Substitute.For<IUserManager>();

            controller = new UsersController(manager);

            // Mock do usuário autenticado com o papel correto
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "user@example.com"),
                new Claim(ClaimTypes.Role, "Admin") // Simula um usuário com permissão
            }, "mock"));

            var httpContext = new DefaultHttpContext { User = user };
            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };
        }


        [Fact]
        public async Task Get_Ok()
        {
            // Arrange
            var fakeEmail = "user@example.com";
            var fakeUser = new UserView { Email = fakeEmail };

            manager.GetAsync(fakeEmail).Returns(fakeUser);

            // Act
            var result = await controller.Get() as ObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeOfType<UserView>();
            ((UserView)result.Value).Email.Should().Be(fakeEmail);
        }
    }
}
