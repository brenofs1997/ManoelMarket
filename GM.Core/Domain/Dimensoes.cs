namespace GM.Core.Domain
{
    public class Dimensoes
    {
        public int Id { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }
        public int CalcularVolume()
        {
            return Altura * Largura * Comprimento;
        }
    }

}