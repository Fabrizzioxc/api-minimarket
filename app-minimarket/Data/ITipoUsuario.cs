using app_minimarket;
using app_minimarket.Model;


namespace app_minimarket.Data
{
    public interface ITipoUsuario
    {
        Task<IEnumerable<TipoUsuario>> ListarTipoUsuario();
        Task<TipoUsuario> MostrarTipoUsuario(string id);
        Task<bool> RegistrarTipoUsuario(TipoUsuario tipoUsuario);
        Task<bool> ActualizarTipoUsuario(TipoUsuario tipoUsuario);
        Task<bool> EliminarTipoUsuario(string id);
    }
}
