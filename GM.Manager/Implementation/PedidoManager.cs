using GM.Core.Domain;
using GM.Manager.Interfaces.Managers;
using GM.Manager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Manager.Implementation
{
    public class PedidoManager : IPedidoManager
    {
        private readonly IPedidoRepository _repository;

        public PedidoManager(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task SalvarPedidosAsync(IEnumerable<Pedido> pedidos)
        {
            var listaPedidos = new List<Pedido>();
            foreach (var pedido in pedidos)
            {
              
                var novoPedido = new Pedido
                {
                    Produtos = pedido.Produtos
                        .Where(p => string.IsNullOrWhiteSpace(p.Observacao) && p.Dimensoes != null)
                        .Select(p => new Produto
                        {
                            Produto_Id = p.Produto_Id,
                            CaixaId = p.CaixaId,
                            DimensoesId = p.Dimensoes.Id,
                            Dimensoes = p.Dimensoes,
                            Observacao = p.Observacao
                        }).ToList()
                };
                listaPedidos.Add(novoPedido);
               
            }
            await _repository.SalvarPedidoAsync(listaPedidos);
        }

        public async Task SalvarCaixaAsync(Caixa caixa) 
        {
            await _repository.SalvarCaixaAsync(caixa);
        }

        public async Task<List<Caixa>> GetCaixaAsync()
        {
            return await _repository.GetCaixaAsync();
        }
    }
}
