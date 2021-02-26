namespace Entidades.Parametrica
{
    public class ServicioMano
    {
        public int Id_Servicio_Mano { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal Vlr_minimo { get; set; }
        public decimal Vlr_maximo { get; set; }
    }
}