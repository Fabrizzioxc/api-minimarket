namespace app_minimarket.Data
{
    public class Configuracion
    {
        public string Conectar { get; set; }
        public Configuracion(String conectar)
        {
            Conectar = conectar;
        }
    }
}
