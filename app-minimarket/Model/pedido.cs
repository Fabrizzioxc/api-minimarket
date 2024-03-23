namespace app_minimarket.Model
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double CostoTotal { get; set; }
        public int IdUsuario { get; set; }
        public int IdProveedor { get; set; }
    }
}
