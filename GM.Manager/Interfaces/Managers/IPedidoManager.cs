using GM.Core.Domain;
using GM.Core.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Manager.Interfaces.Managers
{
    public interface IPedidoManager
    {
        Task SalvarPedidosAsync(IEnumerable<Pedido> pedidos);
        Task SalvarCaixaAsync(Caixa caixa);
        Task<List<Caixa>> GetCaixaAsync();

    }
}
