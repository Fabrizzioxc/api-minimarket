using app_minimarket;
using app_minimarket.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace app_minimarket.Data
{
    public class CRUDPedido : IPedido
    {
        private Configuracion _conexion;

        // Inyectar en el constructor la conexión de la clase Configuracion
        public CRUDPedido(Configuracion conexion)
        {
            _conexion = conexion;
        }

        // Método para conectar
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        // Método para listar pedidos
        public async Task<IEnumerable<Pedido>> ListarPedidos()
        {
            var bd = Conectar();
            string cad_saql = @"SELECT * FROM pedido";
            return await bd.QueryAsync<Pedido>(cad_saql, new { });
        }

        // Método para mostrar la información de un pedido
        public async Task<Pedido> MostrarPedido(int id)
        {
            var bd = Conectar();
            string cad_sql = @"SELECT * FROM pedido WHERE id = @id";
            return await bd.QueryFirstAsync<Pedido>(cad_sql, new { id = id });
        }

        // Método para registrar un pedido
        public async Task<bool> RegistrarPedido(Pedido pedido)
        {
            try
            {
                var bd = Conectar();
                string cad_sql = @"INSERT INTO pedido (fecha, costoTotal, id_usuario, id_proveedor) VALUES (@fecha, @costoTotal, @id_usuario, @id_proveedor)";
                await bd.ExecuteAsync(cad_sql, pedido);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método para actualizar un pedido
        public async Task<bool> ActualizarPedido(Pedido pedido)
        {
            try
            {
                var bd = Conectar();
                string cad_sql = @"UPDATE pedido SET fecha = @fecha, costoTotal = @costoTotal, id_usuario = @id_usuario, id_proveedor = @id_proveedor WHERE id = @id";
                await bd.ExecuteAsync(cad_sql, pedido);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método para eliminar un pedido
        public async Task<bool> EliminarPedido(int id)
        {
            try
            {
                var bd = Conectar();
                string cad_sql = @"DELETE FROM pedido WHERE id = @id";
                await bd.ExecuteAsync(cad_sql, new { id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
