using app_minimarket;
using app_minimarket.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace app_minimarket.Data
{
    public class CRUDTipoUsuario : ITipoUsuario
    {
        private Configuracion _conexion;

        // Inyectar en el constructor la conexión de la clase Configuracion
        public CRUDTipoUsuario(Configuracion conexion)
        {
            _conexion = conexion;
        }

        // Método para conectar
        protected MySqlConnection Conectar()
        {
            return new MySqlConnection(_conexion.Conectar);
        }

        // Método para listar tipos de usuario
        public async Task<IEnumerable<TipoUsuario>> ListarTipoUsuarios()
        {
            var bd = Conectar();
            string cad_saql = @"SELECT * FROM tipo_usuario";
            return await bd.QueryAsync<TipoUsuario>(cad_saql, new { });
        }

        // Método para mostrar la información de un tipo de usuario
        public async Task<TipoUsuario> MostrarTipoUsuario(int id)
        {
            var bd = Conectar();
            string cad_sql = @"SELECT * FROM tipo_usuario WHERE id = @id";
            return await bd.QueryFirstAsync<TipoUsuario>(cad_sql, new { id = id });
        }

        // Método para registrar un tipo de usuario
        public async Task<bool> RegistrarTipoUsuario(TipoUsuario tipoUsuario)
        {
            try
            {
                var bd = Conectar();
                string cad_sql = @"INSERT INTO tipo_usuario (nombre, descripcion) VALUES (@nombre, @descripcion)";
                await bd.ExecuteAsync(cad_sql, tipoUsuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método para actualizar un tipo de usuario
        public async Task<bool> ActualizarTipoUsuario(TipoUsuario tipoUsuario)
        {
            try
            {
                var bd = Conectar();
                string cad_sql = @"UPDATE tipo_usuario SET nombre = @nombre, descripcion = @descripcion WHERE id = @id";
                await bd.ExecuteAsync(cad_sql, tipoUsuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método para eliminar un tipo de usuario
        public async Task<bool> EliminarTipoUsuario(int id)
        {
            try
            {
                var bd = Conectar();
                string cad_sql = @"DELETE FROM tipo_usuario WHERE id = @id";
                await bd.ExecuteAsync(cad_sql, new { id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<IEnumerable<TipoUsuario>> ListarTipoUsuario()
        {
            throw new NotImplementedException();
        }

        public Task<TipoUsuario> MostrarTipoUsuario(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarTipoUsuario(string id)
        {
            throw new NotImplementedException();
        }
    }
}
