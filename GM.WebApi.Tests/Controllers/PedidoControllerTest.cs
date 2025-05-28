using FluentAssertions;
using GM.Core.Domain;
using GM.Core.Domain.Request;
using GM.Core.Shared.ModelViews.User;
using GM.Manager.Interfaces.Managers;
using GM.Manager.Interfaces.Services;
using GM.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Security.Claims;
namespace GM.WebApi.Tests.Controllers
{
    public class PedidoControllerTest
    {
        
        private readonly IPedidoManager manager;
        private readonly IPedidoService service;

        private readonly PedidoController controller;
        public PedidoControllerTest()
        {
            manager    = Substitute.For<IPedidoManager>();
            service = Substitute.For<IPedidoService>();

            controller = new PedidoController(service,manager);

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
        public async Task Post_Created()
        {
            manager.SalvarPedidosAsync(Arg.Any<List<Pedido>>()).Returns(Task.CompletedTask);

            var resultado = (ObjectResult)await controller.Post(Arg.Any<PedidoRequest>());

            await manager.Received().SalvarPedidosAsync(Arg.Any<List<Pedido>>());
            resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
        }
    }
}
