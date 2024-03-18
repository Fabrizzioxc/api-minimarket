namespace app_minimarket.Model
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precioVenta { get; set; }
        public int cantidad { get; set; }
        public string codigoBarras { get; set;}
        public int id_categoria { get; set; }
        public int id_estado { get; set; }
    }
}
