using GM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Manager.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> SalvarPedidoAsync(List<Pedido> pedidos);
        Task<Caixa> SalvarCaixaAsync(Caixa caixa);
        Task<List<Caixa>> GetCaixaAsync();
    }
}
