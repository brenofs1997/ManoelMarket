using GM.Core.Domain;
using GM.Data.Context;
using GM.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GM.Data.Repository
{
    public class PedidoRepository:IPedidoRepository
    {
        private readonly GMContext context;

        public PedidoRepository(GMContext context)
        {
            this.context = context;
        }
  
        public async Task<List<Pedido>> SalvarPedidoAsync(List<Pedido> pedidos)
        {
            context.Pedidos.AddRange(pedidos); 
            await context.SaveChangesAsync();
            return pedidos;
        }

        public async Task<Caixa> SalvarCaixaAsync(Caixa caixa)
        {
            var dimensoesExistente = await context.Dimensoes.FirstOrDefaultAsync(d =>
            d.Altura == caixa.Dimensoes.Altura &&
            d.Largura == caixa.Dimensoes.Largura &&
            d.Comprimento == caixa.Dimensoes.Comprimento);

            if (dimensoesExistente == null)
            {
                context.Dimensoes.Add(caixa.Dimensoes);
                await context.SaveChangesAsync();
                caixa.DimensoesId = caixa.Dimensoes.Id;
            }
            else
            {
                caixa.Dimensoes = null;
                caixa.DimensoesId = dimensoesExistente.Id;
            }

            var existeCaixa = await context.Caixas.FirstOrDefaultAsync(c => c.DimensoesId == caixa.DimensoesId);

            if (existeCaixa == null)
            {
                await context.Caixas.AddAsync(caixa);
                await context.SaveChangesAsync();
                return caixa;
            }

            return existeCaixa;
        }

        public async Task<List<Caixa>> GetCaixaAsync()
        {
            return await context.Caixas
                                 .Include(c => c.Dimensoes)
                                 .ToListAsync();
        }
    }
}
