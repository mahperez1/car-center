using System;

namespace Entidades.Negocio
{
    public class Factura
    {
        public int Id_Factura { get; set; }
        public int Id_Persona { get; set; }
        public DateTime Fecha_factura { get; set; }
        public decimal Valor_factura { get; set; }
        public decimal Valor_iva { get; set; }
        public decimal Valor_total { get; set; }
        public string Placa_vehiculo { get; set; }
        public int AplicaLimitePresupuesto { get; set; }
        public decimal Valor_limite_presupuesto { get; set; }
    }
}