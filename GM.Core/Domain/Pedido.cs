using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Core.Domain
{
    public class Pedido
    {
        public int? Pedido_Id { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<Caixa>? Caixas { get; set; }
    }
}
