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
            var produtos = new List<Produto>
            {
                new Produto
                {
                    Produto_Id = "PS5",
                    DimensoesId = 1,
                    CaixaId = "1",
                    Dimensoes = new Dimensoes
                    {
                        Id = 1,
                        Altura = 10,
                        Largura = 10,
                        Comprimento = 20
                    }
                }
            };

            var pedido = new Pedido
            {
                Pedido_Id = 1,
                Produtos = produtos
            };

            var request = new PedidoRequest
            {
                Pedidos = new List<Pedido> { pedido }
            };

            var caixasDisponiveis = new List<Caixa>
            {
                new Caixa { CaixaId = "CX1", Dimensoes = new Dimensoes { Altura = 50, Largura = 50, Comprimento = 50 }, Produtos = new List<Produto>() }
            };

            var caixasEmpacotadas = new List<Caixa>
            {
                new Caixa
                {
                    CaixaId = "CX1",
                    Dimensoes = new Dimensoes { Altura = 50, Largura = 50, Comprimento = 50 },
                    Produtos = produtos,
                    Observacao = null
                }
            };

            manager.GetCaixaAsync().Returns(caixasDisponiveis);
            service.Empacotar(produtos, caixasDisponiveis).Returns(caixasEmpacotadas);

           
            var result = await controller.Post(request);

           
            await manager.Received().SalvarPedidosAsync(Arg.Any<List<Pedido>>());
            await manager.Received(3).SalvarCaixaAsync(Arg.Any<Caixa>()); // As três caixas fixas do controller
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
