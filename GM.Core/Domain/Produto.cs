using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Core.Domain
{
    public class Produto
    { 
        public string Produto_Id { get; set; }
        public int DimensoesId { get; set; }
        public Dimensoes Dimensoes { get; set; }

        public string? Observacao { get; set; }

        public string? CaixaId { get; set; }   
        public Caixa? Caixa { get; set; }
        public int CalcularVolume ()
        {
            return Dimensoes.CalcularVolume ();
        }
    }

}
