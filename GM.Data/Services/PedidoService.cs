using GM.Core.Domain;
using GM.Manager.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Data.Services
{
    public class PedidoService : IPedidoService
    {

        public List<Caixa> Empacotar(List<Produto> produtos, List<Caixa> caixas)
        {
            var produtosRestantes = new List<Produto>(produtos.OrderByDescending(p => p.CalcularVolume()));
            var caixasUsadas = new List<Caixa>();
            int contadorCaixa = 1;

            while (produtosRestantes.Any())
            {
                bool algumProdutoEmpacotado = false;

                foreach (var caixaModelo in caixas.OrderBy(c => c.Dimensoes.CalcularVolume()))
                {
                    var produtosNaCaixa = new List<Produto>();
                    var volumeDisponivel = caixaModelo.Dimensoes.CalcularVolume();

                    foreach (var produto in produtosRestantes.ToList())
                    {
                        if (produto.CalcularVolume() <= volumeDisponivel)
                        {
                            produtosNaCaixa.Add(produto);
                            volumeDisponivel -= produto.CalcularVolume();
                            produtosRestantes.Remove(produto);
                        }
                    }

                    if (produtosNaCaixa.Any())
                    {
                        caixasUsadas.Add(new Caixa
                        {
                            CaixaId = caixaModelo.CaixaId,
                            DimensoesId = caixaModelo.DimensoesId,
                            Dimensoes = caixaModelo.Dimensoes,
                            Produtos = produtosNaCaixa .Select(p => new Produto { Produto_Id = p.Produto_Id }).ToList()
                        });

                        algumProdutoEmpacotado = true;
                        break;
                    }
                }

                if (!algumProdutoEmpacotado)
                {
                    foreach (var produto in produtosRestantes)
                    {
                        caixasUsadas.Add(new Caixa
                        {
                            CaixaId = null,
                            Produtos = new List<Produto> { new Produto { Produto_Id = produto.Produto_Id } },
                            Observacao = "Produto não cabe em nenhuma caixa disponível."
                        });
                    }

                    break;
                }
            }

            return caixasUsadas;
        }
    }
}
