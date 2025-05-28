using GM.Core.Domain;
using GM.Core.Domain.Request;
using GM.Core.Shared.ModelViews.User;
using GM.Data.Services;
using GM.Manager.Interfaces.Managers;
using GM.Manager.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
       
        private readonly IPedidoService _service ;
        private readonly IPedidoManager manager;

        public PedidoController(IPedidoService _service, IPedidoManager manager)
        {
            
            this._service = _service;
            this.manager = manager;

        }
        [HttpPost]
        [ProducesResponseType(typeof(PedidoRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(PedidoRequest request)
        {
            var caixasParaInserir = new List<Caixa>
            {
                 new Caixa { Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 } },
                 new Caixa { Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 } },
                 new Caixa { Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 } }
            };

            foreach (var caixa in caixasParaInserir)
            {
                await manager.SalvarCaixaAsync(caixa);
            }
            var caixasDisponiveis = await manager.GetCaixaAsync();

            var pedidos = request.Pedidos.Select(pedido => new
            {
                pedido_id = pedido.Pedido_Id,
                caixas = _service.Empacotar(pedido.Produtos, caixasDisponiveis).Select(caixa => new
                {
                    caixa_id = caixa.CaixaId,
                    produtos = caixa.Produtos,
                    observacao = string.IsNullOrWhiteSpace(caixa.Observacao) ? null : caixa.Observacao
                }).ToList()
            }).ToList();

            var resposta = new
            {
                pedidos
            };

            List<Pedido> pedidosParaSalvar = new List<Pedido>();

            foreach (var pedidoOriginal in request.Pedidos)
            {
                var caixasEmpacotadas = _service.Empacotar(pedidoOriginal.Produtos, caixasDisponiveis);

                var produtosComCaixa = caixasEmpacotadas
                    .SelectMany(caixa => caixa.Produtos.Select(produto =>
                    {
                        produto.CaixaId = caixa.CaixaId; // associa corretamente o produto à caixa salva
                        produto.Dimensoes = caixa.Dimensoes;
                        return produto;
                    }))
                    .ToList();

                pedidosParaSalvar.Add(new Pedido
                {
                    Pedido_Id = pedidoOriginal.Pedido_Id,
                    Produtos = produtosComCaixa
                });
            }


            await manager.SalvarPedidosAsync(pedidosParaSalvar);

      
            return Ok(resposta);
        }
    }
}
