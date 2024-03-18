using app_minimarket;
using app_minimarket.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace app_minimarket.Data
{
    public class CRUDProducto : IProducto
    {
        private Configuracion _conexion;

        // Inyectar en el constructor la conexion de la clase Configuracion
        public CRUDProducto(Configuracion conexion)
        {
            _conexion = conexion;
        }

        //Metodo para conectar

        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        // Metodo para listar productos
        public async Task<IEnumerable<Producto>> ListarProducto()
        {
            var bd = Conectar();

            String cad_saql = @"select * from producto";

            return await bd.QueryAsync<Producto>(cad_saql, new {});
        }

        // Metodo para mostrar la informacion de un producto
        public async Task<Producto> MostrarProducto(String id)
        {
            var bd = Conectar();

            String cad_sql = @"select * from producto where id = @id";

            return await bd.QueryFirstAsync<Producto>(cad_sql, new { id = id });

        }

        // Metodo para registrar un producto
      

        public Task<bool> ActualizarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarProducto(string id)
        {
            throw new NotImplementedException();
        }

        


        public Task<bool> RegistrarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
