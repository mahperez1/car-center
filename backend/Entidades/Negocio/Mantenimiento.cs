using System;

namespace Entidades.Negocio
{
    public class Mantenimiento
    {
        public int Id_mantenimiento { get; set; }
        public string Nombre_mantenimiento { get; set; }
        public string Descripcion { get; set; }
        public int Id_Estado_mantenimiento { get; set; }
        public DateTime fecha_registro { get; set; }
        public int Id_Factura { get; set; }
    }
}