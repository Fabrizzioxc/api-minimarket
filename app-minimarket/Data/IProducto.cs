using app_minimarket;
using app_minimarket.Model;

namespace app_minimarket.Data
{
    public interface IProducto
    {
        // Definir los métodos asincronos a implementar
        Task<IEnumerable<Producto>> ListarProducto();
        Task<Producto> MostrarProducto(String id);
        Task<bool> RegistrarProducto(Producto producto);
        Task<bool> ActualizarProducto(Producto producto);
        // Task<bool> EliminarProducto(Producto producto);
        Task<bool> EliminarProducto(String id);
    }
}
