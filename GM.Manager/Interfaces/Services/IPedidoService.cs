using GM.Core.Domain;

namespace GM.Manager.Interfaces.Services
{
    public interface IPedidoService
    {
        List<Caixa> Empacotar(List<Produto> produtos, List<Caixa> caixas);
    }
}
