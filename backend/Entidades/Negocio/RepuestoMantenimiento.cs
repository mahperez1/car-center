namespace Entidades.Negocio
{
    public class RepuestoMantenimiento
    {
        public int Id_Respuesto_mantenimiento { get; set; }
        public int Id_mantenimiento { get; set; }
        public int Id_Mecanico { get; set; }
        public int Id_Respuesto { get; set; }
        public int N_unidades { get; set; }
        public decimal Valor_descuento { get; set; }
        public bool Aplica_servicio_mano_obra { get; set; }
        public int Id_Servicio_Mano { get; set; }
        public decimal Vlr_mano_obra { get; set; }
    }
}