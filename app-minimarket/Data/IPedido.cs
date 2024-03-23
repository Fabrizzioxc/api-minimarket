using app_minimarket.Model;

namespace app_minimarket.Data
{
    public interface IPedido
    {
        Task<IEnumerable<Pedido>> ListarPedidos();
        Task<Pedido> MostrarPedido(int id);
        Task<bool> RegistrarPedido(Pedido pedido);
        Task<bool> ActualizarPedido(Pedido pedido);
        Task<bool> EliminarPedido(int id);
    }
}
