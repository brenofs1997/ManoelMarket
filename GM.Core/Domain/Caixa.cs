using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Core.Domain
{
    public class Caixa
    {
        public string CaixaId { get; set; }
        public string? Observacao { get; set; }

        public int DimensoesId { get; set; }
        public Dimensoes Dimensoes { get; set; }
        public int? PedidoId { get; set; }     

        public List<Produto> Produtos { get; set; }
    }
}
