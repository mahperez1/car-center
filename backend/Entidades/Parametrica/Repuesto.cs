namespace Entidades.Parametrica
{
    public class Repuesto
    {
        public int Id_repuesto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int codigo { get; set; }
        public decimal Vlr_unitario { get; set; }
        public int Cantidad_disponible { get; set; }
    }
}